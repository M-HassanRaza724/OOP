using HXA_SOFTWARE_LAB.DL;

namespace HXA_SOFTWARE_LAB.BL
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


    }
}
