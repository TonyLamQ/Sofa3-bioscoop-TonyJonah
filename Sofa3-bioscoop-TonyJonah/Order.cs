using System.Text;
using System.Xml;
using System.Text.Json;
using System.Text.Json.Nodes;

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
                decimal ticketPrice = (decimal)ticket.GetPrice();
                bool isPremium = ticket.IsPremiumTicket();
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
                { "isStudentOrder", this.IsStudent },
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
