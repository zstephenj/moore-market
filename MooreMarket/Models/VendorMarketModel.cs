using System.Collections.Generic;
using MooreMarket.Data;

namespace MooreMarket.Models
{
    public class VendorMarket
    {
        public int Id {get;set;}
        public int MarketId {get;set;}
        public Market Market {get;set;}
        public int VendorId {get;set;}
        public UserModel Vendor {get;set;}

    }
}