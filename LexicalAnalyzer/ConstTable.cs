using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LexicalAnalyzer
{
    /// <summary>
    /// 用来记录查询表
    /// </summary>
    class ConstTable
    {
        //关键字
        public static string[] keyWords = { "asm", "auto", "break", "case", "cdecl", "char", "const", "continue", "default", "do", "double", "else", 
                                          "enum", "extern", "float", "far", "for", "goto", "if", "int", "interrupt", "long", "register", "return", "short",
                                          "signed", "sizeof", "static", "struct", "switch", "typedef", "union", "unsigned", "void", "volatile",
                                          "while", "near", "pascal", "include"};
        //转义字符的右半部分
        public static char[] escapeChars = {'r', '0', 't', 'v', 'b', 'f', 'a', '"', '\'', '\\' };
        //单界符
        public static char[] singleChars = { '{', '}', '[', ']', '(', ')', '~', ',', ';', '.', '#', '?', ':' };
        //种别码映射
        public static string[] typeStrs = { "IDN", "asm", "auto", "break", "case", "cdecl", "char", "const", "continue", "default", "do", "double", "else", 
                                          "enum", "extern", "float", "far", "for", "goto", "if", "int", "interrupt", "long", "register", "return", "short",
                                          "signed", "sizeof", "static", "struct", "switch", "typedef", "union", "unsigned", "void", "volatile",
                                          "while", "near", "pascal", "sizeof", "NULL", "huge", "include", "{", "}", "[", "]", "(", ")", "~", ",", ";", ".", 
                                          "#", "?", ":", "<<", ">>", "<", "<=", ">", ">=", "=", "==", "|", "||", "|=", "^", "^=", "&", "&&", "&=", "%",
                                           "%=", "+", "++", "+=", "-", "--", "-=", "->", "/", "/=", "*", "*=", "!", "!=", "INT10", "INT16", "INT8", "FLOAT", 
                                           "CHAR", "STR" };
        //关系运算符
        public static string[] relops = { "<", "<=", "==", "!=", ">", ">=" };

        public static bool isRelop(string str)
        {
            bool flag = false;
            foreach (string s in relops)
            {
                if (s.Equals(str))
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
    }
}
