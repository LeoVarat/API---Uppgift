namespace OnlineShop.WebApi.Models
{
    public class AdressCreateModel
    {
        public AdressCreateModel(string adress, int postalNumber, string city)
        {
            Adress = adress;
            PostalNumber = postalNumber;
            City = city;
        }

        public string Adress { get; set; }

        public int PostalNumber { get; set; }

        public string City { get; set; }
    }
}
