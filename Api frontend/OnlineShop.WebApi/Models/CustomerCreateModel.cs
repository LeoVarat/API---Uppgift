namespace OnlineShop.WebApi.Models
{
    public class CustomerCreateModel
    {
        public CustomerCreateModel()
        {

        }

        public CustomerCreateModel(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public CustomerCreateModel(string firstName, string lastName, string email, int adressId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            AdressId = adressId;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int AdressId { get; set; }

    }
}
