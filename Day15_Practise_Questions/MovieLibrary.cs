namespace Day15_Practise_Questons
{
    interface IFilm
    {
        string? Title { get; set; }
        string? Director { get; set; }
        int Year { get; set; }
    }
    interface IFilmLibrary
    {
        void AddFilm(IFilm film);
        void RemoveFilm(string title);
        IFilm? GetFilm(string title);
    }
    class Film : IFilm
    {
        public string? Title { get; set; }
        public string? Director { get; set; }
        public int Year{ get; set; }
    }
    class FilmLibrary : IFilmLibrary
    {
        private List<IFilm> _films = new List<IFilm>();

        public void AddFilm(IFilm film)
        {
            _films.Add(film);
        }

        public void RemoveFilm(string title)
        {
            _films.RemoveAll(f => (f as Film)?.Title == title);
        }

        public IFilm? GetFilm(string title)
        {
            return _films.FirstOrDefault(f => (f as Film)?.Title == title);
        }
    }
}