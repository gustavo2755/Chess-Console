using System;
using Xadrez_console.Chess;

namespace Xadrez_console.Table
{
     public class Component
    {
        public Position Position { get; set; }
        public Color Color  { get; protected set; }
        public int QtdMoviments { get; protected set; }
        public Tables Table { get; protected set; }

        public Component( Color color, Tables table)
        {
            Position = null;
            Color = color;
            Table = table;
            QtdMoviments = 0;
        }

        public Component(Tables table)
        {
        }
    }
}
