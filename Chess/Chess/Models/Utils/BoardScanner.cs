using Chess.Models.Base;
using Chess.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Utils
{

    /// <summary>
    /// Utility class for "walking" along the various squares of a ChessBoard. This is useful
    /// for checking to see what ChessSquares are available and whether or not we can capture.
    /// Users of this class will have to implement their sentinel conditions for determining
    /// when to stop checking, as this class only allows for movement around the ChessBoard
    /// from its initial Start ChessSquare and only provides methods to check if the next
    /// ChessSquare is contained within the board.
    /// </summary>
    public class BoardScanner
    {
        // The direction we are scanning through the board
        private MoveDirection _direction;
        public MoveDirection Direction
        {
            get
            {
                return _direction;
            }
            set
            {
                _direction = value;
                Reset();
            }
        }

        public ChessSquare Pivot { get; set; }

        private const int NO_LIMIT = 64;
        public int Limit { get; set; }

        private ChessPiece _piece;

        private char _nextFile;
        private int _nextRank;

        private ChessBoard _board;


        public BoardScanner(ChessPiece piece, int limit = NO_LIMIT)
        {
            _piece = piece;
            _board = ChessPiece.Board;
            Pivot  = _piece.Location;
            Limit = limit;
        }

        public List<ChessSquare> Scan()
        {
            List<ChessSquare> available = new List<ChessSquare>();

            _piece.Directions.ForEach(d =>
            {
                Direction = d;
                int count = 0;

                while (HasNext() && count < Limit)
                {
                    ChessSquare square = Next();
                    count++;
                    if (square.IsOccupied())
                    {
                        if (_piece.IsOpponent(square.Piece))
                        {
                            available.Add(square);
                        }
                        break;
                    }
                    available.Add(square);
                }
            });
            return available;
        }

        public List<ChessSquare> ScanBranched()
        {
            List<ChessSquare> available = new List<ChessSquare>();

            _piece.Directions.ForEach(d =>
            {
                Direction = d;
                int count = 0;
                const int BRANCH_THRESHOLD = 1; // where we branch out

                ChessSquare square = null;

                while (HasNext() && count < BRANCH_THRESHOLD)
                {
                    square = Next();
                    count++;
                }
                // Get diagonals and filter out any nulls
                if (square != null)
                {
                    available.AddRange(DiagonalsFrom(square, d).Where(s => s != null));
                }
            });

            return available;
        }

        public List<ChessSquare> DiagonalsFrom(ChessSquare square, MoveDirection startDirection)
        {
            List<ChessSquare> diagonals = null;

            int moveDirection = GetMoveDirection(startDirection);

            if ((startDirection == MoveDirection.NORTH) || (startDirection == MoveDirection.SOUTH))
            {
                // left and right
                diagonals = new List<ChessSquare>()
                {
                    _board.SquareAt((char)(square.File + 1), square.Rank + moveDirection),
                    _board.SquareAt((char)(square.File - 1), square.Rank + moveDirection),
                };
            } else
            {
                diagonals = new List<ChessSquare>()
                {
                    _board.SquareAt((char)(square.File + moveDirection), square.Rank + 1),
                    _board.SquareAt((char)(square.File + moveDirection), square.Rank - 1),
                };
            }
            return diagonals;
        }

        public int GetMoveDirection(MoveDirection d)
        {
            int value = 0;
            switch (d)
            {
                case MoveDirection.NORTH:
                case MoveDirection.EAST:
                    value = 1;
                    break;
                case MoveDirection.SOUTH:
                case MoveDirection.WEST:
                    value = -1;
                    break;
            }

            return value;
        }

        private void Reset()
        {
            _nextFile = Pivot.File;
            _nextRank = Pivot.Rank;
        }

        /// <summary>
        /// Gets the next ChessSquare in the current scan direction context.
        /// </summary>
        /// <returns>next ChessSquare</returns>
        public ChessSquare Next()
        {
            Update(ref _nextFile, ref _nextRank);
            return _board.SquareAt(_nextFile, _nextRank);
        }

        /// <summary>
        /// Updates the nextFile and nextRank based on the current scan direction context.
        /// </summary>
        /// <param name="nextFile">nextFile to update (depending on direction)</param>
        /// <param name="nextRank">nextRank to update (depending on direction)</param>
        private void Update(ref char nextFile, ref int nextRank)
        {
            switch (Direction)
            {
                case MoveDirection.NORTH:
                    nextRank++;
                    break;
                case MoveDirection.SOUTH:
                    nextRank--;
                    break;
                case MoveDirection.EAST:
                    nextFile++;
                    break;
                case MoveDirection.WEST:
                    nextFile--;
                    break;
                case MoveDirection.NORTH_EAST:
                    nextFile++;
                    nextRank++;
                    break;
                case MoveDirection.NORTH_WEST:
                    nextFile--;
                    nextRank++;
                    break;
                case MoveDirection.SOUTH_EAST:
                    nextRank--;
                    nextFile++;
                    break;
                case MoveDirection.SOUTH_WEST:
                    nextRank--;
                    nextFile--;
                    break;

            }
        }

        /// <summary>
        /// Checks to see if there exists another ChessSquare in the current
        /// scan direction context.
        /// </summary>
        /// <returns>true if the next ChessSquare is not null</returns>
        public bool HasNext()
        {
            char nextFile = _nextFile;
            int nextRank = _nextRank;
            Update(ref nextFile, ref nextRank);
            return _board.SquareAt(nextFile, nextRank) != null;
        }
    }

    /// <summary>
    /// Enum for all the different possible movement directions.
    /// </summary>
    public enum MoveDirection
    {
        NORTH, SOUTH, EAST, WEST,
        NORTH_EAST, NORTH_WEST, SOUTH_EAST, SOUTH_WEST,
    }
}
