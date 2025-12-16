namespace MomentozWebClient.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobilePhone { get; set; }
        public string? Email { get; set; }
        public string? StreetName { get; set; }
        public string? Zipcode { get; set; }

        public string? LoginUserId { get; set; }

        public Customer(int id, string? firstName, string? lastName, string? mobilePhone, string? email, string? street, string? zipcode) 
        {
            CustomerID = id;
            FirstName = firstName;
            LastName = lastName;
            MobilePhone = mobilePhone;
            Email = email;
            StreetName = street;
            Zipcode = zipcode;
        }

        public Customer(int id, string? firstName, string? lastName, string? mobilePhone, string? email, string? street, string? zipcode, string? loginUserId)
        {
            CustomerID = id;
            FirstName = firstName;
            LastName = lastName;
            MobilePhone = mobilePhone;
            Email = email;
            StreetName = street;
            Zipcode = zipcode;
            LoginUserId = loginUserId;
        }
        public Customer(string? firstName, string? lastName, string? mobilePhone, string? email, string? street, string? zipcode, string? loginUserId)
        {
            FirstName = firstName;
            LastName = lastName;
            MobilePhone = mobilePhone;
            Email = email;
            StreetName = street;
            Zipcode = zipcode;
            LoginUserId = loginUserId;
        }

        public Customer()
        {
        }
        public Customer(IFormCollection form)
        {
            FirstName = form["FirstName"];
            LastName = form["LastName"];
            MobilePhone = form["MobilePhone"];
            LoginUserId = form["LoginUserId"];
            StreetName = form["StreetName"];
            Zipcode = form["Zipcode"];
        }


        public Customer(string? inEmail, string? inLoginUserId)
        {
            Email = inEmail;
            LoginUserId = inLoginUserId;
        }
    }
}
