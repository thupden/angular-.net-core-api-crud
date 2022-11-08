using Cards.API.Models;
using Cards.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Cards.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardsController : Controller
    {
        private readonly ICardsRepository cardsRepository;

        public CardsController(ICardsRepository cardsRepository)
        {
            this.cardsRepository = cardsRepository;
        }

        //Get All cards
        [HttpGet]
        public async Task<IActionResult> GetAllCards()
        {
            var cards = await cardsRepository.GetAllAsync();
            return Ok(cards);
        }

        //Get card by Id
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetCard")]
        public async Task<IActionResult> GetCard([FromRoute] Guid id)
        {
            var card = await cardsRepository.GetByIdAsync(id);
            if(card!=null)
            {
                return Ok(card);
            }
            return NotFound("Card not found");
        }

        //Add card
        [HttpPost]
        public async Task<IActionResult> AddCard([FromBody] Card card)
        {
            var cards = await cardsRepository.AddCardAsync(card);
            return CreatedAtAction(nameof(GetCard), new { id = card.Id }, card);
        }

        //Update Card
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCard([FromRoute] Guid id,[FromBody] Card card)
        {
            var updateCard = await cardsRepository.UpdateCardAsync(id, card);
            if(updateCard!=null)
            {
                return Ok(updateCard);
            }
            return NotFound("Card not found");
            
        }

        //Delete Card
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCard([FromRoute] Guid id)
        {
            var card = await cardsRepository.DeleteCardAsync(id);
            if(card!=null)
            {
                return Ok(card);
            }
            return NotFound("Card not found");
        }

    }
}
