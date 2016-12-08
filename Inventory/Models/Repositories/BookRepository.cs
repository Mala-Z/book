using Inventory.Models.Abstract;
using Inventory.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory.Models.Repositories
{
    public class BookRepository : IBookRepository
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        //public BookModel Delete(BookModel book)
        //{
        //    //todo

        //    //var book = db.Books.FirstOrDefault(b => b.BookModelId == id);
        //    //if (book != null)
        //    //{
        //    //    db.Books.Remove(book);
        //    //}
        //    //return true;
        //    return db.Books.Remove(book);
        //    //return true;

        //}

        public BookModel Find(int? id)
        {
            return db.Books.Find(id);
        }

        public IEnumerable<BookModel> GetAll()
        {
            return db.Books.ToList();
        }

        public void InsertOrUpdate(BookModel book)
        {
            if (book.BookModelId <= 0)
            {
                db.Books.Add(book);
            }
            else
            {
                db.Entry(book).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
        }
    }
}