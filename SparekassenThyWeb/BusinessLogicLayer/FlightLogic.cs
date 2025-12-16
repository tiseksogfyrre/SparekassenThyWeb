using MomentozWebClient.ServiceLayer;
using MomentozWebClient.Models;

namespace MomentozWebClient.BusinessLogicLayer
{
    public class FlightLogic
    {
        private readonly FlightService _flightServiceAccess;

        public FlightLogic(IConfiguration inConfiguration)
        {
            _flightServiceAccess = new FlightService(inConfiguration);
        }

        public async Task<Flight> GetFlightById(int id)
        {
            Flight foundFlight;
            try
            {
                foundFlight = await _flightServiceAccess.GetFlightById(id);
            }
            catch
            {
                // Log fejlen hvis det er nødvendigt
                foundFlight = null;
            }
            return foundFlight;
        }


        public async Task<List<Flight>> GetAllFlights()
        {
            List<Flight> foundFlights;
            try
            {
                foundFlights = await _flightServiceAccess.GetAllFlights();
            }
            catch
            {
                foundFlights = null;
            }
            return foundFlights;
        }
    }
}
