using System.Transactions;
using lab4;

List<Book> Books = new List<Book>()
{
    new Book("Demotitle",new List<string> {"author1","author2"},"DemoPublisher",123456789,10F,100,2024),
    new Book("Demo2title",new List<string> {"author12","author22"},"Demo2Publisher",123456789,10F,100,2025)
};
List<Member> Members = new List<Member>()
{
    new Member("Hassan",1),new Member("umer"),new Member("saad",2),new Member("Amir",3)
};

int Choice = Menu();
while(Choice != 10)
{
    switch (Choice)
    {
        case 1:
            string title, publisher;
            int ISBN, copies, publicationYear;
            float price;
            List<string> authors;
            Console.Write("Enter Book Title: ");
            title = Console.ReadLine();
            Console.Write("Enter Book Publisher: ");
            publisher = Console.ReadLine();
            Console.Write("Enter Book publication year: ");
            publicationYear = int.Parse(Console.ReadLine());
            Console.Write("Enter Book ISBN number: ");
            ISBN = int.Parse(Console.ReadLine());
            Console.Write("Enter Book price: ");
            price = float.Parse(Console.ReadLine());
            Console.Write("Enter total number of book copies: ");
            copies = int.Parse(Console.ReadLine());
            authors = ListInput("author");
            AddBook(title, authors, publisher, ISBN, price, copies, publicationYear, Books);
            break;
        case 2:
            Console.Write("Enter Book Title: ");
            title = Console.ReadLine();
            int idx = SearchByTitle(title, Books);
            if (idx != -1)
                Books[idx].BookInfo();
            else Console.WriteLine("Book not found ...!");
            break;
        case 3:
            Console.Write("Enter Book ISBN: ");
            ISBN = int.Parse(Console.ReadLine());
            idx = SearchByISBN(ISBN, Books);
            if (idx != -1)
                Books[idx].BookInfo();
            else Console.WriteLine("Book not found ...!");
            break;
        case 4:
            Console.Write("Enter Book Title: ");
            string input = Console.ReadLine();
            idx = SearchByTitle(input, Books);
            if (idx != -1)
                idx = SearchByISBN(int.Parse(input), Books);
            if (idx != -1)
            {
                Books[idx].BookInfo();
                Console.WriteLine("Enter 1 to update stock: ");
                if (int.Parse(Console.ReadLine()) == 1)
                {
                    Console.Write("Increse or decrese Stock by: ");
                    Books[idx].UpdateStockNumber(int.Parse(Console.ReadLine()));
                }
            }
            else
                Console.WriteLine("Book not found ...!");
            break;
        case 5:
            int memberId;
            string memberName;
            Console.Write("Enter Member Name: ");
            memberName = Console.ReadLine();
            Console.Write("Enter Member ID (0 for ocassional customer): ");
            memberId = int.Parse(Console.ReadLine());
            AddMember(memberName, memberId, Members);
            break;
        case 6:
            Console.Write("Enter Member Name or ID: ");
            input = Console.ReadLine();
            idx = SearchByName(input, Members);
            if (idx != -1)
                idx = SearchByID(int.Parse(input), Members);
            if (idx != -1)
                Members[idx].MemberInfo();
            else
                Console.WriteLine("Member not found ...!");
            break;
        case 7:
            Console.Write("Enter Member Name or ID: ");
            input = Console.ReadLine();
            idx = SearchByName(input, Members);
            if (idx != -1)
                idx = SearchByID(int.Parse(input), Members);
            if (idx != -1)
            {
                Console.WriteLine("Enter new name: ");
                Members[idx].UpdateName(Console.ReadLine());
                Console.WriteLine("Enter new ID: ");
                Members[idx].UpdateID(int.Parse(Console.ReadLine()));
            }
            else
                Console.WriteLine("Member not found ...!");
            break;
        case 8:
            Console.Write("Enter Member Name: ");
            memberName = Console.ReadLine();
            Console.Write("Enter Member ID (0 for ocassional customer): ");
            memberId = int.Parse(Console.ReadLine());
            idx = SearchByName(memberName, Members);
            if(idx != -1)
            {
                Console.WriteLine("Select a Book: ");
                for(int i = 0; i < Books.Count();i++)
                {
                    Console.WriteLine($"{i+1}) {Books[i].Title} by {Books[i].Authors[0]}...");
                }
                Console.WriteLine($"Enter 1-{Books.Count()}: ");
                int bookPurchaseIdx = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Quantity: ");
                int bookPurchaseQuantity = int.Parse(Console.ReadLine());


                if (Members[idx].MemberID == 0)
            }
            break;
        case 9:
            break;

    }
    Choice = Menu();
}

static int Menu()
{
    Console.WriteLine("1) Add a Book:");
    Console.WriteLine("2) Search book by Title");
    Console.WriteLine("3) Search book by ISBN");
    Console.WriteLine("4) Update Stock of a Book");
    Console.WriteLine("5) Add a Member");
    Console.WriteLine("6) Search for a Member by Name or ID");
    Console.WriteLine("7) Update Member Information");
    Console.WriteLine("8) Purchase a Book");
    Console.WriteLine("9) Display Total Sales and Membership Stats");
    Console.WriteLine("10) Exit"); 


    Console.Write("Enter your choice: ");
    return int.Parse(Console.ReadLine());
}
static void Purchase(Member member,Book book,int quantity,float revenue)
{
    if(member.MemberID == 0)
    {
        member.Books.Add(book);
        revenue += (book.Price)*quantity;
    }
    else
    {
        member.Books.Add(book);
    }
}
static void AddBook(string title, List<string> author, string publisher, int ISBN, float price, int copies, int publicationYear,List<Book> books)
{
    Book book = new Book(title,author,publisher,ISBN,price,copies,publicationYear);
    books.Add(book);
}
static void AddMember(string memberName,int memberID,List<Member> members)
{
    Member member = new Member(memberName,memberID);
    members.Add(member);
}
static int SearchByTitle(string title, List<Book> books)
{
    for (int i = 0; i < books.Count(); i++)
        if (books[i].Title == title) return i;
    return -1;
}
static int SearchByISBN(int ISBN, List<Book> books)
{
    for (int i = 0; i < books.Count(); i++)
    {
        if (books[i].ISBN == ISBN) return i;
    }
    return -1;
}
static int SearchByName(string Name, List<Member> Members)
{
    for (int i = 0; i < Members.Count(); i++)
        if (Members[i].Person == Name) return i;
    return -1;
}
static int SearchByID(int ID, List<Member> Members)
{
    for (int i = 0; i < Members.Count(); i++)
    {
        if (Members[i].MemberID == ID) return i;
    }
    return -1;
}
static List<string> ListInput(string elementName)
{
    List<string> list = new List<string>();
    Console.Write($"Enter total number of {elementName}: ");
    int length = int.Parse(Console.ReadLine());
    for (int i = 1;i <= length; i++)
    {
        Console.Write($"Enter {elementName} {i}: ");
        string element = Console.ReadLine();
        list.Add(element);
    }
    return list;
}
static void MemberPurchase()
{

}