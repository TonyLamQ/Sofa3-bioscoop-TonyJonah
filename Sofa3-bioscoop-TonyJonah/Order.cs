using System.Xml;
using System.Text.Json;

namespace Sofa3_bioscoop_TonyJonah
{
    public class Order
    {
        private int OrderNr { get; set; }
        private bool IsStudent { get; set; }

        private List<MovieTicket> MovieTickets { get; set; }

        public Order(int orderNr, bool isStudent)
        {
            this.OrderNr = orderNr;
            this.IsStudent = isStudent;
            MovieTickets = new List<MovieTicket>();

        }
        public void AddSeatReservation(MovieTicket ticket)
        {
            this.MovieTickets.Add(ticket);
        }
        public decimal CalculatePrice()
        {
            //ToDo: Implement calculatePrice function.
            List<int> duringWeek = new List<int>() { 1, 2, 3, 4 };
            List<int> weekend = new List<int>() { 6, 0 };
            int today = (int)DateTime.Today.DayOfWeek;
            decimal totalPrice = 0.00M;
            int ticketCount = MovieTickets.Count;
            if (IsStudent)
            {
                int freeTickets = ticketCount / 2;
                ticketCount -= freeTickets;
            }
            for (int i = 0; i < ticketCount; i++)
            {
                MovieTicket ticket = MovieTickets[i];
                decimal ticketPrice = (decimal)ticket.getPrice();
                bool isPremium = ticket.isPremiumTicket();
                decimal addPrice = isPremium ? (IsStudent ? 2M : 3M) : 0M;
                totalPrice += ticketCount * (ticketPrice + addPrice);

                if (weekend.Contains(today) && ticketCount >= 6)
                {
                    totalPrice *= 0.9M;
                }
            }
            return totalPrice;
        }

        public void Export(TicketExportFormat format)
        {
            switch (format)
            {
                case TicketExportFormat.PlainText:
                    string fileName = $"Order_{OrderNr}_PlainText.txt";

                    using (StreamWriter writer = new StreamWriter(fileName))
                    {
                        writer.WriteLine($"Order Number: {OrderNr}");
                        writer.WriteLine($"Is Student: {IsStudent}");
                        writer.WriteLine("Movie Tickets:");

                        foreach (var ticket in MovieTickets)
                        {
                            writer.WriteLine($"- {ticket}");
                        }

                        writer.WriteLine($"Total Price: {CalculatePrice():C}");
                    }

                    Console.WriteLine($"Order exported to {fileName} in plain text format.");
                    break;
                case TicketExportFormat.Json:
                    string file = $"Order_{OrderNr}_Json.json";

                    using (StreamWriter writer = new StreamWriter(file))
                    {
                        var jsonOptions = new JsonSerializerOptions
                        {
                            WriteIndented = true
                        };

                        string json = JsonSerializer.Serialize(this, jsonOptions);
                        writer.Write(json);
                    }

                    Console.WriteLine($"Order exported to {file} in JSON format.");
                    break;
                default:
                    Console.WriteLine("Unsupported export format");
                    break;
            }
        }
        public enum TicketExportFormat
        {
            PlainText,
            Json
        }


    }
}
