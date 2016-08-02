using Chess.Models.Base;
using Chess.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Pieces
{
    public class BishopChessPiece : ChessPiece
    {
        public BishopChessPiece(ChessSquare location, ChessColor color) : base(location, color)
        {
        }

        public override List<MoveDirection> Directions
        {
            get
            {
                return new List<MoveDirection>
                {
                    MoveDirection.NORTH_EAST, MoveDirection.NORTH_WEST,
                    MoveDirection.SOUTH_EAST, MoveDirection.SOUTH_WEST
                };
            }
        }

        public override char Symbol
        {
            get
            {
                return 'B';
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
