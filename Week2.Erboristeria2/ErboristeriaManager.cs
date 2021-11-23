using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Erboristeria2
{
    internal class ErboristeriaManager
    {
        private static List<Product> products = new List<Product>()
        {
            new Product() 
            { 
                Code = "ABC",
                Name = "Snellente", 
                Category = CategoryEnum.Cosmetic, 
                Price = 13.99m 
            },
            new Product() { Code = "P05", Name = "Relax", Category = CategoryEnum.Tea, Price = 5.99m},
            new Product() { Code = "T10", Name = "Energy mix", Category = CategoryEnum.Supplement, Price = 7.99M}
        };



    }
}
