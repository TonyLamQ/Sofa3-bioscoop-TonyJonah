namespace Sofa3_bioscoop_TonyJonah
{
    public class MovieTicket
    {
        private int rowNr { get; set; }
        private int seatNr { get; set; }

        private bool isPremium { get; set; }

        public MovieTicket(int rowNr, int seatNr, bool isPremium)
        {
            this.rowNr = rowNr;
            this.seatNr = seatNr;
            this.isPremium = isPremium;
        }
        public double getPrice()
        {
            //ToDo: Implement getPrice function.
            return 0;
        }
        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
