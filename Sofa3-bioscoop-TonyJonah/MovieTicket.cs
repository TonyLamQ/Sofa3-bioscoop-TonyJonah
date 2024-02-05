namespace Sofa3_bioscoop_TonyJonah
{
    public class MovieTicket
    {
        private int RowNr { get; set; }
        private int SeatNr { get; set; }

        private bool IsPremium { get; set; }
        private MovieScreening MovieScreening { get; set; }

        public MovieTicket(MovieScreening movieScreening, int rowNr, int seatNr, bool isPremium)
        {
            this.MovieScreening = movieScreening;
            this.RowNr = rowNr;
            this.SeatNr = seatNr;
            this.IsPremium = isPremium;
        }
        public bool IsPremiumTicket()
        {
            return IsPremium;
        }
        public decimal GetPrice()
        {
            return MovieScreening.GetPricePerSeat();
        }

        public DateTime GetScreeningDate()
        {
            return MovieScreening.GetDate();
        }
        public override string? ToString()
        {
            return "Premium Ticket: " + IsPremium + "     |     " + GetScreeningDate() + "     |     " + "price: " + GetPrice();
        }
    }
}
