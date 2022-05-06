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
            return DBMysql.GetCitiesInfo(int.Parse(cookie[cookie.Length - 1].ToString()));
        }

        public Models.CountryDataModel UpdateCountryData(string cookie)
        {
            List<Models.CityDataModel> CitiesModel = UpdateCities(cookie);

            Models.CountryDataModel CountryModel = DBMysql.GetCountryInfo(int.Parse(cookie[cookie.Length - 1].ToString()));
            CountryModel.Cities = CitiesModel;
            return CountryModel;
        }

        public List<Models.OtherCountry> OtherCountriesData(string cookie)
        {
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