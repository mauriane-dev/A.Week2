using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Erboristeria2
{
    internal class Product
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public CategoryEnum Category { get; set; }  
    }

    internal enum CategoryEnum
    {
        Cosmetic = 1,
        Tea = 2,
        Supplement = 3
    }
}
