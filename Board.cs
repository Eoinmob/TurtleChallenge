using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleChallenge
{
    public class Board
    {
        public const int EXIT  =  1;
        public const int MINE  = -1;

        private int[,] tiles = null;
        private int[] startPos = null;
        private int startDir = -1;

        public int N = 0;
        public int M = 0;

        public Board() { }

        public Board(Settings settings)
        {
            N = settings.N;
            M = settings.M;

            Tiles = new int[N, M];

            Tiles[settings.exit[0], settings.exit[1]] = EXIT;

            foreach (int[] tile in settings.minedTiles)
            {
                Tiles[tile[0], tile[1]] = MINE;
            }

            StartPos = settings.startPos;
            StartDir = settings.startDir;
        }

        public int[,] Tiles { get => tiles; set => tiles = value; }
        public int[] StartPos { get => startPos; set => startPos = value; }
        public int StartDir { get => startDir; set => startDir = value; }
    }
}
