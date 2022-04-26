using System;
using Xadrez_console.Chess;

namespace Xadrez_console.Table
{
     public abstract class Component
    {
        public Position Position { get; set; }
        public Color Color  { get; protected set; }
        public int QtdMoviments { get; protected set; }
        public Tables Table { get; protected set; }

        public Component( Color color, Tables table)
        {
            Position = null;
            Color = color;
            Table = table;
            QtdMoviments = 0;
        }
        public abstract bool[,] PossibleMoves();
       

        public void IncrementMoviment()
        {
            QtdMoviments++;
        }

        public void DecrementMoviment()
        {
            QtdMoviments--;
        }

        public bool CanMoveTo(Position pos)
        {
            return PossibleMoves()[pos.Line, pos.Colun];
        }


        public bool ValidatePossibleMoviments ()
        {
            bool[,] mat = PossibleMoves();
            for (int i = 0; i < Table.Lines; i++)
            {
                for (int j = 0; j < Table.Coluns; j++)
                {
                    if (mat[i, j] == true)
                    {
                        return true;
                    }
                }

            }
            return false;
        }
    }
}
