using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LexicalAnalyzer
{
    public class SemanicError
    {
        private string lineIndex;
        private string errorInfo;

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
