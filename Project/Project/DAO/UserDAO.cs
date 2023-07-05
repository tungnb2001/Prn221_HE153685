using Project.Models;
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
    }
}
