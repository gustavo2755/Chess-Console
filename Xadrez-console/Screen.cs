using System;
using Xadrez_console.Table;
using Xadrez_console.Chess;



namespace Xadrez_console
{
    class Screen
    {
        public static void PrintTable(Tables tab)
        {
            for (int i = 0; i < tab.Lines; i++)
            {
                Console.Write((tab.Lines - i) + " ");
                for (int j = 0; j < tab.Coluns; j++)
                {
                    if (tab.component(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Screen.PrintComponent(tab.component(i,j));
                        Console.Write(" ");
                    }

                }
                Console.WriteLine();
            }

            Console.Write("  a b c d e f g h ");


            Console.WriteLine("\n");





        }
        public static void PrintComponent(Component component)
        {
            if (component.Color == Color.White)
            {
                Console.Write(component);

            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(component);
                Console.ForegroundColor = aux;
            }
        }

        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();
            char colun = s[0];
            int line = int.Parse(s[1] + "");

            return new ChessPosition(colun, line);
            
        }
    }

}
