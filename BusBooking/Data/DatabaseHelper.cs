using BusBooking.Models;
using Microsoft.AspNetCore.Routing;
using System.Data.SqlClient;

public class DatabaseHelper
{
    private readonly string _connectionString;

    public DatabaseHelper(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("BusBookingDb");
    }


    public List<Bus> RetrieveBusesForFilter(string departureLocation, string arrivalLocation, DateTime date)
    {
        var buses = new List<Bus>();

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var query = "SELECT * FROM Buses WHERE DepartureLocation = @DepartureLocation AND DepartureTime >= @Date";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DepartureLocation", departureLocation);
                command.Parameters.AddWithValue("@ArrivalLocation", arrivalLocation);
                command.Parameters.AddWithValue("@Date", date);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        buses.Add(new Bus
                        {
                            BusId = reader.GetInt32(0),
                            BusNumber = reader.GetString(1),
                            DepartureLocation = reader.GetString(2),
                            ArrivalLocation = reader.GetString(3),
                            DepartureTime = reader.GetDateTime(4),
                            ArrivalTime = reader.GetDateTime(5),
                            CompanyId = reader.GetInt32(6),
                            SeatCount = reader.GetInt32(7),
                        });
                    }
                }
            }
        }

        return buses;
    }

    public bool HandleBooking(int busId, int seatCount)
    {
        bool result = false;
        // not implemented yet.
        return result;
    }
}
