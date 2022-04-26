using System;
using Xadrez_console.Table;

namespace Xadrez_console.Chess
{
    class Rook : Component
    {
        public Rook(Color color, Tables table) : base(color, table)
        {

        }
        public override string ToString()
        {
            return "R";
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
            while (Table.ValidPossition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colun] = true;
                if (Table.component(pos) != null && Table.component(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line - 1;

            }

            //down

            pos.DefineValues(Position.Line + 1, Position.Colun);
            while (Table.ValidPossition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colun] = true;
                if (Table.component(pos) != null && Table.component(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line + 1;
            }

            //right

            pos.DefineValues(Position.Line, Position.Colun + 1);
            while (Table.ValidPossition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colun] = true;
                if (Table.component(pos) != null && Table.component(pos).Color != Color)
                {
                    break;
                }
                pos.Colun = pos.Colun + 1;
            }
            //left

            pos.DefineValues(Position.Line, Position.Colun - 1);
            while (Table.ValidPossition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colun] = true;
                if (Table.component(pos) != null && Table.component(pos).Color != Color)
                {
                    break;
                }
                pos.Colun = pos.Colun - 1;

            }
            return mat;

        }
    }
}
    


