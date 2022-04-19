using System;
using Xadrez_console.Table;


namespace Xadrez_console
{
    class Screen
    {
        public static void PrintTable(Tables tab)
        {
            for(int i =0; i < tab.Lines; i++)
            {
                for (int j = 0; j < tab.Coluns; j++)
                {
                   if(tab.component(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(tab.component(i, j) + " ");
                    }
                    
                }
                Console.WriteLine();
            }
        }
    }
}
