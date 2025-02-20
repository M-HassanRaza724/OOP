using ConsoleApp1;
/*
==========TASK(WP)========== 

ClockType emptyTime = new ClockType();
ClockType hourTime = new ClockType(5);
ClockType minuteTime = new ClockType(5, 30);
ClockType fullTime = new ClockType(5, 30, 40);

Console.WriteLine("Empty Time ");
emptyTime.ShowTime();

Console.WriteLine("Hour Time ");
hourTime.ShowTime();
Console.WriteLine("Min Time ");
minuteTime.ShowTime();
Console.WriteLine("Full Time ");
fullTime.ShowTime();

fullTime.IncrementSec();
Console.WriteLine("Second increment ");
fullTime.ShowTime();

fullTime.IncrementMin();
Console.WriteLine("Minute increment ");
fullTime.ShowTime();

fullTime.IncrementHour();
Console.WriteLine("Hour increment ");
fullTime.ShowTime();
bool flag;
flag = fullTime.IsEqual(5, 30, 40);
Console.WriteLine($"Flag is {flag}");

ClockType newTime = new ClockType(3, 30, 40);
flag = fullTime.IsEqual(newTime);
Console.WriteLine($"Flag is {flag}");
 */

/*
==========Challenge 1==========
ClockType Time = new ClockType(24, 00, 00);
Console.WriteLine($"Elapsed Time is {Time.ElapsedTime()}");
Console.WriteLine($"Remaining Time is {Time.RemainingTime()}");
 */

//========== Challenge 2 ==========

int Choice = Menu();
List<Product> Products = new List<Product>();


while (Choice != 6)
{
    switch (Choice)
    {
        case 1:
            string name = "", category = "";
            float price = 0.0F;
            int quantity = 0, threshold = 0;
            Console.Write("Enter name: ");
            name = Console.ReadLine();
            Console.Write("Enter category: ");
            category = Console.ReadLine();
            Console.Write("Enter Price: ");
            price = float.Parse(Console.ReadLine());
            Console.Write("Enter Quantity: ");
            quantity = int.Parse(Console.ReadLine());
            Console.Write("Enter minimum threshold value: ");
            threshold = int.Parse(Console.ReadLine());

            AddProducts(name, price, category, quantity, threshold, Products);
            break;
        case 2:
            Console.WriteLine("Name\t\tCategory\tPrice\t\tStockQuantity\t\tMinQuantity\t\t");
            foreach (Product P in Products)
                P.PrintProduct();
            break;
        case 3:
            Console.WriteLine("Name\t\tCategory\tPrice\t\tStockQuantity\t\tMinQuantity\t\t");
            (HighestPricedProduct(Products)).PrintProduct();
            break;
        case 4:
            Console.WriteLine("Name\t\tCategory\tPrice\t\tSalesTax");
            foreach (Product P in Products)
                Console.WriteLine($"{P.Name}\t\t{P.Category}\t\t{P.Price}\t\t{P.TaxCalculator()}");
            break;
        case 5:
            Console.WriteLine("Name\t\tCategory\tPrice\t\tStockQuantity\t\tMinQuantity\t\t");
            foreach (Product P in Products)
                if (P.MinQuantity > P.StockQuantity)
                    P.PrintProduct();
            break;
    }
    Console.ReadKey();
    Console.Clear();
    Choice = Menu();
}
static int Menu()
{
    Console.WriteLine("1● Add Product. ");
    Console.WriteLine("2● View All Product.");
    Console.WriteLine("3● Find Product with the Highest Unit Price");
    Console.WriteLine("4● View Sales Tax of All Products.");
    Console.WriteLine("5● Products to be Ordered.");
    Console.WriteLine("6● Exit.");
    Console.Write("Enter Your choice: ");
    return int.Parse(Console.ReadLine());
}
static void AddProducts(string name, float price, string category, int quantity, int threshold, List<Product> Products)
{
    if(name != null && category != null)
    {
        Product P = new Product(name, category, price, quantity, threshold);
        Products.Add(P);
    }
}

static Product HighestPricedProduct(List<Product> products)
{
    Product MaxPriceProduct = new Product();
    foreach (Product product in products)
    {
        if (product.Price > MaxPriceProduct.Price)
        {
            MaxPriceProduct = product;
        }
    }
    return MaxPriceProduct;
}

