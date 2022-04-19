using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez_console.Table
{
     public class Component
    {
        public Possition Position { get; set; }
        public Color Color  { get; protected set; }
        public int QtdMoviments { get; protected set; }
        public Tables Table { get; protected set; }

        public Component(Possition position, Color color, Tables table)
        {
            Position = position;
            Color = color;
            Table = table;
            QtdMoviments = 0;
        }
    }
}
