﻿using BookManagement.Entities;
using BookManagement.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Factory
{
    public class GeneralBookFactory : BaseBookFactory
    {
        public GeneralBookFactory(Bk book) : base(book)
        {
        }

        public override IBookManager Create()
        {
            GeneralBookManager manager = new GeneralBookManager();
            _book.Price = manager.GetPrice();
            _book.Discount = manager.GetDiscount();
            return manager;
        }
    }
}
