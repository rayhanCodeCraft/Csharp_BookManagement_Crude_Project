using BookManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Factory
{
    public class BookManagerFactory
    {
        public BaseBookFactory CreateFactory(Bk book)
        {
            BaseBookFactory returnValue = null;
            if (book.Booktype == BoT.Academic)
            {
                returnValue = new AcademicBookFactory(book);
            }
            else if (book.Booktype == BoT.General)
            {
                returnValue = new GeneralBookFactory(book);
            }
            return returnValue;
        }
    }
}
