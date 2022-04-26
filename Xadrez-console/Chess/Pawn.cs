using Xadrez_console.Table;

namespace Xadrez_console.Chess
{
    public class Pawn : Component
    {
        private ChessMatch Match;
        public Pawn (Color color, Tables table, ChessMatch match) : base(color, table)
        {
            Match = match;
        }



        public override string ToString()
        {
            return "P";
        }

        private bool CanMove(Position pos)
        {
            Component p = Table.component(pos);
            return p == null || p.Color != this.Color;
        }

        private bool HasEnemy(Position pos)
        {
            Component p = Table.component(pos);
            return p != null && p.Color != Color;
        }

        private bool Free(Position pos)
        {
            return Table.component(pos) == null;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Table.Lines, Table.Coluns];

            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                pos.DefineValues(Position.Line - 1, Position.Colun);
                if (Table.ValidPossition(pos) && Free(pos))
                {
                    mat[pos.Line, pos.Colun] = true;
                }
                pos.DefineValues(Position.Line - 2, Position.Colun);
                Position p2 = new Position(Position.Line - 1, Position.Colun);
                if (Table.ValidPossition(p2) && Free(p2) && Table.ValidPossition(pos) && Free(pos) && QtdMoviments == 0)
                {
                    mat[pos.Line, pos.Colun] = true;
                }
                pos.DefineValues(Position.Line - 1, Position.Colun - 1);
                if (Table.ValidPossition(pos) && HasEnemy(pos))
                {
                    mat[pos.Line, pos.Colun] = true;
                }
                pos.DefineValues(Position.Line - 1, Position.Colun + 1);
                if (Table.ValidPossition(pos) && HasEnemy(pos))
                {
                    mat[pos.Line, pos.Colun] = true;
                }
                //#SpecialMove EnPassan
                if (Position.Line == 3)
                {
                    Position Left = new Position (Position.Line  , Position.Colun - 1);
                    if(Table.ValidPossition (Left) && HasEnemy(Left) && Table.component(Left) == Match.EnPassant )
                    {

                        mat[Left.Line - 1, Left.Colun] = true;

                    }
                    Position Right = new Position(Position.Line, Position.Colun + 1);
                    if (Table.ValidPossition(Right) && HasEnemy(Right) && Table.component(Right) == Match.EnPassant)
                    {

                        mat[Right.Line - 1, Right.Colun] = true;

                    }
                }
            }
            else
            {
                pos.DefineValues(Position.Line + 1, Position.Colun);
                if (Table.ValidPossition(pos) && Free(pos))
                {
                    mat[pos.Line, pos.Colun] = true;
                }
                pos.DefineValues(Position.Line + 2, Position.Colun);
                Position p2 = new Position(Position.Line + 1, Position.Colun);
                if (Table.ValidPossition(p2) && Free(p2) && Table.ValidPossition(pos) && Free(pos) && QtdMoviments == 0)
                {
                    mat[pos.Line, pos.Colun] = true;
                }
                pos.DefineValues(Position.Line + 1, Position.Colun - 1);
                if (Table.ValidPossition(pos) && HasEnemy(pos))
                {
                    mat[pos.Line, pos.Colun] = true;
                }
                pos.DefineValues(Position.Line + 1, Position.Colun + 1);
                if (Table.ValidPossition(pos) && HasEnemy(pos))
                {
                    mat[pos.Line, pos.Colun] = true;
                }

                //#SpecialMove EnPassan
                if (Position.Line == 4)
                {
                    Position Left = new Position(Position.Line, Position.Colun - 1);
                    if (Table.ValidPossition(Left) && HasEnemy(Left) && Table.component(Left) == Match.EnPassant)
                    {

                        mat[Left.Line + 1, Left.Colun] = true;

                    }
                    Position Right = new Position(Position.Line, Position.Colun + 1);
                    if (Table.ValidPossition(Right) && HasEnemy(Right) && Table.component(Right) == Match.EnPassant)
                    {

                        mat[Right.Line + 1, Right.Colun] = true;

                    }
                }
            }

            return mat;
        }

    }
}
