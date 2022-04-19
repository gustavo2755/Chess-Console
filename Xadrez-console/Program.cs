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
            try
            {
                Tables tab = new Tables(8, 8);
                tab.PutComponent(new Tower(Color.Black, tab), new Position(0, 0));
                tab.PutComponent(new Tower(Color.Black, tab), new Position(1, 3));
                tab.PutComponent(new King(Color.Black, tab), new Position(2, 4));
                Screen.PrintTable(tab);
            }
            catch (TableException e)
            {
                Console.WriteLine( e.Message );
            }
        }
    }
}
