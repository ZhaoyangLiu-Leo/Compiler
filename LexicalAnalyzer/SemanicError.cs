using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LexicalAnalyzer
{
    public class SemanicError
    {
        private string lineIndex;               //语义错误的行号
        private string errorInfo;               //错误信息

        public SemanicError(string lineIndex, string errorInfo)
        {
            this.lineIndex = lineIndex;
            this.errorInfo = errorInfo;
        }

        public string LineIndex
        {
            get { return lineIndex; }
            set { lineIndex = value; }
        }
        
        public string ErrorInfo
        {
            get { return errorInfo; }
            set { errorInfo = value; }
        }
    }
}
