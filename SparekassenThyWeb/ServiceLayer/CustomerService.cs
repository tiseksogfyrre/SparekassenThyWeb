using MomentozWebClient.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace MomentozWebClient.ServiceLayer
{
    public class CustomerService : ICustomerAccess

    {
        readonly IServiceConnection _customerServiceConnection;

        public CustomerService(IConfiguration inConfiguration)
        {
            UseServiceUrl = inConfiguration["ServiceUrlToUse"];
            _customerServiceConnection = new ServiceConnection(UseServiceUrl);
        }

        public string UseServiceUrl { get; set; }


        public async Task<List<Customer>>? GetAllCustomers()
        {
            List<Customer>? customersFromService = null;

            _customerServiceConnection.UseUrl = _customerServiceConnection.BaseUrl;
            _customerServiceConnection.UseUrl += "customers";


            if (_customerServiceConnection != null)
            {
                try
                {
                    var serviceResponse = await _customerServiceConnection.CallServiceGet();
                    if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                    {
                        var content = await serviceResponse.Content.ReadAsStringAsync();

                        customersFromService = JsonConvert.DeserializeObject<List<Customer>>(content);
                    }
                    else
                    {
                        if (serviceResponse != null && serviceResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
                        {
                            customersFromService = new List<Customer>();
                        }
                        else
                        {
                            customersFromService = null;
                        }
                    }
                }
                catch
                {
                    customersFromService = null;
                }
            }
            return customersFromService;
        }

        public async Task<Customer> GetCustomerByUserId(string userId)
        {
            Customer customerFromService = null;

            _customerServiceConnection.UseUrl = _customerServiceConnection.BaseUrl;
            _customerServiceConnection.UseUrl += "Customers/" + userId;

            if (_customerServiceConnection != null)
            {
                try
                {
                    var serviceResponse = await _customerServiceConnection.CallServiceGet();      
                    if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                    {
                        if (serviceResponse.StatusCode == HttpStatusCode.OK)
                        {
                            var content = await serviceResponse.Content.ReadAsStringAsync();
                            customerFromService = JsonConvert.DeserializeObject<Customer>(content);
                        }
                        else
                        {
                            customerFromService = new Customer();
                        }
                    }
                    else
                    {
                        customerFromService = null;
                    }
                }
                catch
                {
                    customerFromService = null;
                }
            }
            return customerFromService;
        }
        public async Task<Customer> getCustomerByOrderCustomerId(int id)
        {
            Customer customerFromService = null;

            _customerServiceConnection.UseUrl = _customerServiceConnection.BaseUrl;
            _customerServiceConnection.UseUrl += "Customers/" + id;

            if (_customerServiceConnection != null)
            {
                try
                {
                    var serviceResponse = await _customerServiceConnection.CallServiceGet();
                    if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                    {
                        if (serviceResponse.StatusCode == HttpStatusCode.OK)
                        {
                            var content = await serviceResponse.Content.ReadAsStringAsync();
                            customerFromService = JsonConvert.DeserializeObject<Customer>(content);
                        }
                        else
                        {
                            customerFromService = new Customer();
                        }
                    }
                    else
                    {
                        customerFromService = null;
                    }
                }
                catch
                {
                    customerFromService = null;
                }
            }
            return customerFromService;
        }


        public async Task<Customer> SaveCustomerMinimal(Customer newCust)
        {
            Customer customerFromService = null;

            _customerServiceConnection.UseUrl = _customerServiceConnection.BaseUrl;
            _customerServiceConnection.UseUrl += "Customers/";
            if (_customerServiceConnection != null)
            {
                try
                {
                    var json = JsonConvert.SerializeObject(newCust);
                    var inContent = new StringContent(json, Encoding.UTF8, "application/json");

                    var serviceResponse = await _customerServiceConnection.CallServicePost(inContent);
                    if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                    {
                        var resultContent = await serviceResponse.Content.ReadAsStringAsync();
                        customerFromService = JsonConvert.DeserializeObject<Customer>(resultContent);
                    }
                }
                catch
                {
                    customerFromService = null;
                }
            }

            return customerFromService;
        }



        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            Customer customerFromService = null;

            _customerServiceConnection.UseUrl += "Customers/" + customer.LoginUserId;

            if (_customerServiceConnection != null)
            {
                try
                {
                    var json = JsonConvert.SerializeObject(customer);
                    var inContent = new StringContent(json, Encoding.UTF8, "application/json");

                    var serviceResponse = await _customerServiceConnection.CallServicePut(inContent);
                    if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                    {
                        var resultContent = await serviceResponse.Content.ReadAsStringAsync();
                        customerFromService = JsonConvert.DeserializeObject<Customer>(resultContent);
                    }
                }
                catch
                {
                    customerFromService = null;
                }
            }

            return customerFromService;
        }
        public Task<bool> AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Customer> GetCustomer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
