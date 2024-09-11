using BookManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Repository
{
    public interface IBookRepository
    {
        IEnumerable<Bk>GetAllBooks();
        Bk GetBook(int id);
        Bk AddBook(Bk book);
        Bk UpdateBook(Bk book);
        Bk DeleteBook(int id);
    }
}
