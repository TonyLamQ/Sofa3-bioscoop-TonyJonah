namespace Sofa3_bioscoop_TonyJonah
{
    public class Movie
    {
        private string title { get; set; }

        public Movie(string title)
        {
            this.title = title;
        }

        public void addScreening(MovieScreening screening)
        {
            //ToDo: Implement addScreening method
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
