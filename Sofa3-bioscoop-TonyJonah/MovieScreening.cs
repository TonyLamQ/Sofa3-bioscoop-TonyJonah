namespace Sofa3_bioscoop_TonyJonah
{
    public class MovieScreening
    {
        private DateTime DateAndTime { get; set; }
        private double PricePerSeat { get; set; }
        private List<MovieTicket> TicketList { get; set; }


        public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
        {
            this.DateAndTime = dateAndTime;
            this.PricePerSeat = pricePerSeat;
            this.TicketList = new List<MovieTicket>();
        }
        public double GetPricePerSeat()
        {
            return PricePerSeat;
        }

        public DateTime GetDate()
        {
            return DateAndTime;
        }
        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
