using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCcore.Web.Marty.Data;
using MVCcore.Web.Marty.Models;

namespace MVCcore.Web.Marty.Controllers
{
    public class CategoryController : Controller
    {
        // Utilisation de la dependency Injection
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> cat = _db.Category;
            return View(cat);
        }

        // GET - CREATE
        public IActionResult Create()
        {
            return View();
        }


        // POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid) // Ajouté pour gerer le [Required] du model
            {
                _db.Category.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj); // Si saisie mauvaise on retourne au formulaire avec les données saisie
        }

        // GET - EDIT
        public IActionResult Edit(int? id)
        {   
            if(id==null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid) // Ajouté pour gerer le [Required] du model
            {
                _db.Category.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj); // Si saisie mauvaise on retourne au formulaire avec les données saisie
        }

        // GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id) // Remarque le nom de la méthode Delete est DeletePost car même arg que ci-dessus
        {
            var obj = _db.Category.Find(id);
            if (obj == null) // Vérifie que la clé Id existe
            {
                return NotFound();
            }
            _db.Category.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
