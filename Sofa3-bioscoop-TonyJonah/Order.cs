using System.Text;
using System.Xml;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Sofa3_bioscoop_TonyJonah
{
    public class Order
    {
        private int OrderNr { get; set; }

        private List<MovieTicket> MovieTickets { get; set; }

        public Order(int orderNr)
        {
            this.OrderNr = orderNr;
            MovieTickets = new List<MovieTicket>();

        }
        public void AddSeatReservation(MovieTicket ticket)
        {
            this.MovieTickets.Add(ticket);
        }
        public decimal CalculatePrice()
        {
            RemoveFreeTickets();
            decimal totalPrice = 0.00M;
            int today = (int)DateTime.Today.DayOfWeek;
            int ticketCount = MovieTickets.Count;
            List<int> weekend = new List<int>() { 6, 0 };
            for (int i = 0; i < this.MovieTickets.Count; i++)
            {
                MovieTicket ticket = MovieTickets[i];
                decimal ticketPrice = ticket.GetPrice();
                totalPrice += ticketPrice;
            }
            if (weekend.Contains(today) && ticketCount >= 6)
            {
                totalPrice *= 0.9M;
            }
            return totalPrice;
        }

        public void RemoveFreeTickets()
        {
            int ticketCount = MovieTickets.Count;
            int studentTickets = 0;
            for (int i = 0;i < ticketCount; i++)
            {
                MovieTicket ticket = MovieTickets[i];
                if (ticket is StudentMovieTicket)
                {
                    studentTickets++;
                }
            }
            int freeTickets = studentTickets / 2;
            this.MovieTickets.Sort((x, y) => x.GetPrice().CompareTo(y.GetPrice()));

            for (int i = 0; freeTickets > 0 && i < MovieTickets.Count; i++)
            {
                if (MovieTickets[i] is StudentMovieTicket)
                {
                    MovieTickets.RemoveAt(i);
                    i--;
                    freeTickets--;
                }
            }
        }

        public void Export(TicketExportFormat format)
        {
            switch (format)
            {
                case TicketExportFormat.PLAINTEXT:
                    ExportToPlainText();
                    break;
                case TicketExportFormat.JSON:
                    ExportToJson();
                    break;
            }
        }
        
        private void ExportToPlainText()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Order: {this.OrderNr} | Price: {this.CalculatePrice():C2}");
            foreach (MovieTicket ticket in MovieTickets)
                sb.AppendLine(ticket.ToString());

            string path = Path.Combine(Path.GetTempPath(), "", $"order_{this.OrderNr}.txt");
            File.WriteAllText(path, sb.ToString());
            Console.WriteLine(File.ReadAllText(path));
        }

        private void ExportToJson()
        {
            JsonObject jsonOrder = new JsonObject
            {
                { "orderNr", this.OrderNr },
                { "totalPrice", this.CalculatePrice() }
            };

            JsonArray jsonTickets = new JsonArray();
            foreach (MovieTicket ticket in MovieTickets)
            {
                JsonObject jsonTicket = new JsonObject
                {
                    { "screeningDate", ticket.GetScreeningDate() },
                    { "isPremiumTicket", ticket.IsPremiumTicket() },
                    { "price", ticket.GetPrice() },
                };
                jsonTickets.Add(jsonTicket);
            }
            jsonOrder.Add("tickets", jsonTickets);

            string path = Path.Combine(Path.GetTempPath(), "", $"order_{this.OrderNr}.json");
            File.WriteAllText(path, jsonOrder.ToString());
        }
    }
}
