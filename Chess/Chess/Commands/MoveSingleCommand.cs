using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Models.Base;

namespace Chess.Commands
{
    public class MoveSingleCommand : ChessCommand
    {
        public override string Pattern
        {
            get
            {
                return @"([a-h])([1-8])\s+([a-h])([1-8])(\*)?$";
            }
        }

        public override void Execute(ChessBoard board)
        {
            int count = _match.Groups.Count;

            ChessSquare startSquare = GetSquareFromMatch(board, 1, 2);

            if (startSquare.IsOccupied())
            {
                ChessSquare endSquare = GetSquareFromMatch(board, 3, 4);

                //TODO remove try catch after implementation finished for all other chess pieces.
                // this is just here so that we don't crash, during development
                try
                {
                    bool didMove = startSquare.Piece.MoveTo(endSquare);

                    if (!didMove)
                    {
                        Debug.PrintWarning(string.Format("Invalid for {0} at {1} to move to {2}", startSquare.Piece, startSquare, endSquare));
                    }

                } catch (NotImplementedException ex)
                {
                    Debug.PrintWarning("Movement not yet implemented for piece: " + startSquare.Piece);
                }
            } else
            {
                Debug.PrintWarning("There is no piece to move on: " + startSquare);
            }
        }
    }
}
