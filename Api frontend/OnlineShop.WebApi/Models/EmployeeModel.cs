namespace OnlineShop.WebApi.Models
{
    public class EmployeeModel
    {
        public EmployeeModel()
        {

        }
        public EmployeeModel(int id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public EmployeeModel(string firstName, string lastName, int employmentNumber, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            EmploymentNumber = employmentNumber;
            Email = email;
        }

        public EmployeeModel(int id, string firstName, string lastName, int employmentNumber, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            EmploymentNumber = employmentNumber;
            Email = email;
        }

        public EmployeeModel(int id, string firstName, string lastName, int employmentNumber, string email, string password)
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
