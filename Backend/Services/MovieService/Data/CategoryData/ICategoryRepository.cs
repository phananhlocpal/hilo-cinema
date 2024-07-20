using MovieService.Models;

namespace MovieService.Data.CategoryData
{
    public interface ICategoryRepository
    {
        IEnumerable<Categories> GetAll();
        Categories GetById(int id);
        void Insert(Categories categories);
        void Update(int id, Categories categories);
        bool saveChange();
    }
}
