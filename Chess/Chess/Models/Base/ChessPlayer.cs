using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Base
{
    /// <summary>
    /// This class represents a single chess player. This class is used to 
    /// control game flow and allow for alternation between moves.
    /// </summary>
    public class ChessPlayer
    {
        public List<ChessPiece> Pieces { get; private set; }

        // The active chess piece the player is attempting to move
        public ChessPiece ActivePiece { get; set; }

        public ChessColor Color { get; private set; }

        // Is it this ChessPlayer's current move?
        public bool IsCurrentMove { get; set; }

        /// <summary>
        /// Constructs a new ChessPlayer with the specified ChessColor
        /// and List of ChessPieces, that the ChessPlayer can move around
        /// during gameplay.
        /// </summary>
        /// <param name="color">Color of this player</param>
        /// <param name="pieces">Chesspieces of this player</param>
        public ChessPlayer(ChessColor color, List<ChessPiece> pieces)
        {
            Color = color;
            Pieces = pieces;
        }

        public override string ToString()
        {
            return "Player: " + Color;
        }
    }
}
