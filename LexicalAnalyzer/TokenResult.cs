using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LexicalAnalyzer
{
    /// <summary>
    /// tokenResult类，用来记录token识别的结果
    /// </summary>
    class TokenResult
    {
        private Token token;
        private int typeNum;
        private string className;
        private int lineIndex;

        public TokenResult(Token token, int typeNum, string className, int lineIndex)
        {
            this.token = token;
            this.typeNum = typeNum;
            this.className = className;
            this.lineIndex = lineIndex;
        }

        /// <summary>
        /// 属性访问器，set or get token
        /// </summary>
        internal Token Token
        {
            get { return token; }
            set { token = value; }
        }

        /// <summary>
        /// 属性访问器，set or get 种别码
        /// </summary>
        public int TypeNum
        {
            get { return typeNum; }
            set { typeNum = value; }
        }
        
        /// <summary>
        /// 属性访问器，set or get 种类
        /// </summary>
        public string ClassName
        {
            get { return className; }
            set { className = value; }
        }
        
        /// <summary>
        /// 属性访问器，set or get 行号
        /// </summary>
        public int LineIndex
        {
            get { return lineIndex; }
            set { lineIndex = value; }
        }

        public override string ToString()
        {
            return "(" + token.ToString() + ", " + typeNum + ", " + className + ", " + lineIndex + ")";
        }

    }
}
