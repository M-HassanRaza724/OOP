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
        public string OrderId { get; set; }
        public string Type { get; set; }
        public string Platform { get; set; }
        public string PBudget { get; set; }
        public string Time { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public enum OrderStatus { Uncompleted, Completed }
        public double RevenueGenerated { get; set; }
        public string Title { get; set; }

        public Order(string orderId, string type, string platform, string pBudget, string time, string description, string status, double revenueGenerated, string title = null)
        {
            OrderId = orderId;
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
        public string GetOrderId()
        {
            return OrderId;
        }
        public string GetOrdererEmail()
        {
            return OrderId.Split('_')[1];
        }

        public string GetType()
        {
            return Type;
        }
        public string GetPlatform()
        {
            return Platform;
        }
        public string GetPBudget()
        {
            return PBudget;
        }
        public string GetTime()
        {
            return Time;
        }
        public string GetDescription()
        {
            return Description;
        }
        public string GetStatus()
        {
            return Status;
        }
        public double GetRevenueGenerated()
        {
            return RevenueGenerated;
        }
    }
   
}
