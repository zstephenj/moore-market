using System.Collections.Generic;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using MooreMarket.Data;

namespace MooreMarket.Models
{
    public enum AccountType
    {
        Farmer,
        User
    }
  public class UserModel
    {
        public string Username { get; set; }
        public int ID { get; set; }
        public string Password { get; set; }
        private string salt;
        public AccountType AccountType { get; set; } = AccountType.User;

        public IList<Product> Products { get; set; }

        public UserModel() 
        {
            salt = Hash.MakeSalt(); 
        }
        public UserModel(string username, string password)
            :this()
        {
            Username = username;
            Password = Hash.CreateHash(password, salt);
        }
    }
}
