using System;
// Creativity: Added levels to the program, when the user gets over 1000 points, they level up.

class Program
{
    static void Main(string[] args)
    {
        // Create a GoalManager object 
        // Call the start function on that object 
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}