using Project.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        //private OrderDetailsManager OrderDetails;
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
            //if (string.IsNullOrEmpty(taiKhoan.avatar))
            //{
            //    Uri uri = new Uri("pack://application:,,,/Res/mountains.jpg");
            //    ImageBrush imageBrush = new ImageBrush(new BitmapImage(uri));
            //    imgAvatar.Fill = imageBrush;
            //}
            //else
            //{
            //    string staupPath = Environment.CurrentDirectory + "\\Res";
            //    string filePath = Path.Combine(staupPath, taiKhoan.avatar);
            //    if (File.Exists(filePath))
            //    {
            //        ImageBrush imageBrush = new ImageBrush(new BitmapImage(new Uri(filePath)));
            //        imgAvatar.Fill = imageBrush;

            //    }
            //    else
            //    {
            //        new DialogCustoms("Không tồn tại file ảnh của nhân viên " + taiKhoan.NhanVien.HoTen, "Thông báo", DialogCustoms.OK).ShowDialog();
            //    }
            //}
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
                        //if (OrderDetails == null)
                        //{
                        //    OrderDetails = new OrderDetailsManager();
                        //}
                        //contenDisplayMain.Content = OrderDetails;
                        //break;
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



    }
    public class ItemMenuMainWindow
    {
        public string name { get; set; }
        public string foreColor { get; set; }
        public string kind_Icon { get; set; }

        public ItemMenuMainWindow() { }

    }
}
