using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Base
{
    /// <summary>
    /// Simple enum for Black/White color representation in chess.
    /// </summary>
    public enum ChessColor
    {
        BLACK,
        WHITE,

        LIGHT = WHITE,
        DARK = BLACK,
    }
}
