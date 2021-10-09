using System;

namespace ROBOT_CHALLENGE
{
    class Robot
    {
        //Attributes 
        public int RobLocX { get; set; }
        public int RobLocY { get; set; }
        public Enumerations.Direction RobLocF { get; set; }
        public int RobSerial { get; set; }

        //Methods
        public void ExecuteCommand()
        {
            switch (Human.Comm)
            {
                case Enumerations.Command.place:
                    Human.Place();
                    break;
                case Enumerations.Command.change:
                    Human.ChangeSerial();
                    break;
                case Enumerations.Command.left:
                    Rotate();
                    break;
                case Enumerations.Command.right:
                    Rotate();
                    break;
                case Enumerations.Command.move:
                    Move();
                    break;
                case Enumerations.Command.report:
                    Human.Report();
                    break;
                case Enumerations.Command.exit:
                    Human.Exit();
                    break;
            }
        }

        // Move method should tell user whether robot is on the table, and ensure robot would not fall from the table.
        private void Move()
        {
            switch (RobLocF)
            {
                case Enumerations.Direction.east:
                    RobLocX++;
                    if (!Ground.CheckOntable(RobLocX, RobLocY))
                    {
                        RobLocX--;
                        Console.WriteLine();
                        Console.WriteLine("ERROR!!! ROBOT " + RobSerial + " is going to fall from the table, this command would not execute, please try again.");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("EXECUTE SUCCEED. ROBOT " + RobSerial + " has moved one unit.");
                    }
                    break;
                case Enumerations.Direction.south:
                    RobLocY--;
                    if (!Ground.CheckOntable(RobLocX, RobLocY))
                    {
                        RobLocY++;
                        Console.WriteLine();
                        Console.WriteLine("ERROR!!! ROBOT " + RobSerial + " is going to fall from the table, this command would not execute, please try again.");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("EXECUTE SUCCEED. ROBOT " + RobSerial + " has moved one unit.");
                    }
                    break;
                case Enumerations.Direction.west:
                    RobLocX--;
                    if (!Ground.CheckOntable(RobLocX, RobLocY))
                    {
                        RobLocX++;
                        Console.WriteLine();
                        Console.WriteLine("ERROR!!! ROBOT " + RobSerial + " is going to fall from the table, this command would not execute, please try again.");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("EXECUTE SUCCEED. ROBOT " + RobSerial + " has moved one unit.");
                    }
                    break;
                case Enumerations.Direction.north:
                    RobLocY++;
                    if (!Ground.CheckOntable(RobLocX, RobLocY))
                    {
                        RobLocY--;
                        Console.WriteLine();
                        Console.WriteLine("ERROR!!! ROBOT " + RobSerial + " is going to fall from the table, this command would not execute, please try again.");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("EXECUTE SUCCEED. ROBOT " + RobSerial + " has moved one unit.");
                    }
                    break;
            }
        }

        private void Rotate()
        {
            if (Human.Comm == Enumerations.Command.left)
            {
                switch (RobLocF)
                {
                    case Enumerations.Direction.east:
                        RobLocF = Enumerations.Direction.north;
                        break;
                    case Enumerations.Direction.south:
                        RobLocF = Enumerations.Direction.east;
                        break;
                    case Enumerations.Direction.west:
                        RobLocF = Enumerations.Direction.south;
                        break;
                    case Enumerations.Direction.north:
                        RobLocF = Enumerations.Direction.west;
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("EXECUTE SUCCEED. ROBOT " + RobSerial + " has turned left.");
            }
            else
            {
                switch (RobLocF)
                {
                    case Enumerations.Direction.east:
                        RobLocF = Enumerations.Direction.south;
                        break;
                    case Enumerations.Direction.south:
                        RobLocF = Enumerations.Direction.west;
                        break;
                    case Enumerations.Direction.west:
                        RobLocF = Enumerations.Direction.north;
                        break;
                    case Enumerations.Direction.north:
                        RobLocF = Enumerations.Direction.east;
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("EXECUTE SUCCEED. ROBOT " + RobSerial + " has turned right.");
            }
        }

        public void Report()
        {
            Console.Write("ROBOT " + RobSerial + ": " + RobLocX + ", " + RobLocY + ", " + RobLocF.ToString().ToUpper());
            if (Human.ManipulateSerial == RobSerial)
            {
                Console.WriteLine("    ACTIVE.");
            }
            else
            {
                Console.WriteLine();
            }
        }
    }
}
