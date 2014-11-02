using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LexicalAnalyzer
{
    public class ComRecord
    {
        private string symbol;                      //文法符号
        private Hashtable inheritedAttr;            //继承属性

        public ComRecord(string symbol)
        {
            this.symbol = symbol;
            inheritedAttr = new Hashtable();
        }

        public string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }


        public Hashtable InheritedAttr
        {
            get { return inheritedAttr; }
            set { inheritedAttr = value; }
        }

        public override string ToString()
        {
            return "symbol: " + symbol;
        }
    }
}
