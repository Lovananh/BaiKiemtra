using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace BaiKiemTra
{
    public partial class Form1 : Form
    {
        private ShoppingCart cart;
        private List<Product> productList;
        private Product selectedProduct;
        public Form1()
        {
            InitializeComponent();
             cart = new ShoppingCart();
            Khosanpham();
            Luutru();
            CapNhap();
        }
        public void Khosanpham ()
        {
            productList = new List<Product>
            {
                new Product("Laptop", 1500m, 1),
                new Product("Smartphone", 800m, 2),
                new Product("Tablet", 500m, 1)
            };
        }
        public void Luutru()
        {
            // Gán danh sách sản phẩm vào DataGridView danh sách sản phẩm
            dataGridView2.DataSource = productList;

            dataGridView2.Columns["Quantity"].Visible = true;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;
        }
        public void CapNhap()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {


        }
        private void btnThemvaogiohang_Click(object sender, EventArgs e)
        {
            if (selectedProduct != null)
            {
                cart.AddToCart(selectedProduct);


                dataGridView1.DataSource = null;
                dataGridView1.DataSource = cart.CartItems;

                // Cập nhật tổng giá trị trong giỏ hàng
                txtTong.Text = $"{cart.CartItems.Sum(item => item.GetTotalPrice()):C}";
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm từ danh sách.");
            }
        }

        // Cập nhật lại DataGridView1 để hiển thị danh sách mới

    private void UpdateDataGridView1()
    {
        // Xóa tất cả các dòng trong DataGridView1
        dataGridView1.Rows.Clear();

        // Duyệt qua CartItems và thêm từng sản phẩm vào DataGridView1
        foreach (var item in cart.CartItems)
        {
            dataGridView1.Rows.Add(item.Name, item.Quantity, item.Price); // Thêm các cột phù hợp
        }
    }

    private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedItem = (Product)dataGridView1.SelectedRows[0].DataBoundItem;
                cart.RemoveProduct(selectedItem.Name);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = cart.CartItems;

                // Cập nhật tổng giá trị trong giỏ hàng
                txtTong.Text = $"{cart.CartItems.Sum(item => item.GetTotalPrice()):C}";
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm trong giỏ hàng để xóa.");
            }
        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            decimal totalAmount = cart.Checkout();
            MessageBox.Show($"Đơn hàng đã được thanh toán. Tổng giá trị: {totalAmount:C}", "Thanh toán thành công");

            // Làm mới giỏ hàng sau khi thanh toán
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = cart.CartItems;
            txtTong.Text = $"{cart.CartItems.Sum(item => item.GetTotalPrice()):C}";

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //dataGridView1.DataSource = null;
            //dataGridView1.DataSource = cart.Products;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                selectedProduct = (Product)dataGridView2.SelectedRows[0].DataBoundItem;
            }
        }
    }
}
