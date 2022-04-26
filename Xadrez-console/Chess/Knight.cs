using Xadrez_console.Table;

namespace Xadrez_console.Chess
{
    public class Knight : Component
    {
        public Knight(Color color, Tables table) : base(color, table)
        {
        }

        public override string ToString()
        {
            return "H";
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
            
            pos.DefineValues(Position.Line - 1, Position.Colun - 2);
            if (Table.ValidPossition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colun] = true;
            }
            
            pos.DefineValues(Position.Line - 2, Position.Colun - 1);
            if (Table.ValidPossition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colun] = true;
            }
            
            pos.DefineValues(Position.Line - 2, Position.Colun + 1);
            if (Table.ValidPossition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colun] = true;
            }
           
            pos.DefineValues(Position.Line - 1, Position.Colun + 2);
            if (Table.ValidPossition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colun] = true;
            }
            
            pos.DefineValues(Position.Line + 1, Position.Colun + 2);
            if (Table.ValidPossition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colun] = true;
            }
            
            pos.DefineValues(Position.Line + 2, Position.Colun + 1);
            if (Table.ValidPossition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colun] = true;
            }
            
            pos.DefineValues(Position.Line + 2, Position.Colun - 1);
            if (Table.ValidPossition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colun] = true;
            }
             
            pos.DefineValues(Position.Line + 1, Position.Colun - 2);
            if (Table.ValidPossition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Colun] = true;
            }
            return mat;
        }


    }
}
