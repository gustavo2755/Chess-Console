using System;
using Xadrez_console.Table;

namespace Xadrez_console.Chess
{
    class Tower : Component
    {
        public Tower(Color color, Tables table) : base(color, table)
        {

        }
        public override string ToString()
        {
            return "T";
        }
    }
}
