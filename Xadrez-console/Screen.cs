using System;
using Xadrez_console.Table;
using Xadrez_console.Chess;
using System.Collections.Generic;



namespace Xadrez_console
{
    class Screen
    {
        public static void PrintMatch(ChessMatch play)
        {
            
            Screen.PrintTable(play.tab);
            PrintCapturedPiecesLis(play);
            Console.WriteLine();
            Console.WriteLine(" Turn : " + play.turn);
            if (!play.Finished)
            {
                Console.WriteLine(" Waiting play from : " + play.ActualPlayer);
                if (play.check)
                {
                    Console.WriteLine(" You are in check ");
                }
            }
            else
            {
                Console.WriteLine(" Checkmate");
                Console.WriteLine(" Winner : " + play.ActualPlayer);
            }
           
        }

        public static void PrintCapturedPiecesLis(ChessMatch play)
        {
            Console.WriteLine(" Captured pieces : ");
            Console.Write(" White : ");
            PrintStruct(play.CapturedPiecesByColor(Color.White));
            Console.WriteLine();
            Console.Write(" Black : ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            PrintStruct(play.CapturedPiecesByColor(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void PrintStruct(HashSet<Component> aux)
        {
            Console.Write("(");

            foreach (Component x in aux)
            {
                Console.Write(x + " ");
            }

            Console.Write(")");
           
        }


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
