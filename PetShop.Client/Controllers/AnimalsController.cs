#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetShop.Data.Contexts;
using PetShop.Data.Model;
using PetShop.Service;

namespace PetShop.Client.Controllers
{ //var Top2List = _context.Animals.FromSqlRaw("select top 2 AnimalID, count(AnimalID)'comments'from Comment group by AnimalID order by comments desc").ToList();
    public class AnimalsController : Controller
    {
        private readonly IAnimalService animalService;
        private readonly ICategoryService categoryService;
        private readonly ICommentService commentService;

        public AnimalsController(IAnimalService animalService,ICategoryService categoryService, ICommentService commentService)
        {
            this.animalService = animalService;
            this.categoryService = categoryService;
            this.commentService = commentService;
        }

        // GET: Animals
        public async Task<IActionResult> Index()
        {
            var animals = animalService.GetAll();
            return View(animalService.GetAll());
        }

        // GET: Animals/Details/5
        public async Task<IActionResult> Details(AnimalCommentViewModel model, int? id)
        {
            model.animal = animalService.Get(id);
            //if (model.animal.AnimalId == null)
            //{
            //    return NotFound();
            //}
            //var animal = animalService.Get(model.animal.AnimalId);
            //ViewBag.comments = animal.Comments;
            /*var animal = await _context.Animals
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.AnimalId == id);*/
            ViewBag.Comments = this.commentService.GetAnimalComments(id);
            var comments = this.commentService.GetAnimalComments(id);
            if (model.animal == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // GET: Animals/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(categoryService.GetAllcategory(), "CategoryId", "Name");
            return View();
        }

        // POST: Animals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnimalId,Name,Description,BirthDate,PhotoUrl,CategoryId")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                animalService.Add(animal);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(categoryService.GetAllcategory(), "CategoryId", "Name", animal.CategoryId);
            return View(animal);
        }

        // GET: Animals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = /*await*/ animalService.Get(id);     //_context.Animals.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(categoryService.GetAllcategory(), "CategoryId", "Name", animal.CategoryId);
            return View(animal);
        }

        // POST: Animals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnimalId,Name,Description,BirthDate,PhotoUrl,CategoryId")] Animal animal)
        {
            if (id != animal.AnimalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    animalService.Update(animal);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalExists(animal.AnimalId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(categoryService.GetAllcategory(), "CategoryId", "Name", animal.CategoryId);
            return View(animal);
        }

        
        // GET: Animals/Delete/5
        public async Task<IActionResult> Delete(int id) ////******??????
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await animalService.GetAll()
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.AnimalId == id);
            if (animal == null)
            {
                return NotFound();
            }
           
            return View(animal);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animal = /*await*/ animalService.Get(id);
            animalService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalExists(int id)
        {
            return animalService.GetAll().Any(e => e.AnimalId == id);
        }

        [HttpPost]
        public void Upload_Comment(int animalID, string comment)
        {
            commentService.AddComment(comment, animalID);
            Response.Redirect($"../Animals/Details/{animalID}");
            //RedirectToAction("Edit_Animal", new { animalId = animalID });
        }


    }
}
