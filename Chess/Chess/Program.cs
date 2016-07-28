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
        }

        /// <summary>
        /// Executes Milestone 1 - File/IO Demo
        /// </summary>
        /// <param name="args">Command Line args</param>
        public static void FileIODemo(string[] args)
        {
            string filename = args[0];
            FileIO.ProcessFile(filename);
        }
    }
}
