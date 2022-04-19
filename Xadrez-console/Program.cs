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
                    Console.Clear();
                    Screen.PrintTable(Play.tab);

                    Console.Write(" Type the origin : ");         
                    Position origin = Screen.ReadChessPosition().ToChessPosition();
                    Console.Write(" Type the destiny : ");
                    Position destiny = Screen.ReadChessPosition().ToChessPosition();
                    Play.Moviment(origin, destiny);
                }
                
            }
            catch (TableException e)
            {
                Console.WriteLine( e.Message );
            }
        }
    }
}
