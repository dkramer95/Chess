using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhase1.Models
{
    /// <summary>
    /// This class represents a chessboard, consisting of an 8X8 Grid of ChessTiles.
    /// </summary>
    public class ChessBoard
    {
        // Horizontal Boundaries
        private const char MIN_FILE = 'a';
        private const char MAX_FILE = 'h';

        // Vertical Boundaries
        private const int MIN_RANK = 1;
        private const int MAX_RANK = 8;

        // Contains all 64 chess tiles and allows us access tiles by their name
        private Dictionary<string, ChessTile> _tiles;

        public ChessBoard()
        {
            Init();
        }

        /// <summary>
        /// Resets the chess board such that all the game pieces are in their original,
        /// proper starting positions.
        /// </summary>
        public void Reset()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Initializes this Chessboard by ensuring that all the tiles are created.
        /// </summary>
        private void Init()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the tile based off the name
        /// </summary>
        /// <param name="name">ChessTile name</param>
        /// <returns>ChessTile at the location specified by the name</returns>
        public ChessTile GetTile(string name)
        {
            ChessTile tile = null;
            _tiles.TryGetValue(name, out tile);
            return tile;
        }
    }
}
