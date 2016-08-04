using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Models.Base;

namespace Chess.Commands
{
    class GetMovesCommand : ChessCommand
    {
        public override string Pattern
        {
            get
            {
                return @"showmoves$";
            }
        }

        public override bool Execute(ChessBoard board)
        {
            Dictionary<ChessPiece, List<ChessSquare>> allMoves = new Dictionary<ChessPiece, List<ChessSquare>>();
            CurrentPlayer.Pieces.ForEach(p => allMoves.Add(p, p.GetAvailableMoves()));

            foreach (ChessPiece p in allMoves.Keys)
            {
                List<ChessSquare> movesForPiece = allMoves[p];
                movesForPiece.ForEach(s => Console.WriteLine(p + " at: " + p.Location + " can move to : " + s));
            }

            //CurrentPlayer.Pieces.ForEach(p => allMoves.AddRange(p.GetAvailableMoves()));
            //allMoves.ForEach(s => Console.WriteLine(s));
            return false;
        }
    }
}
