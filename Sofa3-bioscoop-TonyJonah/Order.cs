namespace Sofa3_bioscoop_TonyJonah
{
    public class Order
    {
        private int orderNr { get; set; }
        private bool isStudent { get; set; }

        public Order(int orderNr, bool isStudent)
        {
            this.orderNr = orderNr;
            this.isStudent = isStudent;
        }
        public void addSeatReservation(MovieTicket ticket)
        {
            //ToDo: Implement addSeatReservation function.
        }
        public double calculatePrice()
        {
            //ToDo: Implement calculatePrice function.
            return 0;
        }
        public void export(TicketExportFormat format)
        {
            //ToDo: Implement export function.
        }

    }
}
