using Chess.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Models.Utils;

namespace Chess.Models.Pieces
{
    public class KnightChessPiece : ChessPiece
    {
        public KnightChessPiece(ChessSquare location, ChessColor color) : base(location, color)
        {
        }
        

        public override char Symbol
        {
            get
            {
                return 'N';
            }
        }

        public override MoveDirection[] MoveDirections
        {
            get
            {
                return Moves.HORIZ_VERT;
            }
        }

        public override int Value
        {
            get
            {
                return 350;
            }
        }

        public override string ToString()
        {
            return Color + " Knight";
        }

        public override List<ChessSquare> GetAvailableMoves()
        {
            return new BoardScanner(this).ScanBranched();
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
