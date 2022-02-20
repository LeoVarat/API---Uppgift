namespace OnlineShop.WebApi.Models
{
    public class EmployeeCreateModel
    {
        public EmployeeCreateModel(string firstName, string lastName, int employmentNumber, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            EmploymentNumber = employmentNumber;
            Email = email;
            Password = password;
        }

        public EmployeeCreateModel(int id, string firstName, string lastName, int employmentNumber, string email, string password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            EmploymentNumber = employmentNumber;
            Email = email;
            Password = password;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmploymentNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
