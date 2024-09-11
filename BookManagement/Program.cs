using BookManagement.Entities;
using BookManagement.Factory;
using BookManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement
{
    internal class Program
    {
        public static BookRepository repo = new BookRepository();
        static void Main(string[] args)
        {
			try
			{
                DoTask();
			}
			catch (Exception ex)
			{

                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }

        private static void DoTask()
        {
            Console.WriteLine("\t\t\t\t=====Project of BookShop=====\r");
            Console.WriteLine("\t\t\t\tName : Md.Rayhan Mia\r");
            Console.WriteLine("\t\t\t\tTraineeId : 1280382\r");
            Console.WriteLine("\t\t\t\t--------------------\n");
            Console.WriteLine("\t\tHow many operation would you like to perform?\n");
            int count = Convert.ToInt32(Console.ReadLine());
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine("\t\t\t\tSelect Operation\n");
                    Console.WriteLine("\t\tHint: \nSelect -1\nAdd    -2\nUpdate -3\nDelete -4");
                    int opeCount = Convert.ToInt32(Console.ReadLine());
                    switch (opeCount)
                    {
                        case 1: GetBook(null); break;
                        case 2: AddBook(); break;
                        case 3: UpdateBook(); break;
                        case 4: DeleteBook(); break;
                    }
                }
            }
        }

        private static void DeleteBook()
        {
            Console.WriteLine("Enter Your Id");
            int id=Convert.ToInt32(Console.ReadLine());
            Bk deleteBook = new Bk();
            deleteBook.Id = id;
            deleteBook = repo.GetBook(deleteBook.Id);

            Console.WriteLine("Book Deleted Successfully");
            GetBook(deleteBook);
        }

        private static void UpdateBook()
        {
            Console.WriteLine("Enter Your Id");
            int id = Convert.ToInt32(Console.ReadLine());
            Bk upBook = new Bk();
            upBook.Id = id;
            upBook.BookName = "Chronicles of Celestia";
            upBook.AuthorName = "Aurora Skyborne";
            upBook.Language = "English";
            upBook.Booktype = BoT.Academic;
            upBook.Booktype = BoT.General;
            upBook.Genre = BookGenres.Adventure;
            upBook = repo.UpdateBook(upBook);
            Console.WriteLine("Book Update Successfully");
            GetBook(upBook);
        }

        private static void AddBook()
        {
            Console.WriteLine("Enter Your Id");
            int id = Convert.ToInt32(Console.ReadLine());
            Bk book = new Bk(id, "Dreams of Stardust","Nova Celestia  ","French  ",BoT.General  ,BookGenres.Fiction  );
            book.Booktype = BoT.General;
            BaseBookFactory bookFactory = new BookManagerFactory().CreateFactory(book);
            bookFactory.PriceAndDiscount();
            repo.AddBook(book);
            Console.WriteLine("Book Add Successfully");
            GetBook(book);
        }

        private static void GetBook(Bk book)
        {
            IEnumerable<Bk> books = repo.GetAllBooks();
            Console.WriteLine(string.Format("|{0,5}| {1,35}| {2,-10}| {3,12}| {4,12}| {5,15}|", "ID", "BookName", "AuthorName     " ,"Language","BoT","Genre"));
            Console.WriteLine();
            if (book == null)
            {
                foreach (Bk item in books)
                {
                    Console.WriteLine(string.Format("|{0,5}| {1,35}| {2,-10}| {3,12}| {4,12}| {5,15}|",
                        item.Id, item.BookName, item.AuthorName, item.Language,item.Booktype,item.Genre));
                }
            }
            else
            {
                Console.WriteLine(string.Format("|{0,5}| {1,35}| {2,-10}| {3,12}| {4,12}| {5,15}|",
                    book.Id, book.BookName, book.AuthorName, book.Language,book.Booktype,book.Genre));
            }
            Console.WriteLine();
        }
    }
}
