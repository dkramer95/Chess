using Chess.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Pieces
{
    public class RookChessPiece : ChessPiece
    {
        public RookChessPiece(ChessTile location, ChessColor color) : base(location, color)
        {
        }

        public override bool Capture(ChessPiece pieceToCapture)
        {
            throw new NotImplementedException();
        }

        public override bool MoveTo(ChessTile newLocation)
        {
            throw new NotImplementedException();
        }

        protected override bool IsValidMove(ChessTile newLocation)
        {
            throw new NotImplementedException();
        }
    }
}
