namespace Sofa3_bioscoop_TonyJonah
{
    public class RegularTicketPrice : ITicketPrice
    {
        public decimal GetPrice(MovieTicket movieTicket)
        {
            decimal Price = movieTicket.GetMovieScreening().GetPricePerSeat();
            if (movieTicket.IsPremiumTicket())
            {
                Price += 3M;
            }
            return Price;
        }
    }
}
