using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LexicalAnalyzer
{
    class Token
    {
        private string tokenName;
        private string tokenValue;

        public Token(string tokenName, string tokenValue)
        {
            this.tokenName = tokenName;
            this.tokenValue = tokenValue;
        }

        /// <summary>
        /// 属性访问器，set or get token name
        /// </summary>
        public string TokenName
        {
            get { return tokenName; }
            set { tokenName = value; }
        }
        
        /// <summary>
        /// 属性访问器，set or get token value 
        /// </summary>
        public string TokenValue
        {
            get { return tokenValue; }
            set { tokenValue = value; }
        }

        public override string ToString()
        {
            return "<" + tokenName + ", " + tokenValue + ">"; 
        }

    }
}
