﻿using System.Text;
using System.Xml;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Sofa3_bioscoop_TonyJonah
{
    public class Order
    {
        private int OrderNr { get; set; }

        private List<MovieTicket> MovieTickets { get; set; }

        public Order(int orderNr, bool isStudent)
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
            decimal TotalPrice = 0.00M;
            int Today = (int)DateTime.Today.DayOfWeek;
            int TicketCount = MovieTickets.Count;
            List<int> Weekend = new List<int>() { 6, 0 };
            for (int i = 0; i < this.MovieTickets.Count; i++)
            {
                MovieTicket ticket = MovieTickets[i];
                decimal ticketPrice = ticket.GetPrice();
                TotalPrice += ticketPrice;
            }
            if (Weekend.Contains(Today) && TicketCount >= 6)
            {
                TotalPrice *= 0.9M;
            }
            return TotalPrice;
        }

        public void RemoveFreeTickets()
        {
            int TicketCount = MovieTickets.Count;
            int StudentTickets = 0;
            for (int i = 0;i < TicketCount; i++)
            {
                MovieTicket ticket = MovieTickets[i];
                if (ticket.IsStudentTicket())
                {
                    StudentTickets++;
                }
            }
            int freeTickets = StudentTickets / 2;
            this.MovieTickets.Sort((x, y) => x.GetPrice().CompareTo(y.GetPrice()));

            for (int i = 0; freeTickets > 0 && i < MovieTickets.Count; i++)
            {
                if (MovieTickets[i].IsStudentTicket())
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
