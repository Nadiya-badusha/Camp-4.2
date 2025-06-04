using System;
using System.Threading.Tasks;

class Program
{
    static int seconds = 0;
    static bool isRunning = false;

    static async Task Main(string[] args)
    {
        Console.WriteLine("Simple Stopwatch");
        Console.WriteLine("Commands: start | pause | stop | exit");

        while (true)
        {
            if (isRunning)
            {
                seconds++;
                Console.Clear();
                Console.WriteLine($"Stopwatch: {seconds} second(s)");
                Console.WriteLine("Commands: pause | stop | exit");
                await Task.Delay(1000); // Wait 1 second
            }
            else
            {
                Console.Write("\nEnter command: ");
                string? input = Console.ReadLine()?.ToLower();

                if (input == "start")
                {
                    isRunning = true;
                }
                else if (input == "pause")
                {
                    isRunning = false;
                }
                else if (input == "stop")
                {
                    isRunning = false;
                    seconds = 0;
                    Console.Clear();
                    Console.WriteLine("Stopwatch reset to 0.");
                }
                else if (input == "exit")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid command.");
                }
            }
        }
    }
}
