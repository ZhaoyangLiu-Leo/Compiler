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
        public static string[] keyWords = { "asm", "auto", "break", "case", "cdecl", "char", "const", "continue", "default", "do", "double", "else", 
                                          "enum", "extern", "float", "far", "for", "goto", "if", "int", "interrupt", "long", "register", "return", "short",
                                          "signed", "sizeof", "static", "struct", "switch", "typedef", "union", "unsigned", "void", "volatile",
                                          "while", "near", "pascal"};
        public static char[] escapeChars = {'r', '0', 't', 'v', 'b', 'f', 'a', '"', '\'', '\\' };
        public static char[] singleChars = { '{', '}', '[', ']', '(', ')', '~', ',', ';', '.', '#', '?', ':' };
        public static string[] typeStrs = { "IDN", "asm", "auto", "break", "case", "cdecl", "char", "const", "continue", "default", "do", "double", "else", 
                                          "enum", "extern", "float", "far", "for", "goto", "if", "int", "interrupt", "long", "register", "return", "short",
                                          "signed", "sizeof", "static", "struct", "switch", "typedef", "union", "unsigned", "void", "volatile",
                                          "while", "near", "pascal", "sizeof", "NULL", "huge", "include", "{", "}", "[", "]", "(", ")", "~", ",", ";", ".", 
                                          "#", "?", ":", "<<", ">>", "<", "<=", ">", ">=", "=", "==", "|", "||", "|=", "^", "^=", "&", "&&", "&=", "%",
                                           "%=", "+", "++", "+=", "-", "--", "-=", "->", "/", "/=", "*", "*=", "!", "!=", "INT10", "INT16", "INT8", "FLOAT", 
                                           "CHAR", "STR" };
    }
}
