using PromotionService.Models;

namespace PromotionService.Data
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly PromotionDbContext _context;
        public PromotionRepository(PromotionDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Promotion> GetAll()
        {
            return _context.Promotion.ToList();
        }

        public Promotion GetById(int id)
        {
            return _context.Promotion.FirstOrDefault(pro => pro.Id == id);
        }

        public void Insert(Promotion promotion)
        {
            _context.Promotion.Add(promotion);
            _context.SaveChanges();
        }

        public void Update(Promotion promotion)
        {
            _context.Promotion.Update(promotion);
            _context.SaveChanges();
        }
    }
}
