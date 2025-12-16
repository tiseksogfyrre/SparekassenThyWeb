namespace MomentozWebClient.Models
{
    public class Flight
    {
       public int FlightID{ get; set; }
       public string Departure { get; set; }
       public string City { get; set; }
       public double Price { get; set; }
       public string DestinationAddress { get; set; }
       public string? DestinationCountry { get; set; }

        public Flight(int id, string? address, string? city, double price, string? destinationAddress, string? destinationCountry)

        {
            FlightID = id;
            Departure = address;
            City = city;
            Price = price;
            DestinationAddress = destinationAddress;
            DestinationCountry = destinationCountry;
        }
        public Flight() { }

    }
}
