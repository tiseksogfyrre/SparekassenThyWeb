using MomentozWebClient.Models;
using Newtonsoft.Json;
using System.Text;

namespace MomentozWebClient.ServiceLayer
{
    public class OrderService : IOrderAccess

    {
        readonly IServiceConnection _orderServiceConnection;

        public OrderService(IConfiguration inConfiguration)
        {
            UseServiceUrl = inConfiguration["ServiceUrlToUse"];
            _orderServiceConnection = new ServiceConnection(UseServiceUrl);
        }

        public string UseServiceUrl { get; set; }


        public async Task<List<Order>>? GetAllOrders()
        {
            List<Order>? orderFromService = null;

            _orderServiceConnection.UseUrl = _orderServiceConnection.BaseUrl;
            _orderServiceConnection.UseUrl += "orders";


            if (_orderServiceConnection != null)
            {
                try
                {
                    var serviceResponse = await _orderServiceConnection.CallServiceGet();
                    if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                    {
                        var content = await serviceResponse.Content.ReadAsStringAsync();

                        orderFromService = JsonConvert.DeserializeObject<List<Order>>(content);

                    }
                    else
                    {
                        if (serviceResponse != null && serviceResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
                        {
                            orderFromService = new List<Order>();
                        }
                        else
                        {
                            orderFromService = null;
                        }
                    }
                }
                catch
                {
                    orderFromService = null;
                }
            }
            return orderFromService;
        }

        public async Task<Order> AddOrder(Order newOrder)
        {
            int? orderFromService = null;

            _orderServiceConnection.UseUrl = _orderServiceConnection.BaseUrl;
            _orderServiceConnection.UseUrl += "orders/";
            if (_orderServiceConnection != null)
            {
                try
                {
                    var json = JsonConvert.SerializeObject(newOrder);
                    var inContent = new StringContent(json, Encoding.UTF8, "application/json");

                    var serviceResponse = await _orderServiceConnection.CallServicePost(inContent);
                    if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                    {
                        var resultContent = await serviceResponse.Content.ReadAsStringAsync();
                        orderFromService = JsonConvert.DeserializeObject<int>(resultContent);
                    }
                }
                catch
                {
                    orderFromService = null;
                }
            }
            if(orderFromService == null)
            {
                return null;
            }
            newOrder.OrderID = orderFromService;
            return newOrder;
            
        }

        public Task<Order> DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }


        public Task<Order> UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
