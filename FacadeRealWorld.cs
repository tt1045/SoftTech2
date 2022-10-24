using System;

/// <summary>
/// Създаване на подсистемен клас ProductStocks (SubsystemClassA)
/// </summary>
class ProductStocks
{
    public bool ProductIsAvailable(Customer cstmr)
    {
        Console.WriteLine("Проверка на наличност за продукт с ID: " + cstmr.ProductId);
        return true;
    }
}

/// <summary>
/// Създаване на подсистемен клас Payment (SubsystemClassB)
/// </summary>
class Payment
{
    public bool PaymentIsConfirmed(Customer cstmr)
    {
        Console.WriteLine("Проверка на плащане от " + cstmr.Name) ;
        return true;
    }
}

/// <summary>
/// Създаване на подсистемен клас Customer (SubsystemClassC)
/// </summary>
class Customer
{
    private string _name;
    private int _productId;


    // Конструктор
    public Customer(string name, int productId)
    {
        this._name = name;
        this._productId = productId; 
    }

    // Вземане на името на клиента
    public string Name
    { get { return _name; } }

    // Вземане на ID на продукта
    public int ProductId
    { get { return _productId; } }
        
}

/// <summary>
/// Създаване на фасаден клас Order (Facade)
/// </summary>
class Order
{
    private ProductStocks _check1 = new ProductStocks();
    private Payment _check2 = new Payment();

    public bool IsCompleted(Customer cstmr)
    {
        Console.WriteLine("---- Онлайн поръчка ----\n");
        bool isCompleted = true;

        // Проверка за наличност на продукта и за потвърждение от плащането
        if (!_check1.ProductIsAvailable(cstmr))
        {
            isCompleted = false;
        }
        else if (!_check2.PaymentIsConfirmed(cstmr))
        {
            isCompleted = false;
        }

        return isCompleted;
    }
}

/// <summary>
/// MainApp клас
/// </summary>
class MainApp
{
    /// <summary>
    /// Начало на конзолното приложение
    /// </summary>
    public static void Main()
    {
        // Фасада
        Order order = new Order();

        // Проверки за поръчката
        Customer cstmr = new Customer("Иван Георгиев", 13);
        bool completed = order.IsCompleted(cstmr);

        // Отпечатване в конзолата
        Console.WriteLine("\nПоръчка на името на " + cstmr.Name + (completed ? " е завършена успешно!" : "е неуспешна! Опитайте пак."));

        Console.ReadKey();
    }
}
