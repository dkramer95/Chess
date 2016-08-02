using Chess.Models.Base;
using Chess.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Models.Utils;

namespace Chess.Models.Pieces
{
    /// <summary>
    /// This is the ChessPiece implementation for Pawns.
    /// 
    /// ::MOVEMENT_RULES::
    /// For their first move, a Pawn may move up to two ChessTiles, and thereafter they
    /// may only move one ChessSquare at a time.
    /// 
    /// ::PROMOTION::
    /// If a pawn advances to the end rank (8 for LIGHT, 1 for DARK), it can be promoted.
    /// A promotion means this Pawn can be exchanged for any other piece, with the exception
    /// of another Pawn or a King.
    /// 
    /// ::CAPTURING::
    /// Pawns capture by moving one square diagonally, either to the right or left. Pawns
    /// CANNOT capture, by moving straight foreward. Captures can only happen on pieces of
    /// the opposite color of this Pawn.
    /// 
    /// ::VALUE::
    /// Pawns have a value of 1.
    /// </summary>
    public class PawnChessPiece : ChessPiece
    {
        // Movement direction constants
        private const int LIGHT_MOVE_DIRECTION  = -1;
        private const int DARK_MOVE_DIRECTION   = 1;

        private int _moveDirection;

        public override char Symbol
        {
            get
            {
                return 'P';
            }
        }

        public override List<MoveDirection> Directions
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public PawnChessPiece(ChessSquare location, ChessColor color) : base(location, color)
        {
            Init();
        }

        protected void Init()
        {
            _moveDirection = (Color == ChessColor.LIGHT) ? DARK_MOVE_DIRECTION : LIGHT_MOVE_DIRECTION;
            Value = 1;
        }

        /// <summary>
        /// Movement for this PawnChessPiece. Pawns can move one ChessSquare in the
        /// direction of the enemy camp. It cannot move, if there is another ChessPiece
        /// in front of it nor can it capture it. A PawnChessPiece can also never
        /// move backwards.
        /// </summary>
        /// <param name="newLocation">The potential new ChessSquare location
        /// for this PawnChessPiece</param>
        /// <returns>true if move occurred and was successful</returns>
        public override bool MoveTo(ChessSquare newLocation)
        {
            bool moveSuccess = false;

            if (IsValidMove(newLocation))
            {
                if (newLocation.IsOccupied())
                {
                    Capture(newLocation.Piece);
                }
                UpdateLocation(newLocation);
                moveSuccess = true;
                Debug.PrintMsg(this + " moved to " + newLocation);
            } else
            {
                Debug.PrintWarning("Invalid movement for: " + this);
            }

            return moveSuccess;
        }

        protected override bool CheckAvailableCaptures()
        {
            // Check Diagonally Left and Right From Current Position
            // And Look For ChessPieces
            List<ChessSquare> diagonals = GetDiagonals();
            List<ChessPiece> availableCaptures = new List<ChessPiece>();
            diagonals.ForEach(s =>
            {
                if (s != null)
                {
                    if (s.IsOccupied())
                    {
                        availableCaptures.Add(s.Piece);
                    }
                }
            });
            return availableCaptures.Count > 0;
        }

        private bool CanCapture(List<ChessSquare> squaresToCheck)
        {
            foreach(ChessSquare s in squaresToCheck)
            {
                if (s != null && s.IsOccupied() && s.Piece.Color != Color)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Gets the left and right diagonals for this PawnChessPiece. NOTE: Depending
        /// on the position of this PawnChessPiece, a diagonal may be NULL because it
        /// is out of bounds from the ChessBoard.
        /// </summary>
        /// <returns>List containing left and right diagonal ChessSquares</returns>
        protected List<ChessSquare> GetDiagonals()
        {
            List<ChessSquare> diagonals = new List<ChessSquare>()
            {
                _board.SquareAt((char)(Location.File + 1), Location.Rank + _moveDirection),
                _board.SquareAt((char)(Location.File - 1), Location.Rank + _moveDirection),
            };
            return diagonals;
        }

        /// <summary>
        /// Validates new ChessSquare location movement for this PawnChessPiece.
        /// </summary>
        /// <param name="newLocation">The potential new ChessSquare location
        /// for this PawnChessPiece</param>
        /// <returns>true if movement is valid</returns>
        protected override bool IsValidMove(ChessSquare newLocation)
        {
            List<ChessSquare> diagonals = GetDiagonals();

            bool isValid = (diagonals.Contains(newLocation) && CanCapture(diagonals)) || 
                            IsInline(newLocation) && !newLocation.IsOccupied();
            return isValid;
        }

        private bool IsInline(ChessSquare newLocation)
        {
            return (newLocation.Rank == (Location.Rank + _moveDirection))
                    && (newLocation.File == Location.File);
        }

        public override bool CanCapture(ChessPiece pieceToCapture)
        {
            throw new NotImplementedException();
        }

        public override List<ChessSquare> GetAvailableMoves()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return Color + " Pawn";
        }
    }
}
