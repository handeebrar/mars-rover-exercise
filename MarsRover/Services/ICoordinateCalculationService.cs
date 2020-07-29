using System;
using System.Collections.Generic;
using System.Text;
using MarsRover.Models;

namespace MarsRover.Services
{
    public interface ICoordinateCalculationService
    {
        void SpinRight(Rover rover);
        void SpinLeft(Rover rover);
        void Move(Rover rover);
        void MoveToFinalLocation(Rover rover, string roverCommand, List<int> upperRightCoordinates);
    }
}
