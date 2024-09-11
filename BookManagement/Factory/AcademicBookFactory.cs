using BookManagement.Entities;
using BookManagement.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Factory
{
    public class AcademicBookFactory : BaseBookFactory
    {
        Bk _book;
        public AcademicBookFactory(Bk book) : base(book)
        {
            _book = book;
        }

        public override IBookManager Create()
        {
            AcademicBookManager manager = new AcademicBookManager();
            _book.Price = manager.GetPrice();
            _book.Discount = manager.GetDiscount();
            return manager;
        }
    }
}
