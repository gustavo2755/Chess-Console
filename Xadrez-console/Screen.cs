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
                      Screen.PrintComponent(tab.Component(i, j));
 
                }
                Console.WriteLine();
            }

            Console.Write("  a b c d e f g h ");


            Console.WriteLine("\n");

        }

        public static void PrintTable(Tables tab, bool[,] possiblepositions)
        {
            ConsoleColor OriginalBackground = Console.BackgroundColor;
            ConsoleColor DiferentBackground = ConsoleColor.DarkGray;
            for (int i = 0; i < tab.Lines; i++)
            {
                Console.Write((tab.Lines - i) + " ");
                for (int j = 0; j < tab.Coluns; j++)
                {
                    if (possiblepositions[i,j] == true)
                    {
                        Console.BackgroundColor = DiferentBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = OriginalBackground;
                    }
                    Screen.PrintComponent(tab.Component(i, j));
                    Console.BackgroundColor = OriginalBackground;

                }
                Console.WriteLine();
            }

            Console.Write("  a b c d e f g h ");
            Console.BackgroundColor = OriginalBackground;


            Console.WriteLine("\n");

        }


        public static void PrintComponent(Component component)
        {
            if (component == null)
            {
                Console.Write("- ");
            }
            else
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
                Console.Write(" ");
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
