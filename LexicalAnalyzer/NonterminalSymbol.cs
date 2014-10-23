using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LexicalAnalyzer
{
    class NonterminalSymbol
    {
        private string nChar;                       //非终结符
        private HashSet<string> first;              //非终结符对应的first集
        private HashSet<string> follow;             //非终结符对应得follow集

        public NonterminalSymbol(string nChar)
        {
            this.nChar = nChar;
            this.first = new HashSet<string>();
            this.follow = new HashSet<string>();
        }

        public string NChar
        {
            get { return nChar; }
            set { nChar = value; }
        }

        public HashSet<string> First
        {
            get { return first; }
            set { first = value; }
        }

        public HashSet<string> Follow
        {
            get { return follow; }
            set { follow = value; }
        }

        public override string ToString()
        {
            return nChar;
        }
    }
}
