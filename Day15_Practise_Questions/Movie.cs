namespace Day15_Practise_Questons
{
    public class Movie
    {
    public string Title { get; set; }
    public string Artist { get; set; }
    public string Genre { get; set; }
    public int Ratings { get; set; }
    }

    class Program
    {
        public static List<Movie> MovieList = new List<Movie>();

        // Add Movie
        public static void AddMovie(string movieDetails)
        {
            string[] data = movieDetails.Split(',');

            Movie m = new Movie
            {
                Title = data[0],
                Artist = data[1],
                Genre = data[2],
                Ratings = int.Parse(data[3])
            };

            MovieList.Add(m);
        }

        // View Movies By Genre
        public static List<Movie> ViewMoviesByGenre(string genre)
        {
            List<Movie> result = new List<Movie>();

            foreach (var movie in MovieList)
            {
                if(movie.Genre == genre)
                {
                    result.Add(movie);
                }
            }

            return result;
        }

        // View Movies By Ratings
        public static List<Movie> ViewMoviesByRatings()
        {
            return MovieList.OrderBy(m => m.Ratings).ToList();
        }

        static void Main()
        {
            Console.Write("Enter number of movies: ");
            int n = int.Parse(Console.ReadLine());
            
            string details = Console.ReadLine();
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter movie details (Title,Artist,Genre,Ratings): ");
                AddMovie(details);
            }

            Console.Write("\nEnter genre to search: ");
            string genre = Console.ReadLine();

            var genreMovies = ViewMoviesByGenre(genre);

            if (genreMovies.Count == 0)
            {
                Console.WriteLine($"No Movies found in genre '{genre}'");
            }
            else
            {
                Console.WriteLine("\nMovies in Genre:");
                foreach (var m in genreMovies)
                    Console.WriteLine($"{m.Title} | {m.Artist} | {m.Genre} | {m.Ratings}");
            }

            Console.WriteLine("\nMovies Sorted By Ratings:");
            var sortedMovies = ViewMoviesByRatings();
            foreach (var m in sortedMovies)
                Console.WriteLine($"{m.Title} | {m.Artist} | {m.Genre} | {m.Ratings}");
        }
    }
}