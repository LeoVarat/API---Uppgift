namespace OnlineShop.WebApi.Models
{
    public class StatusTypeModel
    {
        public StatusTypeModel()
        {

        }
        public StatusTypeModel(string name)
        {
            Name = name;
        }

        public StatusTypeModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
