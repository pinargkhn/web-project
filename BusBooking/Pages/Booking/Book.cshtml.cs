using BusBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusBooking.Pages.Booking
{
    public class BookModel : PageModel
    {
        private readonly DatabaseHelper _databaseHelper;

        public BookModel(DatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        [BindProperty]
        public List<Bus> Buses { get; set; }

        public void OnPost(string departureLocation, string arrivalLocation, DateTime date)
        {
            // Retrieve available Buses for spesific filters
            Buses = _databaseHelper.RetrieveBusesForFilter(departureLocation, arrivalLocation, date);
        }

        public IActionResult OnPostBook(int busId, int seats)
        {
            // DB Helper handles booking on database for the bus id and seatcount.
            bool success = _databaseHelper.HandleBooking(busId, seats);

            if (success)
            {
                // Redirect to confirmation page
                return RedirectToPage("BookingConfirmation");
            }
            else
            {
                // Show an error message
                return RedirectToPage("Error");
            }
        }
    }

}
