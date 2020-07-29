using System.Collections.Generic;
using MarsRover.Models;
using Xunit;

namespace MarsRover.Tests
{
    public class MarsRoverMovements
    {
        [Fact]
        public void SpinLeft()
        {
            Services.CoordinateCalculationService marsRover = new Services.CoordinateCalculationService();
            Rover rover = new Rover(1, 2, "N");

            marsRover.SpinLeft(rover);

            Assert.Equal("W", rover.Direction);
        }

        [Fact]
        public void SpinRight()
        {
            Services.CoordinateCalculationService marsRover = new Services.CoordinateCalculationService();
            Rover rover = new Rover(1, 2, "N");

            marsRover.SpinRight(rover);

            Assert.Equal("E", rover.Direction);
        }

        [Fact]
        public void Move()
        {
            Services.CoordinateCalculationService marsRover = new Services.CoordinateCalculationService();
            Rover rover = new Rover(1, 2, "N");

            marsRover.Move(rover);

            Assert.Equal(3, rover.YCoordinate);
        }

        [Fact]
        public void MoveToFinalLocation_55_12N_LMLMLMLMM()
        {
            Services.CoordinateCalculationService marsRover = new Services.CoordinateCalculationService();
            Rover rover = new Rover(1, 2, "N");
            var upperRightCoordinates = new List<int> { 5 , 5};

            marsRover.MoveToFinalLocation(rover , "LMLMLMLMM" , upperRightCoordinates);

            var expectedOutput = "1 3 N";
            var actualOutput = rover.XCoordinate + " " + rover.YCoordinate + " " + rover.Direction;
            Assert.Equal(expectedOutput , actualOutput);
        }

        [Fact]
        public void MoveToFinalLocation_55_33E_MMRMMRMRRM()
        {
            Services.CoordinateCalculationService marsRover = new Services.CoordinateCalculationService();
            Rover rover = new Rover(3, 3, "E");
            var upperRightCoordinates = new List<int> { 5 , 5 };

            marsRover.MoveToFinalLocation(rover , "MMRMMRMRRM" , upperRightCoordinates);

            var expectedOutput = "5 1 E";
            var actualOutput = rover.XCoordinate + " " + rover.YCoordinate + " " + rover.Direction;
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
