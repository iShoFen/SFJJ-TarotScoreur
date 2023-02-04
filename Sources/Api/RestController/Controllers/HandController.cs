using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Games;
using RestController.DTOs;
using RestController.DTOs.Extensions;

namespace RestControllers
{
    [Route("hand/")]
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
        /// <param name="handDtoDetail">The hand to be posted</param>
        /// <returns>
        /// Return a BadRequest if the hand is invalid, 
        /// Return a NoContent if the hand is valid and posted
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> Post(ulong gameId, [FromBody] HandDTODetail handDtoDetail)
        {
            Hand hand = HandDTOExtensions.ToHand(handDtoDetail);
            if (hand is null) return BadRequest();
            var biddingsROD = hand.Biddings;
            var keyValuePairs = biddingsROD.AsEnumerable().ToArray();
            var handInsert = await _manager.InsertHand(gameId, hand.Number, hand.Rules, hand.Date, hand.TakerScore, hand.TwentyOne, hand.Excuse, hand.Petit, hand.Chelem, keyValuePairs); // a completer
            if (handInsert is null) return BadRequest();
            return NoContent();
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
        public async Task<IActionResult> Put(ulong id, [FromBody] HandDTODetail handDtoDetail)
        {
            if(id != handDtoDetail.Id) return BadRequest();
            var hand = await _manager.UpdateHand(HandDTOExtensions.ToHand(handDtoDetail));
            if (hand is null) return NotFound();
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

