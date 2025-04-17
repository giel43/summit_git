namespace RazorApp.Models
{
    public class Auteur
    {
        public int AuteurID { get; set; }
        public string Auteurs { get; set; }

        public Auteur(int auteurID, string auteurs)
        {
            AuteurID = auteurID;
            Auteurs = auteurs;
        }
    }
}
