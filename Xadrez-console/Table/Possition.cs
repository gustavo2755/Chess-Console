﻿using System;


namespace Xadrez_console.Table
{
     class Possition
    {
        public int Line { get; set; }
        public int Colun { get; set; }

        public Possition(int line, int colun)
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