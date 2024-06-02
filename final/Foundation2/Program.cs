using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("232 Maria St", "Milwaukee", "WI", "USA");
        Customer customer1 = new Customer("Jessica Love", address1);

        Product product1 = new Product("Laptop", "24560", 500.00, 1);
        Product product2 = new Product("Case", "92524", 45.00, 1);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Address address2 = new Address("892 Hollow Ave", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Allison Laurent", address2);

        Product product3 = new Product("Book", "29755", 25.00, 3);
        Product product4 = new Product("Highlighters", "92759", 10.00, 1);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);

        Console.WriteLine($"Order1 Total Cost: ${order1.GetTotalCost()}");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();

        Console.WriteLine($"Order2 Total Cost: ${order2.GetTotalCost()}");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());

    }
}