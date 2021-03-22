using System;

public static class Driver
{
    static void Main()
    {
        Clock c1 = new Clock();
        Console.WriteLine("{0}, {1}, {2}", c1.Hours, c1.Minutes, c1.ClockType);

        Clock c2 = new Clock(1, 20, 'P');
        Console.WriteLine("{0}, {1}, {2}", c2.Hours, c2.Minutes, c2.ClockType);

        Clock c3 = new Clock(23, 45, 'M');
        Clock c4 = new Clock(23, 44, 'M');

        if (c3 > c4)
            Console.WriteLine("c3 is larger than c2");

        Console.WriteLine(c3);
        Console.WriteLine(c1);
        Console.Read();
    }
}
