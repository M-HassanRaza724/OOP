using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXA_SOFTWARE_LAB.BL;

namespace HXA_SOFTWARE_LAB.DL
{
    public class MUserCRUD
    {
        static int total_buyers = 0, total_admins = 0, userType = -1,userIndex = -1;

        public static void AddUser(MUser u)
        {
            string query = $"INSERT INTO Users VALUES ('{u.Username}', '{u.Email}', '{u.Password}', '{u.UserRole}')";
            DatabaseHelper.Instance.Update(query);
        }

        public static void EditUser(MUser u)
        {
            string query = $"UPDATE Users SET Name = '{u.Username}', CGPA = {u.Password}  WHERE Email = '{u.Email}'";
            DatabaseHelper.Instance.Update(query);
        }

        public static void DeleteUser(MUser u)
        {
            string query = $"DELETE FROM User WHERE Email = '{u.Email}'";
            DatabaseHelper.Instance.Update(query);
        }

        public static bool SearchUser(MUser u)  // need in signup
        {
            string query = $"SELECT * FROM Users WHERE Email = '{u.Email}'";
            var reader = DatabaseHelper.Instance.getData(query);
            if (reader.Read())
            {
                //Console.WriteLine($"{reader["UserName"]} - {reader["Email"]} - {reader["Password"]} - {reader["UserRole"]}");
                return true;
            }
            //Console.WriteLine("User not found.");
            return false;
        }
        public static bool AuthenticateUser(MUser u)  // need in login
        {
            string query = $"SELECT * FROM Users WHERE Email = '{u.Email}'";
            var reader = DatabaseHelper.Instance.getData(query);
            if (reader.Read())
            {
                if (u.Password == $"{reader["Password"]}") ;
                {
                    if ($"{reader["role"]}" == "admin")
                        u.UserRole = "admin";
                    u.Username = $"{reader["Username"]}";
                    return true;
                }
            }
            //Console.WriteLine("User not found.");
            return false;
        }
        public static MUser GetUser(string email)
        {
            string query = $"SELECT * FROM Users WHERE Email = '{email}'";
            var reader = DatabaseHelper.Instance.getData(query);
            if (reader.Read())
            {
                return new MUser($"{reader["UserName"]}", $"{reader["Email"]}", $"{reader["Password"]}");
            }
            return null;
        }
    }
}
