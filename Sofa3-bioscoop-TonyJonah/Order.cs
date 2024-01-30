namespace Sofa3_bioscoop_TonyJonah
{
    public class Order
    {
        private int orderNr { get; set; }
        private bool isStudent { get; set; }

        private List<MovieTicket> movieTickets { get; set; }

        public Order(int orderNr, bool isStudent)
        {
            this.orderNr = orderNr;
            this.isStudent = isStudent;
            movieTickets = new List<MovieTicket>();

        }
        public void addSeatReservation(MovieTicket ticket)
        {
            this.movieTickets.Add(ticket);
        }
        public double calculatePrice()
        {
            //ToDo: Implement calculatePrice function.
            List<int> duringWeek = [1,2,3,4];
            List<int> weekend = [6,0];
            int today = (int)DateTime.Today.DayOfWeek;
            int ticketCount = movieTickets.Count;
            double totalPrice = 0.00;
            //Sunday = 0, Saturday = 6
            for (int i = 0; i < ticketCount; i++)
            {
                MovieTicket ticket = movieTickets[i];
                double ticketprice = ticket.getPrice();
                bool isPremium = ticket.isPremiumTicket();
                if (isStudent)
                {
                    int freeTickets = ticketCount / 2;
                    ticketCount -= freeTickets;
                    if (isPremium)
                    {
                        totalPrice += ticketprice+2.00;
                    }
                }
                else
                {
                    if (isPremium)
                    {
                        totalPrice += ticketprice + 3.00;
                    }
                    if (weekend.Contains(today) && ticketCount >= 6)
                    {
                        totalPrice *= 0.9;
                    }
                }

            }
            return totalPrice;
        }
        public void export(TicketExportFormat format)
        {
            //ToDo: Implement export function.
        }

    }
}
