using Inventory.Models;
using Inventory.Models.Abstract;
using Inventory.Models.Entity;
using Inventory.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Inventory.Controllers
{
    public class BookController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private IBookRepository bookRepository;
        //private object db;

        public BookController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public BookController() : this(new BookRepository()) {
        }




        // Find(int id)
        public BookModel Find(int? id)
        {
            BookModel book = bookRepository.Find(id);
            return book;
        }

        //[AllowAnonymous]
        //public ActionResult Index()
        //{

        //    return View(bookRepository.GetAll());
        //}

        [AllowAnonymous]
        public ActionResult Index(string search = "")
        {
            //JsonResult
            //return data as Json (api)
            //return Json(studentRepo.GetAll(), JsonRequestBehavior.AllowGet);

            var results = bookRepository.GetAll();
            if (!String.IsNullOrEmpty(search))
            {
                var searchedNames = from s in results
                                    where s.Title.ToLower()
                                        .Contains(search.ToLower()) ||
                                        s.Rating.Contains(search)
                                      
                                        
                                    select s;

                results = searchedNames;
            }

            return View(results.ToList());



            
        }



        // Create view 
        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        // HTTP Post: create new student to ORM DB
        [HttpPost]
        public ActionResult Create(BookModel book)
        {

            if (ModelState.IsValid)
            {
                //then I want to save the student object
                bookRepository.InsertOrUpdate(book);
                //CreateImage();

                return RedirectToAction("Index");
            }
            return View();

        }

        // - Get student from the db
        // - view - fields
        // edit action method
        // validtion
        [HttpGet]
        // int? just tells the int it can be null
        public ActionResult Edit(int? id)
        {
            // if no id is found
            if (id == null)
            {
                return new HttpNotFoundResult();
            }

            BookModel book = bookRepository.Find(id);
            // if the student is not found in the ORM

            if (book == null)
            {
                return new HttpNotFoundResult();
            }
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(BookModel book)
        {
            if (ModelState.IsValid)
            {
                // How to update sql statement
                bookRepository.InsertOrUpdate(book);
                return RedirectToAction("Index");
            }
            return View("Thanks for Editing the book");
        }

        // // Make the Delete function
        // [HttpPost]
        // public ActionResult Delete(BookModel book)
        // {
        //     if (book == null)
        //     {
        //         return new HttpNotFoundResult();
        //     }

        //     bookRepository.Delete(book);

        //     return RedirectToAction("Index");
        //}
        // GET: /Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookModel book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: /Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookModel book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
    
