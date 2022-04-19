using System;
using Xadrez_console.Table;

namespace Xadrez_console.Chess
{
    class ChessMatch
    {
        public Tables tab { get; protected set; }
        private int turn;
        private Color ActualPlayer;
        public bool Finished { get; protected set; }

        public ChessMatch()
        {
            tab = new Tables(8, 8);
            turn = 1;
            Finished = false;
            ActualPlayer = Color.White;
            PutAllPiecies();
        }

        public void Moviment(Position origen, Position destination)
        {
            Component p = tab.WithdrawComponet(origen);
            p.IncrementMoviment();
            Component Capturedcomponent = tab.WithdrawComponet(destination);
            tab.PutComponent(p, destination);
        }
          public void PutAllPiecies()
        {
            tab.PutComponent(new Tower(Color.Black, tab), new ChessPosition('c',1).ToChessPosition());
            tab.PutComponent(new Tower(Color.White, tab), new ChessPosition('d', 1).ToChessPosition());
            tab.PutComponent(new Tower(Color.Black, tab), new ChessPosition('a', 3).ToChessPosition());
            tab.PutComponent(new Tower(Color.Black, tab), new ChessPosition('c', 2).ToChessPosition());
        }
    }
}
