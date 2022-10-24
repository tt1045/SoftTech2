using System;
using System.Collections.Generic;


/// <summary>
/// Създаване на клас JuiceMachine (Director)
/// </summary>
class JuiceMachine
{
    // Изпълнението на инструкции стъпка по стъпка
    public void MakeJuice(JuiceMaker juiceMaker)
    {
        juiceMaker.SetWater();
        juiceMaker.SetFruit();
        juiceMaker.SetSugar();
    }
}

/// <summary>
/// Създаване на абстрактен клас JuiceMaker (Builder)
/// </summary>
abstract class JuiceMaker
{
    protected Juice juice;


    // Вземане на инстанция на Juice
    public Juice Juice
    {
        get { return juice; }
    }

    // Абстрактни методи за конструкция на продукта
    public abstract void SetWater();
    public abstract void SetFruit();
    public abstract void SetSugar();
}

/// <summary>
/// Създаване на клас MultivitaminJuiceMaker, наследяващ JuiceMaker (ConcreteBuilder1)
/// </summary>
class MultivitaminJuiceMaker : JuiceMaker
{
    public MultivitaminJuiceMaker()
    {
        juice = new Juice("Сок мултивитамин");
    }

    public override void SetWater()
    {
        juice["water"] = 160;
    }

    public override void SetFruit()
    {
        juice["fruit"] = 60;
    }

    public override void SetSugar()
    {
        juice["sugar"] = 20;
    }
}

/// <summary>
/// Създаване на клас OrangeJuiceMaker, наследяващ JuiceMaker (ConcreteBuilder2)
/// </summary>
class OrangeJuiceMaker : JuiceMaker
{
    public OrangeJuiceMaker()
    {
        juice = new Juice("Сок от портокал");
    }

    public override void SetWater()
    {
        juice["water"] = 150;
    }

    public override void SetFruit()
    {
        juice["fruit"] = 50;
    }

    public override void SetSugar()
    {
        juice["sugar"] = 10;
    }
}

/// <summary>
/// Създаване на клас BananaStrawberryJuiceMaker, наследяващ JuiceMaker (ConcreteBuilder3)
/// </summary>
class BananaStrawberryJuiceMaker : JuiceMaker
{

    public BananaStrawberryJuiceMaker()
    {
        juice = new Juice("Сок от банан и ягода");
    }

    public override void SetWater()
    {
        juice["water"] = 200;
    }

    public override void SetFruit()
    {
        juice["fruit"] = 45;
    }

    public override void SetSugar()
    {
        juice["sugar"] = 20;
    }
}

/// <summary>
/// Създаване на клас Juice (Product)
/// </summary>
class Juice
{
    private string _juiceName { get; set; }
    private Dictionary<string, int> _ingredients = new Dictionary<string, int>();

    // Конструктор
    public Juice(string juiceName)
    {
        this._juiceName = juiceName;
    }

    // Взимане/записване на стойност от/в масива
    public int this[string key]
    {
        get { return _ingredients[key]; }
        set { _ingredients[key] = value; }
    }

    // Метод Show(), връщащ какво съдържа сокът
    public String Show()
    {
        return "------ " + _juiceName + " ------\nВода: " + _ingredients["water"] + "мл.\nПлодове: " + _ingredients["fruit"] + "гр.\nЗахар: "
            + _ingredients["sugar"] + "гр.\n";
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
        // Създаване на Director и Builder
        JuiceMaker maker;
        JuiceMachine juiceMachine = new JuiceMachine();

        // Създаване на различни сокове и отпечатване в конзолата
        maker = new MultivitaminJuiceMaker();
        juiceMachine.MakeJuice(maker);
        Console.WriteLine(maker.Juice.Show());

        maker = new BananaStrawberryJuiceMaker();
        juiceMachine.MakeJuice(maker);
        Console.WriteLine(maker.Juice.Show());


        maker = new OrangeJuiceMaker();
        juiceMachine.MakeJuice(maker);
        Console.WriteLine(maker.Juice.Show());


        Console.ReadKey();
    }
}
