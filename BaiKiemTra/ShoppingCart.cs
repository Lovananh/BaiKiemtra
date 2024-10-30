using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace BaiKiemTra
{

    internal class ShoppingCart
    {
        public List<Product> CartItems { get; private set; }

        public ShoppingCart()
        {
            CartItems = new List<Product>();
        }

        // Phương thức thêm sản phẩm vào giỏ hàng
        public void AddToCart(Product product)
        {
            var existingItem = CartItems.FirstOrDefault(p => p.Name == product.Name);
            if (existingItem != null)
            {
                existingItem.Quantity += product.Quantity;
            }
            else
            {
                CartItems.Add(product);
            }
        }

        // Phương thức xóa sản phẩm khỏi giỏ hàng
        public void RemoveProduct(string productName)
        {
            var itemToRemove = CartItems.FirstOrDefault(p => p.Name == productName);
            if (itemToRemove != null)
            {
                CartItems.Remove(itemToRemove);
            }
        }

        // Phương thức thanh toán
        public decimal Checkout()
        {
            decimal totalAmount = CartItems.Sum(item => item.Price * item.Quantity);
            CartItems.Clear();
            return totalAmount;
        }
    }
}
