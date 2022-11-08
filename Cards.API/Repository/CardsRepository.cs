using Cards.API.Data;
using Cards.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Cards.API.Repository
{
    public class CardsRepository : ICardsRepository
    {
        private readonly CardsDbContext cardsDbContext;
        //constructor
        public CardsRepository(CardsDbContext cardsDbContext)
        {
            this.cardsDbContext = cardsDbContext;
        }

        public async Task<Card> AddCardAsync(Card card)
        {
            card.Id = Guid.NewGuid();
            await cardsDbContext.Cards.AddAsync(card);
            await cardsDbContext.SaveChangesAsync();
            return card;
        }

        public async Task<Card> DeleteCardAsync(Guid id)
        {
            var existingCard = await cardsDbContext.Cards.FirstOrDefaultAsync(x => x.Id == id);
            if(existingCard!=null)
            {
                cardsDbContext.Remove(existingCard);
                await cardsDbContext.SaveChangesAsync();
            }
            return existingCard;
        }

        public async Task<ICollection<Card>> GetAllAsync()
        {
            var cards = await cardsDbContext.Cards.ToListAsync();
            return cards;
        }

        public async Task<Card> GetByIdAsync(Guid id)
        {
            var card = await cardsDbContext.Cards.FirstOrDefaultAsync(x=>x.Id==id);
            return card;
        }

        public async Task<Card> UpdateCardAsync(Guid id, Card card)
        {
            var oldCard = await cardsDbContext.Cards.FirstOrDefaultAsync(x => x.Id == id);
            if(oldCard!=null)
            {
                oldCard.CardholderName = card.CardholderName;
                oldCard.CardNumber = card.CardNumber;
                oldCard.ExpiryMonth = card.ExpiryMonth;
                oldCard.ExpiryYear = card.ExpiryYear;
                oldCard.CVC = card.CVC;
                await cardsDbContext.SaveChangesAsync();
            }
            

            return oldCard;
        }
    }
}
