using System;

public class Clock
{
    private int hours;
    private int minutes;
    private char clockType;

    // No Parameter Constructor
    public Clock()
    {
        // insert code here
    }

    // Three Parameter Constructor
    public Clock(int hrs, int mins, char cType)
    {
        // insert code here
    }

    // Hours Property
    public int Hours
    {
        // insert code here
    }

    // Minutes Property
    public int Minutes
    {
        // insert code here
    }

    public char ClockType
    {
        // insert code here
    }

    //ConvertToMilitary method
    private void ConvertToMilitary()
    {
        // insert code here
    }

    //ConvertToMilitary method
    private void ConvertToStandard()
    {
        // insert code here
    }

    // ToString method
    public override string ToString()
    {
        return;    //!!!!!CHANGE WHEN POSSIBLE,,, PLACEHOLDER!!!!
    }

    // Overloaded Operator Addition method
    public static Clock operator+(Clock clk1, Clock clk2)
    {
        return;    //!!!!!CHANGE WHEN POSSIBLE,,, PLACEHOLDER!!!!
    }

    // Greater Than operator
    public static bool operator>(Clock clk1, Clock clk2)
    {
        return true;    //!!!!!CHANGE WHEN POSSIBLE,,, PLACEHOLDER!!!!
    }

    // Less Than operator
    public static bool operator<(Clock clk1, Clock clk2)
    {
        return true;    //!!!!!CHANGE WHEN POSSIBLE,,, PLACEHOLDER!!!!
    }
}

    