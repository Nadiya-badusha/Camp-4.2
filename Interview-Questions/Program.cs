using System;
using System.Collections.Generic;


namespace Interview_Questions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Find char count and replace
            /*
            Console.Write("Enter a sentence: ");
            string input = Console.ReadLine();

            Console.Write("Enter the target character to count and replace: ");
            char targetChar = Console.ReadLine()[0];
            Console.WriteLine();

            Console.Write("Enter the replacement character: ");
            char replacement = Console.ReadLine()[0];
            Console.WriteLine();

            string[] words = input.Split(' ');

            foreach (string word in words)
            {
                int count = 0;
                foreach (char c in word)
                {
                    if (c == targetChar)
                        count++;
                }
                Console.WriteLine($"'{targetChar}' appears {count} times in \"{word}\"");
            }

            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Replace(targetChar, replacement);
            }

            string result = string.Join(" ", words);
            Console.WriteLine("Modified string: " + result);*/
            #endregion

            #region Use Recursion
            /*
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            long result = Factorial(number);
            Console.WriteLine($"Factorial of {number} is {result}");


            static long Factorial(int n)
            {
                if (n < 0)
                {
                    throw new ArgumentException("Factorial is not defined for negative numbers.");
                }
                if (n == 0 || n == 1)
                {
                    return 1;
                }

                return n * Factorial(n - 1);
            }

            */
            #endregion

            #region Convert first letter to UpperCase
            /*
            Console.Write("Enter a sentence: ");
        string input = Console.ReadLine();

        string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < words.Length; i++)
        {
            words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
        }

        string result = string.Join(" ", words);
        Console.WriteLine("Capitalized: " + result);
 
            */

            #endregion

            #region Count words starting with A or a

            /*
       Console.Write("Enter words separated by spaces: ");
       string input = Console.ReadLine();

       List<string> words = new List<string>(input.Split(' ', StringSplitOptions.RemoveEmptyEntries));

       int count = 0;
       foreach (string word in words)
       {
           if (word.StartsWith("a", StringComparison.OrdinalIgnoreCase))
               count++;
       }

       Console.WriteLine("Number of words starting with 'a' or 'A': " + count);

           */


            #endregion

            #region remove even number

            /*
       // Ask the user to enter numbers
       Console.Write("Enter numbers separated by spaces: ");
       string input = Console.ReadLine();

       // Split the input string into parts and convert to a list of integers
       string[] parts = input.Split(' ');
       List<int> numbers = new List<int>();

       foreach (string part in parts)
       {
           if (int.TryParse(part, out int number))
           {
               numbers.Add(number);
           }
       }

       // Create a new list to hold only odd numbers
       List<int> oddNumbers = new List<int>();

       foreach (int number in numbers)
       {
           if (number % 2 != 0)
           {
               oddNumbers.Add(number);
           }
       }

       // Show the result
       Console.WriteLine("List after removing even numbers: " + string.Join(", ", oddNumbers));

*/

            #endregion

            #region remove duplicate number
            /*
            
        // Ask the user to enter numbers separated by spaces
        Console.Write("Enter numbers separated by spaces: ");
        string input = Console.ReadLine();

        // Split the input string into parts
        string[] parts = input.Split(' ');

        // Convert parts to integers, ignoring invalid input
        List<int> numbers = new List<int>();
        foreach (string part in parts)
        {
            if (int.TryParse(part, out int number))
            {
                numbers.Add(number);
            }
        }

        // Create a dictionary to count occurrences of each number
        Dictionary<int, int> counts = new Dictionary<int, int>();
        foreach (int number in numbers)
        {
            if (counts.ContainsKey(number))
            {
                counts[number]++;
            }
            else
            {
                counts[number] = 1;
            }
        }

        // Find numbers that appear exactly once
        List<int> uniqueNumbers = new List<int>();
        foreach (var pair in counts)
        {
            if (pair.Value == 1)
            {
                uniqueNumbers.Add(pair.Key);
            }
        }

        // Print the unique numbers
        Console.WriteLine("Unique numbers: " + string.Join(", ", uniqueNumbers));
    
            */

            #endregion
            
            #region fibonnacci exponential combination series
            int n = 10;
            int a = 0, b = 1;

            Console.WriteLine("Fibonacci Squared Series:");
            for (int i = 0; i < n; i++)
            {
                Console.Write(Math.Pow(a, 2) + " ");
                int temp = a;
                a = b;
                b = temp + b;

            }
            #endregion
            

        }
    }
}