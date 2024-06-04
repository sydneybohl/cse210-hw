using System;
using Microsoft.VisualBasic;

class Program
{
    static void Main(string[] args)
    {
        var running = new Running("6/12/2024", 30, 2);
        var biking = new Biking("6/21/2024", 45, 10);
        var swimming = new Swimming("6/30/2024", 30, 15);

        Activity[] activities = { running, biking, swimming };

        foreach (Activity a in activities)
        {
            Console.WriteLine(a.GetSummary());
        }
    }
}