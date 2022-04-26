using System.Collections.Generic;
using Xadrez_console.Table;

namespace Xadrez_console.Chess
{
    public class ChessMatch
    {
        public Tables tab { get; private set; }
        public int turn{ get; private set; }
        public Color ActualPlayer { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Component> PiecesList;
        private HashSet<Component> CapturedPiecesList;
        public bool check { get; private set; }
        public Component EnPassant { get; private set; }

        public ChessMatch()
        {
            tab = new Tables(8, 8);
            turn = 1;
            Finished = false;
            ActualPlayer = Color.White;
            check = false;
            EnPassant = null;
            PiecesList = new HashSet<Component>();
            CapturedPiecesList = new HashSet<Component>();
            PutAllPiecies();

        }

        public void PutNewPiece(char colun,int line, Component component)
        {
            tab.PutComponent(component,new ChessPosition(colun,line).ToChessPosition());
            PiecesList.Add(component);
        }

      

        public Component Moviment(Position origin, Position destination)
        {
            Component p = tab.WithdrawComponet(origin);
            p.IncrementMoviment();
            Component CapturedComponent = tab.WithdrawComponet(destination);
            tab.PutComponent(p, destination);
            if(CapturedComponent != null)
            {
                CapturedPiecesList.Add(CapturedComponent);
            }

            //#SpecialMove Roque
            //litlle
            if(p is King && destination.Colun == origin.Colun +2 )
            {
                Position originT = new Position(origin.Line, origin.Colun + 3);
                Position destinyT = new Position(origin.Line, origin.Colun + 1);
                Component T = tab.WithdrawComponet(originT);
                T.IncrementMoviment();
                tab.PutComponent(T, destinyT);
            }
            //big
            if (p is King && destination.Colun == origin.Colun - 2)
            {
                Position originT = new Position(origin.Line, origin.Colun - 4);
                Position destinyT = new Position(origin.Line, origin.Colun - 1);
                Component T = tab.WithdrawComponet(originT);
                T.IncrementMoviment();
                tab.PutComponent(T, destinyT);
            }

            //#SpecialMove EnPassan
            if(p is Pawn)
            {
                if ( origin.Colun != destination.Colun && CapturedComponent == null)
                {
                    Position posP;
                    if(p.Color == Color.White)
                    {
                        posP = new Position(destination.Line + 1, destination.Colun );
                    }
                    else
                    {
                        posP = new Position(destination.Line - 1, destination.Colun);
                    }
                    CapturedComponent = tab.WithdrawComponet(posP);
                    CapturedPiecesList.Add(CapturedComponent);
                }
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


        public void UnmakeMoviment(Position origin,Position destiny,Component capturedPiece)
        {
            Component p = tab.WithdrawComponet(destiny);
            p.DecrementMoviment();
            if(capturedPiece != null)
            {
                tab.PutComponent(capturedPiece, destiny);
                CapturedPiecesList.Remove(capturedPiece);
            }
            tab.PutComponent(p, origin);

            //#SpecialMove Roque
            //litlle
            if (p is King && destiny.Colun == origin.Colun + 2)
            {
                Position originT = new Position(origin.Line, origin.Colun + 3);
                Position destinyT = new Position(origin.Line, origin.Colun + 1);
                Component T = tab.WithdrawComponet(destinyT);
                T.DecrementMoviment();
                tab.PutComponent(T, originT);
            }
            //big
            if (p is King && destiny.Colun == origin.Colun - 2)
            {
                Position originT = new Position(origin.Line, origin.Colun - 4);
                Position destinyT = new Position(origin.Line, origin.Colun - 1);
                Component T = tab.WithdrawComponet(destinyT);
                T.IncrementMoviment();
                tab.PutComponent(T, originT);
            }


            //#SpecialMove EnPassan
            if (p is Pawn)
            {
                if (origin.Colun != destiny.Colun && capturedPiece == EnPassant)
                {
                    Component pawn = tab.WithdrawComponet(destiny);
                    Position posP;
                    if(p.Color == Color.White)
                    {
                        posP = new Position (3,destiny.Colun);
                    }
                    else
                    {
                        posP = new Position(4, destiny.Colun);
                    }

                    tab.PutComponent(pawn, posP);
                }
            }


        }

        public void Play (Position origin , Position destiny)
        {
            
            Component capturedpiece = Moviment(origin,destiny);

            if (Check(ActualPlayer))
            {
                UnmakeMoviment(origin,destiny, capturedpiece);
                throw new TableException(" U cannot put ur own king in check ");
            }

            Component p = tab.component(destiny);

            //#Special Move Promotion
            if(p is Pawn)
            {
                if(p.Color == Color.White && destiny.Line ==0 || p.Color == Color.White && destiny.Line == 7)
                {
                    p=tab.WithdrawComponet(destiny);
                    PiecesList.Remove(p);
                    Component queen = new Queen(p.Color, tab);
                    tab.PutComponent(queen, destiny);
                    PiecesList.Add(queen);
                }
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

            

            //#SpecialMove EnPassant
            if (p is Pawn && (destiny.Line == origin.Line + 2  || destiny.Line == origin.Line - 2 ))
            {
                EnPassant = p;
            }
            else
            {
                EnPassant = null;
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
            PutNewPiece('a', 1, new Rook(Color.White, tab));
            PutNewPiece('b', 1, new Knight(Color.White, tab));
            PutNewPiece('c', 1, new Bishop(Color.White, tab));
            PutNewPiece('d', 1, new Queen(Color.White, tab));
            PutNewPiece('e', 1, new King(Color.White, tab, this));
            PutNewPiece('f', 1, new Bishop(Color.White, tab));
            PutNewPiece('g', 1, new Knight(Color.White, tab));
            PutNewPiece('h', 1, new Rook(Color.White, tab));
            PutNewPiece('a', 2, new Pawn(Color.White, tab,this));
            PutNewPiece('b', 2, new Pawn(Color.White, tab, this));
            PutNewPiece('c', 2, new Pawn(Color.White, tab, this));
            PutNewPiece('d', 2, new Pawn(Color.White, tab, this));
            PutNewPiece('e', 2, new Pawn(Color.White, tab, this));
            PutNewPiece('f', 2, new Pawn(Color.White, tab, this));
            PutNewPiece('g', 2, new Pawn(Color.White, tab, this));
            PutNewPiece('h', 2, new Pawn(Color.White, tab, this));

            PutNewPiece('a', 8, new Rook(Color.Black, tab));
            PutNewPiece('b', 8, new Knight(Color.Black, tab));
            PutNewPiece('c', 8, new Bishop(Color.Black, tab));
            PutNewPiece('d', 8, new Queen(Color.Black, tab)); 
            PutNewPiece('e', 8, new King(Color.Black, tab,this));
            PutNewPiece('f', 8, new Bishop(Color.Black, tab));
            PutNewPiece('g', 8, new Knight(Color.Black, tab));
            PutNewPiece('h', 8, new Rook(Color.Black, tab));
            PutNewPiece('a', 7, new Pawn(Color.Black, tab,this));
            PutNewPiece('b', 7, new Pawn(Color.Black, tab,this));
            PutNewPiece('c', 7, new Pawn(Color.Black, tab,this));
            PutNewPiece('d', 7, new Pawn(Color.Black, tab,this));
            PutNewPiece('e', 7, new Pawn(Color.Black, tab,this));
            PutNewPiece('f', 7, new Pawn(Color.Black, tab,this));
            PutNewPiece('g', 7, new Pawn(Color.Black, tab,this));
            PutNewPiece('h', 7, new Pawn(Color.Black, tab,this)); 
            
        }
    }
}
