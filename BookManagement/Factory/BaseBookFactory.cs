using BookManagement.Entities;
using BookManagement.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Factory
{
    public abstract class BaseBookFactory
    {
        protected Bk _book;
        protected BaseBookFactory(Bk book)
        {
            _book = book;
        }
        public abstract IBookManager Create();
        public Bk PriceAndDiscount()
        {
            IBookManager manager = this.Create();
            _book.Price =manager.GetPrice();
            _book.Discount =manager.GetDiscount();
            return _book;
        }
    }
}
