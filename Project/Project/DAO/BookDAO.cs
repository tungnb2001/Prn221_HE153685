using Project.Models;
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

        public Book GetBookById(int bookId)
        {
            PRN221_Project_HE153685Context context = new PRN221_Project_HE153685Context();
            
            Book book = context.Books.FirstOrDefault(e => e.BookId == bookId);

            return book;
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
                        throw new Exception("Insufficient quantity in stock.");
                    }
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Error reducing book quantity: " + ex.Message);
                throw; 
            }
        }



    }
}
