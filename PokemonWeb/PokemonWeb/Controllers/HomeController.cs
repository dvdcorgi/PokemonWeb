using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokemonWeb.Controllers
{
    public class HomeController : Controller
    {
        DBPokemonEntities db = new DBPokemonEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Pokemon()
        {
            List<tblPokemon> pokemonList = (from a in db.tblPokemons
                                            select a).ToList();

            //Swiggity swoot

            return View(pokemonList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}