using System;

public class Clock
{
    private int hours;
    private int minutes;
    private char clockType;

    // No Parameter Constructor
    public Clock()
    {
        //set default. 12:00AM
        hours = 12;
        minutes = 0;
        clockType = 'a';
    }

    // Three Parameter Constructor
    public Clock(int hrs, int mins, char cType)
    {
        ClockType = cType;
        Hours = hrs;
        Minutes = mins;
        
    }

    // Hours Property
    public int Hours
    {
        get;    //default getter

        set
        {
            if (ClockType == 'm')
            {
                if (value <= 23 && hours >= 0)  //checks if hours are valid 0 - 23 for military
                    hours = value;
                else
                {
                    hours = 0;
                    Console.WriteLine("invalid time entered... Hours set to 00");
                }
            }
            else
            {
                if (value <= 12 && hours > 0)   //checks if hours are valid 1 - 12 for standard time
                    hours = value;
                else
                {
                    hours = 12;
                    Console.WriteLine("invalid time entered... Hours set to 12");
                }
            }
        }
    }

    // Minutes Property
    public int Minutes
    {
        get;
        set
        {
            if (value < 59 && value >= 0)   //checks if mintues are valid. 0-59
                minutes = value;
            else
            {
                minutes = 0;
                Console.WriteLine("invalid time entered... Minutes set to 00");
            }
        }
        
    }

    //Clock type property
    public char ClockType
    {
        get;    //default getter

        set //checks if value is correct, else sets type to AM
        {
            if (value == 'A' || value == 'P' || value == 'M')
                clockType = value;
            else
                clockType = 'A';
        }
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

    