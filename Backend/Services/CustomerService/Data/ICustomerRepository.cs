using CustomerService.Models;

namespace CustomerService.Data
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer SearchByEmail(string email);
        Customer SearchByPhone(string phone);
        Customer SearchById(int id);
        void Update(Customer customer);
        int GetAllCount();
    }
}
