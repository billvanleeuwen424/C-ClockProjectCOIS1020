//William Van Leeuwen

//Assignment 5
//COIS 1020
using System;


//Description
/*
 * This class holds the properties and attributes of a regular old clock
 * 
 * has the instance variables of hours, minutes, and clockType
 * 
 * has a no parameter constructor, and a three parameter constructor
 * 
 * all variables can be modified through the properties, with restrictions to keep the time proper
 * 
 * 
 */
public class Clock
{
    private int hours;
    private int minutes;
    private char clockType;

    // No Parameter Constructor
    //hours, int
    //minutes, int
    //Clocktype, char, A for am, P for pm, and M for Military time
    public Clock()
    {
        //set default. 12:00AM
        hours = 12;
        minutes = 0;
        clockType = 'A';
    }

    // Three Parameter Constructor
    //hours, int
    //minutes, int
    //Clocktype, char, A for am, P for pm, and M for Military time
    public Clock(int hrs, int mins, char cType)
    {
        ClockType = cType;
        Hours = hrs;
        Minutes = mins;
        
    }

    // Hours Property
    //Description: if military time, min 1 hr max 23hrs, if standard, min 1 max 12 hours
    //: returns validated hours
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
        if (ClockType != 'M')
        {
            if (ClockType == 'P')
            {
                ClockType = 'M';
                if (Hours == 12)
                    totalHour = 12;
                
                else    //if the clock is anything but 12pm, military time is equal to 12 + the current hour. e.g. if time = 1:15pm, military hours will be 12 + 1, 1315hrs
                {
                    totalHour = 12;
                    totalHour += Hours;
                    Hours = totalHour;
                }
                
                
            }
            else    //when the clock is am
            {
                ClockType = 'M';
                if (Hours == 12)    //if the clock is am, and the hours are 12, in military time that is 00
                    Hours = 0;
                else    //otherwise can just convert hours to hours
                    totalHour = Hours; 
            }
                
        }
    }

    //ConvertToStandard method
    //depending on the hours, the clocktype, and hours will be changed into standard format. Since the minutes are in the same format, those do not need to be touched
    private void ConvertToStandard()
    {
        int totalHours = Hours;
        //will only work if clocktype is military
        if (ClockType == 'M')
        {
            if (Hours > 12) //if the military time is > 1200 hrs, then it is no longer possible to be AM 
            {
                clockType = 'P';
                totalHours -= 12;
                Hours = totalHours;    //take away 12 hours, add the remainder to the hours after setting to pm
            }
            else if (Hours == 12)
            {
                clockType = 'P';
                Hours = totalHours;
            }
            else if (Hours == 0)
            {
                Hours = 12; //military 00 = 12am
            }
            else   //if the military time is < 1159, then it is not possible to be PM
            {
                ClockType = 'A';
                Hours = Hours;
                //hours can stay the same. I have it like this (hours = hours) so that the program can catch any errors if they happen
            }
        }
    }

    
    // ToString method
    //over rides the ToString in order to print a proper format of a clock
    public override string ToString()
    {
        if (ClockType == 'M')   //if military
        {
            return(Hours.ToString("D2") + Minutes.ToString("D2") + "hrs");
        }

        //else the clock is standard.
        return (Hours.ToString() + ':' + Minutes.ToString("D2") + ClockType.ToString() + 'M');
    }
    

    // Overloaded Operator Addition method
    //this method works by creating a new clock object, and adding the sum of the two together into it. 
    //to accomplish this, both of the clocks that will be added are converted into military, they are converted back after
    //Parameters
        //two clock objects
    //variables
        //int temp minutes, holds the minutes of both clocks to do some validation before adding them to the new clock
        //int hours, same as minutes, but hours
        //bool clk1 and clk2convert, used in an if statement to check if the clocks need to be converted
    public static Clock operator+(Clock clk1, Clock clk2)
    {
        int tempMinutes = 0;
        int tempHours = 0;
        
        bool clk1Convert = false, clk2Convert = false;  //booleans to keep track of conversion
        Clock clk3 = new Clock(0, 0, 'M');  //Create a blank military clock to act as a vessel for clk1 & 2 values

        //these ifs keep track if clk1 or 2 need to be converted to military, so that they can be converted back later
        if (clk1.ClockType != 'M')
        {
            clk1Convert = true;
        }
        if (clk2.ClockType != 'M')
        {
            clk2Convert = true;
        }

        //converts clocks to military, the way that the method is created, wont change anything if clock is already military
        clk1.ConvertToMilitary();
        clk2.ConvertToMilitary();

        //populates clck3 values
        tempMinutes = (clk1.Minutes + clk2.Minutes);
        tempHours = (clk1.Hours + clk2.Hours);

        //works out the overfilled minutes and hours.
        if (tempMinutes >= 60) //if the minutes are larger than 60, rounds one into hours, and removes 60
        {
            tempHours++;
            tempMinutes -= 60;
        }
        if (tempHours >= 24)   //if hours are larger than 24, rounds out the 24 hours, signifies a day passing into the next
            tempHours -= 24;

        //if the original two clocks were converted, c
        if (clk1Convert)
            clk1.ConvertToStandard();
        if (clk2Convert)
            clk2.ConvertToStandard();

        clk3.Hours = tempHours;
        clk3.Minutes = tempMinutes;

        return clk3;
    }

    // Greater Than operator
    //works by checking for all possible instances where clk1 could be larger than clk2, if else, returns false
    //if one is military while the other is not, will convert
    //Parameters
        //2 clock objects
    //variables
        //bool clock1 and clock2convert, see if they need to be converted to military and back
    public static bool operator>(Clock clk1, Clock clk2)
    {

        // if both clocks are standard
        if ((clk1.ClockType == 'P' || clk1.ClockType == 'A') && (clk2.ClockType == 'P' || clk2.ClockType == 'A'))   //if both clocks are standard
        {
            
            //this block : if both clocks are AM
            if(clk1.ClockType == 'A')
                if(clk2.ClockType == 'A')
                {
                    if(clk1.Hours > clk2.Hours)
                        return true;

                    if(clk1.Hours == clk2.Hours)
                        if (clk1.Minutes > clk2.Minutes)
                            return true;
                }



            //this block: if clock one is PM
            if (clk1.ClockType == 'P')
            {
                if (clk2.ClockType == 'A')
                    return true;

                //past here implies clock two is PM also
                if (clk1.Hours > clk2.Hours)
                    return true;

                if (clk1.Hours > clk2.Hours)
                    return true;

                if (clk1.Hours == clk2.Hours)
                    if (clk1.Minutes > clk2.Minutes)
                        return true;
            }
        }
        

        //if both clocks are military or if only one is military
        if (clk1.ClockType == 'M' || clk2.ClockType == 'M')
        {
            bool clk1Convert = false, clk2Convert = false;  //booleans to keep track if one of the clocks was non military
            if (clk1.ClockType != 'M')
            {
                clk1Convert = true;
            }
            if (clk2.ClockType != 'M')
            {
                clk2Convert = true;
            }

            //converts clocks to military, the way that the method is created, wont change anything if clock is already military
            clk1.ConvertToMilitary();
            clk2.ConvertToMilitary();

            //formats hours/minutes into military. eg, 01 hours and 23 minutes = 0123, eg 23 hours 59 minutes = 2359. 0123 < 2359
            //holding them in new values in order to compare, and convert back before returning
            int clock1Time = ((clk1.Hours * 100) + clk1.Minutes);
            int clock2Time = ((clk2.Hours * 100) + clk2.Minutes);

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


    