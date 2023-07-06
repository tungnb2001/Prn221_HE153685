using Microsoft.EntityFrameworkCore;
using Project.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAO
{
    public class UserDAO
    {
        public User getUserByUsernameAndPassword(string username, string password)
        {

            PRN221_Project_HE153685Context context = new PRN221_Project_HE153685Context();
            User user = context.Users.ToList().Where(p => p.UserName == username && p.Password == password).FirstOrDefault();
            return user;

        }
        public bool UpdateImagePath(string userName, string imagePath)
        {
            try
            {
                using (PRN221_Project_HE153685Context context = new PRN221_Project_HE153685Context())
                {
                    // Tìm người dùng trong cơ sở dữ liệu theo userId
                    User user = context.Users.FirstOrDefault(u => u.UserName == userName);
                    if (user != null)
                    {
                        // Cập nhật đường dẫn ảnh mới
                        int maxLength = 255; // Maximum length for the Image column
                        if (imagePath.Length > maxLength)
                        {
                            string fileName = System.IO.Path.GetFileName(imagePath); // Extract the file name
                            string extension = System.IO.Path.GetExtension(imagePath); // Extract the file extension

                            int availableLength = maxLength - extension.Length; // Calculate the available length for the file name

                            if (availableLength <= 0)
                            {
                                return false; // If the available length is not sufficient, return false
                            }

                            string truncatedFileName = fileName.Substring(0, availableLength);
                            imagePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(imagePath), truncatedFileName + extension);
                        }
                        user.Image = imagePath;
                        context.SaveChanges();
                        return true; // Cập nhật thành công
                    }
                    else
                    {
                        return false; // Không tìm thấy người dùng
                    }
                }
            }
            catch (DbUpdateException ex)
            {
                // Log the detailed exception message for debugging
                Console.WriteLine("Lỗi: " + ex.InnerException?.Message);
                return false;
            }
            catch (Exception ex)
            {
                // Log the exception message for debugging
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }
    }
}
