using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LexicalAnalyzer
{
    public class GrammerError
    {
        private string stackTopStr;         //栈顶符号
        private string tokenStr;            //输入带当前符号
        private string errorInfo;           //错误信息

        public GrammerError(string stackTopStr, string tokenStr, string errorInfo)
        {
            this.stackTopStr = stackTopStr;
            this.tokenStr = tokenStr;
            this.errorInfo = errorInfo;
        }

        public string StackTopStr
        {
            get { return stackTopStr; }
            set { stackTopStr = value; }
        }

        public string TokenStr
        {
            get { return tokenStr; }
            set { tokenStr = value; }
        }

        public string ErrorInfo
        {
            get { return errorInfo; }
            set { errorInfo = value; }
        }

        public override string ToString()
        {
            return stackTopStr + "; " + tokenStr + "; " + errorInfo;
        }
    }
}
