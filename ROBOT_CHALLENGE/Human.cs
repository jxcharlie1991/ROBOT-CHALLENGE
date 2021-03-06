using System;
using System.Collections.Generic;

namespace ROBOT_CHALLENGE
{
    class Human
    {
        //Attributes
        //There is only one human user and at least one human user, so it is better to declare static attributes.
        public static List<Robot> robs = new List<Robot>();
        public static int CommLocX { get; set; }
        public static int CommLocY { get; set; }
        public static Enumerations.Direction CommLocF { get; set; }
        public static Enumerations.Command Comm { get; set; }
        public static int CommSerial { get; set; }
        public static int DeclareSerial { get; set; } = 0;
        public static int ManipulateSerial { get; set; }

        //Methods
        //There is only one human user and at least one human user, so it is better to declare static methods.
        //Because the first command has to be a place command, 
        //thus separate the first command executing from the command checking would optimise the efficiency, and user would be more clear to input command.
        public static void ExecuteFirstCommand(string userInput)
        {
            userInput = userInput.ToLower();
            if (userInput == "exit")
            {
                Comm = Enumerations.Command.exit;
                Exit();
            }
            else if (userInput.StartsWith("place "))
            {
                string[] placeLoc = userInput.Substring(6).Split(',');
                if (placeLoc.Length == 3 && int.TryParse(placeLoc[0], out int x) && int.TryParse(placeLoc[1], out int y) && Enum.IsDefined(typeof(Enumerations.Direction), placeLoc[2]))
                {
                    if (Ground.CheckOntable(x, y))
                    {
                        Enumerations.Direction f = (Enumerations.Direction)Enum.Parse(typeof(Enumerations.Direction), placeLoc[2]);
                        Comm = Enumerations.Command.place;
                        CommLocX = x;
                        CommLocY = y;
                        CommLocF = f;
                        Place();
                    }
                    else
                    {
                        Comm = Enumerations.Command.unrecognise;
                        Unrecogise();
                        Console.WriteLine("This robot is not placed on the table, this command would not execute, you MUST place the robot on the table.");

                    }
                }
                else
                {
                    Comm = Enumerations.Command.unrecognise;
                    Unrecogise();
                    Console.WriteLine("Please input a valid PLACE command as the first command.");
                }
            }
            else
            {
                Comm = Enumerations.Command.unrecognise;
                Unrecogise();
                Console.WriteLine("The first command has to be PLACE command, please try again.");
            }
        }

