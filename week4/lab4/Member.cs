namespace lab4
{
    public class Member
    {
        public string Person { get; set; }
        public int MemberID { get; set; }
        public List<Book> Books { get; set; }
        public int BooksBought { get; set; }
        public float MoneyInBank { get; set; }
        public float AmountSpent { get; set; }
        public Member() { }
        public Member(string person, int memberID = 0)
        {
            Person = person;
            MemberID = memberID;
        }
        public Member(string person, float moneyInBank, int memberID = 0)
        {
            Person = person;
            MemberID = memberID;
            MoneyInBank = moneyInBank;
        }
        public string ShowName()
        {
            return Person;
        }
        public void UpdateName(string name)
        {
            Person = name;
        }
        public void UpdateID(int memberID)
        {
            MemberID = memberID;
        }
        public int TotalBooksBought()
        {
            return BooksBought;
        }
        public void UpdateBooksBought(int increment = 1)
        {
            BooksBought += increment;
        }
        public float TotalAmountSpent()
        {
            if (MemberID != 0)
                return AmountSpent;
            else return 0;
        }
        public void UpdateAmountSpent(int increment)
        {
            if (MemberID != 0)
            {
                if (BooksBought != 1 && BooksBought % 10 == 1)
                    AmountSpent = increment;
                else
                    BooksBought += increment;
            }
        }
        public void MemberInfo()
        {
            Console.WriteLine("Name :" + Person);
            Console.WriteLine($"Member Id: {MemberID}");
            Console.WriteLine($"BooksBought {BooksBought}");
            Console.WriteLine($"MoneyInBank {MoneyInBank}");
            Console.WriteLine("Books: ");
            foreach(Book book in Books)
                Console.WriteLine($"\t{book}");
        }





    }
}
