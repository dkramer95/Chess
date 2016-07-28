using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhase1.Models
{
    /// <summary>
    /// This class represents a ChessTile on a chess board. A ChessTile has a location
    /// with a [File, Rank] format, a TileColor, and at most one ChessPiece.
    /// </summary>
    public class ChessTile
    {
        // Vertical row { A - H }
        public char File { get; set; }

        // Horizontal row { 1 - 8 }
        public int Rank { get; set; }

        // String representation of this tiles File,Rank location
        protected string _name;

        public string Name { get { return _name; } private set { _name = value; } }

        public ChessColor Color { get; set; }

        // The chess piece that is currently on this ChessTile, if any
        public ChessPiece Piece { get; set; }

        /// <summary>
        /// Constructs a new ChessTile.
        /// </summary>
        /// <param name="file">Vertical Row (File)</param>
        /// <param name="rank">Horizontal Row (Rank)</param>
        /// <param name="color">Color (White / Black)</param>
        public ChessTile(char file, int rank, ChessColor color)
        {
            File = file;
            Rank = rank;
            Color = color;
            Name = File + "" + Rank;
        }

        /// <summary>
        /// Checks to see if this ChessTile is occupied with a chess piece.
        /// </summary>
        /// <returns>true if occupied</returns>
        public bool IsOccupied()
        {
            // If OccupiedPiece is null, we know that this ChessTile is available
            return Piece != null;
        }
    }
}
