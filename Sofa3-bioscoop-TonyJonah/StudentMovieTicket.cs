namespace Sofa3_bioscoop_TonyJonah
{
    public class StudentMovieTicket : MovieTicket
    {
        public StudentMovieTicket(MovieScreening movieScreening, int rowNr, int seatNr, bool isPremium)
            : base(movieScreening, rowNr, seatNr, isPremium)
        {
        }

        public override decimal GetPrice()
        {
            decimal price = this.MovieScreening.GetPricePerSeat();
            if (this.IsPremium)
            {
                price += 2M;
            }
            return price;
        }
    }
}
