using System;

class Program
{
    static void Main(string[] args)
    {
        // Lecture 
        Address lectureAddress = new Address("345 Dennis St", "Woodland", "WI", "USA");
        Lecture lecture = new Lecture("Effects of Technology", "AI", "9/15/2024", "7:00pm", lectureAddress, "Maria Hawthrone", 250);

        // Reception 
        Address receptionAddress = new Address("592 Spring St", "Springfield", "WI", "USA");
        Reception reception = new Reception("Wedding Reception", "For Jessica & Mark McCormick", "11/25/2024", "6:00pm", receptionAddress, "rsvp@wedding.com");

        // Outdoor
        Address outdoorAddress = new Address("819 Black St", "Berlin", "WI", "USA");
        Outdoor outdoor = new Outdoor("Fireworks", "July 3rd Fireworks at the Park", "7/3/2024", "9:00pm", outdoorAddress, "Clear Sky and Chilly");

        Event[] events = { lecture, reception, outdoor };

        foreach (Event e in events)
        {
            Console.WriteLine(e.StandardDetails());
            Console.WriteLine();

            Console.WriteLine(e.FullDetails());
            Console.WriteLine();

            Console.WriteLine(e.ShortDescription());
            Console.WriteLine("=========================");
            Console.WriteLine();
        }
    }
}