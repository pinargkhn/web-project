namespace BusBooking.Models
{
    public class Bus
    {
        public int BusId { get; set; }
        public string BusNumber { get; set; }
        public string DepartureLocation { get; set; }
        public string ArrivalLocation { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int CompanyId { get; set; }
        public int SeatCount { get; set; }
    }
}
