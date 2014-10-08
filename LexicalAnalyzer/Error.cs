using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LexicalAnalyzer
{
    /// <summary>
    /// error类，用来记录错误信息
    /// </summary>
    class Error
    {
        private string errorType;
        private string errorWord;
        private int errorLine;

        public Error(string errorType, string errorWord, int errorLine)
        {
            this.errorType = errorType;
            this.errorWord = errorWord;
            this.errorLine = errorLine;
        }

        /// <summary>
        /// 属性访问器，set or get 错误类型
        /// </summary>
        public string ErrorType
        {
            get { return errorType; }
            set { errorType = value; }
        }
        
        /// <summary>
        /// 属性访问器，set or get 错误单词
        /// </summary>
        public string ErrorWord
        {
            get { return errorWord; }
            set { errorWord = value; }
        }
        
        /// <summary>
        /// 属性访问器，set or get 错误行
        /// </summary>
        public int ErrorLine
        {
            get { return errorLine; }
            set { errorLine = value; }
        }

        public override string ToString()
        {
            return errorType + ", " + errorWord + ", " + errorLine;
        }

    }
}
