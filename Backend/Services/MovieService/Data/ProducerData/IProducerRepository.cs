using MovieService.Models;

namespace MovieService.Data.Producer
{
    public interface IProducerRepository
    {
        IEnumerable<Models.Producers> GetAll();
        Models.Producers GetById(int id);
        void InsertProducer(Models.Producers producers);
        void UpdateProducer(int id, Models.Producers producers);
        bool saveChange();
    }
}
