using System;
using System.Collections.Generic;
using MarsRover.Constants;

namespace MarsRover.Entities
{
    public class MarsRover
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string Direction { get; set; }

        public MarsRover(int initialXCoordinate , int initialYCoordinate , string initialDirection)
        {
            XCoordinate = initialXCoordinate;
            YCoordinate = initialYCoordinate;
            Direction = initialDirection;
        }

        public static readonly LinkedList<string> directions =
            new LinkedList<string>(new[] { "N", "E", "S", "W" });

        //the rover spins 90 degrees right without moving from its current spot
        public void SpinRight()
        {
            var currentDirection = directions.Find(Direction);
            var rightDirection = currentDirection?.Next ?? currentDirection?.List.First;

            Direction = rightDirection?.Value;
        }

        //the rover spins 90 degrees left without moving from its current spot
        public void SpinLeft()
        {
            var currentDirection = directions.Find(Direction);
            var rightDirection = currentDirection?.Previous ?? currentDirection?.List.Last;

            Direction = rightDirection?.Value;
        }

        //the rover moves forward one grid point
        public void Move()
        {
            switch (Direction)
            {
                case "N":
                    YCoordinate += 1;
                    break;
                case "E":
                    XCoordinate += 1;
                    break;
                case "S":
                    YCoordinate -= 1;
                    break;
                case "W":
                    XCoordinate -= 1;
                    break;
                default:
                    throw new Exception($"Invalid direction : {Direction.ToString()}");
            }
        }
        
        //rover moves according to the command sent by nasa
        public void MoveToFinalLocation(string roverCommand , List<int> upperRightCoordinates)
        {
            foreach (var command in roverCommand)
            {
                switch (command)
                {
                    case 'R':
                        SpinRight();
                        break;
                    case 'L':
                        SpinLeft();
                        break;
                    case 'M':
                        Move();
                        break;
                    default:
                        throw new Exception($"Invalid command : {command}");
                }

                if (XCoordinate < 0 || XCoordinate > upperRightCoordinates[0] || YCoordinate < 0 || YCoordinate > upperRightCoordinates[1])
                {
                    throw new Exception($"Plateau limit exceeded : The lower-left coordinates must be 0,0 and the upper-right coordinates must be {upperRightCoordinates[0]},{upperRightCoordinates[1]}.");
                }
            }
        }
    }
}
