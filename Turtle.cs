using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleChallenge
{
    public class Turtle
    {
        const int NORTH = 0;
        const int EAST = 1;
        const int SOUTH = 2;
        const int WEST = 3;

        private static int[] pos;
        private static int dir;

        private Turtle() { }

        private static Turtle turtle;

        public static int[] Pos { get => pos; set => pos = value; }
        public static int Dir { get => dir; set => dir = value; }

        /// <summary>
        /// Return single instance for singleton pattern
        /// </summary>
        
        public static Turtle GetInstance()
        {
            if (turtle == null)
            {
                turtle = new Turtle();
            }
            return turtle;
        }

        /// <summary>
        /// Adjust turtles position based on current direction
        /// </summary>
        
        public static void MoveTurtle()
        {
            switch (Dir)
            {
                case NORTH:
                    Pos[1]--;
                    break;
                case EAST:
                    Pos[0]++;
                    break;
                case SOUTH:
                    Pos[1]++;
                    break;
                case WEST:
                    Pos[0]--;
                    break;
            }
        }

        /// <summary>
        /// Increment integer represting oriention. Adjust to 0 on full revolution.
        /// </summary>

        public static void RotateTurtle()
        {
            Dir++;

            if (Dir > 3)
            {
                Dir = 0;
            }
        }
    }
}
