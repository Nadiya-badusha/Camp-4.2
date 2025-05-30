using System;

namespace SimpleArrayMenuApp
{
    // Define a delegate that represents methods which take and return an int array
    public delegate int[] ArrayOperationdelegate(int[] array);

    public class ArrayProcessor
    {
        // Declare an event based on the delegate
        public event ArrayOperationdelegate reverseeventdelegate;
        public event ArrayOperationdelegate sorteventdelegate;

        public ArrayProcessor() 
        {
            reverseeventdelegate += new ArrayOperationdelegate(this.ReverseArray);
            sorteventdelegate += new ArrayOperationdelegate(this.SortArray);
        }

        public int[] ProcessSort(int[] array)
        {
            return sorteventdelegate?.Invoke(array);
        }

        public int[] ProcessReverse(int[] array)
        {
            return reverseeventdelegate?.Invoke(array);
        }
        // Sort method
        public int[] SortArray(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j=0;j < array.Length-i-1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp=array[j];
                        array[j]=array[j+1];
                        array[j+1]=temp;
                    }
                }
            }
            return array;
        }

        // Reverse method
        public int[] ReverseArray(int[] array)
        {
            int length=array.Length;
            int[] reversed=new int[length];
            for (int i = 0; i<length;i++)
            {
                reversed[i] = array[length - 1 - i];
            }
            return reversed;
        }

        // This method triggers the event to process the array
        //public int[] Process(int[] array)
        //{
        //    if (OnArrayProcesseventdelegate != null)
        //    {
        //        return OnArrayProcesseventdelegate(array);
        //    }
        //    return array;
        //}
    }

    class Program
    {
        static void Main()
        {
            //class object creation
            ArrayProcessor processor = new ArrayProcessor();

            // Read array input from user
            Console.WriteLine("Enter array elements separated by space:");
            string[] input = Console.ReadLine().Split();
            int[] numbers = Array.ConvertAll(input, int.Parse);

            // Menu
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Sort the array");
            Console.WriteLine("2. Reverse the array");
            Console.Write("Enter your choice (1 or 2): ");
            string choice = Console.ReadLine();

            // Set delegate/event based on choice
            if (choice == "1")
            {

                int[] result = processor.ProcessSort(numbers);
                Console.WriteLine("Sorted array: " + string.Join(", ", result));

            }
            else if (choice == "2")
            {
                int[] result = processor.ProcessReverse(numbers);
                Console.WriteLine("Reversed array: " + string.Join(", ", result));

            }
            else
            {
                Console.WriteLine("Invalid choice.");
                return;
            }

            
        }
    }
}
