using Chess.Models.Base;
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
            //FileIODemo(args);
            ChessBoard b = new ChessBoard();
            b.PrintDebug();
        }

        /// <summary>
        /// Executes Milestone 1 - File/IO Demo
        /// </summary>
        /// <param name="args">Command Line args</param>
        public static void FileIODemo(string[] args)
        {
            if (args.Length > 0)
            {
                string filename = args[0];
                FileIO io = new FileIO();
                io.ProcessFile(filename);
            } else
            {
                throw new ArgumentException("Must supply file as command line argument!");
            }
        }
    }
}
