

namespace Xadrez_console.Table
{
    public class Tables
    {
        public int Lines { get; set; }
        public int Coluns { get; set; }
        private Component[,] pecas;
       
        public Tables(int lines, int coluns)
        {
            Lines = lines;
            Coluns = coluns;
            pecas = new Component[lines, coluns];
        }

        public Component component ( int linha, int coluna)
        {
            return pecas [linha, coluna];
        }
        public Component component(Position poss)
        {
            return pecas[poss.Line,poss.Colun];
        }

       public bool ExistComponent(Position pos)
        {
            ValidatingPossition(pos);
            return component(pos) != null;
            
        }
        public void PutComponent (Component p,Position pos)
        {
            if (ExistComponent(pos))
            {
                throw new TableException(" Already exist a component in this position");
            }
            pecas[pos.Line, pos.Colun] = p;
            p.Position = pos;
        }

        /* Encurtar esse método ?? */
        public bool ValidPossition (Position pos)
        {
            if (pos.Line <0 || pos.Line >= Lines || pos.Colun < 0 || pos.Colun >= Coluns)
            {
                return false;
            }
            return true;
        }

        public void ValidatingPossition(Position pos)
        {
            if (!ValidPossition(pos))
            {
                throw new TableException(" Invalid Position !");
            }

        }
        
    }
}
