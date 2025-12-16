using MomentozWebClient.Models;

namespace MomentozWebClient.ServiceLayer
{
    public interface IOrderAccess
    {

        Task<List<Order>>? GetAllOrders();

        Task<Order> AddOrder(Order order);

        Task<Order> UpdateOrder(Order order);

        Task<Order> DeleteOrder(int id);

    }
}

