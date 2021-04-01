//William Van Leeuwen

//Assignment 5
//COIS 1020
using System;

public static class Driver
{
    static void Main()
    {
        
        Clock[] testClock = new Clock[6];   //declaring the reference array

        testClock[0] = new Clock(3, 8, 'P');
        testClock[1] = new Clock(20, 54, 'M');

        //creates testClock 2 and 3 using user input
        for (int i = 2; i <= 3; i++)
        {
            Console.WriteLine("\nNow entering for testClock[{0}] \n", i);
            
            //construct object to default, assign values as user inputs using proper methods
            testClock[i] = new Clock();
            testClock[i].ClockType = ValidateClockType();
            testClock[i].Hours = ValidateHours(testClock[i].ClockType);
            testClock[i].Minutes = ValidateMinutes();
        }

        Console.WriteLine("\nnow printing clocks\n");
        for (int i = 0; i < 4; i++)  //for loop to cycle all clocks
            Console.WriteLine("testClock[{0}] = {1}", i, testClock[i]);

        //assign values to testclock 4 and 5, test addition operator
        testClock[4] = testClock[0] + testClock[1];
        testClock[5] = testClock[2] + testClock[3];

        for (int i = 4; i < 6; i++)
            Console.WriteLine("testClock[{0}] = {1}", i, testClock[i]);

        //compare values
        Console.WriteLine("\n");
        if (testClock[0] > testClock[1])
            Console.WriteLine("testClock 0 is larger than testClock 1");
        if (testClock[0] < testClock[1])
            Console.WriteLine("testClock 0 is smaller than testClock 1");


        if (testClock[2] > testClock[3])
            Console.WriteLine("testClock 2 is larger than testClock 3");
        if (testClock[2] < testClock[3])
            Console.WriteLine("testClock 2 is smaller than testClock 3");
        

        Console.Read(); //hold console window
    }



    //this method validates the clocktype info entered
    //void method, user enters info while in this method
    //uses a boolean to hold in the do-while loop
    //once the loop is left, it is safe to assume that the clocktype the user entered is valid
    //it will then return the validated clocktype
    //char type, the clocktype that will be entered by the user
    
    public static char ValidateClockType()
    {
        char type = ' ';
        bool leaveLoop = false;

        do
        {
            Console.WriteLine("Valid clock types are 'A' for AM, 'P' for PM, and 'M' for military time");
            Console.Write("Enter the clock type: ");

            type = Char.ToUpper(Convert.ToChar(Console.ReadLine()));

            switch (type)   //switch to select the three clock types
            {
                case 'A':
                    leaveLoop = true;
                    break;
                case 'P':
                    leaveLoop = true;
                    break;
                case 'M':
                    leaveLoop = true;
                    break;
                default:    //invalid entry
                    Console.WriteLine("Invalid Entry. Try Again.");
                    break;
            }
        } while (!leaveLoop);  //only leaves after input is validated

        return type;

    }

    //this method validates the hours entered by the user. Very similar to the clocktype validation method
    //validates user entered hours depending on the clocktype passed.
    //int hours, user entered hours
    //bool leaveloop, self explanitory, will become true once input is valid
    public static int ValidateHours(char clockType)
    {
        bool leaveLoop = false;
        int hours = 0;
        do
        {
            Console.WriteLine("Regular clock rules apply");
            Console.WriteLine("Military time is between 0 and 23, standard time is between 1 and 12");
            Console.Write("Enter the hours: ");

            hours = Convert.ToInt32(Console.ReadLine());


            if (clockType == 'M' && hours < 24 && hours >= 0) //checks if input is valid military time
                leaveLoop = true;
            else if (clockType != 'M' && hours <= 12 && hours > 0)  //checks if input is valid standard time
                leaveLoop = true;
            else
                Console.WriteLine("Invalid Entry, try again");

        } while (!leaveLoop);   //only leaves after input is validated

        return hours;
    }

    //this method validates the minutes entered by the user. Very similar to the clocktype validation method
    //validates user entered minutes
    //int minutes, user entered minutes
    //bool leaveloop, self explanitory, will become true once input is valid
    public static int ValidateMinutes()
    {
        bool leaveLoop = false;
        int minutes = 0;

        do
        {
            Console.WriteLine("Regular clock rules apply");
            Console.WriteLine("Between 0 and 59");
            Console.Write("Enter the minutes: ");

            minutes = Convert.ToInt32(Console.ReadLine());

            if (minutes < 60 && minutes >= 0)   //checks if minutes are 0 - 60
                leaveLoop = true;
            else
                Console.WriteLine("Invalid Entry, try again");

        } while (!leaveLoop);   //only leaves after input is validated

        return minutes;
    }
}
