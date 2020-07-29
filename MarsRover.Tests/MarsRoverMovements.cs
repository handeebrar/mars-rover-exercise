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
            var coordinateCalculationService = new Services.CoordinateCalculationService();
            var rover = new Rover(1, 2, "N");

            coordinateCalculationService.SpinLeft(rover);

            Assert.Equal("W", rover.Direction);
        }

        [Fact]
        public void SpinRight()
        {
            var coordinateCalculationService = new Services.CoordinateCalculationService();
            var rover = new Rover(1, 2, "N");

            coordinateCalculationService.SpinRight(rover);

            Assert.Equal("E", rover.Direction);
        }

        [Fact]
        public void Move()
        {
            var coordinateCalculationService = new Services.CoordinateCalculationService();
            var rover = new Rover(1, 2, "N");

            coordinateCalculationService.Move(rover);

            Assert.Equal(3, rover.YCoordinate);
        }

        [Fact]
        public void MoveToFinalLocation_55_12N_LMLMLMLMM()
        {
            var coordinateCalculationService = new Services.CoordinateCalculationService();
            var rover = new Rover(1, 2, "N");
            var upperRightCoordinates = new List<int> { 5 , 5};

            coordinateCalculationService.MoveToFinalLocation(rover , "LMLMLMLMM" , upperRightCoordinates);

            var expectedOutput = "1 3 N";
            var actualOutput = rover.XCoordinate + " " + rover.YCoordinate + " " + rover.Direction;
            Assert.Equal(expectedOutput , actualOutput);
        }

        [Fact]
        public void MoveToFinalLocation_55_33E_MMRMMRMRRM()
        {
            var coordinateCalculationService = new Services.CoordinateCalculationService();
            var rover = new Rover(3, 3, "E");
            var upperRightCoordinates = new List<int> { 5 , 5 };

            coordinateCalculationService.MoveToFinalLocation(rover , "MMRMMRMRRM" , upperRightCoordinates);

            var expectedOutput = "5 1 E";
            var actualOutput = rover.XCoordinate + " " + rover.YCoordinate + " " + rover.Direction;
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
