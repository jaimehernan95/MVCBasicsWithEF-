using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCBasicsWithEF.Data;
using MVCBasicsWithEF.Models;

namespace MVCBasicsWithEF.Controllers
{
    public class GamesController : Controller
    {
        private readonly EFContext _context;
        public GamesController(EFContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Games.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Title,Year")]Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Add(game);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(game);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            Game game = _context.Games.Where(g => g.Id == id).FirstOrDefault();
            if (game == null)
                return NotFound();

            return View(game);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            Game game = _context.Games.Where(g => g.Id == id).FirstOrDefault();
            if (game == null)
                return NotFound();

            return View(game);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,Title,Year")] Game game)
        {
            if (id != game.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                _context.Update(game);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(game);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            Game game = _context.Games.Where(g => g.Id == id).FirstOrDefault();
            if (game == null)
                return NotFound();

            return View(game);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Game game = _context.Games.Where(g => g.Id == id).FirstOrDefault();
            _context.Remove(game);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
