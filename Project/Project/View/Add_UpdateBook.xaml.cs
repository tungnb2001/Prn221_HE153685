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
using System.Windows.Shapes;

namespace Project.View
{
    /// <summary>
    /// Interaction logic for Add_UpdateBook.xaml
    /// </summary>
    public partial class Add_UpdateBook : Window
    {

        public delegate void CRUD(Book book);

        public CRUD addBook;
        public CRUD updateBook;
        public CRUD books;
        private string bookId;

        private SupplierDAO supplierDAO;
        public Add_UpdateBook()
        {
            InitializeComponent();
            supplierDAO = new SupplierDAO();
            books = new CRUD(getData);

            LoadSuppliers();
        }
        private void LoadSuppliers()
        {
            ObservableCollection<Supplier> suppliers = supplierDAO.loadAllSupplier(); 
            cbSuplier.ItemsSource = suppliers;
            cbSuplier.DisplayMemberPath = "SupplierName";
            cbSuplier.SelectedValuePath = "SupplierId";
            
        }

        public void getData(Book book1)
        {
            txbTitle.Text = "Update Book";
            bookId = book1.BookId.ToString();
            txbTitleBook.Text = book1.Title;
            txtPrice.Text = book1.Price.ToString();
            txtQuantity.Text = book1.Quantity.ToString();
            cbSuplier.SelectedValue = book1.SupplierId;

          
        }
        private bool checkValidInformation()
        {
            if (string.IsNullOrWhiteSpace(txbTitleBook.Text))
            {
                txbTitleBook.Focus();
                new DialogCustoms("Nhập tiêu đề!", "Thông báo", DialogCustoms.OK).ShowDialog();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                txtQuantity.Focus();
                new DialogCustoms("Nhập số lượng !", "Thông báo", DialogCustoms.OK).ShowDialog();
                return false;
            }
            else
            {
                if (!int.TryParse(txtQuantity.Text, out int quantity))
                {
                    txtQuantity.Focus();
                    new DialogCustoms("Nhập số lượng đúng định dạng số !", "Thông báo", DialogCustoms.OK).ShowDialog();
                    return false;
                }
              
            }

            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                txtPrice.Focus();
                new DialogCustoms("Nhập giá!", "Thông báo", DialogCustoms.OK).ShowDialog();
                return false;
            }
            else
            {
                if (!decimal.TryParse(txtPrice.Text, out decimal price))
                {
                    txtPrice.Focus();
                    new DialogCustoms("Nhập giá đúng định dạng số !", "Thông báo", DialogCustoms.OK).ShowDialog();
                    return false;
                }

            }

            return true;

        }
        private void btnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            if (checkValidInformation())
            {
                int selectedSupplierId = (int)cbSuplier.SelectedValue;
                Book updBook = new Book()
                {
                    BookId = int.Parse(bookId),
                    SupplierId = selectedSupplierId,
                    Title = txbTitleBook.Text,
                    Quantity = int.Parse(txtQuantity.Text),
                    Price = decimal.Parse(txtPrice.Text)
                };
                if (updateBook != null)
                {
                    updateBook(updBook);
                }
                this.Close();
            }
            
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            Window wd = Window.GetWindow(sender as Button);
            wd.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (checkValidInformation())
            {
                int selectedSupplierId = (int)cbSuplier.SelectedValue;
                Book createBook = new Book()
                {
                    SupplierId = selectedSupplierId,
                    Title = txbTitleBook.Text,
                    Quantity = int.Parse(txtQuantity.Text),
                    Price = decimal.Parse(txtPrice.Text)
                };
                if (addBook != null)
                {
                    if(createBook.Title != null)
                    {
                        new DialogCustoms("Đã có sản phẩm này trong cửa hàng !", "Thông báo", DialogCustoms.OK).ShowDialog();
                    }
                    else
                    {
                        addBook(createBook);
                    }
                }
                this.Close();
            }

        }
    }
}
