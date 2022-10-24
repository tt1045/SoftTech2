using System;
using System.Collections.Generic;


/// <summary>
/// Създаване на Director клас
/// </summary>
class Director
{
    // Builder използва сложна последователност от стъпки
    public void Construct(Builder builder)
    {
        builder.BuildPartA();
        builder.BuildPartB();
    }
}

/// <summary>
/// Създаване на абстрактен клас Builder
/// </summary>
abstract class Builder
{
    //Абстрактни методи за създаване на продукта
    public abstract void BuildPartA();
    public abstract void BuildPartB();
    //Абстрактен метод, който ще връща продукта
    public abstract Product GetResult();
}

/// <summary>
/// Създаване на ConcreteBuilder2 клас
/// </summary>
class ConcreteBuilder1 : Builder
{
    private Product _product = new Product();

    public override void BuildPartA()
    {
        _product.Add("ЧастА");
    }

    public override void BuildPartB()
    {
        _product.Add("ЧастБ");
    }

    public override Product GetResult()
    {
        return _product;
    }
}

/// <summary>
/// Създаване на ConcreteBuilder2 клас
/// </summary>
class ConcreteBuilder2 : Builder
{
    private Product _product = new Product();

    public override void BuildPartA()
    {
        _product.Add("ЧастХ");
    }

    public override void BuildPartB()
    {
        _product.Add("ЧастУ");
    }

    public override Product GetResult()
    {
        return _product;
    }
}

/// <summary>
/// Създаване на Product клас
/// </summary>
class Product
{
    private List<string> _parts = new List<string>();

    public void Add(string part)
    {
        _parts.Add(part);
    }

    public void Show()
    {
        Console.WriteLine("\nЧасти на продукт -------");
        foreach (string part in _parts)
            Console.WriteLine(part);
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
        // Създаване на Director и Builder-и
        Director director = new Director();

        Builder b1 = new ConcreteBuilder1();
        Builder b2 = new ConcreteBuilder2();

        // Конструиране на продукти и отпечатване в конзолата
        director.Construct(b1);
        Product p1 = b1.GetResult();
        p1.Show();

        director.Construct(b2);
        Product p2 = b2.GetResult();
        p2.Show();

        Console.ReadKey();
    }
}
