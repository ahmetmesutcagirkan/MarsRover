using MarsRover.Core;
using MarsRover.Core.Validators;
using MarsRover.Core.Vectors;
using System;

namespace MarsRover.ConsoleApp
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Mars!");
            Console.WriteLine("Please enter the plateau boundaries");

            var plateauBoundaries = Console.ReadLine();

            if (!Validator.ValidatePlateauBoundaries(plateauBoundaries))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid plateau boundaries");
                Console.ReadKey();
                return;
            }

            var plateauBoundaryArray = plateauBoundaries.Split(" ");
            Plateau plateau = new Plateau();
            plateau.Boundary = new Tuple<int, int>(Convert.ToInt32(plateauBoundaryArray[0]), Convert.ToInt32(plateauBoundaryArray[1]));

            WaitForInstructions(plateau);
        }

        public static void WaitForInstructions(Plateau plateau)
        {
            Console.WriteLine("Please enter the Rover location and direction on the plateau");
            var roverPosition = Console.ReadLine();
            if (!Validator.ValidateRoverPosition(roverPosition))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid location and direction");
                Console.ReadKey();
                return;
            }

            var roverLocationArray = roverPosition.Split(" ");
            Console.WriteLine("Please enter the Rover commands");
            var roverCommands = Console.ReadLine().ToUpper();
            if (!Validator.ValidateRoverCommands(roverCommands))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid commands");
                Console.ReadKey();
                return;
            }

            var rover = new Rover(plateau);
            rover.commands = roverCommands.ToCharArray();
            rover.location.X = Convert.ToInt32(roverLocationArray[0]);
            rover.location.Y = Convert.ToInt32(roverLocationArray[1]);
            rover.direction = roverLocationArray[2].ToDirection();

            var result = rover.Run();
            Console.WriteLine(result);

            Console.WriteLine("Do you want to deploy new rover? (Y/N)");
            var answer = Console.ReadLine();

            if (string.Equals(answer, "Y", StringComparison.OrdinalIgnoreCase))
                WaitForInstructions(plateau);
        }
    }
}
