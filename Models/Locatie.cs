namespace RazorApp.Models
{
    public class Locatie
    {
        public int Locatie_ID { get; set; }
        public string Boek_ID { get; set; }
        public string Locatie_Rij { get; set; }
        public int Locatie_Vak { get; set; }
        public int Locatie_Verdieping { get; set; }

        public Locatie(int locatie_ID, string boek_ID, string locatie_Rij, int locatie_Vak, int locatie_Verdieping)
        {
            Locatie_ID = locatie_ID;
            Boek_ID = boek_ID;
            Locatie_Rij = locatie_Rij;
            Locatie_Vak = locatie_Vak;
            Locatie_Verdieping = locatie_Verdieping;
        }
    }
}
