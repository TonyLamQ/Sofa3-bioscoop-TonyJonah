namespace Sofa3_bioscoop_TonyJonah
{
    public class MovieTicket
    {
        private int rowNr { get; set; }
        private int seatNr { get; set; }

        private bool isPremium { get; set; }
        private MovieScreening movieScreening { get; set; }

        public MovieTicket(MovieScreening movieScreening, int rowNr, int seatNr, bool isPremium)
        {
            this.movieScreening = movieScreening;
            this.rowNr = rowNr;
            this.seatNr = seatNr;
            this.isPremium = isPremium;
        }
        public bool isPremiumTicket()
        {
            return isPremium;
        }
        public double getPrice()
        {
            return movieScreening.getPricePerSeat();
        }
        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
