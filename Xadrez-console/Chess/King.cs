using System;
using Xadrez_console.Table;

namespace Xadrez_console.Chess
{
    class King: Component
    {
        public King  (Color color,Tables table) : base(color, table)
        {

        }
        public override string ToString()
        {
            return "K";
        }

        private bool CanMove(Position pos)
        {
            Component p = Table.component(pos);
            return p == null || p.Color != this.Color;
        }
        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Table.Lines, Table.Coluns];
            Position pos = new Position(0, 0);
            //up
            pos.DefineValues(Position.Line - 1, Position.Colun);
            if (Table.ValidPossition(pos) && CanMove(pos))
            {
                mat[pos.Line,pos.Colun] = true;
            }
            //ne
            pos.DefineValues(Position.Line - 1, Position.Colun +1);
            if (Table.ValidPossition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colun] = true;
            }
            //east
            pos.DefineValues(Position.Line , Position.Colun + 1);
            if (Table.ValidPossition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colun] = true;
            }
            //se
            pos.DefineValues(Position.Line+1, Position.Colun + 1);
            if (Table.ValidPossition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colun] = true;
            }
            //down
            pos.DefineValues(Position.Line + 1, Position.Colun );
            if (Table.ValidPossition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colun] = true;
            }
            //sw
            pos.DefineValues(Position.Line + 1, Position.Colun - 1);
            if (Table.ValidPossition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colun] = true;
            }
            //west
            pos.DefineValues(Position.Line , Position.Colun -1);
            if (Table.ValidPossition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colun] = true;
            }
            //nw 
            pos.DefineValues(Position.Line - 1, Position.Colun - 1);
            if (Table.ValidPossition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colun] = true;
            }
            return mat;
        }


    }
}
