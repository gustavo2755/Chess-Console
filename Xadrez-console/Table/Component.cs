using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez_console.Table
{
     class Component
    {
        public Possition Position { get; set; }
        public Color Color  { get; protected set; }
        public int QtdMoviments { get; protected set; }
        public Table Table { get; protected set; }

        public Component(Possition position, Color color, Table table)
        {
            Position = position;
            Color = color;
            Table = table;
            QtdMoviments = 0;
        }
    }
}
