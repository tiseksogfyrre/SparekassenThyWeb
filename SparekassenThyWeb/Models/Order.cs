namespace MomentozWebClient.Models
{
    public class Order
    {
        public int? OrderID { get; set; }
        public double TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int CustomerID { get; set; }
        public int FlightID { get; set; }
        public Order() { }
    }
}