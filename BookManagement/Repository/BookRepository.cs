using BookManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Repository
{
    public class BookRepository : IBookRepository
    {
        private List<Bk> booklist;
        public BookRepository()
        {
            booklist = new List<Bk>()
            {
                new Bk() {Id=1,BookName="Chronicles of Celestia",AuthorName="Aurora Skyborne",Language="English",Booktype=BoT.General,Genre=BookGenres.Adventure},
                new Bk() {Id=2,BookName="Cipher of Shadows",AuthorName="Victor Nocturne",Language="Spanish",Booktype=BoT.General,Genre=BookGenres.Mystery},
                new Bk() {Id=3,BookName="The Interpretation of Dreams",AuthorName="Sigmund Freud  ",Language= "German",Booktype= BoT.Academic,Genre= BookGenres.Fiction},
                new Bk() {Id=4,BookName="Moby-Dick",AuthorName="Herman Melville",Language="English",Booktype =BoT.Academic, Genre=BookGenres.Adventure}
            };
        }
        public Bk AddBook(Bk book)
        {
            Bk newBook = ((from m in booklist orderby m.Id descending select m).Take(1)).Single() as Bk;
            book.Id = newBook.Id + 1;
            booklist.Add(book);
            return book;
        }

        public Bk DeleteBook(int id)
        {
            Bk deleteBook = GetBook(id);
            if (deleteBook != null)
            {
                booklist.Remove(deleteBook);
            }
            return deleteBook;
        }

        public IEnumerable<Bk> GetAllBooks()
        {
            return from rows in booklist select rows;
        }

        public Bk GetBook(int id)
        {
            var books = (from e in booklist where e.Id == id select e).Single();
            return books;
        }

        public Bk UpdateBook(Bk updateBook)
        {
            Bk book = GetBook(updateBook.Id);
            if (book != null)
            {
                book.Id = updateBook.Id;
                book.BookName = updateBook.BookName;
                book.AuthorName= updateBook.AuthorName;
                book.Language= updateBook.Language;
                book.Booktype= updateBook.Booktype;
                book.Genre= updateBook.Genre;
            }
            return book;
        }
    }
}
