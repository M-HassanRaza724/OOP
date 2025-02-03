namespace Week2Tasks
{
    class Program
    {
        //--------------------Task1----------------------
        //static void Main(string[] args)
        //{
        //    int lastStudentIdx = 0, choice = 0;
        //    Student[] students = new Student[5];
        //    while (choice != 5)
        //    {
        //        Console.WriteLine("---Student Management System---");
        //        choice = Menu();
        //        if (choice == 1)
        //        {
        //            Console.Write("Total entries to add: ");
        //            int entries = int.Parse(Console.ReadLine());
        //            for (int i = 0; i < entries; i++)
        //            {
        //                string name;
        //                float mMarks, fMarks, eMarks;
        //                Console.Write("Enter name: ");
        //                name = Console.ReadLine();
        //                Console.Write("Enter matric marks: ");
        //                mMarks = float.Parse(Console.ReadLine());
        //                Console.Write("Enter fsc marks: ");
        //                fMarks = float.Parse(Console.ReadLine());
        //                Console.Write("Enter ecat marks: ");
        //                eMarks = float.Parse(Console.ReadLine());
        //                add_students(students, ref lastStudentIdx, name, mMarks, fMarks, eMarks);
        //            }
        //        }
        //        else if (choice == 2)
        //        {
        //            Console.WriteLine("Name\tMatricMarks\tFScMarks\tECAT Marks\tAggregate");
        //            for (int i = 0; i < lastStudentIdx; i++)
        //                Console.WriteLine($"{students[i].name}\t\t{students[i].matricMarks}\t\t{students[i].fscMarks}\t\t{students[i].ecatMarks}\t\t{students[i].aggregate}");
        //        }
        //        else if (choice == 3)
        //        {
        //            for (int i = 0; i < lastStudentIdx; i++)
        //                students[i].aggCal();
        //        }
        //        else if (choice == 4)
        //        {
        //            int[] topstdIdxs = new int[3];
        //            topStdCal(students,lastStudentIdx, topstdIdxs);
        //            for (int i = 0; i < 3; i++)
        //                Console.WriteLine($"{students[topstdIdxs[i]].name}\t\t{students[topstdIdxs[i]].matricMarks}\t\t{students[topstdIdxs[i]].fscMarks}\t\t{students[topstdIdxs[i]].ecatMarks}\t\t{students[topstdIdxs[i]].aggregate}");
        //        }
        //        if (choice == 5) ;
        //        else
        //            Console.WriteLine("Invalid Choice...!");
        //        Console.ReadKey();
        //        Console.Clear();
        //    }
        //}
        //static void add_students(Student[] students, ref int lastStudent, string name, float mMarks, float fMarks, float eMarks)
        //{
        //    Student s = new Student(name, mMarks, fMarks, eMarks);
        //    students[lastStudent] = s;
        //    lastStudent = lastStudent + 1;
        //}
        //static void topStdCal(Student[] stds,int lastIdx,int[] topStdIdxs)
        //{
        //    float[] aggregate = new float[lastIdx];
        //    int maxIdx = 0;
        //    for (int i = 0; i < lastIdx; i++)
        //        aggregate[i] = stds[i].aggCal();
        //    for (int i = 0; i < 3; i++)
        //    {
        //        for (int j = 0; j < lastIdx; j++)
        //        {
        //            if (aggregate[maxIdx] < aggregate[j])
        //                maxIdx = j;
        //        }
        //        topStdIdxs[i] = maxIdx;
        //        aggregate[maxIdx] = 0.0F;
        //    }
        //}
        //static int Menu()
        //{
        //    Console.WriteLine("1. Add students.");
        //    Console.WriteLine("2. Show students.");
        //    Console.WriteLine("3. Calculate Aggregates");
        //    Console.WriteLine("4. Top stuedents.");
        //    Console.WriteLine("5. Exit");
        //    Console.WriteLine("Enter your Choice: ");
        //    int choice = int.Parse(Console.ReadLine());
        //    return choice;
        //}
        //-------------Task2-------------
        //static void Main(string[] args)
        //{
        //    int lastProductIdx = 0, choice = 0;
        //    Product[] products = new Product[5];
        //    while (choice != 4)
        //    {
        //        Console.WriteLine("---Product Management System---");
        //        choice = Menu();
        //        if (choice == 1)
        //        {
        //            Console.Write("Total entries to add: ");
        //            int entries = int.Parse(Console.ReadLine());
        //            for (int i = 0; i < entries; i++)
        //            {
        //                int id = 0;
        //                string name = "", category = "", brand = "", country = "";
        //                float price = 0.0F;
        //                Console.Write("Enter Id: ");
        //                id = int.Parse(Console.ReadLine());
        //                Console.Write("Enter name: ");
        //                name = Console.ReadLine();
        //                Console.Write("Enter Price: ");
        //                price = float.Parse(Console.ReadLine());
        //                Console.Write("Enter category: ");
        //                category = Console.ReadLine();
        //                Console.Write("Enter Brand: ");
        //                brand = Console.ReadLine();
        //                Console.Write("Enter Country: ");
        //                country = Console.ReadLine();
        //                add_Products(products, ref lastProductIdx, id, name, price, category, brand, country);
        //            }
        //        }
        //        else if (choice == 2)
        //        {
        //            Console.WriteLine("ID\tName\t\tPrice\t\tCategory\t\tBrand\tCountry");
        //            for (int i = 0; i < lastProductIdx; i++)
        //                Console.WriteLine($"{products[i].Id}\t{products[i].Name}\t\t{products[i].Price}\t\t{products[i].Category}\t\t{products[i].BrandName}\t\t{products[i].Country}");
        //        }
        //        else if (choice == 3)
        //        {
        //            Console.Write($"Total Worth is {totalWorth(products,lastProductIdx)}");
        //        }
        //        else if (choice != 4)
        //            Console.WriteLine("Invalid Choice...!");

        //        Console.ReadKey();
        //        Console.Clear();
        //    }
        //}
        //static float totalWorth(Product[] Products,int lastProduct)
        //{
        //    float total = 0F;
        //    for (int i = 0; i < lastProduct; i++)
        //        total += Products[i].Price;
        //    return total;
        //}
        //static void add_Products(Product[] Products, ref int lastProduct, int id, string name, float price, string category, string brand, string country)
        //{
        //    Product p = new Product(id, name, price, category, brand, country);
        //    Products[lastProduct] = p;
        //    lastProduct = lastProduct + 1;
        //}
        //static int Menu()
        //{
        //    Console.WriteLine("1. Add Products.");
        //    Console.WriteLine("2. Show Products.");
        //    Console.WriteLine("3. Total store worth.");
        //    Console.WriteLine("4. Exit");
        //    Console.WriteLine("Enter your Choice: ");
        //    int choice = int.Parse(Console.ReadLine());
        //    return choice;
        //}
        //------------------Task3-------------------
        static void Main(string[] args)
        {
            Console.WriteLine();
        }
    }
}