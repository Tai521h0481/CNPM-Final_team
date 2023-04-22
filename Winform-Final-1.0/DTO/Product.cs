using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    /*CREATE TABLE Product(
    product_id INTEGER PRIMARY KEY,
    product_name TEXT NOT NULL,
    product_description TEXT,
    price REAL NOT NULL
);*/
    public class Product
    {
        // create class Product
        
        public int product_id { get; set; }
        public string product_name { get; set; }
        public string product_description { get; set; }
        public float price { get; set; }
        public Product(int id, string name, string des, float price)
        {
            product_description= des;
            product_id = id;
            product_name = name;
            this.price = price;
        }
    }
}
