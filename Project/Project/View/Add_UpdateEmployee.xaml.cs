using Project.Models;
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
    /// Interaction logic for Add_UpdateEmployee.xaml
    /// </summary>
    public partial class Add_UpdateEmployee : Window
    {
        public delegate void CRUD(Employee emp);

        public CRUD addEmployee;
        public CRUD updateEmployee;
        public CRUD employee;
        private string employeeId;

        public Add_UpdateEmployee()
        {
            InitializeComponent();
            employee = new CRUD(getData);
        }

        public void getData(Employee emp)
        {
            txbTitle.Text = "Update Employee";
            employeeId = emp.EmployeeId.ToString();
            txbFullName.Text = emp.FullName;
            txbCardId.Text = emp.CardId;
            cbGender.Text = emp.Gender;
            txbAddress.Text = emp.Address;
            cbRole.Text = emp.Role;
            txbPhone.Text = emp.Phone;
            txbEmail.Text = emp.Email;


        }
        private bool checkValidInformation()
        {
            if (string.IsNullOrWhiteSpace(txbFullName.Text))
            {
                txbFullName.Focus();
                new DialogCustoms("Nhập đầy đủ họ tên !", "Thông báo", DialogCustoms.OK).ShowDialog();
                return false;
            }


            //Căn cước công dân
            if (string.IsNullOrWhiteSpace(txbCardId.Text))
            {
                txbCardId.Focus();
                new DialogCustoms("Nhập đầy đủ căn cước công dân !", "Thông báo", DialogCustoms.OK).ShowDialog();
                return false;
            }
            else
            {
                if (!long.TryParse(txbCardId.Text, out long cardId))
                {
                    txbCardId.Focus();
                    new DialogCustoms("Nhập căn cước công dân đúng định dạng số !", "Thông báo", DialogCustoms.OK).ShowDialog();
                    return false;
                }
                if (txbCardId.Text.Length > 12)
                {
                    txbCardId.Focus();
                    new DialogCustoms("Nhập căn cước công dân không quá 12 ký tự !", "Thông báo", DialogCustoms.OK).ShowDialog();
                    return false;
                }
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
        private void click_ThemNV(object sender, RoutedEventArgs e)
        {
            if (checkValidInformation())
            {
                Employee addEmp = new Employee()
                {
                    FullName = txbFullName.Text,
                    CardId = txbCardId.Text,
                    Gender = cbGender.Text,
                    Address = txbAddress.Text,
                    Role = cbRole.Text,
                    Phone = txbPhone.Text,
                    Email = txbEmail.Text
                };
                if(addEmployee != null )
                {
                    addEmployee(addEmp);
                }
                this.Close();
            }
          
           

        }
        private void click_Sua(object sender, RoutedEventArgs e)
        {

            if (checkValidInformation())
            {
                Employee updateEmp = new Employee()
                {
                    EmployeeId = int.Parse(employeeId),
                    FullName = txbFullName.Text,
                    CardId = txbCardId.Text,
                    Gender = cbGender.Text,
                    Address = txbAddress.Text,
                    Role = cbRole.Text,
                    Phone = txbPhone.Text,
                    Email = txbEmail.Text
                };
                if (updateEmployee != null)
                {
                    updateEmployee(updateEmp);
                }
                this.Close();
            }   
        }


        
    }
}
