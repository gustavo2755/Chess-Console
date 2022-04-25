using System;
using Xadrez_console.Table;

namespace Xadrez_console.Chess
{
    class ChessMatch
    {
        public Tables tab { get; private set; }
        public int turn{ get; private set; }
        public Color ActualPlayer { get; private set; }
        public bool Finished { get; private set; }

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

        public void Play (Position origem , Position destiny)
        {
            Moviment(origem,destiny);
            turn ++;
            ChangePlayer();
        }
        private void ChangePlayer()
        {
            if (ActualPlayer == Color.White)
            {
                ActualPlayer = Color.Black;
            }
            else
            {
                ActualPlayer = Color.White;
            }
        }

        public void ConfirmOrigenPosition(Position pos)
        {
            if (tab.component (pos) == null)
            {
                throw new TableException(" There is no piece in this position ");
            }
            if (ActualPlayer != tab.component(pos).Color)
            {
                throw new TableException(" The piece that was choose isn't yours ");
            }
            if (!tab.component(pos).ValidatePossibleMoviments())
            {
                throw new TableException(" There is no posible moviments to this piece ");
            }

        }

       public void ConfirmDestinyPosition(Position origin,Position destiny)
        {
            if (!tab.component(origin).CanMoveTo(destiny))
            {
                throw new TableException(" Invalid destiny Position ");
            }

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
