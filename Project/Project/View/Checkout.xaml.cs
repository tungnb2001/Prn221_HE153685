using Project.DAO;
using Project.Models;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    /// Interaction logic for Checkout.xaml
    /// </summary>
    public partial class Checkout : Window
    {
        private List<SelectedBookItem> listBook;

        private Book book1;

        private OrderDetailDAO orderDetailDAO ;

        private OrderDetail orderDetail;
        public Checkout()
        {
            InitializeComponent();
        }

        public Checkout(Book book, ObservableCollection<SelectedBookItem> selectedBookItems) :this()
        {
            this.book1 = book;
            orderDetailDAO = new OrderDetailDAO();
            listBook = selectedBookItems.ToList();
           
            try
            {
                lvDichVuDaSD.ItemsSource = listBook;
                decimal totalAmount = listBook.Sum(x => x.TotalAmount);
                DateTime invoiceDate = DateTime.Now;
                string employeeName = Account.UserName; 
                int totalProducts = selectedBookItems.Count;

                 orderDetail = new OrderDetail()
                {
                    EmployeeName = employeeName,
                    DateCreated = invoiceDate,
                    Total = totalAmount

                };
                orderDetailDAO.CreateOrderDetail(orderDetail);


                txbNgayLapHoadon.Text = invoiceDate.ToString();
                txbSoHoaDon.Text = orderDetail.OrderDetailId.ToString();
                txbNhanVien.Text = employeeName;
                txbTotal.Text = totalProducts.ToString();
                
                txbTongTien.Text = totalAmount.ToString();

               

            }
            catch (Exception ex)
            {

            }
            
        }

        //private void btnInHoaDon_Click(object sender, RoutedEventArgs e)
        //{
            //        try
            //            {
            //                // Create a new PDF document
            //                Document document = new Document();
            //        PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("Invoice.pdf", FileMode.Create));
            //        document.Open();

            //                // Add content to the PDF document
            //                iTextSharp.text.Paragraph heading = new iTextSharp.text.Paragraph("Invoice");
            //        heading.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
            //                document.Add(heading);

            //                // Add order details to the PDF document
            //                iTextSharp.text.Paragraph orderDetailParagraph = new iTextSharp.text.Paragraph($"Order ID: {orderDetail.OrderDetailId}");
            //        document.Add(orderDetailParagraph);

            //                iTextSharp.text.Paragraph employeeParagraph = new iTextSharp.text.Paragraph($"Employee: {orderDetail.EmployeeName}");
            //        document.Add(employeeParagraph);

            //                iTextSharp.text.Paragraph dateParagraph = new iTextSharp.text.Paragraph($"Date: {orderDetail.DateCreated}");
            //        document.Add(dateParagraph);

            //                // Add book details to the PDF document
            //                PdfPTable table = new PdfPTable(3); // Assuming each book has 3 columns (e.g., title, quantity, price)

            //                foreach (SelectedBookItem bookItem in listBook)
            //                {
            //                    table.AddCell(bookItem.Title);
            //                    table.AddCell(bookItem.Quantity.ToString());
            //                    table.AddCell(bookItem.Price.ToString());
            //                }

            //    document.Add(table);

            //                // Add total amount to the PDF document
            //                iTextSharp.text.Paragraph totalAmountParagraph = new iTextSharp.text.Paragraph($"Total Amount: {orderDetail.Total}");
            //    document.Add(totalAmountParagraph);

            //                document.Close();

            //                new DialogCustoms("Invoice generated successfully!", "Notification", DialogCustoms.OK).ShowDialog();
            //}
            //            catch (Exception ex)
            //            {
            //    new DialogCustoms("Failed to generate invoice! Error: " + ex.Message, "Notification", DialogCustoms.OK).ShowDialog();
            //}
        //}






        //public Checkout(int orderDetailId) :this()
        //{
        //    try
        //    {
        //        orderDetailDAO = new OrderDetailDAO();

        //        OrderDetail orderDetail = orderDetailDAO.getOrderDetailById(orderDetailId);
        //        if(orderDetail == null)
        //        {
        //            new DialogCustoms("Hóa đơn không tồn tại!", "Thông báo", DialogCustoms.OK).ShowDialog();
        //            return;
        //        }
        //        txbSoHoaDon.Text=orderDetail.OrderDetailId.ToString();
        //        txbNhanVien.Text = orderDetail.EmployeeName;
        //        txbNgayLapHoadon.Text = orderDetail.DateCreated.ToString();

        //        // Lấy danh sách các SelectedBookItem từ orderDetail.BookList
        //        listBook = orderDetail.BookList != null ? orderDetail.BookList : new List<SelectedBookItem>();
        //        lvDichVuDaSD.ItemsSource = listBook;


        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //}

    }
}






