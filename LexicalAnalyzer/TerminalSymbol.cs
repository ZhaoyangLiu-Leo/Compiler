using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LexicalAnalyzer
{
    class TerminalSymbol
    {
        private string tChar;           //终结符

        public string TChar
        {
            get { return tChar; }
            set { tChar = value; }
        }

    }
}
