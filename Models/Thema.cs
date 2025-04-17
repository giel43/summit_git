namespace RazorApp.Models
{
    public class Thema
    {
        public int Thema_ID { get; set; }
        public string Themas { get; set; }

        public Thema(int thema_ID, string themas)
        {
            Thema_ID = thema_ID;
            Themas = themas;
        }
    }
}
