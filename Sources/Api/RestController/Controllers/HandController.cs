using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Enums;
using Model.Games;
using Model.Players;
using Model.Rules;
using RestController.DTOs;
using RestController.DTOs.Extensions;

namespace RestController.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class HandController : ControllerBase
    {
        private readonly Manager _manager;

        /// <summary>
        /// Constructor for the HandController
        /// </summary>
        /// <param name="manager">The manger to use</param>
        public HandController(Manager manager)
        {
            _manager = manager;
        }

        /// <summary>
        /// Get the hand of a player with the given id
        /// </summary>
        /// <param name="id"> The id of the hand </param>
        /// <returns>
        /// Return NotFound if the hand is not found
        /// Returns the hand of the player with the given id
        /// </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<HandDTODetail>> Get(ulong id)
        {
            var hand = await _manager.GetHandById(id);
            if (hand == null) return NotFound();
            return Ok(hand.ToHandDTODetail());
        }

        /// <summary>
        /// Post a new hand to the database
        /// </summary>
        /// <param name="gameId">The id of the game the hand belongs to</param>
        /// <param name="request">The hand to be posted</param>
        /// <returns>
        /// Return a BadRequest if the hand is invalid, 
        /// Return a NoContent if the hand is valid and posted
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HandInsertRequest request)
        {
            var game = await _manager.GetGameById(request.GameId);
            if (game is null)
            {
                return BadRequest($"The game with id {request.GameId} does not exist");
            }

            var rules = RulesFactory.Create(request.Rules);
            if (rules is null)
            {
                return BadRequest($"The rules {request.Rules} does not correspond to any rules");
            }

            var biddings = new List<KeyValuePair<Player, (Biddings, Poignee)>>();
            foreach (var bidding in request.Biddings)
            {
                var user = await _manager.GetUserById(bidding.UserId);
                if (user is null)
                {
                    return BadRequest($"The user with id {bidding.UserId} does not exist");
                }

                biddings.Add(new KeyValuePair<Player, (Biddings, Poignee)>(
                    user, (bidding.Biddings.ToBiddings(), bidding.Poignee.ToPoignee()))
                );
            }

            var handInserted = await _manager.InsertHand(
                request.GameId,
                request.Number,
                rules,
                request.Date,
                request.TakerScore,
                request.TwentyOne,
                request.Excuse,
                request.Petit.ToPetitResults(),
                request.Chelem.ToChelem(),
                biddings.ToArray()
            );

            if (handInserted is null) return BadRequest("An error occured while inserted the hand");

            var handReply = handInserted.ToHandDTODetail();
            handReply.GameId = request.GameId;
            return CreatedAtAction(
                nameof(Get),
                new { id = handInserted.Id },
                handReply
            );
        }

        /// <summary>
        /// Update a Hand in the database by its id.
        /// </summary>
        /// <param name="id">The id of the Hand to be updated.</param>
        /// <param name="handDtoDetail">The DTO containing the updated information for the Hand.</param>
        /// <returns>
        /// Returns a BadRequest result if the id in the request does not match the id in the DTO. 
        /// Returns a NotFound result if the hand is not found. 
        /// Returns a NoContent result if the update is successful.
        /// </returns>
        [HttpPut("{id}")]
        [MapToApiVersion("2.0")]
        public async Task<IActionResult> Put(ulong id, [FromBody] HandUpdateRequest request)
        {
            if (id != request.Id) return BadRequest();

            var rules = RulesFactory.Create(request.Rules);
            if (rules is null)
            {
                return BadRequest($"The rules {request.Rules} does not correspond to any rules");
            }

            var biddings = new List<KeyValuePair<Player, (Biddings, Poignee)>>();
            foreach (var bidding in request.Biddings)
            {
                var user = await _manager.GetUserById(bidding.UserId);
                if (user is null)
                {
                    return BadRequest($"The user with id {bidding.UserId} does not exist");
                }

                biddings.Add(new KeyValuePair<Player, (Biddings, Poignee)>(
                    user, (bidding.Biddings.ToBiddings(), bidding.Poignee.ToPoignee()))
                );
            }

            var hand = new Hand(
                request.Id,
                request.Number,
                rules,
                request.Date,
                request.TakerScore,
                request.TwentyOne,
                request.Excuse,
                request.Petit.ToPetitResults(),
                request.Chelem.ToChelem(),
                biddings.ToArray()
            );

            var handUpdated = await _manager.UpdateHand(hand);
            if (handUpdated is null) return NotFound();
            return NoContent();
        }

        /// <summary>
        /// Delete a Hand from the database by its id.
        /// </summary>
        /// <param name="id">The id of the Hand to be deleted.</param>
        /// <returns>
        /// Returns a NotFound result if the hand is not found. 
        /// Returns a NoContent result if the deletion is successful.
        /// </returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(ulong id)
        {
            var hand = await _manager.GetHandById(id);
            if (hand is null) return NotFound();
            await _manager.DeleteHand(hand);
            return NoContent();
        }
    }
}