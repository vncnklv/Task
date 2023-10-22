using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class Product
    {
        public string productName { get; set; }
        public double price { get; set; }
        public double rating { get; set; }
        public Product(string name, string price, string rating)
        {
            this.productName = HtmlEntity.DeEntitize(name.Trim());
            this.price = double.Parse(price.Trim().Replace(",", "").Replace(".", ","));
            this.rating = double.Parse(rating.Trim().Replace(".", ","));

            if(this.rating > 5)
            {
                this.rating /= 2;
            }
        }

        

    }
}
