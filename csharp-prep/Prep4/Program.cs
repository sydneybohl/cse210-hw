using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        int userNumber = -1;
        while (userNumber != 0)
        {
            Console.Write("Enter a number, type 0 to quit: ");

            string userResponse = Console.ReadLine();
            userNumber = int.Parse(userResponse);

            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        // Find the Sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        // Find the Average
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // Find the Max
        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                // goes through and compares each number to the max, if greater, we found a new max 
                max = number;
            }
        }
        Console.WriteLine($"The max is: {max}");
    }
}