using Microsoft.AspNetCore.Mvc;

namespace Sofa3_bioscoop_TonyJonah.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        [HttpGet(Name = "test")]
        public void Get()
        {
            Movie movie = new Movie("Appel in Amerika");
            MovieScreening movieScreening = new MovieScreening(movie, DateTime.Now, 2.00);
            movie.addScreening(movieScreening);

            MovieTicket movieTicket = new MovieTicket(movieScreening, 1, 1, true);

            Order order = new Order(1, true);
            order.AddSeatReservation(movieTicket);

            order.CalculatePrice();

        }
    }


}
