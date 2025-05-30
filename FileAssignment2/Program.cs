using System.Transactions;

namespace FileAssignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Create a program that generates curriculum vitas on a folder 
                based on the entities in an application. The curriculum vitae 
                should be text file. The name of files should be a concatenated 
                name of both the Name as well as location. */
            Console.WriteLine("enter name:");
            string name = Console.ReadLine();

            Console.WriteLine("enter age:");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter gender:");
            string gender = Console.ReadLine();

            Console.WriteLine("enter loaction:");
            string location = Console.ReadLine();

            //1-Defining a file
            string filepath = $"{name}{location}.txt"; //relative path
            Console.WriteLine(filepath);

            //2-check if the file exsists

            if (!File.Exists(filepath))
            {
                //create new file if it dosent exsists
                FileStream fs = File.Create(filepath);
                fs.Close();
                Console.WriteLine("File created");
            }
            
            //3-write string data into the file
            using (StreamWriter sw = new StreamWriter(filepath))
            {
                sw.WriteLine($"Name:{name}");
                sw.WriteLine($"Age:{age}");
                sw.WriteLine($"Gender:{gender}");
                sw.WriteLine($"Location:{location}");

            }
            Console.WriteLine("Data written to the file");

            //4-read data from file as string
            string filecontent = File.ReadAllText(filepath);
            Console.WriteLine(filecontent);
            Console.ReadKey();





        }

    }
}
