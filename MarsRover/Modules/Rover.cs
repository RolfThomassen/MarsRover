using System;
using System.Diagnostics;

namespace MarsRover.Modules
{
    class Rover
    {
        public int MinX = 0;
        public int MinY = 0;
        public int MaxX = 0;
        public int MaxY = 0;

        public int PosX = 0;
        public int PosY = 0;
        public Direction Dir = Direction.North;
        public string Cmd = "";

        public enum Direction
        {
            Low = -1,
            North,
            East,
            South,
            West,
            High
        }

        public Rover()
        {
            PosX = 0;
            PosY = 0;
            Dir = Direction.North;
        }

        public Rover(int posX, int posY, Direction dir)
        {
            PosX = posX;
            PosY = posY;
            Dir = dir;
        }

        private void TurnLeft()
        {
            Dir -= 1;
            if (Dir < Direction.North) Dir = Direction.West;
        }
        private void TurnRight()
        {
            Dir += 1;
            if (Dir > Direction.West) Dir = Direction.North;
        }
        private void Move()
        {
            switch (Dir)
            {
                case Direction.North: PosY += 1; break;
                case Direction.South: PosY -= 1; break;
                case Direction.East:  PosX += 1; break;
                case Direction.West:  PosX -= 1; break;

                case Direction.High:
                case Direction.Low:
                    throw new Exception();
                default:
                    break;
            }
            if (PosX < MinX || PosY < MinY || PosX > MaxX || PosY > MaxY)
            {
                throw new Exception("Rover out of bound, rover lost!");
            }
        }

        public void SetCMD(string cmd)
        {
            Cmd = cmd;
        }

        public void SetGrid(int minX, int minY, int maxX, int maxY)
        {
            MinX = minX;
            MinY = minY;
            MaxX = maxX;
            MaxY = maxY;
        }

        public static Direction GetDir(string d)
        {
            d = d.ToUpper();
            return (d == "N") ? Direction.North
                 : (d == "E") ? Direction.East
                 : (d == "S") ? Direction.South
                 : (d == "W") ? Direction.West
                 : Direction.Low;
        }

        public void ExcuteCMD()
        {
            Debug.Print($"Start Pos:{this.ToString()}");
            foreach (char c in Cmd.ToUpper().ToCharArray())
            {
                switch (c)
                {
                    case 'L': TurnLeft(); break;
                    case 'R': TurnRight(); break;
                    case 'M': Move(); break;
                    default: break;
                }
                Debug.Print($"{c}:{this.ToString()}");
            }
        }

        public override string ToString()
        {
            return $"Rover pos: {PosX} {PosY} {Dir.ToString()}";
        }
    }
}

