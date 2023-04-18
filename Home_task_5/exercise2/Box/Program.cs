namespace Box
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var storeBox = new Box("Store", 100, 100, 100);
            var product1 = new Product { Name = "Apple", DepartmentPath = "Fruits", Width = 5, Height = 5, Depth = 5 };
            var product2 = new Product { Name = "Milk", DepartmentPath = "Dairy/Fresh", Width = 10, Height = 10, Depth = 10 };
            var product3 = new Product { Name = "Bread", DepartmentPath = "Bakery", Width = 15, Height = 15, Depth = 15 };
            List<Product> products = new List<Product>();
            products.Add(product1);
            products.Add(product2);
            products.Add(product3);

            storeBox.ConsoleReading();

            storeBox.BoxPacking(products);
            
            storeBox.Print();
        }
    }
}