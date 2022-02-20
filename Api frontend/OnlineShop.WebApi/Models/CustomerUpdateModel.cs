namespace OnlineShop.WebApi.Models.Entities
{
    public class CustomerUpdateModel
    {
        public CustomerUpdateModel(int id, string firstName, string lastName, string email, int adressId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            AdressId = adressId;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int AdressId { get; set; }
    }
}
