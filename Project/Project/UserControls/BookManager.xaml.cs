using Project.DAO;
using Project.Models;
using Project.View;
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
        private readonly SupplierDAO supplierDAO;
        private ObservableCollection<Book> books;
        private bool isAscendingSort = true;



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
            tbTotal.Text = "Số lượng sản phẩm có trong cửa hàng : " + totalQuantity.ToString();
        }
        private void FilterEmployeeData(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                lvSanPham.ItemsSource = books;

            }
            else
            {
                var filteredBooks = books.Where(x => x.Title.Contains(searchTerm)).ToList();
                lvSanPham.ItemsSource = filteredBooks;
            }
        }
        private void txbTimKiem_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchTerm = txbTimKiem.Text;
            FilterEmployeeData(searchTerm);
        }
        private void SortByQuantity()
        {
            if (isAscendingSort)
            {
                var sortedBooks = books.OrderBy(book => book.Quantity).ToList();
                lvSanPham.ItemsSource = sortedBooks;
            }
            else
            {
                var sortedBooks = books.OrderByDescending(book => book.Quantity).ToList();
                lvSanPham.ItemsSource = sortedBooks;
            }
            isAscendingSort = !isAscendingSort;
        }

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            SortByQuantity();

        }
        public void CreateBook(ObservableCollection<Book> books)
        {
            PRN221_Project_HE153685Context context = new PRN221_Project_HE153685Context();
            try
            {
                context.Books.AddRange(books);
            }
            catch (Exception ex)
            {

            }

        }

        private void btnThemHoaDon_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            if (order != null)
            {
                order.selectData = new Order.SelectData(CreateBook);
                order.ShowDialog();
                loadBookData();
            }
        }
    }
}
 
