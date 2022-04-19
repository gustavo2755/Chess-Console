using System;


namespace Xadrez_console.Table
{
     public class Position
    {
        public int Line { get; set; }
        public int Colun { get; set; }

        public Position(int line, int colun)
        {
            Line = line;
            Colun = colun;
        }

        public override string ToString()
        {
            return " line :" + Line + " colun :" + Colun; 
        }
    }
}
