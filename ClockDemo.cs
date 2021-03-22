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
            testClock[i].ClockType = UserInput();
            testClock[i].Hours = ValidateHours(testClock[i].ClockType);
            testClock[i].Minutes = ValidateMinutes();
        }

        Console.WriteLine("\nnow printing all clocks\n");
        for (int i = 0; i < testClock.Length; i++)  //for loop to cycle all clocks
            Console.WriteLine("testClock[{0}] = {1}", i, testClock[i]);


        Console.Read(); //hold console window
    }

    public static char UserInput()
    {
        char type = ' ';
        bool leaveLoop = false;

        do
        {
            Console.WriteLine("Valid clock types are 'A' for AM, 'P' for PM, and 'M' for military time");
            Console.Write("Enter the clock type: ");

            type = Char.ToUpper(Convert.ToChar(Console.ReadLine()));

            switch (type)
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
