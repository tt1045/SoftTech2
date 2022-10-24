using System;

/// <summary>
/// Създаване на абстрактен клас Mediator
/// </summary>
abstract class Mediator
{
    // Изпраща съобщение до Colleague обект
    public abstract void Send(string message,
        Colleague colleague);
}

/// <summary>
/// Създаване на клас ConcreteMediator, наследяващ Mediator
/// </summary>
class ConcreteMediator : Mediator
{
    private ConcreteColleague1 _colleague1;
    private ConcreteColleague2 _colleague2;

    public ConcreteColleague1 Colleague1
    {
        set { _colleague1 = value; }
    }

    public ConcreteColleague2 Colleague2
    {
        set { _colleague2 = value; }
    }

    public override void Send(string message,
        Colleague colleague)
    {
        if (colleague == _colleague1)
        {
            _colleague2.Notify(message);
        }
        else
        {
            _colleague1.Notify(message);
        }
    }
}

/// <summary>
/// Създаване на абстрактен клас Colleague
/// </summary>
abstract class Colleague
{
    protected Mediator mediator;

    // Constructor
    public Colleague(Mediator mediator)
    {
        this.mediator = mediator;
    }
}

/// <summary>
/// Създаване на клас ConcreteColleague1, наследяващ Colleague
/// </summary>
class ConcreteColleague1 : Colleague
{
    // Конструктор
    public ConcreteColleague1(Mediator mediator)
        : base(mediator)
    {
    }

    public void Send(string message)
    {
        mediator.Send(message, this);
    }

    public void Notify(string message)
    {
        Console.WriteLine("Colleague1 получава съобщение: "
            + message);
    }
}

/// <summary>
/// Създаване на клас ConcreteColleague2, наследяващ Colleague
/// </summary>
class ConcreteColleague2 : Colleague
{
    // Конструктор
    public ConcreteColleague2(Mediator mediator)
        : base(mediator)
    {
    }

    public void Send(string message)
    {
        mediator.Send(message, this);
    }
            
    public void Notify(string message)
    {
        Console.WriteLine("Colleague2 получава съобщение: "
            + message);
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
    static void Main()
    {
        // Създава ConcreteMediator
        ConcreteMediator m = new ConcreteMediator();

        // Създава участниците
        ConcreteColleague1 c1 = new ConcreteColleague1(m);
        ConcreteColleague2 c2 = new ConcreteColleague2(m);

        m.Colleague1 = c1;
        m.Colleague2 = c2;

        // Изпращане на съобщения от двамата участници
        c1.Send("Как си?");
        c2.Send("Добре, благодаря.");

        Console.ReadKey();
    }
}
