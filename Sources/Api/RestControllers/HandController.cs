using System;
using DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StubContext;
using Tarot2B2Model;
using TarotDB;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Games;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestControllers
{
    [Route("hand/")]
    public class HandController : ControllerBase
    {
        private readonly Manager _manager;
        
        public HandController(Manager manager)
        {
            _manager = manager;

        }

        // GET hand/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HandDTO>> Get(ulong id)
        {
            var hand = await _manager.GetHandById(id);
            if (hand == null) return NotFound();
            return Ok(hand.HandToDTO());
        }
        
        // POST api/values
        [HttpPost]
        public async Task<ActionResult<HandDTO>> Post(ulong gameId, [FromBody] HandDTO handDTO)
        {
            var hands = handDTO.hand;
            if (hands is null) return BadRequest();
            var hand = await _manager.InsertHand(gameId, hands.Number, hands.Rules, hands.Date, hands.TakerScore, hands.TwentyOne, hands.Excuse, hands.Petit, hands.Chelem, hands.Biddings); // a completer

            /*return */
        }
        
        // PUT hand/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(ulong id, [FromBody] HandDTO handDTO)
        {
            if(id != handDTO.Id) return BadRequest();
            var hand = await _manager.UpdateHand(handDTO.HandDTOToHand());
            if (hand == null) return NotFound();
            return NoContent();
        }

        // DELETE hand/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(ulong id)
        {
            var hand = await _manager.GetHandById(id);
            if (hand is null) return NotFound();
            await _manager.DeleteHand(hand);
            return NoContent();
        }
        
        // DELETE hand/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Hand hand)
        { 
            if (hand is null) return NotFound();
            await _manager.DeleteHand(hand);
            return NoContent();
        }
    }
}

