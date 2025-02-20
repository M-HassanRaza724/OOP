using System.Diagnostics;

namespace lab4
{
    public class Book
    {
        public string Title { get; set; }
        public List<string> Authors { get; set; }
        public string Publisher { get; set; }
        public int ISBN { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }
        public int PublicationYear { get; set; }

        public Book() { }
        public Book(string title, List<string> author, string publisher, int ISBN, float price, int stock, int publicationYear)
        {
            Title = title;
            Authors = author;
            Publisher = publisher;
            Stock = stock;
            PublicationYear = publicationYear;
            Authors = author;
            this.ISBN = ISBN;
        }
        public string ShowTitle()
        {
            return Title;
        }
        public void UpdateTitle(string title)
        {
            Title = title;
        }
        public bool CheckTitle(string title)
        {
            if (Title == title) return true;
            return false;
        }
        public int TotalStock()
        {
            return Stock;
        }
        public void UpdateStockNumber(int stock)
        {
            if(Stock+stock < 0)
            {
                Console.WriteLine("not Enought Stock Available!");
                return;
            }
            Stock += stock;
        }
        public int TotalAuthor()
        {
            return Authors.Count();
        }
        public void UpdateAuthor(string author, int authorNo)
        {
            Authors[authorNo - 1] = author;
        }
        public void ShowAllAuthors()
        {
            for (int i = 0; i < Authors.Count(); i++)
                Console.WriteLine($"{i + 1}) {Authors[i]}");
        }
        public int ShowISBN()
        {
            return ISBN;
        }
        public void UpdatePrice(int price)
        {
            Price = price;
        }
        public void BookInfo()
        {
            Console.WriteLine($"Title: {Title}\n");
            Console.WriteLine($"Authors:");
            foreach (string author in Authors){
                Console.WriteLine($"\t{author}");
            }
            Console.WriteLine($"Publisher: {Publisher}\n\n ISBN: {ISBN}\n\nPrice: {Price}\n\nStock: {Stock}\n\nPublicationYear: {PublicationYear}\n\n");
        }
    }
}
