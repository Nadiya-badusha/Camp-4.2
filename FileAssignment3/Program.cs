using System.Reflection;
using System.Xml.Linq;

namespace FileAssignment3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1-Defining a file
            string filepath = "main.txt"; //relative path
            Console.WriteLine(filepath);
            //2-check if the file exsists
            if (!File.Exists(filepath))
            {
                Console.WriteLine("file not found");
            }

            //3-write string data into the file
            using (StreamWriter sw = new StreamWriter(filepath))
            {
                sw.WriteLine("Hi, Hello World");
                sw.WriteLine("I am Nadiya");
                sw.WriteLine("Good to see you all");

            }
            Console.WriteLine("Data written to the file");

            //4-read data from file as string
            string filecontent = File.ReadAllText(filepath);
            Console.WriteLine(filecontent);




            // Get source file path
            Console.Write("Enter the full path of the source file: ");
            string sourcePath = Console.ReadLine();

            // Get destination folder path
            Console.Write("Enter the destination folder path: ");
            string destinationFolder = Console.ReadLine();

            // Get the file name from the source path
            string fileName = "main.txt";

            // Combine destination folder path and file name
            string destinationPath = Path.Combine(destinationFolder, fileName);

            // Copy the file
            File.Copy(sourcePath, destinationPath, true); // true = overwrite if file exists
            Console.WriteLine("File copied successfully to: " + destinationPath);
            

        }
    }
}
