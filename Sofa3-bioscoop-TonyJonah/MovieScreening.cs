namespace Sofa3_bioscoop_TonyJonah
{
    public class MovieScreening
    {
        private DateTime DateAndTime { get; set; }
        private decimal PricePerSeat { get; set; }
        private List<MovieTicket> TicketList { get; set; }
        
        private Movie Movie { get; set; }
        
        public MovieScreening(Movie movie, DateTime dateAndTime, decimal pricePerSeat)
        {
            this.Movie = movie;
            this.DateAndTime = dateAndTime;
            this.PricePerSeat = pricePerSeat;
            this.TicketList = new List<MovieTicket>();
        }
        public decimal GetPricePerSeat()
        {
            return PricePerSeat;
        }

        public DateTime GetDate()
        {
            return DateAndTime;
        }
        public override string? ToString()
        {
            return DateAndTime + " " + PricePerSeat;
        }
    }
}
