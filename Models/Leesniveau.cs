namespace RazorApp.Models
{
    public class Leesniveau
    {
        public int Leesniveau_ID { get; set; }
        public string Leesniveau_Levels { get; set; }

        public Leesniveau(int leesniveau_ID, string leesniveau_Levels)
        {
            Leesniveau_ID = leesniveau_ID;
            Leesniveau_Levels = leesniveau_Levels;

        }
    }
}
