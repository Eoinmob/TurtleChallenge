using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace TurtleChallenge
{
    public class TurtleChallengeMain
    {
        const int MOVE   = 0;
        const int ROTATE = 1;

        public const string OUTOFBOUNDS = "Out of bounds. Turtle lost to no man's land.";
        public const string SUCCESS     = "Success! Exit found.";
        public const string FAILURE     = "Mine Triggered!";
        public const string INCOMPLETE  = "Still stuck in the mine field...";

        /// <summary>
        /// Main entry point of the application
        /// </summary>
        /// <param name="args">Application arguments</param>
        
        static void Main(string[] args)
        {
            Settings settings = LoadSettingsFromFile("game-settings.json");
            List<int[]> sequences = LoadMovesFromFile("moves.json");

            Turtle.GetInstance();
            Board board = new Board(settings);

            for(int i = 0; i < sequences.Count; i++)
            {
                string result = ProcessMoveSequence(sequences[i], board);
                Console.WriteLine("Sequence {0} : {1}", i, result);
            }           
        }

        /// <summary>
        /// Load settings data from .json file
        /// </summary>
        /// <param name="args">File path</param>
        
        public static Settings LoadSettingsFromFile(string path)
        {
            try
            {
                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    Settings settings = JsonConvert.DeserializeObject<Settings>(json);
                    return settings;
                }
            }
            catch
            {
                throw new FileNotFoundException("Settings file not found");
            }
        }

        /// <summary>
        /// Load moves sequences from .json file
        /// </summary>
        /// <param name="args">File path</param>
        
        public static List<int[]> LoadMovesFromFile(string path)
        {
            try
            {
                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    List<int[]> sequences = JsonConvert.DeserializeObject<List<int[]>>(json);
                    return sequences;
                }
            }
            catch
            {
                throw new FileNotFoundException("Moves file not found");
            }
        }

        /// <summary>
        /// Process sequence of moves represented as binary array. If turtle moves, check for terminal result or continue until all moves processed. Return incomplete if moves list exhausted.
        /// </summary>
        /// <param name="args">Sequence of moves to complete, board to complete them on</param>
        
        public static string ProcessMoveSequence(int[] moves, Board board)
        {
            Turtle.Pos = (int[]) board.StartPos.Clone();
            Turtle.Dir = board.StartDir;

            for (int i = 0; i < moves.Length; i++)
            {
                if (moves[i] == MOVE)
                {
                    Turtle.MoveTurtle();

                    int x = Turtle.Pos[0];
                    int y = Turtle.Pos[1];

                    bool isOutOfBounds = ((x < 0 || board.N <= x) || (y < 0 || board.M <= y));

                    if (isOutOfBounds)
                    {
                        return OUTOFBOUNDS;
                    }
                    else if (board.Tiles[x, y] == Board.EXIT)
                    {
                        return SUCCESS;
                    }
                    else if (board.Tiles[x, y] == Board.MINE)
                    {
                        return FAILURE;
                    }
                }
                else if (moves[i] == ROTATE)
                {
                    Turtle.RotateTurtle();
                }
            }

            return INCOMPLETE;
        }
    }
}
