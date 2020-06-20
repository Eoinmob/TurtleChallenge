using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleChallenge
{
    public class Settings
    {
        public int N = 0;
        public int M = 0;

        public int startDir = 0;
        public int[] startPos = null;
        public int[] exit = null;

        public List<int[]> minedTiles = new List<int[]>();
    }
}
