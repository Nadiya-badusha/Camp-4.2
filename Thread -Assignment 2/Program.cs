using System;
using System.Threading.Tasks;

class Program
{
    static int sharedValue = 0; // Shared counter value

    // Shared method accessed by both counters
    static async Task IncrementSharedCounter(string counterName)
    {
        for (int i = 0; i < 5; i++) // Each counter runs 5 times
        {
            sharedValue++; // Increase shared value
            Console.WriteLine($"{counterName}: sharedValue = {sharedValue}");
            await Task.Delay(1000); // Simulate 1-second delay
        }
    }

    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting two counters...");

        // Start two counters running in parallel
        Task counter1 = IncrementSharedCounter("Counter A");
        Task counter2 = IncrementSharedCounter("Counter B");

        // Wait for both to finish
        await Task.WhenAll(counter1, counter2);

        Console.WriteLine("Both counters finished.");
    }
}
