using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            MyScraper scraper = new MyScraper();

            // Scraping from static file
            //string filePath = @"page1.html";
            //List<Product> products = scraper.GetProductsFromFile(filePath);

            // Scraping from web
            string url = "http://127.0.0.1:5500/page.html";
            List<Product> products = scraper.GetProductsFromUrl(url);

            if (products == null)
            {
                Console.WriteLine("Wrong file path or url!");
                Console.ReadLine();
                return;
            }

            foreach (Product product in products)
            {
                Console.WriteLine(" - - - Product - - - ");
                Console.WriteLine("1. " + product.productName);
                Console.WriteLine("2. " + product.price);
                Console.WriteLine("3. " + product.rating);
            }

            Console.WriteLine(" - - - JSON - - - ");

            string json = JsonConvert.SerializeObject(products, Formatting.Indented);
            Console.WriteLine(json);

            Console.ReadLine();
        }
    }

}
