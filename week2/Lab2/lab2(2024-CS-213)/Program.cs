using System;
using System.ComponentModel.Design;
using System.Runtime.ExceptionServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace self_assesment
{
    class Program
    {
    
        static void Main(string[] args)
        {
            //------------ss1----------------
                //First object creation
            Transaction t1 = new Transaction();
            t1.TransactionId = 1;
            t1.ProductName = "Diamond";
            t1.Amount = 1000F;
            t1.Date = "13/4/2024";
            t1.Time = "08:30";
                //Second object with copy constructor
            Transaction t2 = new Transaction(t1);
                //Changes in both objects
            t1.Amount = 10000F;
            t2.ProductName = "Gold";

            t1.show_att();
            t2.show_att();

            Console.WriteLine("\n");
            //------------ss2----------------
            Calculator c1 = new Calculator(6.7F, 3.3F);

            Console.WriteLine($"Sum is {c1.add()}");
            Console.WriteLine($"subtraction is {c1.sub()}");
            Console.WriteLine($"multiplycation is {c1.mul()}");
            Console.WriteLine($"Division is {c1.quotient()}");


            Console.WriteLine("\n");
            //------------ss3----------------
            ATM a1 = new ATM(100F);

            Console.WriteLine($"your balance is {a1.check_balance()}.");

            a1.deposit(50F);
            Console.WriteLine($"your balance is {a1.check_balance()}.");

            a1.withdraw(75F);
            Console.WriteLine($"your balance is {a1.check_balance()}.");

            a1.transaction_history();

            Console.WriteLine("\n");
        }

    }
}