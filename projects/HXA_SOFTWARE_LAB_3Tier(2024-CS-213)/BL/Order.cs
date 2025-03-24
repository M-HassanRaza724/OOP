using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXA_SOFTWARE_LAB.BL
{
    // order record: orederer_id, type(service), platform, p_budget, time, description, status, revenue_generated, title(if present it is special project)

    public class Order
    {
        public int OrdererId { get; set; }
        public string Type { get; set; }
        public string Platform { get; set; }
        public int PBudget { get; set; }
        public string Time { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public double RevenueGenerated { get; set; }
        public string Title { get; set; }
        public Order(int ordererId, string type, string platform, int pBudget, string time, string description, bool status, double revenueGenerated, string title = null)
        {
            OrdererId = ordererId;
            Type = type;
            Platform = platform;
            PBudget = pBudget;
            Time = time;
            Description = description;
            Status = status;
            RevenueGenerated = revenueGenerated;
            Title = title;
        }
        public Order() { }
    }
   
}
