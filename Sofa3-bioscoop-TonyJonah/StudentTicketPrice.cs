namespace Sofa3_bioscoop_TonyJonah
{
    public class StudentTicketPrice : ITicketPrice
    {
        public decimal GetPrice(MovieTicket movieTicket)
        {
            decimal Price = movieTicket.GetMovieScreening().GetPricePerSeat();
            if (movieTicket.IsPremiumTicket())
            {
                Price += 2M;
            }
            return Price;
        }
    }
}
