using System;
using System.Collections.Generic;
using MarsRover.Constants;

namespace MarsRover.Entities
{
    public class MarsRover
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public DirectionEnum Direction { get; set; }

        public MarsRover(int initialXCoordinate , int initialYCoordinate , string initialDirection)
        {
            XCoordinate = initialXCoordinate;
            YCoordinate = initialYCoordinate;
            Direction = (DirectionEnum)Enum.Parse(typeof(DirectionEnum), initialDirection);
        }

        //the rover spins 90 degrees right without moving from its current spot
        public void SpinRight()
        {
            switch (Direction)
            {
                case DirectionEnum.N:
                    Direction = DirectionEnum.E;
                    break;
                case DirectionEnum.E:
                    Direction = DirectionEnum.S;
                    break;
                case DirectionEnum.S:
                    Direction = DirectionEnum.W;
                    break;
                case DirectionEnum.W:
                    Direction = DirectionEnum.N;
                    break;
                default:
                    throw new Exception($"Invalid direction : {Direction.ToString()}");
            }
        }

        //the rover spins 90 degrees left without moving from its current spot
        public void SpinLeft()
        {
            switch (Direction)
            {
                case DirectionEnum.N:
                    Direction = DirectionEnum.W;
                    break;
                case DirectionEnum.W:
                    Direction = DirectionEnum.S;
                    break;
                case DirectionEnum.S:
                    Direction = DirectionEnum.E;
                    break;
                case DirectionEnum.E:
                    Direction = DirectionEnum.N;
                    break;
                default:
                    throw new Exception($"Invalid direction : {Direction.ToString()}");
            }
        }

        //the rover moves forward one grid point
        public void Move()
        {
            switch (Direction)
            {
                case DirectionEnum.N:
                    YCoordinate += 1;
                    break;
                case DirectionEnum.E:
                    XCoordinate += 1;
                    break;
                case DirectionEnum.S:
                    YCoordinate -= 1;
                    break;
                case DirectionEnum.W:
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
