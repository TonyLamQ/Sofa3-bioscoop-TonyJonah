namespace Sofa3_bioscoop_TonyJonah
{
    public abstract class MovieTicket
    {
        protected int RowNr { get; set; }
        protected int SeatNr { get; set; }

        protected bool IsPremium { get; set; }
        protected MovieScreening MovieScreening { get; set; }

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
        public virtual decimal GetPrice()
        {
            decimal Price = MovieScreening.GetPricePerSeat();
            if (IsPremium)
            {
                Price += 3M;
            }
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
