using System.Collections.Generic;
using System.Web.Mvc;
using WorldDomination.Core;

namespace WorldDomination.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public void Index()
        {
            Update();
        }

        public List<Models.CityDataModel> UpdateCities(string cookie)
        {
            /*List<Dictionary<string, string>> cities = DBMysql.GetCitiesInfo(int.Parse(cookie[cookie.Length - 1].ToString()));
            List<CityDataModel> CitiesModel = new List<CityDataModel>();
            foreach (Dictionary<string, string> city in cities)
            {
                CitiesModel.Add(new CityDataModel
                {
                    Id = int.Parse(city["city_id"]),
                    Name = city["name_city"],
                    Progress = int.Parse(city["growth"]),
                    LifeLevel = int.Parse(city["life_level"]),
                    Income = int.Parse(city["income"])
                });
            }*/

            return DBMysql.GetCitiesInfo(int.Parse(cookie[cookie.Length - 1].ToString()));
        }

        public Models.CountryDataModel UpdateCountryData(string cookie)
        {
            List<Models.CityDataModel> CitiesModel = UpdateCities(cookie);

            Models.CountryDataModel CountryModel = DBMysql.GetCountryInfo(int.Parse(cookie[cookie.Length - 1].ToString()));
            CountryModel.Cities = CitiesModel;
            /*Dictionary<string, string> country = DBMysql.GetCountryInfo(int.Parse(cookie[cookie.Length - 1].ToString()));
            CountryDataModel CountryModel = new CountryDataModel
            {
                Id = int.Parse(country["country_id"]),
                Name = country["name_country"],
                Budget = int.Parse(country["budget"]),
                LifeLevel = int.Parse(country["life_level"]),
                Cities = CitiesModel,
                Nuclear = true ? country["nuclear"] == "1" : false
            };*/
            return CountryModel;
        }

        public List<Models.OtherCountry> OtherCountriesData(string cookie)
        {
            /*List<OtherCountry> OtherCountriesData = new List<OtherCountry>();
            List<Dictionary<string, string>> response = DBMysql.GetOtherCountriesInfo(int.Parse(cookie[cookie.Length - 1].ToString()));
            foreach (Dictionary<string, string> country in response)
            {
                OtherCountriesData.Add(new OtherCountry
                {
                    Id = int.Parse(country["country_id"]),
                    Name = country["name_country"]
                });
            }*/
            return DBMysql.GetOtherCountriesInfo(int.Parse(cookie[cookie.Length - 1].ToString()));
        }

        public ActionResult Update()
        {
            string cookie = Request.Cookies["CountryId"].Value;

            Models.CountryDataModel country = UpdateCountryData(cookie);
            List<Models.OtherCountry> otherCountries = OtherCountriesData(cookie);
            Models.GameModel Response = new Models.GameModel
            {
                Country = country,
                OtherCountries = otherCountries
            };
            return View("Index", Response);
        }
    }
}