using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldDomination.Models
{
    public class CityDataModel
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int Progress { get; set; }
        public int LifeLevel { get; set; }
        public int Income { get; set; }
    }
    public class CountryDataModel
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int Budget { get; set; }
        public int LifeLevel { get; set; }
        public List<CityDataModel> Cities { get; set; }
        public List<string> Sanctions { get; set; }
    }
}