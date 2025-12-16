using MomentozWebClient.Models;

namespace MomentozWebClient.ServiceLayer
{
    public interface IFlightAccess
    {

        Task<List<Flight>>? GetAllFlights();

        Task<Flight> GetFlight(int id);

        Task<bool> AddFlight(Flight flight);

        Task<bool> UpdateFlight(Flight flight);

        Task<bool> DeleteFlight(int id);
       
    }
}

