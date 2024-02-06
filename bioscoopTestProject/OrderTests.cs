using Sofa3_bioscoop_TonyJonah;

namespace bioscoopTestProject
{
    public class OrderTests
    {
        [Fact]
        public void CalculatePrice_SecondTicketFreeForStudent()
        {
            Order order = CreateStudentOrder(6, 10M, true, true);
            decimal price = order.CalculatePrice();

            Assert.Equal(36M, price);

        }
        
        [Fact]
        public void CalculatePrice_10ProcentDiscounForNonStudents()
        {
            Order order = CreateOrder(7, 10M, true, true);
            decimal price = order.CalculatePrice();

            Assert.Equal(63M, price);

        }
        
        [Fact]
        public void CalculatePrice_PremiumTicketShouldBeTwoExtraForStudentInPrice()
        {
            Order order = CreateStudentOrder(1, 10M, true, true);
            decimal price = order.CalculatePrice();
            
            Assert.Equal(12M, price);
        }

        [Fact]
        public void CalculatePrice_NonPremiumTicketShouldBeBasePrice()
        {
            Order order = CreateStudentOrder(1, 10M, false, true);
            decimal price = order.CalculatePrice();
            
            Assert.Equal(10M, price);
        }
        
        private static Order CreateStudentOrder(int numberOfTickets, decimal basePrice, bool isPremium, bool isWeekend)
        {
            Movie movie = new Movie("The Matrix");
            
            DateTime date = isWeekend ? new DateTime(2024, 1, 27, 19, 0, 0) : new DateTime(2024, 1, 31, 19, 0, 0);
            MovieScreening movieScreening = new MovieScreening(movie, date, basePrice);
            Order order = new Order(1);
            for (int i = 0; i < numberOfTickets; i++)
                order.AddSeatReservation(new StudentMovieTicket(movieScreening, 1, 1, isPremium));
            return order;
        }
        
        private static Order CreateOrder(int numberOfTickets, decimal basePrice, bool isPremium, bool isWeekend)
        {
            Movie movie = new Movie("The Matrix");
            
            DateTime date = isWeekend ? new DateTime(2024, 1, 27, 19, 0, 0) : new DateTime(2024, 1, 31, 19, 0, 0);
            MovieScreening movieScreening = new MovieScreening(movie, date, basePrice);
            Order order = new Order(1);
            for (int i = 0; i < numberOfTickets; i++)
                order.AddSeatReservation(new MovieTicket(movieScreening, 1, 1, isPremium));
            return order;
        }
    }
}