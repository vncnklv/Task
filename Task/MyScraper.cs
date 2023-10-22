using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class MyScraper
    {
        public List<Product> GetProductsFromFile(string filePath)
        {
            try
            {
                HtmlDocument doc = new HtmlDocument();
                doc.Load(filePath);

                return GetProducts(doc);
            }
            catch
            {
                return null;
            }
        }

        public List<Product> GetProductsFromUrl(string url)
        {
            try
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load(url);

                return GetProducts(doc);
            }
            catch
            {
                return null;
            }
        }

        private List<Product> GetProducts(HtmlDocument doc)
        {
            List<Product> products = new List<Product>();

            var nodes = doc.DocumentNode.SelectNodes("/html/body/div");

            foreach (var node in nodes)
            {
                string rating = node.Attributes["rating"].Value;

                string name = node.SelectSingleNode("div[contains(@class, item-detail)]/h4/a").InnerText;

                string dollars = node.SelectSingleNode("div[contains(@class, item-detail)]/div[contains(@class, pricing)]/p/span/span[2]").InnerText;
                string cents = node.SelectSingleNode("div[contains(@class, item-detail)]/div[contains(@class, pricing)]/p/span/span[3]").InnerText;
                string price = dollars + cents;

                products.Add(new Product(name, price, rating));

            }

            return products;
        }
    }
}
