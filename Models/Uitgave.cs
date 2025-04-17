namespace RazorApp.Models
{
    public class Uitgave
    {
        public int Uitgave_ID { get; set; }
        public string Naam { get; set; }

        public Uitgave(int uitgave_ID, string naam)
        {
            Uitgave_ID = uitgave_ID;
            Naam = naam;


        }
    }
}
