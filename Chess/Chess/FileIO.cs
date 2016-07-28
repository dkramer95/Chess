using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    /// <summary>
    /// First milestone assignment. This class handles receiving a filename as a command
    /// line argument, which contains chess directives.
    /// These directives include:
    /// 1) Place a piece on board
    /// -------------------------
    ///     K = King
    ///     Q = Queen
    ///     B = Bishop
    ///     N = Knight
    ///     R = Rook
    ///     P = Pawn
    ///     
    ///     l = Light
    ///     d = Dark
    /// -------------------------
    /// 2) Move a single piece on the board
    /// 3) Move two pieces in a single turn
    /// </summary>
    public class FileIO
    {
        private List<string> moves;

        public void ProcessFile(string filename)
        {
            StreamReader fileReader = new StreamReader(filename);
            string line = null;

            while ((line = fileReader.ReadLine()) != null)
            {

            }
        }
    }
}
