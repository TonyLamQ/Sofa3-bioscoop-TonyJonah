using System.Xml;

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
            List<int> duringWeek = new List<int>(1, 2, 3, 4);
            List<int> weekend = new List<int>(6, 0);
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
                double ticketprice = ticket.getPrice();
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
            switch (format)
            {
                case TicketExportFormat.PlainText:
                    string fileName = $"Order_{orderNr}_PlainText.txt";

                    using (StreamWriter writer = new StreamWriter(fileName))
                    {
                        writer.WriteLine($"Order Number: {orderNr}");
                        writer.WriteLine($"Is Student: {isStudent}");
                        writer.WriteLine("Movie Tickets:");

                        foreach (var ticket in movieTickets)
                        {
                            writer.WriteLine($"- {ticket}");
                        }

                        writer.WriteLine($"Total Price: {calculatePrice():C}");
                    }

                    Console.WriteLine($"Order exported to {fileName} in plain text format.");
                    break;
                case TicketExportFormat.Json:
                    string fileName = $"Order_{orderNr}_Json.json";

                    using (StreamWriter writer = new StreamWriter(fileName))
                    {
                        string json = JsonConvert.SerializeObject(this, Formatting.Indented);
                        writer.Write(json);
                    }

                    Console.WriteLine($"Order exported to {fileName} in JSON format.");
                    break;
                default:
                    Console.WriteLine("Unsupported export format");
                    break;
            }
        }

    }
}
