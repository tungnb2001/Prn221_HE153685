
using Project.Model;
using Project.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAO
{
    public class SupplierDAO
    {
        public ObservableCollection<Supplier> loadAllSupplier()
        {
            PRN221_Project_HE153685Context context = new PRN221_Project_HE153685Context();
            var list = new ObservableCollection<Supplier>(context.Suppliers.ToList());
            return list;
        }


        public Supplier GetSupplierBySupplierId(int supplierId)
        {
            PRN221_Project_HE153685Context context = new PRN221_Project_HE153685Context();

            
            Supplier supplier = context.Suppliers.FirstOrDefault(e => e.SupplierId == supplierId);

            return supplier;
        }

        public void DeteleSupplier(Supplier supplier)
        {
            using (PRN221_Project_HE153685Context context = new PRN221_Project_HE153685Context())
            {
                Supplier supplierToDelete = context.Suppliers.FirstOrDefault(e => e.SupplierId == supplier.SupplierId);

                if (supplierToDelete != null)
                {
                    context.Suppliers.Remove(supplierToDelete);
                    context.SaveChanges();
                }
            }
        }

        public void CreateSupplier(Supplier supplier)
        {
            PRN221_Project_HE153685Context context = new PRN221_Project_HE153685Context();
            try
            {
                context.Suppliers.Add(supplier);
                context.SaveChanges();
                new DialogCustoms("Thêm nhà phân phối thành công!", "Thông báo", DialogCustoms.OK).ShowDialog();
                loadAllSupplier();
            }
            catch (Exception ex)
            {

            }
        }

        public void UpdateSupplier(Supplier supplier)
        {
            PRN221_Project_HE153685Context context = new PRN221_Project_HE153685Context();
            try
            {
                Supplier existingSupplier = context.Suppliers.Where(x => x.SupplierId == supplier.SupplierId).FirstOrDefault();
            
                if(existingSupplier != null)
                {
                    existingSupplier.SupplierName = supplier.SupplierName;
                    existingSupplier.ContactName = supplier.ContactName;
                    existingSupplier.Phone = supplier.Phone;
                    existingSupplier.Email = supplier.Email;
                    existingSupplier.Address = supplier.Address;
                    context.SaveChanges();
                    new DialogCustoms("Cập nhật nhà phân phối thành công!", "Thông báo", DialogCustoms.OK).ShowDialog();
                    loadAllSupplier();
                }
            
            }
            catch(Exception ex)
            {

            }
        }
    }
}
