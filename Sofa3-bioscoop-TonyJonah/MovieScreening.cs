namespace Sofa3_bioscoop_TonyJonah
{
    public class MovieScreening
    {
        private DateTime dateAndTime { get; set; }
        private double pricePerSeat { get; set; }

        public MovieScreening(DateTime dateAndTime, double pricePerSeat)
        {
            this.dateAndTime = dateAndTime;
            this.pricePerSeat = pricePerSeat;
        }

        public double getPricePerSeat()
        {
            //ToDo: Implement getPricePerSeat function.
            return 0;
        }
        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
