using AttributeLib;
namespace POCO
{
    [@Table(Name = "users")]
    public class User
    {
        private int userid;
        private string email;
        private string password;

        public User()
        {
        }

        public User(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        [@Column(Name = "userid", Datatype = "INT", Key = "PRIMARY KEY", Increment = "IDENTITY(1,1)")]
        public int Userid { get => userid; set => userid = value; }

        [@Column(Name = "email", Datatype = "VARCHAR(100)")]
        public string Email { get => email; set => email = value; }

        [@Column(Name = "password", Datatype = "VARCHAR(100)")]
        public string Password { get => password; set => password = value; }

        public override string ToString()
        {
            return $"{{{nameof(Userid)}={Userid.ToString()}, {nameof(Email)}={Email}}}";
        }
    }
}
