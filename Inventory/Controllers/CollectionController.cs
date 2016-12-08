using Inventory.Models;
using Inventory.Models.Abstract;
using Inventory.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory.Controllers
{
    public class CollectionController : Controller
    {

        public CollectionController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public CollectionController() : this(new BookRepository()) {
        }

        private ApplicationDbContext db = new ApplicationDbContext();
        private IBookRepository bookRepository;
        // GET: Collection
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(bookRepository.GetAll());
        }
    }
}