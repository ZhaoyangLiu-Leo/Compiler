using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LexicalAnalyzer
{
    class Scanner
    {
        private List<string> noteList;
        private List<TokenResult> tokenResList;
        private List<Error> errorList;
        private List<Symbol> symbolList;
        private int memIndex;

        public Scanner()
        {
            noteList = new List<string>();
            tokenResList = new List<TokenResult>();
            errorList = new List<Error>();
            symbolList = new List<Symbol>();
            memIndex = 0;
        }

        /// <summary>
        /// 分析代码，生成分析结果
        /// </summary>
        public void analyzeCode(string programStr, out List<TokenResult> outTokenResList, out List<Error> outErrorList, out List<Symbol> outSymbolList)
        {
            int beginIndex = 0;     //词素的开始下标
            int endIndex = 0;       //词素的结束下标
            int state = 0;          //记录状态机的当前状态
            int codeIndex = 0;      //代码下标
            int lineIndex = 1;      //行号
            string str = "";
            int pointerIndex = 0;

            string codeStr = programStr;
            this.recognationNote(codeStr);
            codeStr = this.cutNote(codeStr) + "$";      //加上一个伪尾，以保证状态机的识别正确

            while (codeIndex < codeStr.Length)
            {
                
                switch (state)
                {
                    case 0:
                        if (codeStr[codeIndex] == '\n')
                        {
                            lineIndex++;
                        }
                        if (isLetter_(codeStr[codeIndex]))
                        {
                            state = 1;
                        }
                        else if (codeStr[codeIndex] == '"')
                        {
                            state = 2;
                        }
                        else if (codeStr[codeIndex] == '\'')
                        {
                            state = 5;
                        }
                        else if (codeStr[codeIndex] == '0')
                        {
                            state = 8;
                        }
                        else if (isOne2Nine(codeStr[codeIndex]))
                        {
                            state = 14;
                        }
                        else if (isSingleChar(codeStr[codeIndex]) > 0)
                        {
                            add2TokenResList(codeStr[codeIndex].ToString(), codeStr[codeIndex].ToString(), "_", isSingleChar(codeStr[codeIndex]), "单界符", lineIndex);
                        }
                        else if (codeStr[codeIndex] == '<')
                        {
                            state = 21;
                        }
                        else if (codeStr[codeIndex] == '>')
                        {
                            state = 24;
                        }
                        else if (codeStr[codeIndex] == '=')
                        {
                            state = 27;
                        }
                        else if (codeStr[codeIndex] == '!')
                        {
                            state = 29;
                        }
                        else if (codeStr[codeIndex] == '|')
                        {
                            state = 31;
                        }
                        else if (codeStr[codeIndex] == '^')
                        {
                            state = 34;
                        }
                        else if (codeStr[codeIndex] == '&')
                        {
                            state = 36;
                        }
                        else if (codeStr[codeIndex] == '+')
                        {
                            state = 39;
                        }
                        else if (codeStr[codeIndex] == '-')
                        {
                            state = 42;
                        }
                        else if (codeStr[codeIndex] == '/')
                        {
                            state = 46;
                        }
                        else if (codeStr[codeIndex] == '*')
                        {
                            state = 48;
                        }
                        else if (codeStr[codeIndex] == '%')
                        {
                            state = 50;
                        }
                        beginIndex = codeIndex;
                        break;

                    //1 匹配标识符
                    case 1:
                        
                        if (!isLetter_(codeStr[codeIndex]) && !isDigit(codeStr[codeIndex]))
                        {
                            retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                            //判断是否为关键字
                            int flag = isKeyWord(str);
                            if (flag < 0)
                            {
                                pointerIndex = add2SymbolList(str, lineIndex);
                                add2TokenResList(str, "IDN", pointerIndex.ToString(), 256, "标识符", lineIndex);
                                
                            }
                            else
                            {
                                add2TokenResList(str, str, "_", flag, "关键字", lineIndex);
                            }
                        }
                        break;

                    //2-4匹配字符串常量
                    case 2:
                        //匹配字符串常量
                        if (codeStr[codeIndex] == '\\')
                        {
                            state = 3;
                        }
                        else if (codeStr[codeIndex] == '\n')
                        {
                            state = 0;
                            endIndex = codeIndex - 1;
                            str = codeStr.Substring(beginIndex, endIndex - beginIndex + 1);
                            add2ErrorList("字符串常数不闭合", str, lineIndex);
                        }
                        else if (codeStr[codeIndex] == '"')
                        {
                            state = 4;
                        }
                        break;
                    case 3:
                        //过滤转义字符
                        state = 2;
                        break;
                    case 4:
                        //接收字符串常量，添加到相应的List中
                        retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                        add2TokenResList(str, "STR", str, 348, "字符串常量", lineIndex);
                        break;

                    //5-7、52匹配字符常量
                    case 5:
                        if (codeStr[codeIndex] == '\\')
                        {
                            state = 6;
                        }
                        else if (codeStr[codeIndex] == '\n')
                        {
                            state = 0;
                            endIndex = codeIndex - 1;
                            str = codeStr.Substring(beginIndex, endIndex - beginIndex + 1);
                            add2ErrorList("字符常数不闭合", str, lineIndex);
                        }
                        else if (codeStr[codeIndex] == '\'')
                        {
                            state = 0;
                            endIndex = codeIndex;
                            str = codeStr.Substring(beginIndex, endIndex - beginIndex + 1);
                            add2ErrorList("空字符常数", str, lineIndex);
                        }
                        else
                        {
                            state = 7;
                        }
                        break;
                    case 6:
                        if (isEscape(codeStr[codeIndex]))
                        {
                            state = 7;
                        }
                        else
                        {
                            state = 0;
                            endIndex = codeIndex;
                            codeIndex--;
                            str = codeStr.Substring(beginIndex, endIndex - beginIndex + 1);
                            add2ErrorList("无效的字符常数", str, lineIndex);
                        }
                        break;
                    case 7:
                        if (codeStr[codeIndex] == '\'')
                        {
                            state = 52;
                        }
                        else
                        {
                            state = 0;
                            endIndex = codeIndex;
                            codeIndex--;
                            str = codeStr.Substring(beginIndex, endIndex - beginIndex + 1);
                            add2ErrorList("无效的字符常数", str, lineIndex);
                        }
                        break;

                    //8->9匹配8进制整数
                    case 8:
                        if (isOne2Seven(codeStr[codeIndex]))
                        {
                            state = 9;
                        }
                        else if (codeStr[codeIndex] == 'x')
                        {
                            state = 10;
                        }
                        else if (codeStr[codeIndex] == '.')
                        {
                            state = 12;
                        }
                        else
                        {
                            retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                            add2TokenResList(str, "INT10", str, 343, "整型常量", lineIndex);
                        }
                        break;
                    case 9:
                        if (!isZero2Seven(codeStr[codeIndex]))
                        {
                            retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                            add2TokenResList(str, "INT8", str, 345, "8进制整型常量", lineIndex);
                        }
                        break;

                    //8->10->11匹配16进制整数
                    case 10:
                        if ((codeStr[codeIndex] >= '1' && codeStr[codeIndex] <= '9') || (codeStr[codeIndex] >= 'a' && codeStr[codeIndex] <= 'f'))
                        {
                            state = 11;
                        }
                        else
                        {
                            state = 0;
                            endIndex = codeIndex;
                            codeIndex--;
                            str = codeStr.Substring(beginIndex, endIndex - beginIndex + 1);
                            add2ErrorList("无效的16进制数", str, lineIndex);
                        }
                        break;
                    case 11:
                        if (!((codeStr[codeIndex] >= '0' && codeStr[codeIndex] <= '9') || (codeStr[codeIndex] >= 'a' && codeStr[codeIndex] <= 'f')))
                        {
                            retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                            add2TokenResList(str, "INT16", str, 344, "16进制整型常量", lineIndex);
                        }
                        break;

                    //8->12->13匹配浮点数
                    case 12:
                        if (isDigit(codeStr[codeIndex]))
                        {
                            state = 13;
                        }
                        else
                        {
                            state = 0;
                            endIndex = codeIndex;
                            codeIndex--;
                            str = codeStr.Substring(beginIndex, endIndex - beginIndex + 1);
                            add2ErrorList("无效的浮点数", str, lineIndex);
                        }
                        break;
                    case 13:
                        if (!isDigit(codeStr[codeIndex]))
                        {
                            retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                            add2TokenResList(str, "FlOAT", str, 346, "浮点型常量", lineIndex);
                        }
                        break;

                    //14匹配整数，14->15->12->13匹配浮点数
                    case 14:
                        if (isDigit(codeStr[codeIndex]))
                        {
                            state = 15;
                        }
                        else if (codeStr[codeIndex] == '.')
                        {
                            state = 16;
                        }
                        else
                        {
                            retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                            add2TokenResList(str, "INT10", str, 343, "整型常量", lineIndex);
                        }
                        break;

                    //15匹配整数
                    case 15:
                        if (codeStr[codeIndex] == '.')
                        {
                            state = 12;
                        }
                        else if (!isDigit(codeStr[codeIndex]))
                        {
                            retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                            add2TokenResList(str, "INT10", str, 343, "整型常量", lineIndex);
                        }
                        break;

                    //14->16->17->18->19->20，匹配科学计数法
                    case 16:
                        if (isDigit(codeStr[codeIndex]))
                        {
                            state = 17;
                        }
                        else
                        {
                            state = 0;
                            endIndex = codeIndex;
                            codeIndex--;
                            str = codeStr.Substring(beginIndex, endIndex - beginIndex + 1);
                            add2ErrorList("无效的浮点数", str, lineIndex);
                        }
                        break;

                    //匹配浮点数
                    case 17:
                        if (codeStr[codeIndex] == 'e')
                        {
                            state = 18;
                        }
                        else if (isDigit(codeStr[codeIndex]))
                        {
                            codeIndex++;
                            continue;
                        }
                        else
                        {
                            retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                            add2TokenResList(str, "FLOAT", str, 346, "浮点型常量", lineIndex);
                        }
                        break;

                    case 18:
                        if (isDigit(codeStr[codeIndex]))
                        {
                            state = 20;
                        }
                        else if (codeStr[codeIndex] == '+' || codeStr[codeIndex] == '-')
                        {
                            state = 19;
                        }
                        else
                        {
                            state = 0;
                            endIndex = codeIndex;
                            codeIndex--;
                            str = codeStr.Substring(beginIndex, endIndex - beginIndex + 1);
                            add2ErrorList("无效的科学计数法", str, lineIndex);
                        }
                        break;

                    case 19:
                        if (isOne2Nine(codeStr[codeIndex]))
                        {
                            state = 20;
                        }
                        else
                        {
                            state = 0;
                            endIndex = codeIndex;
                            codeIndex--;
                            str = codeStr.Substring(beginIndex, endIndex - beginIndex + 1);
                            add2ErrorList("无效的科学计数法", str, lineIndex);
                        }
                        break;

                    //接收科学计数法
                    case 20:
                        if (isDigit(codeStr[codeIndex]))
                        {
                            codeIndex++;
                            continue;
                        }
                        else
                        {
                            retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                            add2TokenResList(str, "FLOAT", str, 346, "浮点数常量", lineIndex);
                        }
                        break;

                    //21-23匹配<<, <=
                    case 21:
                        if (codeStr[codeIndex] == '<')
                        {
                            state = 22;
                        }
                        else if (codeStr[codeIndex] == '=')
                        {
                            state = 23;
                        }
                        else
                        {
                            retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);                       
                            add2TokenResList(str, str, "_", 314, "运算符", lineIndex);
                        }
                        break;

                    case 22:
                        retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                        add2TokenResList(str, str, "_", 312, "运算符", lineIndex);
                        break;
                        
                    case 23:
                        retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                        add2TokenResList(str, str, "_", 315, "运算符", lineIndex);
                        break;

                    //24-26匹配>>, >=
                    case 24:
                        if (codeStr[codeIndex] == '>')
                        {
                            state = 25;
                        }
                        else if (codeStr[codeIndex] == '=')
                        {
                            state = 26;
                        }
                        else
                        {
                            retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                            add2TokenResList(str, str, "_", 316, "运算符", lineIndex);
                        }
                        break;
                    case 25:
                        retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                        add2TokenResList(str, str, "_", 313, "运算符", lineIndex);
                        break;
                    case 26:
                        retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                        add2TokenResList(str, str, "_", 317, "运算符", lineIndex);
                        break;

                    //27-28匹配=, ==
                    case 27:
                        if (codeStr[codeIndex] == '=')
                        {
                            state = 28;
                        }
                        else
                        {
                            retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                            add2TokenResList(str, str, "_", 318, "运算符", lineIndex);
                        }
                        break;
                    case 28:
                        retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                        add2TokenResList(str, str, "_", 319, "运算符", lineIndex);
                        break;

                    //29-30匹配!, !=
                    case 29:
                        if (codeStr[codeIndex] == '=')
                        {
                            state = 30;
                        }
                        else
                        {
                            retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                            add2TokenResList(str, str, "_", 341, "运算符", lineIndex);
                        }
                        break;
                    case 30:
                        retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                        add2TokenResList(str, str, "_", 342, "运算符", lineIndex);
                        break;

                    //31-33匹配|, ||, |=
                    case 31:
                        if (codeStr[codeIndex] == '|')
                        {
                            state = 32;
                        }
                        else if (codeStr[codeIndex] == '=')
                        {
                            state = 33;
                        }
                        else
                        {
                            retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                            add2TokenResList(str, str, "_", 320, "运算符", lineIndex);
                            break;
                        }
                        break;

                    case 32:
                        retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                        add2TokenResList(str, str, "_", 321, "运算符", lineIndex);
                        break;

                    case 33:
                        retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                        add2TokenResList(str, str, "_", 322, "运算符", lineIndex);
                        break;

                    //34-35匹配^, ^=
                    case 34:
                        if (codeStr[codeIndex] == '=')
                        {
                            state = 35;
                        }
                        else
                        {
                            retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                            add2TokenResList(str, str, "_", 323, "运算符", lineIndex);
                        }
                        break;
                    case 35:
                        retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                        add2TokenResList(str, str, "_", 324, "运算符", lineIndex);
                        break;

                    //36-38匹配&, &&, &=
                    case 36:
                        if (codeStr[codeIndex] == '&')
                        {
                            state = 37;
                        }
                        else if (codeStr[codeIndex] == '=')
                        {
                            state = 38;
                        }
                        else
                        {
                            retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                            add2TokenResList(str, str, "_", 325, "运算符", lineIndex);
                        }
                        break;

                    case 37:
                        retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                        add2TokenResList(str, str, "_", 326, "运算符", lineIndex);
                        break;

                    case 38:
                        retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                        add2TokenResList(str, str, "_", 327, "运算符", lineIndex);
                        break;

                    //39-41匹配+, ++, +=
                    case 39:
                        if (codeStr[codeIndex] == '+')
                        {
                            state = 40;
                        }
                        else if (codeStr[codeIndex] == '=')
                        {
                            state = 41;
                        }
                        else
                        {
                            retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                            add2TokenResList(str, str, "_", 330, "运算符", lineIndex);
                        }
                        break;

                    case 40:
                        retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                        add2TokenResList(str, str, "_", 331, "运算符", lineIndex);
                        break;

                    case 41:
                        retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                        add2TokenResList(str, str, "_", 332, "运算符", lineIndex);
                        break;

                    //42-45匹配--, -=, ->
                    case 42:
                        if (codeStr[codeIndex] == '-')
                        {
                            state = 43;
                        }
                        else if (codeStr[codeIndex] == '=')
                        {
                            state = 44;
                        }
                        else if (codeStr[codeIndex] == '>')
                        {
                            state = 45;
                        }
                        else
                        {
                            retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                            add2TokenResList(str, str, "_", 333, "运算符", lineIndex);
                        }
                        break;

                    case 43:
                        retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                        add2TokenResList(str, str, "_", 334, "运算符", lineIndex);
                        break;

                    case 44:
                        retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                        add2TokenResList(str, str, "_", 335, "运算符", lineIndex);
                        break;

                    case 45:
                        retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                        add2TokenResList(str, str, "_", 336, "运算符", lineIndex);
                        break;

                    //46-47匹配/, /=
                    case 46:
                        if (codeStr[codeIndex] == '=')
                        {
                            state = 47;
                        }
                        else
                        {
                            retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                            add2TokenResList(str, str, "_", 337, "运算符", lineIndex);
                        }
                        break;
                    case 47:
                        retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                        add2TokenResList(str, str, "_", 338, "运算符", lineIndex);
                        break;

                    //48-49匹配*, *=
                    case 48:
                        if (codeStr[codeIndex] == '=')
                        {
                            state = 49;
                        }
                        else
                        {
                            retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                            add2TokenResList(str, str, "_", 339, "运算符", lineIndex);
                        }
                        break;

                    case 49:
                        retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                        add2TokenResList(str, str, "_", 340, "运算符", lineIndex);
                        break;

                    //50-51匹配%, %=
                    case 50:
                        if (codeStr[codeIndex] == '=')
                        {
                            state = 51;
                        }
                        else
                        {
                            retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                            add2TokenResList(str, str, "_", 328, "运算符", lineIndex);
                        }
                        break;
                    case 51:
                        retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                        add2TokenResList(str, str, "_", 329, "运算符", lineIndex);
                        break;      
 
                    //由于后续字符常量状态机的修改，导致52状态为字符常量的接收状态
                    case 52:
                        retract(ref codeIndex, ref state, ref endIndex, ref str, codeStr, beginIndex);
                        add2TokenResList(str, "CHAR", str, 347, "字符型常量", lineIndex);
                        break;
                }
                codeIndex++;

            }          
            outTokenResList = tokenResList;
            outErrorList = errorList;
            outSymbolList = symbolList;
        }

        /// <summary>
        /// 回退指针，复位状态，截取词素
        /// </summary>
        /// <param name="codeIndex">下标指针</param>
        /// <param name="state">状态</param>
        /// <param name="endIndex">词素的结束位置</param>
        /// <param name="str">待截取的词素</param>
        /// <param name="codeStr">源码</param>
        /// <param name="beginIndex">词素的开始位置</param>
        private void retract(ref int codeIndex, ref int state, ref int endIndex, ref string str, string codeStr, int beginIndex)
        {
            codeIndex--;
            state = 0;
            endIndex = codeIndex;
            str = codeStr.Substring(beginIndex, endIndex - beginIndex + 1);
        }

        /// <summary>
        /// 添加到tokenResList中
        /// </summary>
        private void add2TokenResList(string word, string tokenName, string tokenValue, int typeNum, string className, int lineIndex)
        {
            Token tk = new Token(tokenName, tokenValue);
            TokenResult tr = new TokenResult(word, tk, typeNum, className, lineIndex);
            tokenResList.Add(tr);
        }

        /// <summary>
        /// 添加到symbolList
        /// </summary>
        private int add2SymbolList(string symbolName, int lineIndex)
        {
            int index = -1;
            bool flag = false;
            //判断传入的标识符是否已经在符号表中
            foreach (Symbol symbol in symbolList)
            {
                if (symbolName.Equals(symbol.SymbolName))
                {
                    flag = true;
                    index = symbol.MemIndex;
                    break;
                }
            }
            //不在符号表中，则添加到符号表
            if (!flag)
            {
                symbolList.Add(new Symbol(memIndex, symbolName, lineIndex));
                index = memIndex;
                this.memIndex++;
            }
            return index;
        }


        private void add2ErrorList(string errorType, string errorWord, int errorLine)
        {
            errorList.Add(new Error(errorType, errorWord, errorLine));
        }

        /// <summary>
        /// 判断字符是否是1-9
        /// </summary>
        private bool isOne2Nine(char c)
        {
            bool flag = false;
            if (c >= '1' && c <= '9')
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 判断字符是否是1-7
        /// </summary>
        private bool isOne2Seven(char c)
        {
            bool flag = false;
            if (c >= '1' && c <= '7')
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 判断字符是否是0-7
        /// </summary>
        private bool isZero2Seven(char c)
        {
            bool flag = false;
            if (c >= '0' && c <= '7')
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 判断字符是否为0-9
        /// </summary>
        private bool isDigit(char c)
        {
            bool flag = false;
            if (c >= '0' && c <= '9')
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 判断字符是否为字母
        /// </summary>
        private bool isLetter(char c)
        {
            bool flag = false;
            if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 判断字符是否是字母或者"_"
        /// </summary>
        private bool isLetter_(char c)
        {
            bool flag = false;
            if (isLetter(c) || c == '_')
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 判断字符串是否是关键字
        /// </summary>
        /// <param name="keyWord">关键字字符串</param>
        /// <returns>匹配，关键字对应的种别码；否则，返回-1</returns>
        private int isKeyWord(string keyWord)
        {
            int flag = -1;
            for (int i = 0; i < ConstTable.keyWords.Length; i++)
            {
                if (keyWord.Equals(ConstTable.keyWords[i]))
                {
                    flag = 257 + i;
                }
            }
            return flag;
        }

        /// <summary>
        /// 判断字符是否是单界符
        /// </summary>
        /// <param name="c">单界符</param>
        /// <returns>匹配，返回单界符的种别码；否则，返回-1</returns>
        private int isSingleChar(char c)
        {
            int flag = -1;
            for (int i = 0; i < ConstTable.singleChars.Length; i++)
            {
                if (c == ConstTable.singleChars[i])
                {
                    flag = 299 + i;
                }
            }
            return flag;
        }

        /// <summary>
        /// 判断输入字符是否是转义字符
        /// </summary>
        private bool isEscape(char c)
        {
            bool flag = false;
            for (int i = 0; i < ConstTable.escapeChars.Length; i++)
            {
                if (c.Equals(ConstTable.escapeChars[i]))
                {
                    flag = true;
                }
            }
            return flag;
        }

        /// <summary>
        /// 识别注释，并添加到noteList中
        /// </summary>
        /// <param name="codeStr">程序代码</param>
        private void recognationNote(string codeStr)
        {
            int stateIndex = 0;
            int beginIndex = 0;
            int endIndex = 0;

            for (int i = 0; i < codeStr.Length; i++)
            {
                switch (stateIndex)
                {
                    case 0:
                        if (codeStr[i] == '/')
                        {
                            stateIndex = 1;
                            beginIndex = i;
                        }
                        break;
                    case 1:
                        if (codeStr[i] == '*')
                        {
                            stateIndex = 2;
                        }
                        else if (codeStr[i] == '/')
                        {
                            stateIndex = 5;
                        }
                        break;
                    case 2:
                        if (codeStr[i] == '*')
                        {
                            stateIndex = 3;
                        }
                        break;
                    case 3:
                        if (codeStr[i] == '/')
                        {
                            stateIndex = 4;
                        }
                        else if (codeStr[i] != '*')
                        {
                            stateIndex = 2;
                        }
                        break;
                    case 4:
                        stateIndex = 0;
                        endIndex = i;
                        //截取注释内容，以便后续替换注释内容
                        noteList.Add(codeStr.Substring(beginIndex, endIndex - beginIndex));
                        break;
                    case 5:
                        if (codeStr[i] == '\n')
                        {
                            stateIndex = 6;
                        }
                        break;
                    case 6:
                        stateIndex = 0;
                        endIndex = i - 1;
                        //截取注释内容，以便后续替换注释内容
                        noteList.Add(codeStr.Substring(beginIndex, endIndex - beginIndex));
                        break;
                }
            }
            for (int i = 0; i < noteList.Count; i++)
            {
                Console.WriteLine(noteList[i]);
            }
        }

        /// <summary>
        /// 根据noteList中获取的注释，替换源代码
        /// </summary>
        /// <param name="codeStr">源程序代码</param>
        /// <returns>去除注释后的代码</returns>
        private string cutNote(string codeStr)
        {
            string replaceStr;
            //将注释替换为相应的\n个数
            for (int i = 0; i < noteList.Count; i++)
            {
                replaceStr = "";
                foreach (char c in noteList[i])
                {
                    if (c == '\n')
                    {
                        replaceStr += c.ToString();
                    }
                }
                codeStr = codeStr.Replace(noteList[i], replaceStr);
            }
            Console.Write("CodeStr:\n" + codeStr);
            return codeStr;
        }
    }
}
