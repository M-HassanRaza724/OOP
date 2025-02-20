using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MySqlX.XDevAPI;
using System.Xml.Linq;
using week2;

namespace HXA_SOFTWARE_LAB
{
    public class MUser
    {
        public string Email;
        public string Username;
        public string Password;
        public int UserRole;

        public MUser(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
            UserRole = 0;
        }

        public void AddUser()
        {
            string query = $"INSERT INTO Users VALUES ('{Username}', '{Email}', '{Password}', '{UserRole}')";
            DatabaseHelper.Instance.Update(query);
        }

        public void EditUser()
        {
            string query = $"UPDATE Users SET Name = '{Username}', CGPA = {Password}  WHERE Email = '{Email}'";
            DatabaseHelper.Instance.Update(query);
        }

        public void DeleteUser()
        {
            string query = $"DELETE FROM User WHERE Email = '{Email}'";
            DatabaseHelper.Instance.Update(query);
        }

        public bool SearchUser()  // need in signup
        {
            string query = $"SELECT * FROM Users WHERE Email = '{Email}'";
            var reader = DatabaseHelper.Instance.getData(query);
            if (reader.Read())
            {
                //Console.WriteLine($"{reader["UserName"]} - {reader["Email"]} - {reader["Password"]} - {reader["UserRole"]}");
                return true;
            }
           //Console.WriteLine("User not found.");
            return false;
        }
        public bool AuthenticateUser()  // need in login
        {
            string query = $"SELECT * FROM Users WHERE Email = '{Email}'";
            var reader = DatabaseHelper.Instance.getData(query);
            if (reader.Read())
            {
                if (Password == $"{reader["Password"]}");
                {
                    if ($"{reader["UserRole"]}" == "1")
                        UserRole = 1;
                    Username = $"{reader["UserName"]}";
                    return true;
                }
            }
            //Console.WriteLine("User not found.");
            return false;
        }
        public void ShowUsers()
        {
            string query = "SELECT * FROM Users";
            var reader = DatabaseHelper.Instance.getData(query);
            while (reader.Read())
            {
                Console.WriteLine($"{reader["Email"]} -  {reader["Name"]} - {reader["Department"]} - {reader["Session"]} - {reader["Cgpa"]} - {reader["Address"]}");
            }
        }



    }
}
