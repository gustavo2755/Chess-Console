using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez_console.Table
{
    internal class TableException : Exception
    {
        public TableException(string message) : base(message)
        {

        }
    }
}
