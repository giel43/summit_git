using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using RazorApp.Models;
using System.Collections.Generic;

namespace RazorApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        private static string connectionString = "Data Source=LAPTOP-MV01S0AU;Initial Catalog=master;Integrated Security=True;Trust Server Certificate=True;";

        public List<Boek> Boek_lijst { get; set; } = new List<Boek>();

        public void OnGet()
        {
            Boek_lijst = GetAllBoeken();
        }

        public static List<Boek> GetAllBoeken()
        {
            List<Boek> boeken = new List<Boek>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string boekQuery = "SELECT [Boek_ID], [Titel], [Aantal], [ISBN], [Foto], [Beschrijving] FROM [dbo].[Boek_ID's]";

                using (SqlCommand command = new SqlCommand(boekQuery, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        boeken.Add(new Boek(
                            reader.IsDBNull(0) ? 0 : reader.GetInt32(0),     // BoekID
                            reader.IsDBNull(1) ? string.Empty : reader.GetString(1), // Titel
                            reader.IsDBNull(2) ? 0 : reader.GetInt32(2),      // Aantal
                            reader.IsDBNull(3) ? string.Empty : reader.GetString(3), // ISBN
                            reader.IsDBNull(4) ? string.Empty : reader.GetString(4), // Foto
                            reader.IsDBNull(5) ? string.Empty : reader.GetString(5)  // Beschrijving
                        ));
                    }
                }

                // Get authors for each book
                foreach (var boek in boeken)
                {
                    boek.Auteurs = GetAuteurs(connection, boek.BoekID);
                    boek.Genres = GetGenres(connection, boek.BoekID);
                    boek.Themas = GetThemas(connection, boek.BoekID);
                }
            }

            return boeken;
        }

        public static List<Auteur> GetAuteurs(SqlConnection connection, int boekID)
        {
            List<Auteur> auteurs = new List<Auteur>();
            string sql = @"
                SELECT a.[Auteur_ID], a.[Auteurs] 
                FROM [dbo].[Auteurs_ID's] a
                JOIN [dbo].[Boek_Auteurs_ID's] ba ON a.[Auteur_ID] = ba.[Auteur_ID]
                WHERE ba.[Boek_ID] = @boekID";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@boekID", boekID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        auteurs.Add(new Auteur(
                            reader.IsDBNull(0) ? 0 : reader.GetInt32(0),     // AuteurID
                            reader.IsDBNull(1) ? string.Empty : reader.GetString(1)  // Naam
                        ));
                    }
                }
            }
            return auteurs;
        }
        public static List<Genre> GetGenres(SqlConnection connection, int boekID)
        {
            List<Genre> genres = new List<Genre>();
            string sql = @"
        SELECT g.[Genre_ID], g.[Genres] 
        FROM [dbo].[Genres_ID's] g
        JOIN [dbo].[Boek_genres_ID's] bg ON g.[Genre_ID] = bg.[Genre_ID]
        WHERE bg.[Boek_ID] = @boekID";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@boekID", boekID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        genres.Add(new Genre(
                            reader.IsDBNull(0) ? 0 : reader.GetInt32(0),     // GenreID
                            reader.IsDBNull(1) ? string.Empty : reader.GetString(1)  // GenreNaam
                        ));
                    }
                }
            }
            return genres;
        }
        public static List<Thema> GetThemas(SqlConnection connection, int boekID)
        {
            List<Thema> themas = new List<Thema>();
            string sql = @"
                SELECT t.[Thema_ID], t.[Themas] 
                FROM [dbo].[Thema_ID's] t
                JOIN [dbo].[Boeken_Informatie_ID's] bi ON t.[Thema_ID] = bi.[Thema_ID]
                JOIN [dbo].[Boeken_info_SamenV_ID's] bs ON bi.[Boek_Info_ID] = bs.[Boeken_info_samenV_ID]
                WHERE bs.[Boek_ID] = @boekID";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@boekID", boekID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        themas.Add(new Thema(
                            reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            reader.IsDBNull(1) ? string.Empty : reader.GetString(1)
                        ));
                    }
                }
            }
            return themas;
        }
    }
}