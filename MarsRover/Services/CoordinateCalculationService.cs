using System;
using System.Collections.Generic;
using MarsRover.Models;

namespace MarsRover.Services
{
    public class CoordinateCalculationService : ICoordinateCalculationService
    {
        public static readonly LinkedList<string> directions =
            new LinkedList<string>(new[] { "N", "E", "S", "W" });

        //the rover spins 90 degrees right without moving from its current spot
        public void SpinRight(Rover rover)
        {
            var currentDirection = directions.Find(rover.Direction);
            var rightDirection = currentDirection?.Next ?? currentDirection?.List.First;

            rover.Direction = rightDirection?.Value;
        }

        //the rover spins 90 degrees left without moving from its current spot
        public void SpinLeft(Rover rover)
        {
            var currentDirection = directions.Find(rover.Direction);
            var rightDirection = currentDirection?.Previous ?? currentDirection?.List.Last;

            rover.Direction = rightDirection?.Value;
        }

        //the rover moves forward one grid point
        public void Move(Rover rover)
        {
            switch (rover.Direction)
            {
                case "N":
                    rover.YCoordinate += 1;
                    break;
                case "E":
                    rover.XCoordinate += 1;
                    break;
                case "S":
                    rover.YCoordinate -= 1;
                    break;
                case "W":
                    rover.XCoordinate -= 1;
                    break;
                default:
                    throw new Exception($"Invalid direction : {rover.Direction}");
            }
        }
        
        //rover moves according to the command sent by nasa
        public void MoveToFinalLocation(Rover rover , string roverCommand , List<int> upperRightCoordinates)
        {
            foreach (var command in roverCommand)
            {
                switch (command)
                {
                    case 'R':
                        SpinRight(rover);
                        break;
                    case 'L':
                        SpinLeft(rover);
                        break;
                    case 'M':
                        Move(rover);
                        break;
                    default:
                        throw new Exception($"Invalid command : {command}");
                }

                if (rover.XCoordinate < 0 || rover.XCoordinate > upperRightCoordinates[0] || rover.YCoordinate < 0 || rover.YCoordinate > upperRightCoordinates[1])
                {
                    throw new Exception($"Plateau limit exceeded : The lower-left coordinates must be 0,0 and the upper-right coordinates must be {upperRightCoordinates[0]},{upperRightCoordinates[1]}.");
                }
            }
        }
    }
}
