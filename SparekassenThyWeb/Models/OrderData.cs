using Microsoft.EntityFrameworkCore;

namespace MomentozWebClient.Models
{
    public class OrderData
    {
        private OrderData(int id) { Id = id; }
        public static OrderData getInstance()
        {
            if (Instance == null)
            {
                return new OrderData(1);
            }
            return Instance;
        }
        private static OrderData Instance;
        public int Id { get; set; }
        public Order OrderOrder { get; set; }
        public Customer OrderCustomer { get; set; }
        public Flight OrderFlight { get; set; }
    }
}
