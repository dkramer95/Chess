using Chess.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Base
{
    /// <summary>
    /// This is the base class for all chess pieces. This class provides enforcement of basic
    /// functionality that all ChessPieces will share through abstraction, but allows sub-classes
    /// to define the individual behavior logic for each type of ChessPiece.
    /// All ChessPieces have a particular way of moving around on a ChessBoard and can also
    /// capture other ChessPieces based on the current context. 
    /// </summary>
    public abstract class ChessPiece
    {
        // Location of this chess piece on the board
        public ChessTile Location { get; private set; }

        // Light or Dark Color of this ChessPiece
        public ChessColor Color { get; set; }

        // Value of this ChessPiece (each piece has separate constant value)
        public int Value { get; protected set; }

        // Has this ChessPiece been captured by another ChessPiece?
        public bool IsCaptured { get; protected set; }

        // One character identifier for a chess piece
        public char Symbol { get; protected set; }

        // The ChessBoard that this ChessPiece belongs to and allows for accessing
        // other tiles 
        private ChessBoard _chessBoard;

        /// <summary>
        /// Constructs a new chess piece at the specified location.
        /// </summary>
        /// <param name="location"></param>
        public ChessPiece(ChessTile location, ChessColor color)
        {
            Location = location;
            Color = color;
        }

        /// <summary>
        /// Helpful factory method to return a chess piece based on the specified shorthand
        /// char symbol.
        /// </summary>
        /// <param name="location">Location of where to place piece</param>
        /// <param name="color">Color to assign to piece</param>
        /// <param name="symbol">The symbol type of the chess piece</param>
        /// <returns></returns>
        public static ChessPiece FromSymbol(ChessTile location, ChessColor color, char symbol)
        {
            ChessPiece piece = null;
            switch (symbol)
            {
                case 'P':
                    piece = new PawnChessPiece(location, color);
                    break;
                case 'N':
                    piece = new KnightChessPiece(location, color);
                    break;
                case 'B':
                    piece = new KnightChessPiece(location, color);
                    break;
                case 'R':
                    piece = new RookChessPiece(location, color);
                    break;
                case 'Q':
                    piece = new QueenChessPiece(location, color);
                    break;
                case 'K':
                    piece = new QueenChessPiece(location, color);
                    break;
                default:
                    throw new ArgumentException("Invalid symbol! Must be 'P', 'N', 'B', 'R', 'Q', or 'K'");
            }
            piece.Symbol = symbol;
            return piece;
        }

        /// <summary>
        /// Method to be implemented that allows for a chess piece
        /// to move. When a chess piece moves, it must also update its current
        /// ChessTile and inform it that it is no longer present.
        /// </summary>
        /// <param name="newLocation">New location to move this chess piece too</param>
        /// <returns>true if this chess piece moved to the new location successfully</returns>
        public abstract bool MoveTo(ChessTile newLocation);

        /// <summary>
        /// Method to be implementation that verifies that the potential new location for
        /// this chess piece is valid. This method should be called in the MoveTo() method
        /// to ensure proper piece movement.
        /// </summary>
        /// <param name="newLocation">New location to check and see if this chess piece can move too</param>
        /// <returns>true if new location is valid</returns>
        protected abstract bool IsValidMove(ChessTile newLocation);

        /// <summary>
        /// Method to be implemented that allows this chess piece to capture another chess piece.
        /// Capturing occurs when another ChessPiece moves onto another ChessTile occupied by the
        /// opponent.
        /// </summary>
        /// <param name="pieceToCapture">The ChessPiece that this ChessPiece will capture</param>
        /// <returns>true if a capture was successful</returns>
        public abstract bool Capture(ChessPiece pieceToCapture);
    }
}
