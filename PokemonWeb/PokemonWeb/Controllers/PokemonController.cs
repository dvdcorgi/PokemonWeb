using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PokemonWeb;

namespace PokemonWeb.Controllers
{
    public class PokemonController : Controller
    {
        private DBPokemonEntities db = new DBPokemonEntities();

        // GET: Pokemon
        public ActionResult Index()
        {
            return View(db.tblPokemons.ToList());
        }

        // GET: Pokemon/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPokemon tblPokemon = db.tblPokemons.Find(id);
            if (tblPokemon == null)
            {
                return HttpNotFound();
            }
            return View(tblPokemon);
        }

        // GET: Pokemon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pokemon/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Pokemon,Type,HP,Description,UploadDate")] tblPokemon tblPokemon)
        {
            if (ModelState.IsValid)
            {
                db.tblPokemons.Add(tblPokemon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblPokemon);
        }

        // GET: Pokemon/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPokemon tblPokemon = db.tblPokemons.Find(id);
            if (tblPokemon == null)
            {
                return HttpNotFound();
            }
            return View(tblPokemon);
        }

        // POST: Pokemon/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Pokemon,Type,HP,Description,UploadDate")] tblPokemon tblPokemon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPokemon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblPokemon);
        }

        // GET: Pokemon/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPokemon tblPokemon = db.tblPokemons.Find(id);
            if (tblPokemon == null)
            {
                return HttpNotFound();
            }
            return View(tblPokemon);
        }

        // POST: Pokemon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tblPokemon tblPokemon = db.tblPokemons.Find(id);
            db.tblPokemons.Remove(tblPokemon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
