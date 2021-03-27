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
                if (hours == 12)
                    totalHour = 12;
                
                else    //if the clock is anything but 12pm, military time is equal to 12 + the current hour. e.g. if time = 1:15pm, military hours will be 12 + 1, 1315hrs
                {
                    totalHour = 12;
                    totalHour += hours;
                    hours = totalHour;
                }
                
                
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

    
    // ToString method
    public override string ToString()
    {
        if (clockType == 'M')   //if military
        {
            return(hours.ToString("D2") + minutes.ToString("D2") + "hrs");
        }

        //else the clock is standard.
        return (hours.ToString() + ':' + minutes.ToString("D2") + clockType.ToString() + 'M');
    }
    

    // Overloaded Operator Addition method
    public static Clock operator+(Clock clk1, Clock clk2)
    {
        bool clk1Convert = false, clk2Convert = false;  //booleans to keep track of conversion
        Clock clk3 = new Clock(0, 0, 'M');  //Create a blank military clock to act as a vessel for clk1 & 2 values

        //these ifs keep track if clk1 or 2 need to be converted to military, so that they can be converted back later
        if (clk1.clockType != 'M')
        {
            clk1Convert = true;
        }
        if (clk2.clockType != 'M')
        {
            clk2Convert = true;
        }

        //converts clocks to military, the way that the method is created, wont change anything if clock is already military
        clk1.ConvertToMilitary();
        clk2.ConvertToMilitary();

        //populates clck3 values
        clk3.minutes = (clk1.Minutes + clk2.Minutes);
        clk3.hours = (clk1.Hours + clk2.Hours);

        //works out the overfilled minutes and hours.
        if (clk3.minutes >= 60) //if the minutes are larger than 60, rounds one into hours, and removes 60
        {
            clk3.hours++;
            clk3.minutes -= 60;
        }
        if (clk3.hours >= 24)   //if hours are larger than 24, rounds out the 24 hours, signifies a day passing into the next
            clk3.hours -= 24;

        //if the original two clocks were converted, c
        if (clk1Convert)
            clk1.ConvertToStandard();
        if (clk2Convert)
            clk2.ConvertToStandard();


        return clk3;
    }

    // Greater Than operator
    public static bool operator>(Clock clk1, Clock clk2)
    {

        // if both clocks are standard
        if ((clk1.clockType == 'P' || clk1.clockType == 'A') && (clk2.clockType == 'P' || clk2.clockType == 'A'))   //if both clocks are standard
        {
            
            if(clk1.clockType == 'A')
                if(clk2.clockType == 'A')
                {
                    if(clk1.hours > clk2.hours)
                        return true;

                    if(clk1.hours == clk2.hours)
                        if (clk1.minutes > clk2.minutes)
                            return true;
                }


            if (clk1.clockType == 'P')
            {
                if (clk2.clockType == 'A')
                    return true;

                if (clk1.hours > clk2.hours)
                    return true;

                if (clk1.hours > clk2.hours)
                    return true;

                if (clk1.hours == clk2.hours)
                    if (clk1.minutes > clk2.minutes)
                        return true;
            }
        }
        
        //if both clocks are military/only one is military
        if (clk1.clockType == 'M' || clk2.clockType == 'M')
        {
            bool clk1Convert = false, clk2Convert = false;  //booleans to keep track if one of the clocks was non military
            if (clk1.clockType != 'M')
            {
                clk1Convert = true;
            }
            if (clk2.clockType != 'M')
            {
                clk2Convert = true;
            }

            //converts clocks to military, the way that the method is created, wont change anything if clock is already military
            clk1.ConvertToMilitary();
            clk2.ConvertToMilitary();

            //formats hours/minutes into military. eg, 01 hours and 23 minutes = 0123, eg 23 hours 59 minutes = 2359. 0123 < 2359
            //holding them in new values in order to compare, and convert back before returning
            int clock1Time = ((clk1.hours * 100) + clk1.minutes);
            int clock2Time = ((clk2.hours * 100) + clk2.minutes);

            //if the original two clocks were converted, covert back
            if (clk1Convert)
                clk1.ConvertToStandard();
            if (clk2Convert)
                clk2.ConvertToStandard();

            if (clock1Time > clock2Time)
                return true;
        }
        
        //if we make it here, all tests have been done, clk1 is not > clk2
        return false; 
    }

    // Less Than operator
    public static bool operator<(Clock clk1, Clock clk2)
    {
        //just passes the variables in reverse to the > method
        if (clk2 > clk1)
            return true;

        return false;
    }
     
}


    