using MovieService.Models;

namespace MovieService.Data.Producer
{
    public interface IProducerRepository
    {
        IEnumerable<Producers> GetAll();
        Producers GetById(int id);
        void InsertProducer(Producers producers);
        void UpdateProducer(int id, Producers producers);
        bool saveChange();
    }
}
