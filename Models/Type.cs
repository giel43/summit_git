namespace RazorApp.Models
{
    public class Type
    {
        public int Type_ID { get; set; }
        public string Types { get; set; }

        public Type(int type_id, string types)
        {

            Type_ID = type_id; 
            Types = types;
        }
    }
}
