using System;
using System.Collections.Generic;

namespace MarsRoverKata
{
    public class Controller
    {
        private Rover rover;

        public Controller(Rover rover)
        {
            this.rover = rover;
        }

        public void ProcessCommands(IEnumerable<Char> commands)
        {
            foreach (var command in commands)
                SendCommandToRover(command);
        }

        public void SendCommandToRover(Char command)
        {
            if (CommandIsForward(command))
                rover.MoveForward();
            else if (CommandIsBackward(command))
                rover.MoveBackward();
            else if (CommandIsRight(command))
                rover.TurnRight();
            else if (CommandIsLeft(command))
                rover.TurnLeft();
        }

        private static Boolean CommandIsLeft(Char command)
        {
            return command == 'l';
        }

        private static Boolean CommandIsRight(Char command)
        {
            return command == 'r';
        }

        private static Boolean CommandIsBackward(Char command)
        {
            return command == 'b';
        }

        private static Boolean CommandIsForward(Char command)
        {
            return command == 'f';
        }
    }
}
