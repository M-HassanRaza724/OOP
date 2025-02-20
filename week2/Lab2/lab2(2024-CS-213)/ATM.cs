using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self_assesment
{
    public class ATM
    {
        public float balance;
        //Holds the record of transaction for particular ATM object only
        public string[] Transaction = new string[100];
        public int lastTransaction = 0;

        public ATM(float initial)
        {
            balance = initial;
        }

        public void deposit(float amount)
        {
            balance += amount;
            add_transaction( amount, "deposit");
        }
        public void withdraw(float amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                add_transaction(amount, "withdraw");
            }
            else
            {
                Console.WriteLine("Insufficient Balance");
            }
        }
        public float check_balance()
        {
            return balance;
        }
        public void add_transaction(float amount, string type)
        {
            Transaction[lastTransaction] = $"{lastTransaction}\t{amount}\t{type}.";
            lastTransaction++;
            Console.WriteLine($"{amount} is {type}.");
        }
        public void transaction_history()
        {
            Console.WriteLine("Transaction History:\nSr.\tAmount\tType");
            for (int i = 0; i < lastTransaction; i++)
            {
                Console.WriteLine(Transaction[i]);
            }
        }
    };
}
