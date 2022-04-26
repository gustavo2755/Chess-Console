using Xadrez_console.Table;

namespace Xadrez_console.Chess
{
    class King: Component
    {
        private ChessMatch Match;
        public King  (Color color,Tables table, ChessMatch match) : base(color, table)
        {
            Match = match;
        }

        private bool TestTowerToRoque(Position pos)
        {
            Component p = Table.component(pos);
            return (p != null && p is Rook && p.Color == Color && p.QtdMoviments == 0) ;
            
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

            //#SpecialMove Roque
            if (QtdMoviments == 0 && !Match.check)
            {
                //little roque
                Position posT1 = new Position(Position.Line, Position.Colun + 3);
                if (TestTowerToRoque(posT1))
                {
                    Position p1 = new Position (Position.Line,Position.Colun + 1);
                    Position p2 = new Position(Position.Line, Position.Colun + 2);
                    if (Table.component(p1) == null && Table.component(p2) == null)
                    {
                        mat[Position.Line, Position.Colun + 2] = true;
                    }
                }
            }
            
            if (QtdMoviments == 0 && !Match.check)
            {
                //Big Roque
                Position posT2 = new Position(Position.Line, Position.Colun - 4);
                if (TestTowerToRoque(posT2))
                {
                    Position p1 = new Position(Position.Line, Position.Colun - 1);
                    Position p2 = new Position(Position.Line, Position.Colun - 2);
                    Position p3 = new Position(Position.Line, Position.Colun - 3);
                    if (Table.component(p1) == null && Table.component(p2) == null && Table.component(p3) == null)
                    {
                        mat[Position.Line, Position.Colun - 2] = true;
                    }
                }
            }

            return mat;
        }


    }
}
