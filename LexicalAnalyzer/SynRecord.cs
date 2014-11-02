using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LexicalAnalyzer
{
    public class SynRecord
    {
        private string symbol;              //文法符号
        private Hashtable synAttr;          //综合属性

        public SynRecord(string symbol)
        {
            this.symbol = symbol;
            synAttr = new Hashtable();
        }

        public string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }

        public Hashtable SynAttr
        {
            get { return synAttr; }
            set { synAttr = value; }
        }
    }
}
