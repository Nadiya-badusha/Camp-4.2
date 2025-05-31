using System;

namespace TemperatureChecker
{
    /*create a counter that indicates rise or fall of temperature.  
    If the temperature goes beyond 100 or below 0 then raise an 
    event which gives the message “Critical temperature reached”.*/


    // Step 1: Declare a delegate (defines the shape of the event handler method)
    public delegate void TemperatureAlert(int temperature);

    class TemperatureMonitor
    {
        // Step 2: Declare an event using the delegate
        public event TemperatureAlert OnCriticalTemperature;

        // Store the current temperature
        private int currentTemperature = 25; // default starting temp

        // Method to increase temperature
        public void Increase(int amount)
        {
            currentTemperature += amount;
            Console.WriteLine("Temperature increased to: " + currentTemperature);
            CheckTemperature();
        }

        // Method to decrease temperature
        public void Decrease(int amount)
        {
            currentTemperature -= amount;
            Console.WriteLine("Temperature decreased to: " + currentTemperature);
            CheckTemperature();
        }

        // Step 3: Check if temperature is critical (below 0 or above 100)
        private void CheckTemperature()
        {
            if (currentTemperature < 0 || currentTemperature > 100)
            {
                // Step 4: Raise the event
                OnCriticalTemperature?.Invoke(currentTemperature);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            // Create the monitor object
            TemperatureMonitor monitor = new TemperatureMonitor();

            // Step 5: Subscribe to the event with a method that handles the alert
            monitor.OnCriticalTemperature += temp =>
            {
                Console.WriteLine(" CRITICAL TEMPERATURE REACHED: " + temp);
            };

            // Simple menu loop
            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Increase Temperature");
                Console.WriteLine("2. Decrease Temperature");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option (1-3): ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Enter amount to increase: ");
                    int amount = int.Parse(Console.ReadLine());
                    monitor.Increase(amount);
                }
                else if (choice == "2")
                {
                    Console.Write("Enter amount to decrease: ");
                    int amount = int.Parse(Console.ReadLine());
                    monitor.Decrease(amount);
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Exiting program...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter 1, 2 or 3.");
                }
            }
        }
    }
}
