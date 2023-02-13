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
    /// <summary>
    /// The hands controller for REST API
    /// </summary>
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class HandsController : ControllerBase
    {
        /// <summary>
        /// The manager for the service
        /// </summary>
        private readonly Manager _manager;
        
        /// <summary>
        /// The logger for the service
        /// </summary>
        private readonly ILogger<HandsController> _logger;

        /// <summary>
        /// Constructor for the HandController
        /// </summary>
        /// <param name="manager">The manger to use</param>
        /// <param name="logger">The logger to use</param>
        public HandsController(Manager manager, ILogger<HandsController> logger)
        {
            _manager = manager;
            _logger = logger;
            
            _logger.LogInformation("HandsController created");
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
        public async Task<ActionResult> GetHand(ulong id)
        {
            var hand = await _manager.GetHandById(id);
            if (hand == null)
            {
                _logger.LogWarning("Hand with id {HandId} not found", id);
                return NotFound();
            }
            _logger.LogInformation("Hand with id {HandId} retrieved", id);
            
            return Ok(hand.ToHandDTODetail());
        }

        /// <summary>
        /// Post a new hand to the database
        /// </summary>
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
                _logger.LogWarning("Game with id {GameId} not found", request.GameId);
                return BadRequest($"The game with id {request.GameId} does not exist");
            }

            var rules = RulesFactory.Create(request.Rules);
            if (rules is null)
            {
                _logger.LogWarning("Rules {Rules} not found", request.Rules);
                return BadRequest($"The rules {request.Rules} does not correspond to any rules");
            }

            var biddings = new List<KeyValuePair<Player, (Biddings, Poignee)>>();
            foreach (var bidding in request.Biddings)
            {
                var user = await _manager.GetUserById(bidding.UserId);
                if (user is null)
                {
                    _logger.LogWarning("User with id {UserId} not found", bidding.UserId);
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

            if (handInserted is null)
            {
                _logger.LogWarning("Hand not inserted, an error occured");
                return BadRequest("An error occured while inserted the hand");
            }

            var handReply = handInserted.ToHandDTODetail();
            handReply.GameId = request.GameId;
            _logger.LogInformation("Hand with id {HandId} inserted", handInserted.Id);

            return CreatedAtAction(
                nameof(GetHand),
                new { id = handInserted.Id },
                handReply
            );
        }

        /// <summary>
        /// Update a Hand in the database by its id.
        /// </summary>
        /// <param name="id">The id of the Hand to be updated.</param>
        /// <param name="request">The DTO containing the updated information for the Hand.</param>
        /// <returns>
        /// Returns a BadRequest result if the id in the request does not match the id in the DTO. 
        /// Returns a NotFound result if the hand is not found. 
        /// Returns a NoContent result if the update is successful.
        /// </returns>
        [HttpPut("{id}")]
        [MapToApiVersion("2.0")]
        public async Task<IActionResult> Put(ulong id, [FromBody] HandUpdateRequest request)
        {
            if (id != request.Id)
            {
                _logger.LogWarning("The url id {UrlId} does not correspond to the body id {BodyId}", id, request.Id);
                return BadRequest();
            }

            var rules = RulesFactory.Create(request.Rules);
            if (rules is null)
            {
                _logger.LogWarning("Rules {Rules} not found", request.Rules);
                return BadRequest($"The rules {request.Rules} does not correspond to any rules");
            }

            var biddings = new List<KeyValuePair<Player, (Biddings, Poignee)>>();
            foreach (var bidding in request.Biddings)
            {
                var user = await _manager.GetUserById(bidding.UserId);
                if (user is null)
                {
                    _logger.LogWarning("User with id {UserId} not found", bidding.UserId);
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
            if (handUpdated is null)
            {
                _logger.LogWarning("Hand with id {HandId} not found", id);
                return NotFound();
            }
            _logger.LogInformation("Hand with id {HandId} updated", id);
            
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
            if (hand is null)
            {
                _logger.LogWarning("Hand with id {HandId} not found", id);
                return NotFound();
            }
            await _manager.DeleteHand(hand);
            _logger.LogInformation("Hand with id {HandId} deleted", id);
            
            return NoContent();
        }
    }
}