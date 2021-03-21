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
        clockType = 'A';
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
        get 
        {
            return hours;
        }

        set
        {
            if (ClockType == 'M')
            {
                if (value <= 23 && value >= 0)  //checks if hours are valid 0 - 23 for military
                    hours = value;
                else
                {
                    hours = 0;
                    Console.WriteLine("invalid time entered... Hours set to 00");
                }
            }
            else
            {
                if (value <= 12 && value > 0)   //checks if hours are valid 1 - 12 for standard time
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
        get 
        {
            return minutes;
        }

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
        get 
        {
            return clockType;
        }    

        set //checks if value is correct, else sets type to AM
        {
            if (value == 'A' || value == 'P' || value == 'M')
                clockType = value;
            else
            {
                clockType = 'A';
                Console.WriteLine("invalid time entered... Clocktype set to AM");
            }
        }
    }

    //ConvertToMilitary method
    //depending on the clocktype, the hours will be changed into military format. Since the minutes are in the same format, those do not need to be touched
    private void ConvertToMilitary()
    {
        int totalHour = 0;  //value to hold hours while converting

        // if the clocktype is already military, nothing will happen
        if (clockType != 'M')
        {
            if (clockType == 'P')
            {
                totalHour = 12;
                totalHour += hours;
                hours = totalHour;
            }
            else    //when the clock is am
                if (hours == 12)    //if the clock is am, and the hours are 12, in military time that is 00
                    hours = 0;
                else    //otherwise can just convert hours to hours
                    totalHour = hours;
                
        }
        //after hours are changed, clocktype is switched to m
        clockType = 'M';

    }

    //ConvertToStandard method
    //depending on the hours, the clocktype, and hours will be changed into standard format. Since the minutes are in the same format, those do not need to be touched
    private void ConvertToStandard()
    {
        //will only work if clocktype is military
        if (clockType == 'M')
        {
            if (hours >= 12) //if the military time is > 1200 hrs, then it is no longer possible to be AM 
            {
                clockType = 'P';
                hours -= 12;    //take away 12 hours, add the remainder to the hours after setting to pm
            }
            else   //if the military time is < 1159, then it is not possible to be PM
            {
                clockType = 'A';
                //hours can stay the same
            }
        }
    }
    /*
    // ToString method
    public override string ToString()
    {
        //return;    //!!!!!CHANGE WHEN POSSIBLE,,, PLACEHOLDER!!!!
    }

    // Overloaded Operator Addition method
    public static Clock operator+(Clock clk1, Clock clk2)
    {
        //return;    //!!!!!CHANGE WHEN POSSIBLE,,, PLACEHOLDER!!!!
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
     */
}

    