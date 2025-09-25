using System;
using System.Collections.Generic;

namespace OrderingSystem
{
    
    public class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public void PlaceOrder(ShoppingCart cart) {  }
        public void ViewOrderHistory() {  }
    }

    public class Product
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }

        public bool CheckAvailability() => Stock > 0;
    }

    public class ShoppingCart
    {
        public List<Product> Items { get; set; } = new List<Product>();

        public void AddProduct(Product product) => Items.Add(product);
        public void RemoveProduct(Product product) => Items.Remove(product);
        public float CalculateTotal()
        {
            float total = 0;
            foreach (var item in Items) total += item.Price;
            return total;
        }
    }

    public class Order
    {
        public int OrderID { get; set; }
        public List<Product> Items { get; set; }
        public float TotalPrice { get; set; }
        public string Status { get; set; }

        public void UpdateStatus(string status) => Status = status;
    }

    public class Payment
    {
        public string PaymentType { get; set; }
        public float Amount { get; set; }

        public void ProcessPayment() { /* logic */ }
        public bool ValidatePaymentInfo() => true;
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Online Ordering System Simulation");
            
            Product p1 = new Product { Name = "Laptop", Price = 1200, Stock = 10 };
            Product p2 = new Product { Name = "Mouse", Price = 25, Stock = 50 };

            ShoppingCart cart = new ShoppingCart();
            cart.AddProduct(p1);
            cart.AddProduct(p2);

            Console.WriteLine($"Total Cart Price: {cart.CalculateTotal()}");
        }
    }
}
