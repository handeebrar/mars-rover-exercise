using System;
using System.Collections.Generic;
using MarsRover.Constants;
using Xunit;

namespace MarsRover.Tests
{
    public class MarsRoverMovements
    {
        [Fact]
        public void SpinLeft()
        {
            Entities.MarsRover marsRover = new Entities.MarsRover(1,2,"N");

            marsRover.SpinLeft();

            Assert.Equal(DirectionEnum.W, marsRover.Direction);
        }

        [Fact]
        public void SpinRight()
        {
            Entities.MarsRover marsRover = new Entities.MarsRover(1, 2, "N");

            marsRover.SpinRight();

            Assert.Equal(DirectionEnum.E, marsRover.Direction);
        }

        [Fact]
        public void Move()
        {
            Entities.MarsRover marsRover = new Entities.MarsRover(1, 2, "N");

            marsRover.Move();

            Assert.Equal(3, marsRover.YCoordinate);
        }

        [Fact]
        public void MoveToFinalLocation_55_12N_LMLMLMLMM()
        {
            Entities.MarsRover marsRover = new Entities.MarsRover(1, 2, "N");
            var upperRightCoordinates = new List<int> { 5 , 5};

            marsRover.MoveToFinalLocation("LMLMLMLMM" , upperRightCoordinates);

            var expectedOutput = "1 3 " + DirectionEnum.N;
            var actualOutput = marsRover.XCoordinate + " " + marsRover.YCoordinate + " " + marsRover.Direction;
            Assert.Equal(expectedOutput , actualOutput);
        }

        [Fact]
        public void MoveToFinalLocation_55_33E_MMRMMRMRRM()
        {
            Entities.MarsRover marsRover = new Entities.MarsRover(3, 3, "E");
            var upperRightCoordinates = new List<int> { 5 , 5 };

            marsRover.MoveToFinalLocation("MMRMMRMRRM" , upperRightCoordinates);

            var expectedOutput = "5 1 " + DirectionEnum.E;
            var actualOutput = marsRover.XCoordinate + " " + marsRover.YCoordinate + " " + marsRover.Direction;
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
