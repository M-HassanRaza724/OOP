using week2;

namespace HXA_SOFTWARE_LAB
{
    public class Service
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public string Technologies { get; set; }
        public string Services { get; set; }
    
        public Service(string type, string description, string services, string technologies = null) 
        {
            Type = type;
            Description = description;
            Services = services;
            Technologies = technologies;
        }
        public Service() { }
        public void AddService()
        {
            string query = $"INSERT INTO Services VALUES ('{Type}', '{Description}', '{Technologies}', '{Services}')";
            DatabaseHelper.Instance.Update(query);
        }

        public void EditService()
        {
            string query = $"UPDATE Services SET (Description,Technologies,Services) = ('{Description}', '{Technologies}','{Services}')  WHERE Type = '{Type}'";
            DatabaseHelper.Instance.Update(query);
        }

        public void DeleteService()
        {
            string query = $"DELETE FROM Services WHERE Type = '{Type}'";
            DatabaseHelper.Instance.Update(query);
        }
        public bool SearchService()
        {
            string query = $"SELECT * FROM Services WHERE Type = '{Type}'";
            var reader = DatabaseHelper.Instance.getData(query);
            if (reader.Read())
            {
                Console.WriteLine($"\n{reader["Type"]}\n\t{reader["Description"]}\n\t{reader["Technologies"]}\n\t{reader["Services"]}\n");
                return true;
            }
            Console.WriteLine("Service not found...!");
            return false;
        }
        public void ShowServices()
        {
            string query = "SELECT * FROM Services";
            var reader = DatabaseHelper.Instance.getData(query);
            for (int i = 1; reader.Read();i++)
                Console.WriteLine($"{i}. {reader["Type"]}\n{reader["Description"]}\n{reader["Technologies"]}\n{reader["Services"]}\n");
        }

    }
}
