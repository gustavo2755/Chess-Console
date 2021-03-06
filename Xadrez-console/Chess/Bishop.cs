using Xadrez_console.Table;

namespace Xadrez_console.Chess
{
    public class Bishop : Component

    {
        public Bishop(Color color, Tables table) : base(color, table)
        {
        }
        public override string ToString()
        {
            return "B";
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
            //up - left 

            pos.DefineValues(Position.Line - 1, Position.Colun - 1);
            while (Table.ValidPossition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colun] = true;
                if (Table.component(pos) != null && Table.component(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line - 1, pos.Colun - 1);

            }

            //up - right

            pos.DefineValues(Position.Line - 1, Position.Colun + 1);
            while (Table.ValidPossition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colun] = true;
                if (Table.component(pos) != null && Table.component(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line - 1, pos.Colun + 1);
            }

            // down - left 

            pos.DefineValues(Position.Line + 1, Position.Colun - 1);
            while (Table.ValidPossition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colun] = true;
                if (Table.component(pos) != null && Table.component(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line + 1, pos.Colun - 1);
            }
            //down - right

            pos.DefineValues(Position.Line +1, Position.Colun + 1);
            while (Table.ValidPossition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colun] = true;
                if (Table.component(pos) != null && Table.component(pos).Color != Color)
                {
                    break;
                }
               pos.DefineValues(pos.Line + 1, pos.Colun + 1);

            }
            return mat;
        }
    }
}
