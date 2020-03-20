using MarsRover.Modules;
using System;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Mars mars = new Mars();
            Console.WriteLine("==============");
            Console.WriteLine("| Mars Rover |");
            Console.WriteLine("==============");

            Console.Write("Mars Size: [X Y]"); // Prompt
            string cmd = Console.ReadLine();
            string[] marssize = cmd.Split(" ");
            if (marssize.Length > 1)
            {
                mars.MaxX = marssize[0].ToInt32();
                mars.MaxY = marssize[1].ToInt32();

                while (true) // Loop indefinitely
                {
                    Console.Write("Rover Start Pos [X Y D] : ");
                    string line = Console.ReadLine(); // Get string from user
                    if (line == "") { break; }

                    string[] roverpos = line.Split(" ");
                    if (marssize.Length > 2)
                    {
                        Rover rover = new Rover
                        {
                            PosX = roverpos[0].ToInt32(),
                            PosY = roverpos[1].ToInt32(),
                            Dir = Rover.GetDir(roverpos[2])
                        };
                        Console.Write("Rover CMD : ");
                        cmd = Console.ReadLine(); // Get string from user
                        rover.SetGrid(0, 0, mars.MaxX, mars.MaxY);
                        rover.SetCMD(cmd);
                        mars.Rovers.Add(rover);
                    }
                }

                // Show Result
                foreach (Rover R in mars.Rovers)
                {
                    R.ExcuteCMD();
                    Console.WriteLine(R.ToString());
                }
            }
            Console.Write(">");
            Console.ReadLine();
        }
    }
}
