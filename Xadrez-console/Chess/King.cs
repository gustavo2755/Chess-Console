using System;
using Xadrez_console.Table;

namespace Xadrez_console.Chess
{
    class King: Component
    {
        public King  (Color color,Tables table) : base(color, table)
        {

        }
        public override string ToString()
        {
            return "K";
        }
    }
}
