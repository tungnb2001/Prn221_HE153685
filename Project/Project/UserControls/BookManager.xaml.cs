using Project.DAO;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project.UserControls
{
    /// <summary>
    /// Interaction logic for BookManager.xaml
    /// </summary>
    public partial class BookManager : UserControl
    {

        private readonly BookDAO bookDAO;
        private readonly  SupplierDAO supplierDAO;
        private ObservableCollection<Book> books;
        

        public BookManager()
        {
            InitializeComponent();
            bookDAO = new BookDAO();
            supplierDAO = new SupplierDAO();
            loadBookData();
            
        }

        private void loadBookData()
        {
            books = bookDAO.loadAllBook();
            foreach (var book in books)
            {
                Supplier supplier = supplierDAO.GetSupplierBySupplierId(book.SupplierId);
                if (supplier != null)
                {
                    book.Supplier = supplier;
                }
            }
            lvSanPham.ItemsSource = books;
            CalculateAndDisplayTotalQuantity();
        }

        private void CalculateAndDisplayTotalQuantity()
        {
            int totalQuantity = books.Sum(book => book.Quantity);
            tbTotal.Text = "Số lượng sản phẩm có trong cửa hàng : "+totalQuantity.ToString();
        }
    }
}
