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
                Name = "SNELLENTE",
                Category = CategoryEnum.Cosmetic,
                Price = 13.99m
            },
            new Product() { Code = "P05", Name = "RELAX", Category = CategoryEnum.Tea, Price = 5.99m},
            new Product() { Code = "T10", Name = "ENERGY MIX", Category = CategoryEnum.Supplement, Price = 7.99M}
        };

        internal static Product GetByCode(string code)
        {
            foreach (Product p in products)
            {
                if (p.Code == code)
                {
                    return p;
                }
            }

            return null;
        }

        internal static bool AddProduct(Product newProduct)
        {
            if (newProduct != null) //controllo dell'input al metodo
            {
                products.Add(newProduct);
                return true;
            }

            return false;
        }

        internal static List<Product> FetchProducts(decimal minPrice, decimal maxPrice)
        {
            List<Product> filteredProducts = new List<Product>();

            foreach (Product p in products)
            {
                if (p.Price >= minPrice && p.Price <= maxPrice)
                {
                    filteredProducts.Add(p);
                }
            }

            return filteredProducts;
        }

        internal static bool Delete(Product p)
        {
            if (p != null) //controllo dell'input al metodo
            {
                return products.Remove(p);
            }

            return false;
        }
    }
}
