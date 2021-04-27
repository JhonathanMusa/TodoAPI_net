using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Item> objList = _db.Item;
            return View(objList);
        }

        // GET - create 
        public IActionResult Create()
        {
            return View();
        }

        // POST - create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item obj) 
        {
            _db.Item.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET - Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Item.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST - delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {

            var obj = _db.Item.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Item.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GEt - update
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Item.Find(id);
            if (obj == null )
            {
                return NotFound();
            }


            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Item obj)
        {
            if (ModelState.IsValid)
            {
                _db.Item.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }
    }
}
