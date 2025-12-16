using MomentozWebClient.Models;
using Newtonsoft.Json;

namespace MomentozWebClient.ServiceLayer
{
    public class FlightService : IFlightAccess

    {
        readonly IServiceConnection _flightServiceConnection;

        public FlightService(IConfiguration inConfiguration)
        {
            UseServiceUrl = inConfiguration["ServiceUrlToUse"];
            _flightServiceConnection = new ServiceConnection(UseServiceUrl);
        }

        public string UseServiceUrl { get; set; }


        public async Task<List<Flight>>? GetAllFlights()
        {
            List<Flight>? flightFromService = null;

            _flightServiceConnection.UseUrl = _flightServiceConnection.BaseUrl;
            _flightServiceConnection.UseUrl += "flights";


            if (_flightServiceConnection != null)
            {
                try
                {
                    var serviceResponse = await _flightServiceConnection.CallServiceGet();
                    if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                    {
                        var content = await serviceResponse.Content.ReadAsStringAsync();

                        flightFromService = JsonConvert.DeserializeObject<List<Flight>>(content);

                    }
                    else
                    {
                        if (serviceResponse != null && serviceResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
                        {
                            flightFromService = new List<Flight>();
                        }
                        else
                        {
                            flightFromService = null;
                        }
                    }
                }
                catch
                {
                    flightFromService = null;
                }
            }
            return flightFromService;
        }
        public async Task<Flight>? GetFlightById(int id)
        {
            Flight? flightFromService = null;

            _flightServiceConnection.UseUrl = _flightServiceConnection.BaseUrl;
            _flightServiceConnection.UseUrl += "flights/" + id;


            if (_flightServiceConnection != null)
            {
                try
                {
                    var serviceResponse = await _flightServiceConnection.CallServiceGet();
                    if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                    {
                        var content = await serviceResponse.Content.ReadAsStringAsync();

                        flightFromService = JsonConvert.DeserializeObject<Flight>(content);

                    }
                    else
                    {
                        if (serviceResponse != null && serviceResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
                        {
                            flightFromService = new Flight();
                        }
                        else
                        {
                            flightFromService = null;
                        }
                    }
                }
                catch
                {
                    flightFromService = null;
                }
            }
            return flightFromService;
        }
        public Task<bool> AddFlight(Flight flight)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFlight(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Flight> GetFlight(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateFlight(Flight flight)
        {
            throw new NotImplementedException();
        }
        
    }
}
