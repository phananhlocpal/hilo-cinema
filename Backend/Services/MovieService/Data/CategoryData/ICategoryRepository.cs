using MovieService.Models;

namespace MovieService.Data.CategoryData
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);
        void Insert(Category categories);
        void Update(int id, Category categories);
        bool saveChange();
    }
}
