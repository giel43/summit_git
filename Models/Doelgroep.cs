namespace RazorApp.Models
{
    public class Doelgroep
    {
        public int Doelgroep_ID { get; set; }
        public string Doelgroepen { get; set; }
        public Doelgroep(int doelgroep_ID, string doelgroepen)
        {
            Doelgroep_ID = doelgroep_ID;
            Doelgroepen = doelgroepen;
        }
    }
}
