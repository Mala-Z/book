using Inventory.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models.Abstract
{
    public interface IBookRepository
    {
        IEnumerable<BookModel> GetAll();
        BookModel Find(int? id);
        void InsertOrUpdate(BookModel book);
        //Boolean Delete(int? id);
        //void Delete(BookModel book);
    }
}

