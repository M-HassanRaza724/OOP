using System;

namespace self_assesment
{
    public class Transaction
    {

        public int TransactionId;
        public string ProductName;
        public float Amount;
        public string Date;
        public string Time;

        public Transaction() { }

        public Transaction(Transaction transaction)
        {
            TransactionId = transaction.TransactionId;
            ProductName = transaction.ProductName;
            Amount = transaction.Amount;
            Date = transaction.Date;
            Time = transaction.Time;
        }
        public void show_att()
        {

            Console.WriteLine($"Transaction ID: {TransactionId}");
            Console.WriteLine($"ProductName: {ProductName}");
            Console.WriteLine($"Amount: {Amount}");
            Console.WriteLine($"Date: {Date}");
            Console.WriteLine($"Time: {Time}");
        }
    };

}