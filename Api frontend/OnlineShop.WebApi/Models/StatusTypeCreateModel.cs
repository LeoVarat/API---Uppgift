namespace OnlineShop.WebApi.Models
{

    public class StatusTypeCreateModel
    {
        public StatusTypeCreateModel()
        {

        }

        public StatusTypeCreateModel(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
