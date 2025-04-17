namespace RazorApp.Models
{
    public class List
    {
        public int List_ID { get; set; }
        public string ListName { get; set; }
        public List(int list_ID, string listName)
        {
            List_ID = list_ID;
            ListName = listName;
        }
    }
}
