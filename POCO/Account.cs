using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AttributeLib;
namespace POCO
{
    [@Table(Name = "Account")]
    public class Account
    {
        private int accNumber;
        private string name;
        private string email;
        private string phone;
        private double balance;
        private int userid;

        public Account()
        {
        }

        public Account(int accNumber, string name, string email, string phone, double balance, int userid)
        {
            this.AccNumber = accNumber;
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
            this.Balance = balance;
            this.Userid = userid;
        }

        [@Column(Name = "accNumber", Datatype = "INT", Key = "PRIMARY KEY")]
        public int AccNumber { get => accNumber; set => accNumber = value; }

        [@Column(Name = "name", Datatype = "VARCHAR(100)")]
        public string Name { get => name; set => name = value; }

        [@Column(Name = "email", Datatype = "VARCHAR(100)")]
        public string Email { get => email; set => email = value; }

        [@Column(Name = "phone", Datatype = "VARCHAR(100)")]
        public string Phone { get => phone; set => phone = value; }

        [@Column(Name = "balance", Datatype = "FLOAT")]
        public double Balance { get => balance; set => balance = value; }

        [@Column(Name = "userid", Datatype = "INT", Key = "FOREIGN KEY REFERENCES", Linktotable = "users", Deletecascade = "ON DELETE CASCADE", Linktocolumn = "(userid)")]
        public int Userid { get => userid; set => userid = value; }

        public override string ToString()
        {
            return $"{{{nameof(AccNumber)}={AccNumber.ToString()}, {nameof(Name)}={Name}, {nameof(Email)}={Email}, {nameof(Phone)}={Phone.ToString()}, {nameof(Balance)}={Balance.ToString()}}}";
        }
    }
}
