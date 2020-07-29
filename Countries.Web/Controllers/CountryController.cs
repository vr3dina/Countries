using Countries.Database.Repositories;
using Domain;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Countries.Web.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View(_countryRepository.Get().ToList());
        }

        public ActionResult Search()
        {
            return View();
        }
        public ActionResult Details(string country)
        {
            var v = new CountryLoader().LoadInfo(country).Result;
            return View(v);
        }

        public ActionResult Save(CountryDisplayModel country)
        {
            _countryRepository.Create(country);
            return RedirectToAction("List");
        }

        public ActionResult Delete(long id)
        {
            _countryRepository.Delete(id);
            return RedirectToAction("List");
        }
    }
}
