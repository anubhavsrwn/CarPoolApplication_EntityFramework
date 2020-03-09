using System;
using CarPoolApplication.Models;
namespace CarPoolApplication.Services
{
    public class UserServices
    {
        public bool ValidateUserName(string username)
        {
            using (var db = new UserContext())
            {
                foreach (var user in db.Users)
                {
                    if(user.Username == username)
                        return false;
                }

                return true;
            }
        }

        public void AddUser(string username, string password)
        {
            using (var db = new UserContext())
            {
                db.Users.Add(new User(username, password));
                db.SaveChanges();
            }
        }

        public bool ValidateUser(string username, string password)
        {
            using (var db = new UserContext())
            {
                foreach (var user in db.Users)
                {
                    if ((user.Username == username)&&(user.Password == password))
                    {
                        return true;
                    }
                }

                return false;
            }

        }
    }
}
