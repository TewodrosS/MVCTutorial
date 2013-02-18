using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQuerableIEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            // create and populate ShoppingCart
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product> 
                {
                    new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                    new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
                    new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                    new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
                }
            };

            // create and populate an array of Product objects
            Product[] productArray =
            {
                new Product {Name = "Kayak", Price = 275M},
                new Product {Name = "Lifejacket", Price = 48.95M},
                new Product {Name = "Soccer ball", Price = 19.50M},
                new Product {Name = "Corner flag", Price = 34.95M}
            };

            // get the total value of the products in the cart
            decimal cartTotal = products.TotalPrices();
            decimal arrayTotal = products.TotalPrices();
            Console.WriteLine("Cart Total: {0:c}", cartTotal);
            Console.WriteLine("Array Total: {0:c}", arrayTotal);

            Console.WriteLine(products.FilterByCategory("Soccer").TotalPrices());

            Func<Product, bool> catagoryFilter = delegate(Product prod)
            {
                return prod.Category == "Soccer";
            };

            Console.WriteLine(products.Filter(catagoryFilter).TotalPrices());


            foreach (Product prod in products.Filter(catagoryFilter))
            {
                Console.WriteLine("Name: {0}, Price: {1:c}", prod.Name, prod.Price);
            }

            Func<Product, bool> lambdaFilter = prod => prod.Category == "Soccer";
            foreach (Product prod in products.Filter(lambdaFilter))
            {
                Console.WriteLine("Name: {0}, Price: {1:c}", prod.Name, prod.Price);
            }

            IEnumerable<Product> filteredProducts = products.Filter(prod => prod.Category == "Soccer");

        }
    }
}
