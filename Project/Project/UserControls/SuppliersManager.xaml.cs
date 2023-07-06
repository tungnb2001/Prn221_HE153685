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
    /// Interaction logic for SuppliersManager.xaml
    /// </summary>
    public partial class SuppliersManager : UserControl
    {
        private readonly SupplierDAO supplierDAO; 
        private ObservableCollection<Supplier> suppliers;
        public SuppliersManager()
        {
            InitializeComponent();
            supplierDAO = new SupplierDAO();
            LoadSupplierData();
        }

        private void LoadSupplierData()
        {
            suppliers = supplierDAO.loadAllSupplier();
            lsvSupplier.ItemsSource = suppliers;
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Button btnDelete = (Button)sender;
            Supplier selectedSupplier = btnDelete.DataContext as Supplier;
            var notifi = new DialogCustoms("Bạn có thật sự muốn xóa nhà phân phối : " + selectedSupplier.ContactName, "Thông báo", DialogCustoms.YesNo);

            if (notifi.ShowDialog() == true)
            {
                new DialogCustoms("Xoá thành công", "Thông báo", DialogCustoms.OK).Show();
                supplierDAO.DeteleSupplier(selectedSupplier);
                LoadSupplierData();
            }

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Button btnEdit = (Button)sender;
            Supplier selectedSupplier = btnEdit.DataContext as Supplier;
            Add_UpdateSupplier update = new Add_UpdateSupplier();
            update.getData(selectedSupplier);
            update.updateSupplier = new Add_UpdateSupplier.CRUD(supplierDAO.UpdateSupplier);
            update.ShowDialog();
            LoadSupplierData();

        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Add_UpdateSupplier add = new Add_UpdateSupplier();
            add.addSupplier = new Add_UpdateSupplier.CRUD(supplierDAO.CreateSupplier);
            add.ShowDialog();
            LoadSupplierData();

        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchTerm = txtFilter.Text.Trim();
            FilterSupplierData(searchTerm);
        }
        private void FilterSupplierData(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                lsvSupplier.ItemsSource = suppliers;
            }
            else
            {
                var filteredEmployees = suppliers.Where(sup => sup.ContactName.Contains(searchTerm)).ToList();
                lsvSupplier.ItemsSource = filteredEmployees;
            }
        }
    }
}
