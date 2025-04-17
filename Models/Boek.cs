namespace RazorApp.Models
{
    public class Boek
    {
        public int BoekID { get; set; }
        public string Titel { get; set; }
        public int Aantal { get; set; }
        public string ISBN { get; set; }
        public string Foto { get; set; }
        public string Beschrijving { get; set; }
        public List<Auteur> Auteurs { get; set; }
        public List<Genre> Genres { get; set; }

        public List<Doelgroep> Doelgroepen {  get; set; }

        public List<Leesniveau> Leesniveaus { get; set; }

        public List<Locatie> Locaties { get; set; }

        public List<Taal> Talen {  get; set; }
        public List<Thema> Themas { get; set; }


        public Boek(int boekID, string titel, int aantal, string isbn, string foto, string beschrijving)
        {
            BoekID = boekID;
            Titel = titel;
            Aantal = aantal;
            ISBN = isbn;
            Foto = foto;
            Beschrijving = beschrijving;
            Auteurs = new List<Auteur>();
            Genres = new List<Genre>();
            Doelgroepen = new List<Doelgroep>();
            Leesniveaus = new List<Leesniveau>();
            Locaties = new List<Locatie>();
            Talen = new List<Taal>();
            Themas = new List<Thema>();
        }
    }
}
