using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldDomination.Models
{
    public class CityDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Progress { get; set; }
        public int LifeLevel { get; set; }
        public int Income { get; set; }
    }
    public class CountryDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Budget { get; set; }
        public int LifeLevel { get; set; }
        public List<CityDataModel> Cities { get; set; }
        public bool Nuclear { get; set; }
        //public List<string> Sanctions { get; set; }
    }

    public class OtherCountry
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class GameModel
    {
        public CountryDataModel Country { get; set; }
        public List<OtherCountry> OtherCountries { get; set; }
    }
}