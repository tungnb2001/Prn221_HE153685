using Microsoft.Win32;
using Project.DAO;
using Project.Model;
using Project.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Principal;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private HomeManager Home;
        //private WarehouseManager Warehouse;
        private BookManager Book;
        private EmployeeManager Employees;
        private OrderDetailManager OrderDetails;
        private SuppliersManager Suppliers;
        //private PurchaseOrdersManager PurchaseOrders;


        public List<ItemMenuMainWindow> listMenu { get; set; }
        private string title_Main;

        public string Title_Main
        {
            get => title_Main;
            set
            {
                title_Main = value;
                OnPropertyChanged("Title_Main");
            }
        }

        private int minHeight_ucControlbar;
        public int MinHeight_ucControlbar
        {
            get => minHeight_ucControlbar;
            set
            {
                minHeight_ucControlbar = value;
                OnPropertyChanged("MinHeight_ucControlbar");
                if (value == 1)
                {
                    boGoc.Rect = new Rect(0, 0, SystemParameters.MaximizedPrimaryScreenWidth, SystemParameters.MaximizedPrimaryScreenHeight);
                }
                else
                {
                    boGoc.Rect = new Rect(0, 0, 1300, 700);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string newName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(newName));
            }
        }
        public MainWindow()
        {

            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
        }

        private void btnDangXuat_Click(object sender, RoutedEventArgs e)
        {
            DialogCustoms dialog = new DialogCustoms("Bạn có muốn đăng xuất ?", "Thông báo", DialogCustoms.YesNo);
            if (dialog.ShowDialog() == true)
            {
                new Login().Show();
                this.Close();
            }


        }
        private void initListViewMenu()
        {
            listMenu = new List<ItemMenuMainWindow>();
            //Khoi tao Menu

            listMenu.Add(new ItemMenuMainWindow() { name = "Trang Chủ", foreColor = "Gray", kind_Icon = "Home" });
            listMenu.Add(new ItemMenuMainWindow() { name = "Quản lý bán hàng", foreColor = "#FFF08033", kind_Icon = "StarCircle" });
            listMenu.Add(new ItemMenuMainWindow() { name = "Quản lý nhập hàng", foreColor = "Green", kind_Icon = "StarCircle" });
            listMenu.Add(new ItemMenuMainWindow() { name = "Quản lý nhân viên", foreColor = "#FFD41515", kind_Icon = "StarCircle" });
            listMenu.Add(new ItemMenuMainWindow() { name = "Quản lý kho", foreColor = "#FFD41515", kind_Icon = "StarCircle" });
            listMenu.Add(new ItemMenuMainWindow() { name = "Quản lý nhà phân phối", foreColor = "#FFE6A701", kind_Icon = "StarCircle" });
            listMenu.Add(new ItemMenuMainWindow() { name = "Thống kê", foreColor = "#FFE6A701", kind_Icon = "StarCircle" });



            lisviewMenu.ItemsSource = listMenu;
            lisviewMenu.SelectedValuePath = "name";
            Title_Main = "Trang Chủ";
        }
        private void load_Windows(object sender, RoutedEventArgs e)
        {
            this.DataContext = this;
            Home = new HomeManager();
            contenDisplayMain.Content = Home;
            txbHoTenNV.Text = Account.UserName;
            if (string.IsNullOrEmpty(Account.Image))
            {
                Uri uri = new Uri("D:\\PRN221\\PROJECT_PRN221\\Project_PRN221\\Prn221_HE153685\\Project\\Project\\Res\\Light 010.png");
                ImageBrush imageBrush = new ImageBrush(new BitmapImage(uri));
                imgAvatar.Fill = imageBrush;
            }
            else
            {
                string staupPath = Environment.CurrentDirectory + "\\Res";
                string filePath = System.IO.Path.Combine(staupPath, Account.Image);
                if (File.Exists(filePath))
                {
                    ImageBrush imageBrush = new ImageBrush(new BitmapImage(new Uri(filePath)));
                    imgAvatar.Fill = imageBrush;

                }
                else
                {
                    new DialogCustoms("Không tồn tại file ảnh của nhân viên " + Account.UserName, "Thông báo", DialogCustoms.OK).ShowDialog();
                }
            }
            initListViewMenu();
        }
        private void lisviewMenu_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (lisviewMenu.SelectedValue != null)
            {
                switch (lisviewMenu.SelectedIndex)
                {
                    case 0:
                        //Đang là Home rồi thì không set nữa
                        if (Title_Main.Equals(lisviewMenu.SelectedValue.ToString()))
                        {
                            break;
                        }
                        contenDisplayMain.Content = Home;
                        break;
                    case 1:
                        if (OrderDetails == null)
                        {
                            OrderDetails = new OrderDetailManager();
                        }
                        contenDisplayMain.Content = OrderDetails;
                        break;
                        break;
                    case 2:
                        //if (PurchaseOrders == null)
                        //{
                        //    PurchaseOrders = new PurchaseOrdersManager();
                        //}
                        //contenDisplayMain.Content = PurchaseOrders;
                        break;
                    case 3:
                        if (Employees == null)
                        {
                            Employees = new EmployeeManager();
                        }
                        contenDisplayMain.Content = Employees;
                        break;
                    case 4:
                        if (Book == null)
                        {
                            Book = new BookManager();
                        }
                        contenDisplayMain.Content = Book;
                        break;

                    case 5:
                        if (Suppliers == null)
                        {
                            Suppliers = new SuppliersManager();
                        }
                        contenDisplayMain.Content = Suppliers;
                        break;
                    case 6:
                        //if (Suppliers == null)
                        //{
                        //    Suppliers = new SuppliersManager();
                        //}
                        //contenDisplayMain.Content = Suppliers;
                        break;

                }
                Title_Main = lisviewMenu.SelectedValue.ToString();
                //Tự động hóa việc click Button toggleBtnMenu_Close
                btnCloseLVMenu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        private void btnThayAnh_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;

            if (openFile.ShowDialog() == true)
            {
                try
                {
                    // Xử lý đổi tên tệp tin truyền vào
                    string[] arr = openFile.FileName.Split('\\');
                    string[] arrFileName = arr[arr.Length - 1].Split('.');
                    string newNameFile = "UserName" + Account.UserName + "-" + DateTime.Now.Ticks.ToString() + "." + arrFileName[arrFileName.Length - 1];

                    // Lấy đường dẫn và tên tệp tin nguồn
                    string sourceFile = openFile.FileName;

                    // Lấy đường dẫn đích
                    string currentDirectory = Directory.GetCurrentDirectory();
                    string solutionDirectory = System.IO.Path.GetFullPath(System.IO.Path.Combine(currentDirectory, @"..\..\..\"));
                    string targetPath = System.IO.Path.Combine(solutionDirectory, "Res");

                    // Kết hợp đường dẫn và tên tệp tin đích
                    string destFile = System.IO.Path.Combine(targetPath, newNameFile);

                    // Sao chép tệp tin từ nguồn đến đích
                    File.Copy(sourceFile, destFile, true);

                    // Gán lại giao diện
                    Uri uri = new Uri(destFile);
                    ImageBrush imageBrush = new ImageBrush(new BitmapImage(uri));
                    imgAvatar.Fill = imageBrush;

                    // Thêm đường dẫn vào cơ sở dữ liệu
                    string error = string.Empty;
                    UserDAO userDAO = new UserDAO();
                    if (!string.IsNullOrEmpty(Account.UserName))
                    {
                        bool updateSuccess = userDAO.UpdateImagePath(Account.UserName, destFile);  // Lưu đường dẫn vào cơ sở dữ liệu
                        if (updateSuccess)
                        {
                            new DialogCustoms("Thay đổi ảnh đại diện thành công cho người dùng : " + Account.UserName, "Thông báo", DialogCustoms.OK).ShowDialog();
                        }
                        else
                        {
                            new DialogCustoms("Lỗi: " + error, "Thông báo", DialogCustoms.OK).ShowDialog();
                        }

                    }
                    else
                    {
                        new DialogCustoms("Không có người dùng : " + Account.UserName + " này!", "Thông báo", DialogCustoms.OK).ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    new DialogCustoms("Lỗi: " + ex.Message, "Thông báo", DialogCustoms.OK).ShowDialog();
                }
            }
        }
        public class ItemMenuMainWindow
        {
            public string name { get; set; }
            public string foreColor { get; set; }
            public string kind_Icon { get; set; }

            public ItemMenuMainWindow() { }

        }
    }
}
