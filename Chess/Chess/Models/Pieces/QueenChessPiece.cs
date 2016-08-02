using Chess.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Models.Utils;

namespace Chess.Models.Pieces
{
    public class QueenChessPiece : ChessPiece
    {
        public QueenChessPiece(ChessSquare location, ChessColor color) : base(location, color)
        {
        }

        public override List<MoveDirection> Directions
        {
            get
            {
                return new List<MoveDirection>
                {
                    MoveDirection.NORTH, MoveDirection.SOUTH,
                    MoveDirection.EAST, MoveDirection.WEST,
                    MoveDirection.NORTH_EAST, MoveDirection.NORTH_WEST,
                    MoveDirection.SOUTH_EAST, MoveDirection.SOUTH_WEST
                };
            }
        }

        public override char Symbol
        {
            get
            {
                return 'Q';
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
