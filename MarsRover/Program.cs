using System;
using System.Linq;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Upper-right coordinates : ");
                var upperRightCoordinates = 
                    Console.ReadLine()?.Trim().ToUpper().Split(' ').Select(int.Parse).ToList();

                Console.Write("Initial coordinates of the rover : ");
                var initialCoordinatesOfTheRover = Console.ReadLine()?.Trim().ToUpper().Split(' ').ToList();

                Console.Write("Command string : ");
                var roverCommand = Console.ReadLine()?.Trim().ToUpper();

                #region InputValidation

                if (upperRightCoordinates == null || upperRightCoordinates.Count != 2)
                    throw new Exception(
                        "Missing or incorrect format of input : Upper-right coordinates of the plateau.");

                if (initialCoordinatesOfTheRover == null || initialCoordinatesOfTheRover.Count != 3)
                    throw new Exception("Missing or incorrect format of input : Initial coordinates of the rover.");

                if (roverCommand == null)
                    throw new Exception("Missing or incorrect format of input : The string sent by NASA.");

                #endregion

                var initialXCoordinate = int.Parse(initialCoordinatesOfTheRover[0]);
                var initialYCoordinate = int.Parse(initialCoordinatesOfTheRover[1]);
                var initialDirection = initialCoordinatesOfTheRover[2];
                Entities.MarsRover marsRover =
                    new Entities.MarsRover(initialXCoordinate, initialYCoordinate, initialDirection);
                marsRover.MoveToFinalLocation(roverCommand, upperRightCoordinates);

                Console.WriteLine(
                    $"Output = {marsRover.XCoordinate} {marsRover.YCoordinate} {marsRover.Direction}");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }

    
}
