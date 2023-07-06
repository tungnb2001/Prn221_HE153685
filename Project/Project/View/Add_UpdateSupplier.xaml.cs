using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Add_UpdateSupplier.xaml
    /// </summary>
    public partial class Add_UpdateSupplier : Window
    {

        public delegate void CRUD(Supplier sup);

        public CRUD addSupplier;
        public CRUD updateSupplier;
        public CRUD supplier;
        private string supplierId;
        public Add_UpdateSupplier()
        {
            InitializeComponent();
            supplier = new CRUD(getData);
        }

        public void getData(Supplier sup)
        {
            txbTitle.Text = "Update Supplier";
            supplierId = sup.SupplierId.ToString();
            txbSupplierName.Text = sup.SupplierName;
            txbContactName.Text = sup.ContactName;
            txbPhone.Text = sup.Phone;
            txbEmail.Text = sup.Email;
            txbAddress.Text = sup.Address;
        }
        private bool checkValidInformation()
        {
            if (string.IsNullOrWhiteSpace(txbSupplierName.Text))
            {
                txbSupplierName.Focus();
                new DialogCustoms("Nhập đầy đủ họ tên !", "Thông báo", DialogCustoms.OK).ShowDialog();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txbContactName.Text))
            {
                txbContactName.Focus();
                new DialogCustoms("Nhập đầy đủ họ tên !", "Thông báo", DialogCustoms.OK).ShowDialog();
                return false;
            }

            //địa chỉ
            if (string.IsNullOrWhiteSpace(txbAddress.Text))
            {
                txbAddress.Focus();
                new DialogCustoms("Nhập địa chỉ !", "Thông báo", DialogCustoms.OK).ShowDialog();
                return false;
            }

            // số điện thoại
            if (string.IsNullOrWhiteSpace(txbPhone.Text))
            {
                txbPhone.Focus();
                new DialogCustoms("Nhập số điện thoại!", "Thông báo", DialogCustoms.OK).ShowDialog();
                return false;
            }
            else
            {
                if (!long.TryParse(txbPhone.Text, out long phone))
                {
                    txbPhone.Focus();
                    new DialogCustoms("Nhập số điện thoại đúng định dạng số !", "Thông báo", DialogCustoms.OK).ShowDialog();
                    return false;
                }
                if (txbPhone.Text.Length > 10)
                {
                    txbPhone.Focus();
                    new DialogCustoms("Nhập số điện thoại không quá 10 ký tự !", "Thông báo", DialogCustoms.OK).ShowDialog();
                    return false;
                }
            }

            //email
            if (string.IsNullOrWhiteSpace(txbEmail.Text))
            {
                txbEmail.Focus();
                new DialogCustoms("Nhập địa chỉ email !", "Thông báo", DialogCustoms.OK).ShowDialog();
                return false;
            }
            else
            {
                if (!IsEmailValid(txbEmail.Text))
                {
                    txbEmail.Focus();
                    new DialogCustoms("Nhập địa chỉ email đúng định dạng!", "Thông báo", DialogCustoms.OK).ShowDialog();
                    return false;
                }
            }


            return true;

        }
        private bool IsEmailValid(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }
        private void click_Huy(object sender, RoutedEventArgs e)
        {
            Window wd = Window.GetWindow(sender as Button);
            wd.Close();

        }

        private void click_Sua(object sender, RoutedEventArgs e)
        {
            if (checkValidInformation())
            {
                Supplier updateSupp = new Supplier()
                {
                    SupplierId = int.Parse(supplierId),
                    SupplierName = txbSupplierName.Text,
                    ContactName = txbContactName.Text,
                    Phone = txbPhone.Text,
                    Email = txbEmail.Text,
                    Address = txbAddress.Text,


                };

                if (updateSupp != null)
                {
                   updateSupplier(updateSupp);
                }
                this.Close();
            }

        }
        private void click_Them(object sender, RoutedEventArgs e)
        {
            //if (checkValidInformation())
            //{
                Supplier addSupp = new Supplier()
                {
                    
                    SupplierName = txbSupplierName.Text,
                    ContactName = txbContactName.Text,
                    Phone = txbPhone.Text,
                    Email = txbEmail.Text,
                    Address = txbAddress.Text,


                };

                if (addSupp != null)
                {
                    addSupplier(addSupp);
                }
                this.Close();
            //}
        }
    }
}

