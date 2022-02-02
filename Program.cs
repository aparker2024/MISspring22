using System;

namespace Lab2 // Note: actual namespace depends on the project name.
{
    internal class Program
    {

        static void Main(string[] args)
        {
            short milesTraveled = 0;
            short travelTime = 0;

            Console.WriteLine("Miles traveled:");
            string userInput = Console.ReadLine();
            milesTraveled = short.Parse(userInput);

            Console.WriteLine("Time travel(hours):");
            userInput = Console.ReadLine();
            travelTime = short.Parse(userInput);

            int milesPerGallon = 25;
            double GAS_PRICE = 2.96;

            Console.WriteLine("Enter amount spent on gas: $" + amtSpentonGas + "Your average speed: " + speed + "mph");

            double gallonsUsed = milesTraveled / milesPerGallon;
            double amtSpentonGas = gallonsUsed * GAS_PRICE;
            double speed = milesTraveled / travelTime;

        }
    }
}
