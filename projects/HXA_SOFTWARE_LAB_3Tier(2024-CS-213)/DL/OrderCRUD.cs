using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXA_SOFTWARE_LAB.BL;
namespace HXA_SOFTWARE_LAB.DL
{
    public static class OrderCRUD
    {
        public static void AddOrder(Order o)
        {
            string query = $"INSERT INTO Orders VALUES ({o.OrdererId}, '{o.Type}', '{o.Platform}', {o.PBudget}, '{o.Time}', '{o.Description}', '{o.Status}', {o.RevenueGenerated}, '{o.Title}')";
            DatabaseHelper.Instance.Update(query);
        }
        public static void EditOrder(Order o)
        {
            string query = $"UPDATE Orders SET (Type,Platform,PBudget,Time,Description,Status,RevenueGenerated,Title) = ('{o.Type}', '{o.Platform}', {o.PBudget}, '{o.Time}', '{o.Description}', '{o.Status}', {o.RevenueGenerated}, '{o.Title}')  WHERE OrdererId = {o.OrdererId}";
            DatabaseHelper.Instance.Update(query);
        }
        public static void DeleteOrder(Order o)
        {
            string query = $"DELETE FROM Orders WHERE OrdererId = {o.OrdererId}";
            DatabaseHelper.Instance.Update(query);
        }
        public static Order GetOrder(Order o)
        {
            string query = $"SELECT * FROM Orders WHERE OrdererId = {o.OrdererId}";
            var reader = DatabaseHelper.Instance.getData(query);
            if (reader.Read())
            {
                return new Order(int.Parse($"{reader["OrdererId"]}"),$"{reader["Type"]}",$"{reader["Platform"]}",int.Parse($"{reader["PBudget"]}"),$"{reader["Time"]}",$"{reader["Description"]}",$"{reader["Status"]}",int.Parse($"{reader["RevenueGenerated"]}"),$"{reader["Title"]}");
            }
            return null;
        }
    }
}
