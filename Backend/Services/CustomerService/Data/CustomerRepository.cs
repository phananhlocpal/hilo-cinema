using CustomerService.Models;

namespace CustomerService.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _context;
        public CustomerRepository(CustomerDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Customer> GetAll()
        {
            return  _context.Customer.ToList();
        }

        public int GetAllCount()
        {
            return _context.Customer.Count();
        }

        public Customer SearchByEmail(string email)
        {
            return _context.Customer.FirstOrDefault(e => e.Email == email);
        }

        public Customer SearchById(int id)
        {
            return _context.Customer.FirstOrDefault(x => x.Id == id);
        }

        public Customer SearchByPhone(string phone)
        {
            return _context.Customer.FirstOrDefault(p => p.Phone == phone);
        }

        public void Update(Customer customer)
        {
            _context.Update(customer);
            _context.SaveChanges();

        }
    }
}
