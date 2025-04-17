namespace RazorApp.Models
{
    public class Taal
    {
        public int Taal_ID { get; set; }
        public string Talen { get; set; }
        public Taal(int taal_ID, string talen)
        {

            Taal_ID = taal_ID;
            Talen = talen;
        }
    }
}
