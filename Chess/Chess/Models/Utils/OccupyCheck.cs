using Chess.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Utils
{

    /// <summary>
    /// Utility class to help check ChessTiles when determining where a ChessPiece
    /// can land. This basically allows us to acquire a single ChessSquare that is
    /// occupied and then stop.
    /// </summary>
    public class OccupyCheck
    {
        private int _count;
        private static OccupyCheck _instance = new OccupyCheck();

        // prevent direct instantiation
        private OccupyCheck()
        {
        } 

        private static int Count(ChessSquare square)
        {
            int count = _instance.CountOccupation(square);

            if (count >= 1 && !square.IsOccupied())
            {
                _instance = new OccupyCheck();
            }
            return count;
        }

        public static bool IsValid(ChessSquare square)
        {
            //Debug.PrintMsg("checking: " + square);
            return (!square.IsOccupied() && Count(square) == 0)
                || ( square.IsOccupied() && Count(square) == 1);
        }

        private int CountOccupation(ChessSquare square)
        {
            if (square.IsOccupied())
            {
                ++_count;
            }
            return _count;
        }

    }
}
