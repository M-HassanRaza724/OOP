using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXA_SOFTWARE_LAB.BL;
namespace HXA_SOFTWARE_LAB.DL
{
    public static class ServiceCRUD
    {
        public static List<string> GetServiceTypes()
        {
            List<string> serviceTypes = new List<string>();
            string query = "SELECT DISTINCT type FROM Services";
            var reader = DatabaseHelper.Instance.getData(query);
            while (reader.Read())
            {
                serviceTypes.Add($"{reader["type"]}");
            }
            return serviceTypes;
        }
        public static List<Service> GetServices()
        {
            List<Service> services = new List<Service>();
            string query = "SELECT * FROM Services";
            var reader = DatabaseHelper.Instance.getData(query);
            while (reader.Read())
            {
                services.Add(new Service($"{reader["Type"]}", $"{reader["Description"]}", $"{reader["Technologies"]}", $"{reader["Services_involved"]}"));
            }
            return services;
        }
        public static void AddService(Service s)
        {
            string query = $"INSERT INTO Services VALUES ('{s.Type}', '{s.Description}', '{s.Technologies}', '{s.Services}')";
            DatabaseHelper.Instance.Update(query);
        }

        public static void EditService(Service s)
        {
            string query = $"UPDATE Services SET (Description,Technologies,Services) = ('{s.Description}', '{s.Technologies}','{s.Services}')  WHERE Type = '{s.Type}'";
            DatabaseHelper.Instance.Update(query);
        }

        public static void DeleteService(string type)
        {
            string query = $"DELETE FROM Services WHERE Type = '{type}'";
            DatabaseHelper.Instance.Update(query);
        }
              public static Service GetService(string type)
        {
            string query = $"SELECT * FROM Services WHERE Type = '{type}'";
            var reader = DatabaseHelper.Instance.getData(query);
            if (reader.Read())
            {
                return new Service($"{reader["Type"]}", $"{reader["Description"]}", $"{reader["Technologies"]}", $"{reader["Services_involved"]}");
            }
            return null;
        }
    }
}
