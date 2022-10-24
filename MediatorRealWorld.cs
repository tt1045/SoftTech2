using System;

/// <summary>
/// Създаване на абстрактен клас за центъра за комуникация между светофарите (Mediator)
/// </summary>
abstract class AbstractTrafficLightHub
{
    public abstract void Send(string message,
        TrafficLight trafficLight);
}

/// <summary>
/// Създаване на клас TrafficLightHub, който наследява абстрактния AbstractTrafficLightHub (ConcreteMediator)
/// </summary>
class TrafficLightHub : AbstractTrafficLightHub
{
    private TrafficLight1 _trafficLight1;
    private TrafficLight2 _trafficLight2;
    private TrafficLight3 _trafficLight3;
    private TrafficLight4 _trafficLight4;

    public TrafficLight1 TrafficLight1
    {
        set { _trafficLight1 = value; }
    }

    public TrafficLight2 TrafficLight2
    {
        set { _trafficLight2 = value; }
    }

    public TrafficLight3 TrafficLight3
    {
        set { _trafficLight3 = value; }
    }

    public TrafficLight4 TrafficLight4
    {
        set { _trafficLight4 = value; }
    }

    public override void Send(string message,
        TrafficLight trafficLight)
    {

        if (trafficLight == _trafficLight1)
        {
            _trafficLight2.Notify(message);
        }
        else if (trafficLight == _trafficLight2)
        {
            _trafficLight3.Notify(message);
        }
        else if (trafficLight == _trafficLight3)
        {
            _trafficLight4.Notify(message);
        }
        else
        {
            _trafficLight1.Notify(message);
        }

    }
}

/// <summary>
/// Създаване на абстрактен клас за светофарите (AbstractColleague)
/// </summary>
abstract class TrafficLight
{
    protected AbstractTrafficLightHub trafficLightHub;

    // Конструктор
    public TrafficLight(AbstractTrafficLightHub trafficLightHub)
    {
        this.trafficLightHub = trafficLightHub;
    }
}

/// <summary>
/// Създаване на клас TrafficLight1, който наследява абстрактния TrafficLight (ConcreteColleague1)
/// </summary>
class TrafficLight1 : TrafficLight
{
    // Конструктор
    public TrafficLight1(AbstractTrafficLightHub trafficLightHub)
        : base(trafficLightHub)
    {
    }

    public void Send(string message)
    {
        trafficLightHub.Send(message, this);
    }

    public void Notify(string message)
    {
        if (message == "Червено")
        {
            Console.WriteLine("Светофар 1 получи съобщение: ВКЛЮЧИ ЗЕЛЕНО");
        }
        else
        {
            Console.WriteLine("Светофар 1 получи съобщение: " + message);
        }
    }
}

/// <summary>
/// Създаване на клас TrafficLight2, който наследява абстрактния TrafficLight (ConcreteColleague2)
/// </summary>
class TrafficLight2 : TrafficLight
{
    // Конструктор
    public TrafficLight2(AbstractTrafficLightHub trafficLightHub)
        : base(trafficLightHub)
    {
    }

    public void Send(string message)
    {
        trafficLightHub.Send(message, this);
    }

    public void Notify(string message)
    {
        if (message == "Червено")
        {
            Console.WriteLine("Светофар 2 получи съобщение: ВКЛЮЧИ ЗЕЛЕНО");
        }
        else
        {
            Console.WriteLine("Светофар 2 получи съобщение: " + message);
        }
    }
}

/// <summary>
/// Създаване на клас TrafficLight3, който наследява абстрактния TrafficLight (ConcreteColleague3)
/// </summary>
class TrafficLight3 : TrafficLight
{
    // Конструктор
    public TrafficLight3(AbstractTrafficLightHub trafficLightHub)
        : base(trafficLightHub)
    {
    }

    public void Send(string message)
    {
        trafficLightHub.Send(message, this);
    }

    public void Notify(string message)
    {
        if (message == "Червено")
        {
            Console.WriteLine("Светофар 3 получи съобщение: ВКЛЮЧИ ЗЕЛЕНО");
        }
        else
        {
            Console.WriteLine("Светофар 3 получи съобщение: " + message);
        }
    }
}

/// <summary>
/// Създаване на клас TrafficLight4, който наследява абстрактния TrafficLight (ConcreteColleague4)
/// </summary>
class TrafficLight4 : TrafficLight
{
    // Конструктор
    public TrafficLight4(AbstractTrafficLightHub trafficLightHub)
        : base(trafficLightHub)
    {
    }

    public void Send(string message)
    {
        trafficLightHub.Send(message, this);
    }


    public void Notify(string message)
    {
        if (message == "Червено")
        {
            Console.WriteLine("Светофар 4 получи съобщение: ВКЛЮЧИ ЗЕЛЕНО");
        }
        else
        {
            Console.WriteLine("Светофар 4 получи съобщение: " + message);
        }
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

        // Създаване на център за комуникация между светофарите
        TrafficLightHub tlHub = new TrafficLightHub();

        // Създаване на светофарите
        TrafficLight1 tl1 = new TrafficLight1(tlHub);
        TrafficLight2 tl2 = new TrafficLight2(tlHub);
        TrafficLight3 tl3 = new TrafficLight3(tlHub);
        TrafficLight4 tl4 = new TrafficLight4(tlHub);

        tlHub.TrafficLight1 = tl1;
        tlHub.TrafficLight2 = tl2;
        tlHub.TrafficLight3 = tl3;
        tlHub.TrafficLight4 = tl4;

        // Съобщения между светофарите
        tl1.Send("Зелено");
        tl1.Send("Жълто");
        tl1.Send("Червено");
        tl2.Send("Зелено");
        tl2.Send("Жълто");
        tl2.Send("Червено");
        tl3.Send("Зелено");
        tl3.Send("Жълто");
        tl3.Send("Червено");
        tl4.Send("Зелено");
        tl4.Send("Жълто");
        tl4.Send("Червено");


        Console.ReadKey();
    }
}