using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Utils
{
    /// <summary>
    /// Convenience class for having "tidy" access to different move types. This is just
    /// a collection of static arrays, for each of the different moves. To eliminate
    /// redundancy, ChessPieces should return one of these arrays for their MoveDirection
    /// property.
    /// </summary>
    class Moves
    {
        // Pawn
        public static MoveDirection[] NORTH = 
        {
            MoveDirection.NORTH
        };

        // Pawn
        public static MoveDirection[] SOUTH =
        {
            MoveDirection.SOUTH
        };

        // Rook / Knight
        public static MoveDirection[] HORIZ_VERT = 
        {
            MoveDirection.NORTH,
            MoveDirection.SOUTH,
            MoveDirection.EAST,
            MoveDirection.WEST
        };

        // Bishop
        public static MoveDirection[] DIAGONAL =
        {
            MoveDirection.NORTH_EAST,
            MoveDirection.NORTH_WEST,
            MoveDirection.SOUTH_EAST,
            MoveDirection.SOUTH_WEST
        };

        // King, Queen
        public static MoveDirection[] ALL =
        {
            MoveDirection.NORTH,
            MoveDirection.SOUTH,
            MoveDirection.EAST,
            MoveDirection.WEST,
            MoveDirection.NORTH_EAST,
            MoveDirection.NORTH_WEST,
            MoveDirection.SOUTH_EAST,
            MoveDirection.SOUTH_WEST
        };
    }

    /// <summary>
    /// Enum for all the different possible movement directions.
    /// </summary>
    public enum MoveDirection
    {
        NORTH,
        SOUTH,
        EAST,
        WEST,
        NORTH_EAST,
        NORTH_WEST,
        SOUTH_EAST,
        SOUTH_WEST,
    }
}
