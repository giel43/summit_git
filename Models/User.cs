namespace RazorApp.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public User(int userID, string voornaam, string achternaam, string password, string email)
        {
            UserID = userID;
            Voornaam = voornaam;
            Achternaam = achternaam;
            Password = password;
            Email = email;
        }
    }
}
