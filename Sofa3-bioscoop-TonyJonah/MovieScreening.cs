namespace Sofa3_bioscoop_TonyJonah
{
    public class MovieScreening
    {
        private DateTime dateAndTime { get; set; }
        private double pricePerSeat { get; set; }
        private List<MovieTicket> ticketList { get; set; }


        public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
        {
            this.dateAndTime = dateAndTime;
            this.pricePerSeat = pricePerSeat;
            this.ticketList = new List<MovieTicket>();
        }
        public double getPricePerSeat()
        {
            return pricePerSeat;
        }
        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
