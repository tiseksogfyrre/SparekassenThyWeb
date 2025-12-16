using MomentozWebClient.Models;


namespace MomentozWebClient.ServiceLayer
{
    public interface ICustomerAccess
    {

        Task<List<Customer>>? GetAllCustomers();

        Task<Customer> GetCustomer(int id);

        Task<bool> AddCustomer(Customer customer);

        Task<Customer> UpdateCustomer(Customer customer);

        Task<bool> DeleteCustomer(int id);
        Task<Customer> SaveCustomerMinimal(Customer newCust);
        Task<Customer> getCustomerByOrderCustomerId(int id);
        Task<Customer> GetCustomerByUserId(string userId);
    }
}
