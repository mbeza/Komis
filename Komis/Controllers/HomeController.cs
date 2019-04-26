using Komis.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Komis.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISamochodRepository _samochodRepository;

        public HomeController(ISamochodRepository samochodRepository)
        {
            _samochodRepository = samochodRepository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Tytul = "Przegląd Samochodów"; //dynamiczna zmienna, z okreslona wlasciwoscia tytuł

            var samochody = _samochodRepository.PobierzWszystkieSamochody().OrderBy(s => s.Marka); //pobieranie wszystkich samochodow i posortowanie po marce
            return View(samochody); //przekazanie do widoku 
        }
    }
}
