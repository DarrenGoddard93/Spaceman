using System;

namespace Spaceman
{
    class Program
    {
        static void Main(string[] args)
        {
            Game g = new Game();
            g.Greet();

            do
            {
                g.Display();
                g.Ask();
                Console.Clear();
                if (g.DidLose())
                {
                    g.Display();
                    Console.WriteLine("Oh no! The UFO just flew away with another person!");
                    Console.WriteLine("You Lost!");
                    Console.ReadLine();
                    break;
                }
                else if (g.DidWin())
                {
                    g.Display();
                    Console.WriteLine("Hooray! You saved the person and earned a medal of honor!");
                    Console.ReadLine();

                    break;
                }
            } while (true);

        }
    }
}
