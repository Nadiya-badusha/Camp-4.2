using System.Reflection.PortableExecutable;

namespace FileAssignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1-Defining a file
            string filepath = "displayfivechar.txt"; //relative path

            //2-check if the file exsists

            if (!File.Exists(filepath))
            {
                //create new file if it dosent exsists
                FileStream fs=File.Create(filepath);
                fs.Close();
                Console.WriteLine("File created");
            }

            //3-write string data into the file
            using (StreamWriter sw = new StreamWriter(filepath))
            {
                sw.WriteLine("This is just a test file");
                sw.WriteLine("PropelMarch 2025:Nadiya Badusha");
                
                }

            //4-read data from file as string
            using (StreamReader sr = new StreamReader(filepath))
            {
                // Single loop to skip first 2 and read next 5 characters
                for (int i = 0; i < 7; i++)
                {
                    int ch = sr.Read();


                    if (i >= 2) // Display characters from 3rd to 7th (5 characters)
                    {
                        Console.Write((char)ch);
                    }
                }

                Console.WriteLine(); // Move to next line
            }
            Console.ReadKey();
        }
    }
}
