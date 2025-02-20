namespace ConsoleApp1
{
    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public float Price { get; set; }
        public int StockQuantity { get; set; }
        public int MinQuantity { get; set; }

        public Product()
        {
            StockQuantity = 0;
            MinQuantity = 10;
            Price = 0F;
        }
        public Product(string name, string category, float price, int stockQuantity, int minQuantity = 10)
        {
            Name = name;
            Category = category.ToLower();
            Price = price;
            StockQuantity = stockQuantity;
            MinQuantity = minQuantity;
        }
        public Product(Product P)
        {
            Name = P.Name;
            Category = P.Category;
            Price = P.Price;
            StockQuantity = P.StockQuantity;
            MinQuantity = P.MinQuantity;
        }
        public float TaxCalculator()
        {
            if (Category == "grocery")
                return Price * 0.1F;
            else if (Category == "fruit")
                return Price * 0.05F;
            else return Price * 0.15F;
        }
        public void PrintProduct()
        {
            Console.WriteLine($"{Name}\t\t{Category}\t\t{Price}\t\t{StockQuantity}\t\t{MinQuantity}");
        }
    }
}
