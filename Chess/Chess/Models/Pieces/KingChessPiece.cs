using Chess.Models.Base;
using System;
using System.Collections.Generic;
using Chess.Models.Utils;

namespace Chess.Models.Pieces
{
    public class KingChessPiece : ChessPiece
    {
        public KingChessPiece(ChessSquare location, ChessColor color) : base(location, color)
        {
        }

        public override char Symbol
        {
            get
            {
                return 'K';
            }
        }

        public override MoveDirection[] MoveDirections
        {
            get
            {
                return Moves.ALL;
            }
        }

        public override int Value
        {
            get
            {
                // technically, kings value is infinite because game is over when captured!
                return 10000;
            }
        }

        public override string ToString()
        {
            return Color + " King";
        }

        public override List<ChessSquare> GetAvailableMoves()
        {
            // limit of 1 'jump' per each move direction
            return new BoardScanner(this, 1).Scan();
        }

        public override bool CanCapture(ChessPiece pieceToCapture)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckAvailableCaptures()
        {
            throw new NotImplementedException();
        }
    }
}
