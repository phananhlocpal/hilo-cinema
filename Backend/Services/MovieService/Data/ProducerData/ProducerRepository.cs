using MovieService.Exception;
using MovieService.Models;

namespace MovieService.Data.Producer
{
    public class ProducerRepository : IProducerRepository
    {
        private readonly MovieDbContext _context;
        public ProducerRepository(MovieDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Models.Producers> GetAll()
        {
            IEnumerable<Models.Producers> producers = _context.Producer.ToList();
            if (!producers.Any())
            {
                throw new ResourceNotFoundException("Producers list is empty");
            }
            return producers;
        }

        public Models.Producers GetById(int id)
        {
            Models.Producers producer = _context.Producer.FirstOrDefault(x => x.Id == id);
            if (producer == null)
            {
                throw new DataNotFoundException("Producer does not exist");
            }
            return producer;
        }

        public void InsertProducer(Models.Producers producer)
        {
            if (producer == null)
            {
                throw new ResourceNotFoundException("Producer doest not null");
            }
            _context.Producer.Add(producer);
        }

        public bool saveChange()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateProducer(int id, Models.Producers producers)
        {
            Models.Producers currentProducer = _context.Producer.FirstOrDefault(x => x.Id == id);
            if (currentProducer != null)
            {
                currentProducer.Name = producers.Name;
                currentProducer.Description = producers.Description;
                currentProducer.Img = producers.Img;

                _context.SaveChanges();
            }
        }
    }
}
