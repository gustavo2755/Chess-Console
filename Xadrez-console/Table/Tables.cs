using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void PutComponent (Component p,Possition pos)
        {
            pecas[pos.Line, pos.Colun] = p;
            p.Position = pos;
        }
    }
}
