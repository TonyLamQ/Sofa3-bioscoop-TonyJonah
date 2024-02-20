namespace Sofa3_bioscoop_TonyJonah
{
    public class MovieTicket
    {
        private int RowNr { get; set; }
        private int SeatNr { get; set; }

        private bool IsPremium { get; set; }
        private MovieScreening MovieScreening { get; set; }

        private readonly ITicketPrice TicketPrice;
        public MovieTicket(MovieScreening movieScreening, int rowNr, int seatNr, bool isPremium, ITicketPrice ticketPrice)
        {
            this.MovieScreening = movieScreening;
            this.RowNr = rowNr;
            this.SeatNr = seatNr;
            this.IsPremium = isPremium;
            this.TicketPrice = ticketPrice;
        }
        public bool IsPremiumTicket()
        {
            return IsPremium;
        }
        public MovieScreening GetMovieScreening()
        {
            return MovieScreening;
        }

        public DateTime GetScreeningDate()
        {
            return MovieScreening.GetDate();
        }

        public decimal GetPrice() {
            return TicketPrice.GetPrice(this);
        }
        public override string? ToString()
        {
            return "Premium Ticket: " + IsPremium + "     |     " + GetScreeningDate() + "     |     " + "price: " + GetPrice();
        }
    }
}
