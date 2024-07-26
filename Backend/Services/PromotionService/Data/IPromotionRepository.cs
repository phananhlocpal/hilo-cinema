using PromotionService.Models;

namespace PromotionService.Data
{
    public interface IPromotionRepository
    {
        IEnumerable<Promotion> GetAll();
        Promotion GetById(int id);
        void Insert(Promotion promotion);
        void Update(Promotion promotion);
    }
}
