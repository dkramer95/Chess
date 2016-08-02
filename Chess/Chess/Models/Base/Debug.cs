using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Base
{
    /// <summary>
    /// Utility class for printing debug messages to the console.
    /// </summary>
    public class Debug
    {
        public static bool SHOW_MESSAGES = true;

        private static void Print(string msg)
        {
            if (SHOW_MESSAGES)
            {
                Console.WriteLine(msg);
            }
        }

        private static void PrintColored(ConsoleColor bg, ConsoleColor fg, string txt)
        {
            Console.BackgroundColor = bg;
            Console.ForegroundColor = fg;
            Print(txt);
            ClearColors();
        }

        public static void PrintMsg(string msg)
        {
            PrintColored(ConsoleColor.Green, ConsoleColor.Black, msg);
        }

        public static void PrintErr(string err)
        {
            PrintColored(ConsoleColor.DarkRed, ConsoleColor.White, err);
        }

        public static void PrintWarning(string warning)
        {
            PrintColored(ConsoleColor.Yellow, ConsoleColor.Black, warning);
        }

        private static void ClearColors()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}
