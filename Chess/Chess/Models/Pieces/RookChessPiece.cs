using Chess.Models.Base;
using Chess.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Pieces
{
    public class RookChessPiece : ChessPiece
    {
        public RookChessPiece(ChessSquare location, ChessColor color) : base(location, color)
        {
        }

        public override List<MoveDirection> Directions
        {
            get
            {
                return new List<MoveDirection>
                {
                    MoveDirection.NORTH, MoveDirection.SOUTH,
                    MoveDirection.EAST, MoveDirection.WEST
                };
            }
        }

        public override char Symbol
        {
            get
            {
                return 'R';
            }
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
