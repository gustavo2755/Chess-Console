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
        private HashSet<Component> PiecesList;
        private HashSet<Component> CapturedPiecesList;
        public bool check { get; private set; }
        
        public ChessMatch()
        {
            tab = new Tables(8, 8);
            turn = 1;
            Finished = false;
            ActualPlayer = Color.White;
            check = false;
            PiecesList = new HashSet<Component>();
            CapturedPiecesList = new HashSet<Component>();
            PutAllPiecies();

        }

        public void PutNewPiece(char colun,int line, Component component)
        {
            tab.PutComponent(component,new ChessPosition(colun,line).ToChessPosition());
            PiecesList.Add(component);
        }

      

        public Component Moviment(Position origen, Position destination)
        {
            Component p = tab.WithdrawComponet(origen);
            p.IncrementMoviment();
            Component CapturedComponent = tab.WithdrawComponet(destination);
            tab.PutComponent(p, destination);
            if(CapturedComponent != null)
            {
                CapturedPiecesList.Add(CapturedComponent);
            }
            return CapturedComponent;
        }

        private Component King(Color c)
        {
            foreach(Component x in PiecesByColor(c))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
           
        }

        public bool testCheck(Color c)
        {
            if (!Check(c))
            {
                return false;
            }
            foreach (Component x in PiecesByColor(c))
            {
               // if de teste
                if (x.Position != null)
                {
                    bool[,] mat = x.PossibleMoves();
                    for (int i = 0; i < tab.Lines; i++)
                    {
                        for (int j = 0; j < tab.Coluns; j++)
                        {
                            if (mat[i, j])
                            {
                                Position origin = x.Position;
                                Position destiny = new Position(i, j);
                                Component pecaCapturada = Moviment(origin, destiny);
                                bool testeXeque = Check(c);
                                UnmakeMoviment(origin, destiny, pecaCapturada);
                                if (!testeXeque)
                                {
                                    return false;
                                }
                            }
                
                        }
                    }
                }
            }
            return true;
        }

       

        public bool Check (Color c)
        {
            Component k = King(c);
            if (k == null)
            {
                throw new TableException(" There is no King with this color in this table ");
            }

            foreach (Component x in PiecesByColor(Enemy(c)))
            {
             
                if ( x.Position != null)
                {
                    bool[,] mat = x.PossibleMoves();
                    if (mat[k.Position.Line, k.Position.Colun])
                    {
                        return true;
                    }

                }

            }
            return false;
        }


        private Color Enemy (Color c)
        {
            if (c == Color.White)
            {
                return Color.Black;

            }
            else
            {
                return Color.White;
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
        public HashSet<Component> PiecesByColor(Color c)
        {
            HashSet<Component> aux = new HashSet<Component>();
            foreach (Component x in PiecesList)
            {
                if (x.Color == c)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }


        public void UnmakeMoviment(Position origem,Position destiny,Component capturedPiece)
        {
            Component c = tab.WithdrawComponet(destiny);
            c.DecrementMoviment();
            if(capturedPiece != null)
            {
                tab.PutComponent(capturedPiece, destiny);
                CapturedPiecesList.Remove(capturedPiece);
            }
            tab.PutComponent(c, origem);

        }

        public void Play (Position origem , Position destiny)
        {
            
            Component capturedpiece = Moviment(origem,destiny);

            if (Check(ActualPlayer))
            {
                UnmakeMoviment(origem,destiny, capturedpiece);
                throw new TableException(" U cannot put ur own king in check ");
            }

            if (Check(Enemy(ActualPlayer)))
            {
                check = true;
            }
            else
            {
                check = false;
            }
            if (testCheck(Enemy(ActualPlayer)))
            {
                Finished = true;
            }
            else
            {
                turn++;
                ChangePlayer();
            }

           

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
            PutNewPiece('c', 2, new Tower(Color.White, tab));
            PutNewPiece('d', 1, new King(Color.White, tab));
            PutNewPiece('c', 1, new Tower(Color.White, tab));
            PutNewPiece('d', 2, new Tower(Color.White, tab));
            PutNewPiece('e', 2, new Tower(Color.White, tab));
            PutNewPiece('e', 1, new Tower(Color.White, tab));
            PutNewPiece('d', 8, new King(Color.Black, tab));
            PutNewPiece('c', 8, new Tower(Color.Black, tab));
            PutNewPiece('e', 8, new Tower(Color.Black, tab));
            PutNewPiece('d', 7, new Tower(Color.Black, tab));
            PutNewPiece('c', 7, new Tower(Color.Black, tab));
            PutNewPiece('e', 7, new Tower(Color.Black, tab));
        }
    }
}
