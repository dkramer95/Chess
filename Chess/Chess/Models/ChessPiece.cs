using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhase1.Models
{
    /// <summary>
    /// This is the base class for all chess pieces. The functionality between each ChessPiece
    /// will vary but the main functionality that they all share is being able to move around
    /// on a ChessBoard. The interaction logic between all of the different types of ChessPieces
    /// will need to be implemented in subclasses.
    /// </summary>
    public abstract class ChessPiece
    {
        // Location of this chess piece on the board
        public ChessTile Location { get; private set; }

        public ChessColor Color { get; set; }

        // Value of this ChessPiece (each piece has separate constant value)
        public int Value { get; protected set; }

        // The ChessBoard that this ChessPiece belongs to and allows for accessing
        // other tiles 
        private ChessBoard _chessBoard;

        /// <summary>
        /// Constructs a new chess piece at the specified location.
        /// </summary>
        /// <param name="location"></param>
        public ChessPiece(ChessTile location)
        {
            Location = location;
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
        /// </summary>
        /// <param name="pieceToCapture">The ChessPiece that this ChessPiece will capture</param>
        /// <returns>true if a capture was successful</returns>
        public abstract bool Capture(ChessPiece pieceToCapture);
    }
}
