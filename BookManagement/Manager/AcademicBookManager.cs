using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Manager
{
    public class AcademicBookManager : IBookManager
    {
        public decimal GetDiscount()
        {
            double discount = .4;
            return (decimal)discount;
        }

        public decimal GetPrice()
        {
            double price = 350;
            return (decimal)price;
        }
    }
}
