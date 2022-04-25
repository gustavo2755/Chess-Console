using System;
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
                
                ChessMatch Play = new ChessMatch();
                while (! Play.Finished)
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintTable(Play.tab);
                        Console.WriteLine(" Turn : " + Play.turn);
                        Console.WriteLine(" Waiting play from : " + Play.ActualPlayer);
                        Console.WriteLine();

                        Console.Write(" Type the origin : ");
                        Position origin = Screen.ReadChessPosition().ToChessPosition();
                        Play.ConfirmOrigenPosition(origin);

                        bool[,] PossiblePositions = Play.tab.component(origin).PossibleMoves();
                        Console.Clear();
                        Screen.PrintTable(Play.tab, PossiblePositions);

                        Console.Write(" Type the destiny : ");
                        Position destiny = Screen.ReadChessPosition().ToChessPosition();
                        Play.ConfirmDestinyPosition(origin, destiny);


                        Play.Play(origin, destiny);
                    }
                    catch (TableException e){ 
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }

                }
                
            }
            catch (TableException e)
            {
                Console.WriteLine( e.Message );
            }
        }
    }
}
