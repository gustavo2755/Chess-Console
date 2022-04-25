using System;
using System.Collections.Generic;
using Xadrez_console.Table;

namespace Xadrez_console.Chess
{
    class ChessMatch
    {
        public Tables tab { get; private set; }
        public int turn{ get; private set; }
        public Color ActualPlayer { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Component> ComponentsList;
        private HashSet<Component> CapturedPiecesList;

        public ChessMatch()
        {
            tab = new Tables(8, 8);
            turn = 1;
            Finished = false;
            ActualPlayer = Color.White;
            ComponentsList = new HashSet<Component>();
            CapturedPiecesList = new HashSet<Component>();
            PutAllPiecies();

        }

        public void PutNewPiece(char colun,int line, Component component)
        {
            tab.PutComponent(component,new ChessPosition(colun,line).ToChessPosition());
            ComponentsList.Add(component);
        }

      

        public void Moviment(Position origen, Position destination)
        {
            Component p = tab.WithdrawComponet(origen);
            p.IncrementMoviment();
            Component CapturedComponent = tab.WithdrawComponet(destination);
            tab.PutComponent(p, destination);
            if(CapturedComponent != null)
            {
                CapturedPiecesList.Add(CapturedComponent);
            }
        }

        public HashSet<Component>CapturedPiecesByColor(Color c)
        {
            HashSet<Component> aux = new HashSet<Component>();
            foreach (Component x in CapturedPiecesList)
            {
                if (x.Color == c)
                {
                    aux.Add(x);
                }
            }
            return aux;
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
            PutNewPiece('a', 1, new Tower(Color.White, tab));
            PutNewPiece('b', 1, new King(Color.White, tab));
            PutNewPiece('c', 1, new Tower(Color.Black, tab));
            PutNewPiece('d', 1, new Tower(Color.Black, tab));
            PutNewPiece('e',1, new Tower(Color.Black, tab));
        }
    }
}
