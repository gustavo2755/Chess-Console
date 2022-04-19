using System;
using System.Collections.Generic;
using Xadrez_console.Table;
using Xadrez_console.Chess;

namespace Xadrez_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tables tab = new Tables(8, 8);
            tab.PutComponent(new Tower(Color.Black,tab), new Possition(0, 0));
            tab.PutComponent(new Tower(Color.Black, tab), new Possition(1, 3));
            tab.PutComponent(new King(Color.Black, tab), new Possition(2, 4));
            Screen.PrintTable(tab);

        }
    }
}
