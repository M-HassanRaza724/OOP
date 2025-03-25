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
        public static List<Order> Orders = new List<Order>();
        public static List<string> GetOrderTypes()
        {
            List<string> orderTypes = new List<string>();
            string query = "SELECT DISTINCT Type FROM Orders";
            var reader = DatabaseHelper.Instance.getData(query);
            while (reader.Read())
            {
                orderTypes.Add($"{reader["Type"]}");
            }
            return orderTypes;
        } 
        public static List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();
            string query = "SELECT * FROM Orders";
            var reader = DatabaseHelper.Instance.getData(query);
            while (reader.Read())
            {
                orders.Add(new Order(($"{reader["OrderId"]}"), $"{reader["Type"]}", $"{reader["Platform"]}", $"{reader["PBudget"]}", $"{reader["Time"]}", $"{reader["Description"]}", $"{reader["Status"]}", int.Parse($"{reader["RevenueGenerated"]}"), $"{reader["Title"]}"));
            }
            return orders;
        }
        public static void AddOrder(Order o)
        {
            string query = $"INSERT INTO Orders VALUES ({o.OrderId}, '{o.Type}', '{o.Platform}', {o.PBudget}, '{o.Time}', '{o.Description}', '{o.Status}', {o.RevenueGenerated}, '{o.Title}')";
            DatabaseHelper.Instance.Update(query);
        }
        public static void EditOrder(Order o)
        {
            string query = $"UPDATE Orders SET (Type,Platform,PBudget,Time,Description,Status,RevenueGenerated,Title) = ('{o.Type}', '{o.Platform}', {o.PBudget}, '{o.Time}', '{o.Description}', '{o.Status}', {o.RevenueGenerated}, '{o.Title}')  WHERE OrderId = {o.OrderId}";
            DatabaseHelper.Instance.Update(query);
        }
        public static void DeleteOrder(Order o)
        {
            string query = $"DELETE FROM Orders WHERE OrderId = {o.OrderId}";
            DatabaseHelper.Instance.Update(query);
        }
        public static Order GetOrder(string orderId)
        {
            string query = $"SELECT * FROM Orders WHERE OrderId = {orderId}";
            var reader = DatabaseHelper.Instance.getData(query);
            if (reader.Read())
            {
                return new Order(($"{reader["OrderId"]}"),$"{reader["Type"]}",$"{reader["Platform"]}",($"{reader["PBudget"]}"),$"{reader["Time"]}",$"{reader["Description"]}",$"{reader["Status"]}",int.Parse($"{reader["RevenueGenerated"]}"),$"{reader["Title"]}");
            }
            return null;
        }
        public static List<Order> GetOrdersBYEmail(string orderer)
        {
            List<Order> orders = new List<Order>();
            string query = $"SELECT * FROM orders WHERE Order_id  Like '%{orderer}%'";
            var reader = DatabaseHelper.Instance.getData(query);
            while (reader.Read())
            {
                Order o = new Order
                {
                    OrderId = ($"{reader["OrderId"]}"),
                    Type = $"{reader["Type"]}",
                    Platform = $"{reader["Platform"]}",
                    PBudget = ($"{reader["PBudget"]}"),
                    Time = $"{reader["Time"]}",
                    Description = $"{reader["Description"]}",
                    Status = $"{reader["Status"]}"
                };
                orders.Add(o);
            }
            return null;
        }
    }
}
