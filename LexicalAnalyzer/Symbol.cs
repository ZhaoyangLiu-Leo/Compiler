using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LexicalAnalyzer
{
    class Symbol
    {
        private string symbolName;          //符号名称
        private int memIndex;               //内存位置
        private int lineIndex;              //首次出现行号

        public Symbol(string symbolName, int memIndex, int lineIndex)
        {
            this.symbolName = symbolName;
            this.memIndex = memIndex;
            this.lineIndex = lineIndex;
        }
        
        public string SymbolName
        {
            get { return symbolName; }
            set { symbolName = value; }
        }

        public int MemIndex
        {
            get { return memIndex; }
            set { memIndex = value; }
        }

        public int LineIndex
        {
            get { return lineIndex; }
            set { lineIndex = value; }
        }

        public override string ToString()
        {
            return symbolName + ", " + memIndex + ", " + lineIndex;
        }
    }
}
