using MomentozWebClient.ServiceLayer;
using MomentozWebClient.Models;

namespace MomentozWebClient.BusinessLogicLayer
{
    public class OrderLogic
    {


        private readonly OrderService _orderServiceAccess;
        private readonly FlightService _flightService;

        public OrderLogic(IConfiguration inConfiguration)
        {
            _orderServiceAccess = new OrderService(inConfiguration);
            _flightService = new FlightService(inConfiguration);
        }
        public async Task<Order> postNewOrder(Order newOrder)
        {
            Order createdOrder;
            try
            {
                createdOrder = await _orderServiceAccess.AddOrder(newOrder);
            } catch
            {
                createdOrder = null;
            }
            return createdOrder;
        }
        public async Task<Flight> getFlightById(int flightID)
        {
            Flight flight = await _flightService.GetFlightById(flightID);
            return flight;
        }
    }
}
