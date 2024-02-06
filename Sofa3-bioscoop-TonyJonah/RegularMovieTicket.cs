namespace Sofa3_bioscoop_TonyJonah
{
    public class RegularMovieTicket : MovieTicket
    {
        public RegularMovieTicket(MovieScreening movieScreening, int rowNr, int seatNr, bool isPremium)
        : base(movieScreening, rowNr, seatNr, isPremium)
        {
        }

        public override decimal GetPrice()
        {
            decimal Price = this.MovieScreening.GetPricePerSeat();
            if (this.IsPremium)
            {
                Price += 3M;
            }
            return Price;
        }
    }
}
