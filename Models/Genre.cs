namespace RazorApp.Models
{
    public class Genre
    {
        public int Genre_ID { get; set; }
        public string Genres { get; set; }

        public Genre(int genre_ID, string genres)
        {
            Genre_ID = genre_ID;
            Genres = genres;

        }
    }
}
