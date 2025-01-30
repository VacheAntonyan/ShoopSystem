using System.Xml;

Shop shop = new Shop("Sumper Market",1000);

Console.WriteLine($"                    Welcome {shop.Name}");
int option = 0;
while(true)
{
    Console.WriteLine("1: Admin | 2: User | 3: Exit");
    int position = int.Parse(Console.ReadLine());

    if (position == 1) 
    {
        Console.WriteLine("Admin options:");
        Console.WriteLine($"1: Add Product | 2: Show Products | 3: Show {shop.Name}'s balance | 4: Remove Product | 5: Exit to Main Menu ");
        int adminChoice = int.Parse(Console.ReadLine());

        if (adminChoice == 1)
        {
            shop.GetProductForShop();
        }
        else if (adminChoice == 2)
        {
            shop.ShowProducts();
        }
        else if(adminChoice == 3)
        {
            Console.WriteLine($"Shop's balance: {shop.Balance}");
        }else if(adminChoice == 4)
        {
            Console.WriteLine("Enter the product's id for delete");
            int idP = int.Parse(Console.ReadLine());
            shop.RemoveProduct(idP);
        }
        else if (adminChoice == 5)
        {
            continue;
        }
        else
        {
            Console.WriteLine("Invalid option. Try again.");
        }
    }
    else if (position == 2) 
    {
        Console.WriteLine("User options:");
        Console.WriteLine("1: Show Products | 2: Buy Product | 3: Exit to Main Menu");
        int userChoice = int.Parse(Console.ReadLine());

        if (userChoice == 1)
        {
            shop.ShowProducts();
        }
        else if (userChoice == 2)
        {
            Console.WriteLine("Enter the product name you want to buy:");
            string productName = Console.ReadLine();

            shop.BuyProduct(productName);
        }
        else if (userChoice == 3)
        {
            continue;
        }
        else
        {
            Console.WriteLine("Invalid option. Try again.");
        }
    }
    else if (position == 3) 
    {
        Console.WriteLine("Exiting the program...");
        break;
    }
    else
    {
        Console.WriteLine("Invalid option. Please choose 1, 2, or 3.");
    }
}
    
class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity {  get; set; }
    public Product(int id,string name,decimal price,int quantity)
    {
        Id = id;
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}

class Admin
{
    public string Position { get; set; }
}
interface IShopWorkingUser
{
    void BuyProduct(string name);
    void ShowProducts();
}

interface IShopWorkingAdmin
{
    void GetProductForShop();
    void RemoveProduct(int idP);
}

class Shop : IShopWorkingUser, IShopWorkingAdmin
{
    private List<Product> _products = new List<Product>();
    public string Name { get; set; }
    public decimal Balance {  get; set; }
    public Shop(string name,decimal balance) 
    {
        Name = name;
        Balance = 1000;
    }

    public void BuyProduct(string name)
    {
        foreach (Product product in _products)
        {
            if(product.Name == name)
            {
                Console.WriteLine($"Product founded: Product's price. {product.Price}");
                Console.WriteLine("How many you wont buy");
                int quant = int.Parse(Console.ReadLine());
                if(product.Quantity > quant)
                {
                    Console.WriteLine($"You will pay: {quant * product.Price}");
                    Console.Write("Pay for product: ");
                    decimal amount = decimal.Parse(Console.ReadLine());
                    if(amount > product.Price)
                    {
                        decimal change = amount - product.Price * quant;
                        Console.WriteLine($"Take Your change: {change}");
                        Balance += product.Price * quant;
                        product.Quantity = product.Quantity - quant;
                        Console.WriteLine("     Thank you for purchuse take your chek");
                        Thread.Sleep(5000);
                        Console.WriteLine("                          Thank you for purchuse");
                        Console.WriteLine("\n\n\n");
                        Console.WriteLine($"Product Name: {product.Name} |Quantity: {quant}- Price: {product.Price * quant}");
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough money");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine($"Sorry, we only have {product.Quantity} in stock.");
                }
            }
            else
            {
                Console.WriteLine("Product doesn't founded");
            }
        }
    }

    public void ShowProducts()
    {
        foreach(Product product in _products)
        {
            Console.WriteLine($"Product's Id: {product.Id} | Product's Name: {product.Name} | Product's Price: {product.Price} | Product's Quantity: {product.Quantity}");
        }
    }

    public void GetProductForShop()
    {
        Console.WriteLine("Enter Product's id");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter product's name");
        string name = Console.ReadLine();
        Console.WriteLine("Enter product's price");
        decimal price = decimal.Parse(Console.ReadLine());
        Console.WriteLine("Enter the product's quantity");
        int quantity = int.Parse(Console.ReadLine());
        Product newProduct = new Product(id,name,price,quantity);
        _products.Add(newProduct);
    }

    public void RemoveProduct(int idP)
    {
        foreach (Product product in _products)
        {
            if(product.Id == idP)
            {
                _products.Remove(product);
                Console.WriteLine("Product deleted");
                break;
            }
            else
            {
                Console.WriteLine("Product doesn't founded");
            }
        }
    }
}

