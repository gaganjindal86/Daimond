using System;

namespace NewDayDaimond
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter an uppercase Alphabet: e.g. A B S T");
            Char inputchar = Console.ReadLine()[0];
            if (inputchar < 65 || inputchar > 90)
            {
                Console.WriteLine("Not a valid input.");
            }
            else
            {
                Console.Write(new DiamondBuilder(inputchar).GetDaimond());
            }
        }
    }
}
