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
    public class EmployeeDAO
    {

        public ObservableCollection<Employee> loadAllEmployee()
        {
            PRN221_Project_HE153685Context context = new PRN221_Project_HE153685Context();
            var employees = new ObservableCollection<Employee>(context.Employees.ToList());
            return employees;
        }

        public Employee GetEmployeeByID(int empId)
        {
            PRN221_Project_HE153685Context context = new PRN221_Project_HE153685Context();

            Employee emp = context.Employees.FirstOrDefault(e => e.EmployeeId == empId);

            return emp;
        }

        public void DeleteEmployee(Employee employee)
        {
            using (PRN221_Project_HE153685Context context = new PRN221_Project_HE153685Context())
            {
                Employee employeeToDelete = context.Employees.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);

                if (employeeToDelete != null)
                {
                    context.Employees.Remove(employeeToDelete);
                    context.SaveChanges();
                }
            }
        }

        public void CreateEmployee(Employee employee)
        {
            PRN221_Project_HE153685Context context = new PRN221_Project_HE153685Context();
            try
            {
                context.Employees.Add(employee);
                context.SaveChanges();
                new DialogCustoms("Thêm nhân viên thành công!", "Thông báo", DialogCustoms.OK).ShowDialog();
                loadAllEmployee();
            }
            catch (Exception ex)
            {

            }
            
        }

        public void UpdateEmployee(Employee employee)
        {
            PRN221_Project_HE153685Context context = new PRN221_Project_HE153685Context();
           try
            {
                // Find the existing employee in the context
                Employee existingEmployee = context.Employees.Where(x => x.EmployeeId == employee.EmployeeId).FirstOrDefault();

                if (existingEmployee != null)
                {
                    // Update the properties of the existing employee
                    existingEmployee.FullName = employee.FullName;
                    existingEmployee.CardId = employee.CardId;
                    existingEmployee.Gender = employee.Gender;
                    existingEmployee.Address = employee.Address;
                    existingEmployee.Role = employee.Role;
                    existingEmployee.Phone = employee.Phone;
                    existingEmployee.Email = employee.Email;
                    context.SaveChanges();
                    new DialogCustoms("Cập nhật nhân viên thành công!", "Thông báo", DialogCustoms.OK).ShowDialog();
                    loadAllEmployee();
                }
            }
            catch (Exception ex)
            {

            }
        }


    }
}
