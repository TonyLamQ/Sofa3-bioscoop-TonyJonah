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
        public virtual decimal GetPrice() {  return 0; }

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
