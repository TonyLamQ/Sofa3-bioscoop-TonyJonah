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
        public decimal calculatePrice()
        {
            //ToDo: Implement calculatePrice function.
            List<int> duringWeek = new List<int>() { 1, 2, 3, 4 };
            List<int> weekend = new List<int>() { 6, 0 };
            int today = (int)DateTime.Today.DayOfWeek;
            decimal totalPrice = 0.00M;
            int ticketCount = movieTickets.Count;
            if (isStudent)
            {
                int freeTickets = ticketCount / 2;
                ticketCount -= freeTickets;
            }
            for (int i = 0; i < ticketCount; i++)
            {
                MovieTicket ticket = movieTickets[i];
                decimal ticketPrice = (decimal)ticket.getPrice();
                bool isPremium = ticket.isPremiumTicket();
                decimal addPrice = isPremium ? (isStudent ? 2M : 3M) : 0M;
                totalPrice += ticketCount * (ticketPrice + addPrice);

                if (weekend.Contains(today) && ticketCount >= 6)
                {
                    totalPrice *= 0.9M;
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
