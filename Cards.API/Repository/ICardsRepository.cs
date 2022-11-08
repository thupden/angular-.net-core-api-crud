using Cards.API.Models;

namespace Cards.API.Repository
{
    public interface ICardsRepository
    {
        Task<ICollection<Card>> GetAllAsync();
        Task<Card> GetByIdAsync(Guid id);
        Task<Card> AddCardAsync(Card card);
        Task<Card> UpdateCardAsync(Guid id, Card card);
        Task<Card> DeleteCardAsync(Guid id);
    }
}
