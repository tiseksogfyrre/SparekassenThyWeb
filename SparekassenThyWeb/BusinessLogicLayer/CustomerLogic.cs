using MomentozWebClient.Models;
using MomentozWebClient.ServiceLayer;

namespace MomentozWebClient.BusinessLogicLayer
{
    public class CustomerLogic
    {


        private readonly CustomerService _customerServiceAccess;

        public CustomerLogic(IConfiguration inConfiguration)
        {
            _customerServiceAccess = new CustomerService(inConfiguration);
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            List<Customer> foundCustomers;
            try
            {
                foundCustomers = await _customerServiceAccess.GetAllCustomers();
            }
            catch
            {
                foundCustomers = null;
            }
            return foundCustomers;
        }
        public async Task<Customer> getCustomerByOrderCustomerId(int id)
        {
            Customer foundCustomer;
            try
            {
                foundCustomer = await _customerServiceAccess.getCustomerByOrderCustomerId(id);
            }
            catch
            {
                foundCustomer = null;
            }
            return foundCustomer;
        }

        public async Task<Customer> GetCustomerByUserId(string userId)
        {

            Customer foundCustomer = await _customerServiceAccess.GetCustomerByUserId(userId);

            return foundCustomer;
        }

        public async Task<Customer?> CreateCustomerFromUserAccount(string userId, string? email)
        {
            Customer? createdCust = null;

            if (!string.IsNullOrEmpty(userId))
            {
                Customer custToSave = new Customer(email, userId);
                createdCust = await _customerServiceAccess.SaveCustomerMinimal(custToSave);
            }

            return createdCust;
        }
        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            return await _customerServiceAccess.UpdateCustomer(customer);
        }
    }
}
