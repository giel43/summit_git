using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace RazorApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }


        public class Boek
        {
            public long ISBN { get; set; }
            public string Titel { get; set; }
            public string Score { get; set; }
            public string Lees_niveau { get; set; }
            public string Type { get; set; }
            public string Taal { get; set; }
            public string Jaar_van_uitgave { get; set; }
            public string Uitgeverij { get; set; }
            public int Aantal_beschikbaar { get; set; }
            public string Foto { get; set; }
            public string Inhoud_boek { get; set; }
            public Boek(string isbnStr, string Titel, string Score, string Lees_niveau, string Type, string Taal, string Jaar_van_uitgave, string Uitgeverij, int Aantal_beschikbaar, string Foto, string Inhoud_boek)
            {
                long isbnValue = 0;
                long.TryParse(isbnStr.Trim(), out isbnValue); // Probeer de string naar long om te zetten
                this.ISBN = isbnValue;
                this.Titel = Titel;
                this.Score = Score;
                this.Lees_niveau = Lees_niveau;
                this.Type = Type;
                this.Taal = Taal;
                this.Jaar_van_uitgave = Jaar_van_uitgave;
                this.Uitgeverij = Uitgeverij;
                this.Aantal_beschikbaar = Aantal_beschikbaar;
                this.Foto = Foto;
                this.Inhoud_boek = Inhoud_boek;
            }
        }
        public List<Boek> Boek_lijst = new List<Boek>();

        public void VulBoeken()
        {
            string _connectionString = "Data Source=LAPTOP-MV01S0AU;Initial Catalog=BibliotheekDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM BOEKEN";
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        _logger.LogWarning("Geen boeken gevonden in de database.");
                        return;
                    }

                    while (reader.Read())
                    {
                        string isbnStr = reader.IsDBNull(0) ? "0" : reader.GetString(0).Trim();

                        Boek_lijst.Add(new Boek(
                            isbnStr,
                            reader.IsDBNull(1) ? "Onbekend" : reader.GetString(1),
                            reader.IsDBNull(2) ? "0" : reader.GetValue(2).ToString(),
                            reader.IsDBNull(3) ? "Onbekend" : reader.GetString(3),
                            reader.IsDBNull(4) ? "Onbekend" : reader.GetString(4),
                            reader.IsDBNull(5) ? "Onbekend" : reader.GetString(5),
                            reader.IsDBNull(6) ? "0" : reader.GetValue(6).ToString(),
                            reader.IsDBNull(7) ? "Onbekend" : reader.GetString(7),
                            reader.IsDBNull(8) ? 0 : reader.GetInt32(8),
                            reader.IsDBNull(9) ? "Geen foto" : reader.GetString(9),
                            reader.IsDBNull(10) ? "Geen inhoud" : reader.GetString(10)
                        ));
                    }
                }
            }
        }
            public void OnGet()
        {
            VulBoeken();
        }

    }
}


        