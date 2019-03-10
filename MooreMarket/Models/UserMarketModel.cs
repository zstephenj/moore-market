using System.Collections.Generic;
using MooreMarket.Data;

namespace MooreMarket.Models
{
    public class UserMarket
    {
        public int Id {get;set;}
        public int MarketId {get;set;}
        public Market Market {get;set;}
        public int UserId {get;set;}
        public UserModel User {get;set;}

    }
}