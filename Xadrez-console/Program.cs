using System;
using System.Collections.Generic;
using Xadrez_console.Table;

namespace Xadrez_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tables tab = new Tables(8, 8);
            Screen.PrintTable(tab);
        }
    }
}
