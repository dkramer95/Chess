using Chess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Base
{
    /// <summary>
    /// This class allows for a gameplay to occur by allowing players to alternate
    /// and move their pieces around on the ChessBoard.
    /// </summary>
    public class ChessGame
    {
        private ChessBoard _board;
        private ChessPlayer _lightPlayer;
        private ChessPlayer _darkPlayer;

        // ChessPlayer who is currently in the middle of moving
        private ChessPlayer _activePlayer;
        private CommandProcessor _cmdProcessor;

        private bool _isGameOver;

        public ChessGame()
        {
            _board = new ChessBoard();
            _board.Init();
            _lightPlayer = new ChessPlayer(ChessColor.LIGHT, _board.LightPieces);
            _darkPlayer = new ChessPlayer(ChessColor.DARK, _board.DarkPieces);
            _cmdProcessor = new CommandProcessor(_board);

            // fake out first time --> really is light player
            _activePlayer = _darkPlayer;
            BeginGame();
        }

        public void Play()
        {
            while (!_isGameOver)
            {
                // alternate and get moves between each player
                PromptMove();
            }
        }

        private void PromptMove()
        {
            PrintPrompt();
            ReadCommand();
        }

        private void PrintPrompt()
        {
            ColorizeConsole();
            Console.Write(_activePlayer + "'s move: ");
            Console.ResetColor();
        }

        /// <summary>
        /// Reads in a string on the current line in the console and attempts
        /// process it.
        /// </summary>
        private void ReadCommand()
        {
            string command = Console.ReadLine();
            if (_cmdProcessor.ProcessLine(command))
            {
                NextTurn();
            }
        }

        private void ColorizeConsole()
        {
            ChessColor playerColor = _activePlayer.Color;
            ConsoleColor bg = (playerColor == ChessColor.DARK) ? ConsoleColor.DarkGray : ConsoleColor.White;
            ConsoleColor fg = ConsoleColor.Black;
            Debug.SetConsoleColors(bg, fg);
        }

        private void BeginGame()
        {
            NextTurn();
            _board.PrintDebug();
            Play();
        }

        /// <summary>
        /// Advances the turn to the next player.
        /// </summary>
        private void NextTurn()
        {
            _activePlayer.IsCurrentMove = false;
            _activePlayer = (_activePlayer == _lightPlayer) ? _darkPlayer : _lightPlayer;
            _activePlayer.IsCurrentMove = true;
            _cmdProcessor.CurrentPlayer = _activePlayer;
            _board.PrintDebug();
        }

    }
}
