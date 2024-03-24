using Project.DAO;
using Project.Models;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : Window
    {

        public delegate void SelectData(ObservableCollection<Book> book);

        public SelectData selectData;
        private readonly BookDAO bookDAO;
        private ObservableCollection<Book> books;
        private ObservableCollection<SelectedBookItem> selectedBooks;
        private SelectedBookItem selectedBookItem;
        private Book book1;
        

        public Order()
        {
            InitializeComponent();
            bookDAO = new BookDAO();
            selectedBooks = new ObservableCollection<SelectedBookItem>();
            books =new ObservableCollection<Book>();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            books = new ObservableCollection<Book>(bookDAO.loadAllBook());
            lvBook.ItemsSource = books;
            lvSelectBook.ItemsSource = selectedBooks;
        }

        private void click_Thoat(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedBook = (Book)((Button)sender).DataContext;
            book1 = selectedBook;
            var existingItem = selectedBooks.FirstOrDefault(item => item.Title == selectedBook.Title);
            if (existingItem != null)
            {
                existingItem.Quantity++;
                existingItem.TotalAmount = existingItem.Price * existingItem.Quantity;
            }
            else
            {
                var selectedItem = new SelectedBookItem()
                {
                    Title = selectedBook.Title,
                    Price = selectedBook.Price,
                    Quantity = 1, 
                    TotalAmount = selectedBook.Price  
                };

                selectedBooks.Add(selectedItem);
            }
        }

        private void txbSoLuong_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = (TextBox)sender;
            selectedBookItem = (SelectedBookItem)textBox.DataContext;
            int quantity = 1;
            if (!int.TryParse(textBox.Text, out quantity))
            {
                new DialogCustoms("Lỗi: Nhập số lượng kiểu số nguyên!", "Thông báo", DialogCustoms.OK).ShowDialog();
                return;
            }
                selectedBookItem.Quantity = quantity;
            selectedBookItem.TotalAmount = book1.Price * quantity;

        }

        private void txbSoLuong_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var textBox = (TextBox)sender;
                selectedBookItem = (SelectedBookItem)textBox.DataContext;
                int quantity = 1;
                if (!int.TryParse(textBox.Text, out quantity))
                {
                    new DialogCustoms("Lỗi: Nhập số lượng kiểu số nguyên!", "Thông báo", DialogCustoms.OK).ShowDialog();
                    return;
                }
                selectedBookItem.Quantity = quantity;
                selectedBookItem.TotalAmount = book1.Price * quantity;
            }
        }
        private void FilterEmployeeData(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                lvBook.ItemsSource = books;

            }
            else
            {
                var filteredBooks = books.Where(x => x.Title.Contains(searchTerm)).ToList();
                lvBook.ItemsSource = filteredBooks;
            }
        }


        private void txbTimKiem_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchTerm = txbTimKiem.Text;
            FilterEmployeeData(searchTerm);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var selectedItem = (SelectedBookItem)((Button)sender).DataContext;
            selectedBooks.Remove(selectedItem);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int totalQuantity = selectedBooks.Sum(item => item.Quantity);

            
            if (book1.Quantity >= totalQuantity)
            {
                bookDAO.ReduceBookQuantity(book1, totalQuantity);
                

                this.DialogResult = true;
                this.Visibility = Visibility.Hidden;
                Checkout checkout = new Checkout(book1, selectedBooks);
                checkout.ShowDialog();
            }
            else
            {
                new DialogCustoms("Insufficient quantity in stock. Please reduce the quantity or choose another book.", "Thông báo", DialogCustoms.OK).ShowDialog();
            }
        }
     
    }

}
