using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiKiemTra
{
    internal class Product
    {
        public string Name  {  get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Image image { get; set; }
        public Product(string Name, decimal Price, int Quantity,Image image)
        {
            this.Name = Name;
            this.Price = Price;
            this.Quantity = Quantity;
            this.image = image;
        }  
    }
   
}
