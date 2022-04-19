using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez_console.Table
{
    class Table
    {
        public int Lines { get; set; }
        public int Coluns { get; set; }
        private Component[,] ComponentMatriz;

        public Table(int lines, int coluns)
        {
            Lines = lines;
            Coluns = coluns;
            ComponentMatriz = new Component[lines, coluns];
        }
    }
}
