namespace OnlineShop.WebApi.Models
{
    public class StatusTypeUpdateModel
    {
        public StatusTypeUpdateModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
