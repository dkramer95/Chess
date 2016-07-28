using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Base
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

        //// Light Player's Pieces
        //private List<ChessPiece> _lightPieces;

        //// Dark Player's Pieces
        //private List<ChessPiece> _darkPieces;

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
            CreateTiles();
            AddPieces();
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Creates the 8x8 ChessBoard Tile grid with alternating white and black colors.
        /// </summary>
        private void CreateTiles()
        {
            _tiles = new Dictionary<string, ChessTile>();
            ChessColor tileColor = ChessColor.WHITE;

            // loop top to bottom { 8 - 1 }
            for (int r = MAX_RANK; r >= MIN_RANK; r--)
            {
                // loop left to right { A - H }
                for (char f = MIN_FILE; f <= MAX_FILE; f++)
                {
                    ChessTile tile = new ChessTile(f, r, tileColor);
                    AlternateTileColor(ref tileColor);
                    _tiles.Add(tile.Name, tile);
                }
                AlternateTileColor(ref tileColor);
            }
        }

        public void PrintDebug()
        {
            for (int r = MAX_RANK; r >= MIN_RANK; r--)
            {
                Console.Write(r + " ");

                for (char f = MIN_FILE; f <= MAX_FILE; f++)
                {
                    ChessTile t = GetTile(f, r);
                    char symbol = t.IsOccupied() ? t.Piece.Symbol : ' ';
                    Console.Write("[" + symbol + "]");
                }
                Console.WriteLine();
            }
            Console.Write("   ");
            for (char f = MIN_FILE; f <= MAX_FILE; f++)
            {
                Console.Write(f + "  ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Adds all the LIGHT and DARK pieces
        /// </summary>
        private void AddPieces()
        {
            // Piece layout for DARK (TOP) --> Needs to be reversed for LIGHT (BTM)
            List<char> pieceLayout = new List<char>()
            {
                'R', 'N', 'B', 'Q', 'K', 'B', 'N', 'R',
                'P', 'P', 'P', 'P', 'P', 'P', 'P', 'P',
            };
            
            // Light Pieces Placement boundaries
            const int LIGHT_START_RANK = 2;
            const int LIGHT_END_RANK = 1;
            
            // Dark Pieces Placement boundaries
            const int DARK_START_RANK = MAX_RANK;
            const int DARK_END_RANK = 7;

            AddPieces(pieceLayout, DARK_START_RANK, DARK_END_RANK, ChessColor.DARK);
            pieceLayout.Reverse();
            AddPieces(pieceLayout, LIGHT_START_RANK, LIGHT_END_RANK, ChessColor.LIGHT);
        }

        /// <summary>
        /// Adds pieces to the game tiles.
        /// </summary>
        /// <param name="pieceLayout">Layout of pieces</param>
        /// <param name="start">Starting location</param>
        /// <param name="end">Ending location</param>
        /// <param name="color">The color of the piece</param>
        private void AddPieces(List<char> pieceLayout, int start, int end, ChessColor color)
        {
            int pieceIndex = 0;

            for (int r = start; r >= end; r--)
            {
                for (char f = MIN_FILE; f <= MAX_FILE; f++)
                {
                    ChessTile t = GetTile(f, r);
                    char symbol = pieceLayout.ElementAt(pieceIndex);
                    t.Piece = ChessPiece.FromSymbol(t, color, symbol);
                    pieceIndex++;
                }
            }
        }

        /// <summary>
        /// Alternates between WHITE and BLACK.
        /// </summary>
        /// <param name="lastColor">ChessColor to check and alternate</param>
        private void AlternateTileColor(ref ChessColor lastColor)
        {
            lastColor = (lastColor == ChessColor.BLACK) ? ChessColor.WHITE : ChessColor.BLACK;
        }

        /// <summary>
        /// Returns the ChessTile based off the ChessTile location name
        /// </summary>
        /// <param name="name">ChessTile name</param>
        /// <returns>ChessTile at the location specified by the name</returns>
        public ChessTile GetTile(string name)
        {
            ChessTile tile = null;
            _tiles.TryGetValue(name, out tile);
            return tile;
        }

        /// <summary>
        /// Returns ChessTile based off the file and rank position.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="rank"></param>
        /// <returns></returns>
        public ChessTile GetTile (char file, int rank)
        {
            return GetTile(file + "" + rank);
        }
    }
}