        //Separate the validity checking would make the project easier to modify and update.
        public static void AnalyseCommand(string userInput)
        {
            userInput = userInput.ToLower();
            if (userInput.StartsWith("place "))
            {
                string[] commLoc = userInput.Substring(6).Split(',');
                if (commLoc.Length == 3 && int.TryParse(commLoc[0], out int x) && int.TryParse(commLoc[1], out int y) && Enum.IsDefined(typeof(Enumerations.Direction), commLoc[2]))
                {
                    if (Ground.CheckOntable(x, y))
                    {
                        Enumerations.Direction f = (Enumerations.Direction)Enum.Parse(typeof(Enumerations.Direction), commLoc[2]);
                        Comm = Enumerations.Command.place;
                        CommLocX = x;
                        CommLocY = y;
                        CommLocF = f;
                    }
                    else
                    {
                        Comm = Enumerations.Command.unrecognise;
                        Unrecogise();
                        Console.WriteLine("This robot is not on the table, this command would not execute, you MUST place the robot on the table.");
                    }
                }
                else
                {
                    Comm = Enumerations.Command.unrecognise;
                    Unrecogise();
                    Console.WriteLine("Please input a valid PLACE command.");
                }
            }
            else if (userInput.StartsWith("robot ") && int.TryParse(userInput.Substring(6), out int commSerial))
            {

                if (commSerial > 0 && commSerial <= DeclareSerial)
                {
                    Comm = Enumerations.Command.change;
                    CommSerial = commSerial;
                }
                else
                {
                    Comm = Enumerations.Command.unrecognise;
                    Unrecogise();
                    Console.WriteLine("Please select a valid robot. There are only " + DeclareSerial + " robots on the desk");

                }

            }
            else if (Enum.IsDefined(typeof(Enumerations.Command), userInput))
            {
                Comm = (Enumerations.Command)Enum.Parse(typeof(Enumerations.Command), userInput);
            }
            else
            {
                Comm = Enumerations.Command.unrecognise;
                Unrecogise();
                Console.WriteLine("Invalid command input, please try again.");
            }
        }
        public static void Instruction()
        {
            Console.WriteLine("Dear user,");
            Console.WriteLine();
            Console.WriteLine("The application is a simulation of multiple robots moving on a square tabletop, of dimensions 5 units x 5 units.");
            Console.WriteLine("There are no other obstructions on the table surface, the robots are free to roam around the surface of the table.But any movement that would result in the robot falling from the table would be ignored with an alarming message.");
            Console.WriteLine();
            Console.WriteLine("There are also some rules for the command:");
            Console.WriteLine();
            Console.WriteLine("The first command must be PLACE command.");
            Console.WriteLine();
            Console.WriteLine("PLACE should be like PLACE X, Y, direction. For example: ");
            Console.WriteLine("PLACE 2, 3, NORTH");
            Console.WriteLine("PLACE will put the robot in position X, Y and facing NORTH, SOUTH, EAST or WEST.");
            Console.WriteLine("PLACE command is not allowed to place the robot on the ground, it MUST place the robot on the table.");
            Console.WriteLine();
            Console.WriteLine("CHANGE command would select a robot to manipulate, the effective command should be like ROBOT <number>. For example: ");
            Console.WriteLine("ROBOT 3");
            Console.WriteLine();
            Console.WriteLine("MOVE command will move the robot one unit forward in the direction it is currently facing. For example: ");
            Console.WriteLine("MOVE");
            Console.WriteLine();
            Console.WriteLine("ROTATE command would rotate the robot 90 degrees, the effective command contains LEFT and RIGHT. For example: ");
            Console.WriteLine("LEFT");
            Console.WriteLine();
            Console.WriteLine("REPORT command will announce the X, Y and facing of the robot. For example: ");
            Console.WriteLine("REPORT");
            Console.WriteLine();
            Console.WriteLine("EXIT command will exit the program. For example: ");
            Console.WriteLine("EXIT");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("If you understand this INTRODUCTION, please input: UNDERSTAND");
            string introInput;
            while (true)
            {
                Console.WriteLine();
                introInput = Console.ReadLine().ToLower();
                if (introInput == "understand")
                {
                    Console.Clear();
                    Console.WriteLine("Please PLACE a robot on the desk.");
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("ERROR!!! Please input UNDERSTAND.");
                }
            }
        }
        public static void Place()
        {
            Robot rob = new Robot();
            robs.Add(rob);
            DeclareSerial++;
            rob.RobLocX = CommLocX;
            rob.RobLocY = CommLocY;
            rob.RobLocF = CommLocF;
            rob.RobSerial = DeclareSerial;
            ManipulateSerial = rob.RobSerial;
            Console.WriteLine();
            Console.WriteLine("ROBOT " + rob.RobSerial + " is added on the table.");
        }
        public static void ChangeSerial()
        {
            ManipulateSerial = CommSerial;
            Console.WriteLine();
            Console.WriteLine("EXECUTE SUCCEED. ROBOT " + ManipulateSerial + " is ACTIVE now.");
        }
        public static void Report()
        {
            Console.WriteLine();
            Console.WriteLine("EXECUTE SUCCEED.");
            foreach (Robot rob in robs)
            {
                rob.Report();
            }
        }
        public static void Unrecogise()
        {
            Console.WriteLine();
            Console.Write("ERROR!!! ");
        }

        public static void Exit()
        {
            Console.WriteLine();
            Console.WriteLine("See you next time.");
            Environment.Exit(0);
        }
    }
}
