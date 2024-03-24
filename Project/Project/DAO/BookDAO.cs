using Project.Models;
using Project.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAO
{
    public class BookDAO
    {

        public ObservableCollection<Book> loadAllBook()
        {
            PRN221_Project_HE153685Context  context = new PRN221_Project_HE153685Context();
            var list = new ObservableCollection<Book>(context.Books.ToList());
            return list;
        }

        public ObservableCollection<Warehouse> loadAllWarehouse() 
        {
            PRN221_Project_HE153685Context context = new PRN221_Project_HE153685Context();
            var list = new ObservableCollection<Warehouse>(context.Warehouses.ToList());
            return list;
        }

        public decimal GetTotalBookPrice()
        {
            PRN221_Project_HE153685Context context = new PRN221_Project_HE153685Context();
            loadAllBook();
            return context.Books.Sum(book => book.Price * book.Quantity);
        }


        public Book GetBookById(int bookId)
        {
            PRN221_Project_HE153685Context context = new PRN221_Project_HE153685Context();
            
            Book book = context.Books.FirstOrDefault(e => e.BookId == bookId);

            return book;
        }
        public void CreateNewBook(Book book)
        {
            PRN221_Project_HE153685Context context = new PRN221_Project_HE153685Context();
            try
            {
                context.Books.Add(book);
                context.SaveChanges();
                new DialogCustoms("Thêm sản phẩm thành công!", "Thông báo", DialogCustoms.OK).ShowDialog();
                loadAllBook();
            }
            catch (Exception ex)
            {

            }

        }


        public void UpdateBook(Book book)
        {
            PRN221_Project_HE153685Context context = new PRN221_Project_HE153685Context();
            try
            {
                // Find the existing employee in the context
                Book existingBook = context.Books.Where(x => x.BookId == book.BookId).FirstOrDefault();

                if (existingBook != null)
                {
                    // Update the properties of the existing employee
                    existingBook.SupplierId = book.SupplierId;
                    existingBook.Title = book.Title;
                    existingBook.Price = book.Price;
                    existingBook.Quantity = book.Quantity;
                  
                    context.SaveChanges();
                    new DialogCustoms("Cập nhật sản phẩm thành công!", "Thông báo", DialogCustoms.OK).ShowDialog();
                    loadAllBook();
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void ReduceBookQuantity(Book book, int quantity)
        {
            try
            {
                using (PRN221_Project_HE153685Context context = new PRN221_Project_HE153685Context())
                {
              
                    var dbBook = context.Books.Find(book.BookId);
                    if (dbBook.Quantity >= quantity)
                    {     
                        dbBook.Quantity -= quantity;

                        context.SaveChanges();
                    }
                    else
                    {
                       new DialogCustoms("Không đủ số lượng trong kho!", "Thông báo", DialogCustoms.OK).ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                new DialogCustoms("Error reducing book quantity!", "Thông báo", DialogCustoms.OK).ShowDialog();
                throw; 
            }
        }



    }
}
