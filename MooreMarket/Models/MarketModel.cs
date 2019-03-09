using System.Collections.Generic;
using MooreMarket.Data;

namespace MooreMarket.Models
{
    public class Market
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Address {get;set;}

        public float Lat {get;set;}

        public float Lng {get;set;}
        public string Url {get;set;}
        public IList<UserModel> Users {get;set;}
        public Market()
        {

        }
        public Market(string name, string address, float lat, float lng, string url)
        {
            Name = name;
            Address = address;
            Lat = lat;
            Lng = lng;
            Url = url;
        }


    }
}