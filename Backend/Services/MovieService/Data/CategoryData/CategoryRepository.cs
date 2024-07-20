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


        public IEnumerable<Categories> GetAll()
        {
            IEnumerable<Categories> categories = _context.Categories.ToList();
            return categories;
        }

        public Categories GetById(int id)
        {
            Categories category = _context.Categories.FirstOrDefault(x => x.Id == id);
            return category;
        }

        public void Insert(Categories category)
        {
            _context.Categories.Add(category);

        }

        public void Update(int id, Categories category)
        {
            Categories currentCategory = _context.Categories.FirstOrDefault(x => x.Id == id);
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
