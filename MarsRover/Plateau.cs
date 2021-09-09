using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover
{
    class Plateau
    {
        private int maxX= 0;
        private int maxY = 0;
        private readonly string Directions = "NESW";
        private int[] xmoves = new int[] { 0, 1, 0, -1 };
        private int[] ymoves = new int[] { 1, 0, -1, 0 };
        private List<Rover> rovers;

        public Plateau(string mapinfo)
        {
            if (mapinfo?.Contains(" ") != true)
                throw new ArgumentException("Invalid argument:" + mapinfo);

            string[] cords = mapinfo.Split(' ');
            if(!int.TryParse(cords[0], out maxX) || !int.TryParse(cords[1], out maxY))
                throw new ArgumentException(mapinfo);

            rovers = new List<Rover>();
        }

        public bool AddRover(string startPos)
        {
            if (startPos == null )
                throw new ArgumentException("Invalid argument:" + startPos);


            string[] cords = startPos.Split(' ');
            if(cords.Length < 3)
                throw new ArgumentException("Invalid argument:" + startPos);

            Rover rover = new Rover();
            try
            {
                int x, y;
                if (!int.TryParse(cords[0], out x) || !int.TryParse(cords[1], out y) || !Directions.Contains(cords[2]))
                    throw new ArgumentException("Invalid argument:" + startPos);

                rover.X = x;
                rover.Y = y;
                rover.Direction = Directions.IndexOf(cords[2]);
                if (rover.X < 0 || rover.Y < 0 || rover.X > maxX || rover.Y > maxY)
                {
                    Console.WriteLine("Rover can not out of plate!");
                    return false;
                }
                rovers.Add(rover);
                return true;
            }
            catch (Exception)
            {
                throw new ArgumentException("Invalid argument:" + startPos);
            }
        }

        public string SendCommandToRover(string command)
        {
            Rover rover = rovers.Last();
            foreach (char cmd in command)
            {
                if (cmd == 'L')
                    rover.Direction--;
                else if (cmd == 'R')
                    rover.Direction++;
                else if (cmd== 'M')
                {
                    int tempx = rover.X + xmoves[rover.Direction];
                    int tempy = rover.Y + ymoves[rover.Direction];
                    if (tempx < 0 || tempy < 0 || tempx > maxX || tempy > maxY)
                    {
                        Console.WriteLine("Rover can not out of plate!");
                        continue;
                    }
                    var cangopos = true;
                    for (int i = 0; i < rovers.Count-1; i++)
                    {
                        var past = rovers[i];
                        if(tempx == past.X && tempy == past.Y)
                        {

                            Console.WriteLine("There is another rover at the location!");
                            cangopos = false;
                            break;
                        }
                    }                    
                    if(cangopos)
                    {
                        rover.X = tempx;
                        rover.Y = tempy;
                    }
                }
            }
            return $"{rover.X} {rover.Y} {Directions[rover.Direction]}";
        }


    }
}
