using Project.DAO;
using Project.Model;
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
    /// Interaction logic for EmployeeManager.xaml
    /// </summary>
    public partial class EmployeeManager : UserControl
    {
        private readonly EmployeeDAO employeeDAO;
        private ObservableCollection<Employee> employees;
        public EmployeeManager()
        {
            InitializeComponent();

            employeeDAO = new EmployeeDAO();
            LoadEmployeeData();
        }

        private void LoadEmployeeData()
        {
            employees = employeeDAO.loadAllEmployee();
            lsvNhanVien.ItemsSource = employees;
        }
        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchTerm = txtFilter.Text.Trim();
            FilterEmployeeData(searchTerm);
        }
        private void FilterEmployeeData(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                lsvNhanVien.ItemsSource = employees;
            }
            else
            {
                var filteredEmployees = employees.Where(emp => emp.FullName.Contains(searchTerm)).ToList();
                lsvNhanVien.ItemsSource = filteredEmployees;
            }
        }
      
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Button btnEdit = (Button)sender;
            Employee selectedEmployee = btnEdit.DataContext as Employee;
            Add_UpdateEmployee update = new Add_UpdateEmployee();
            update.getData(selectedEmployee);
            update.updateEmployee = new Add_UpdateEmployee.CRUD(employeeDAO.UpdateEmployee);
            update.ShowDialog();
            LoadEmployeeData();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Button btnDelete = (Button)sender;
            Employee selectedEmployee = btnDelete.DataContext as Employee;
            var notifi = new DialogCustoms("Bạn có thật sự muốn xóa nhân viên : " + selectedEmployee.FullName, "Thông báo", DialogCustoms.YesNo);

            if(notifi.ShowDialog() == true)
            {
                new DialogCustoms("Xoá thành công", "Thông báo", DialogCustoms.OK).Show();
                employeeDAO.DeleteEmployee(selectedEmployee);
                LoadEmployeeData();
            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Add_UpdateEmployee add = new Add_UpdateEmployee();
            add.addEmployee = new Add_UpdateEmployee.CRUD(employeeDAO.CreateEmployee);
            add.ShowDialog();
            LoadEmployeeData();
        }
    }
}
