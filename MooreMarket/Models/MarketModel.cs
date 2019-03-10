using System.Collections.Generic;
using MooreMarket.Data;

namespace MooreMarket.Models
{
    public class Market
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Address {get;set;}

        public double Lat {get;set;}

        public double Lng {get;set;}
        public string Url {get;set;}
        public IList<UserMarket> UserMarkets {get;set;}
        public IList<VendorMarket> VendorMarkets {get;set;}
        public Market()
        {

        }
        public Market(string name, string address, double lat, double lng, string url)
        {
            Name = name;
            Address = address;
            Lat = lat;
            Lng = lng;
            Url = url;
        }


    }
}