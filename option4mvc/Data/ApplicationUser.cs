using Microsoft.AspNetCore.Identity; //this is an existing framework we initialized our project with

namespace option4mvc.Data
{
    //ApplicationUser inherits the default properties of the IdentityUser class in the existing framework.
    //Below, applicationUser is being assigned additional properties to suit the purpose of our application.
    //These properties will be associated with all user accounts and can used to organize user information in the database.
    public class ApplicationUser : IdentityUser
    {
        //the IdentitiyUser parent class already contains the following properties: username, password, email, phone number
        public string? Name { get; set; }
        public string? Birthday { get; set; }
        public string? ProfilePicture {get; set; }
        public int AvailableRewardsPoints { get; set; } = 0; //initial value of 0
        public double AvailableStoreCredit {get; set;} = 0.00; //initial value of 0.00
    }
}
