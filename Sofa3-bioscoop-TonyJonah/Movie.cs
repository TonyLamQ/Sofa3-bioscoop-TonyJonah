namespace Sofa3_bioscoop_TonyJonah
{
    public class Movie
    {
        private string title { get; set; }
        private List<MovieScreening> movieScreenings { get; set; }

        public Movie(string title)
        {
            this.title = title;
            this.movieScreenings = new List<MovieScreening>();
        }

        public void addScreening(MovieScreening screening)
        {
            this.movieScreenings.Add(screening);
        }
    }
}
