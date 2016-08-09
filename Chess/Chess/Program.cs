using Chess.Models.Base;
using Chess.Models.Pieces;
using Chess.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Milestone #1 - File/IO Demo
            FileIODemo(args);
            //InteractiveDemo();
        }

        public static void InteractiveDemo()
        {
            FileIO io = new FileIO();

            for (;;)
            {
                Console.Write("Enter command: ");
                string cmd = Console.ReadLine();
                io.ProcessLine(cmd);
            }
        }

        /// <summary>
        /// Executes Milestone 1 - File/IO Demo
        /// </summary>
        /// <param name="args">ChessCommand Line args</param>
        public static void FileIODemo(string[] args)
        {
            if (args.Length >= 1)
            {
                FileIO io = new FileIO();
                string filename = args[0];
                io.ReadFile(filename);
            } else
            {
                throw new Exception("Missing filename argument!");
            }
        }
    }
}
