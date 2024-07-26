using MovieService.Models;

namespace MovieService.Data.CategoryData
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MovieDbContext _context;
        public CategoryRepository(MovieDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Category> GetAll()
        {
            IEnumerable<Category> categories = _context.Category.ToList();
            return categories;
        }

        public Category GetById(int id)
        {
            Category category = _context.Category.FirstOrDefault(x => x.Id == id);
            return category;
        }

        public void Insert(Category category)
        {
            _context.Category.Add(category);

        }

        public void Update(int id, Category category)
        {
            Category currentCategory = _context.Category.FirstOrDefault(x => x.Id == id);
            if (currentCategory != null)
            {
                currentCategory.Name = category.Name;

                _context.SaveChanges();
            }
        }
        public bool saveChange()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
