namespace OnlineShop.WebApi.Models
{
    public class AdressModel
    {
        public AdressModel(int id, string adress, int postalNumber, string city)
        {
            Id = id;
            Adress = adress;
            PostalNumber = postalNumber;
            City = city;
        }

        public int Id { get; set; }

        public string Adress { get; set; }

        public int PostalNumber { get; set; }

        public string City { get; set; }
    }
}
