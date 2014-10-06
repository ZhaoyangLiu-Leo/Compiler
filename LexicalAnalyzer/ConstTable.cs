using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LexicalAnalyzer
{
    class ConstTable
    {
        public static string[] keyWords = { "auto", "break", "case", "char", "const", "continue", "default", "do", "double", "else", 
                                          "enum", "extern", "float", "for", "goto", "if", "int", "long", "register", "return", "short",
                                          "signed", "sizeof", "static", "struct", "switch", "typedef", "union", "unsigned", "void", "volatile",
                                          "while", "asm", "cdecl", "far", "near", "pascal", "interrupt", "register"};
        public static string[] escapeChars = { "'\n'", "'\r'", "'\0'", "'\t'", "'\v'", "'\b'", "'\f'", "'\a'", "'\"'", "'\''", "\\" };
        public static char[] singleChars = { '{', '}', '[', ']', '(', ')', '~', ',', ';', '.', '#', '?', ':' };
    }
}
