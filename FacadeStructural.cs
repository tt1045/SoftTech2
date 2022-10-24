using System;

/// <summary>
/// Подсистемен клас 1 (SubsystemClass1)
/// </summary>
class SubSystemOne
{
    public void MethodOne()
    {
        Console.WriteLine(" Подсистема1 метод ");
    }
}

/// <summary>
/// Подсистемен клас 2 (SubsystemClass2)
/// </summary>
class SubSystemTwo
{
    public void MethodTwo()
    {
        Console.WriteLine(" Подсистема2 метод ");
    }
}

/// <summary>
/// Подсистемен клас 3 (SubsystemClass3)
/// </summary>
class SubSystemThree
{
    public void MethodThree()
    {
        Console.WriteLine(" Подсистема3 метод ");
    }
}

/// <summary>
/// Подсистемен клас 4 (SubsystemClass4)
/// </summary>
class SubSystemFour
{
    public void MethodFour()
    {
        Console.WriteLine(" Подсистема4 метод ");
    }
}

/// <summary>
/// Facade клас
/// </summary>
class Facade
{
    private SubSystemOne _one;
    private SubSystemTwo _two;
    private SubSystemThree _three;
    private SubSystemFour _four;

    public Facade()
    {
        _one = new SubSystemOne();
        _two = new SubSystemTwo();
        _three = new SubSystemThree();
        _four = new SubSystemFour();
    }

    public void MethodA()
    {
        Console.WriteLine("\nМетодА() ---- ");
        _one.MethodOne();
        _two.MethodTwo();
        _four.MethodFour();
    }

    public void MethodB()
    {
        Console.WriteLine("\nМетодБ() ---- ");
        _two.MethodTwo();
        _three.MethodThree();
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
        Facade facade = new Facade();

        facade.MethodA();
        facade.MethodB();

        // Изчакване за натискане на бутон от потребителя
        Console.ReadKey();
    }
}