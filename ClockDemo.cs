using System;

public static class Driver
{
    static void Main()
    {
        Clock c1 = new Clock();
        Console.WriteLine("{0}, {1}, {2}", c1.Hours, c1.Minutes, c1.ClockType);

        Clock c2 = new Clock(1, 20, 'P');
        Console.WriteLine("{0}, {1}, {2}", c2.Hours, c2.Minutes, c2.ClockType);

        Console.Read();
    }
}
