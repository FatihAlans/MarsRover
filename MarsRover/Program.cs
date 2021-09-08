using System;
using System.Collections.Generic;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please create input file and press any key!");
            Console.ReadKey();
            string[] inputs = System.IO.File.ReadAllLines("input.txt");
            Plateau plateau = new Plateau(inputs[0]);
            List<string> positions = new List<string>();
            for (int i = 1; i < inputs.Length; i+=2)
            {
                plateau.AddRover(inputs[i]);
                string position = plateau.SendCommandToRover(inputs[i + 1]);
                positions.Add(position);

            }
            System.IO.File.WriteAllLines("output.txt", positions);

            Console.WriteLine("You can see rovers last position in output file!");
            Console.ReadKey();
        }
    }
}
