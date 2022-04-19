using System;
using Xadrez_console.Table;

namespace Xadrez_console.Chess
{
    internal class ChessPosition
    {
        public char ColunChess { get; set; }
        public int LineChess { get; set; }

        public ChessPosition(char colunChess, int lineChess)
        {
            ColunChess = colunChess;
            LineChess = lineChess;
        }
        public Position ToChessPosition()
        {
            return new Position(8 - LineChess, ColunChess - 'a');
        }

        public override string ToString()
        {
            return "" + ColunChess + LineChess ;
        }
    }
}
