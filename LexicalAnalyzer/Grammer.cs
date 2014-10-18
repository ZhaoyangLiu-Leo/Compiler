using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LexicalAnalyzer
{
    class Grammer
    {
        private List<Production> productions;
        private HashSet<string> tSymbols;
        private HashSet<string> nSymbols;
        private Hashtable nSymbolTable;
        private HashSet<string> canLeadNullSymbols;

        public Grammer()
        {
            productions = new List<Production>();
            tSymbols = new HashSet<string>();
            nSymbols = new HashSet<string>();
            nSymbolTable = new Hashtable();
            canLeadNullSymbols = new HashSet<string>();
        }

        /// <summary>
        /// 句法分析功能函数
        /// </summary>
        public void grammerAnalyse(string gramContent, out HashSet<string> outTSymbols, out HashSet<string> outNSymbols)
        {
            Production p;
            List<string> right;

            //将文法规则按行划分
            string[] gramLine = gramContent.Split('\n');

            for (int i = 0; i < gramLine.Length; i++)
            {
                //将文法规则的每一行按空格划分
                string[] gramSymbol = gramLine[i].Split(' ');
                right = new List<string>();

                for (int j = 2; j < gramSymbol.Length; j++)
                {
                    //统计文法符号，填充产生式右部
                    tSymbols.Add(gramSymbol[j]);        
                    right.Add(gramSymbol[j]);           
                }

                p = new Production(gramSymbol[0], right);
                productions.Add(p);
                nSymbols.Add(gramSymbol[0]);
            }

            //将文法符号与非终结符做集合差，获得终结符集合
            tSymbols.ExceptWith(nSymbols);
            tSymbols.Remove("$");
            computeFirst();
            outTSymbols = tSymbols;
            outNSymbols = nSymbols;
        }

        /// <summary>
        /// 判断符号是否能够推出空
        /// </summary>
        private bool isLeadNull(string symbol)
        {
            bool flag = false;
            if (isTerminalSymbol(symbol))
            {
                flag = false;
            }
            else
            {
                if (canLeadNullSymbols.Contains(symbol))
                {
                    flag = true;
                }
                else
                {
                    foreach (Production p in productions)
                    {
                        if (symbol.Equals(p.Left))
                        {
                            if (p.Right[0].Equals("$"))
                            {
                                flag = true;
                                break;
                            }
                        }
                    }
                    if (!flag)
                    {
                        bool temp_flag = true;
                        foreach (Production p in productions)
                        {
                            if (symbol.Equals(p.Left))
                            {
                                foreach (string str in p.Right)
                                {
                                    if (!isLeadNull(str))
                                    {
                                        temp_flag = false;
                                        break;
                                    }
                                }
                            }
                        }
                        flag = temp_flag;
                    }
                }
            }
            if (flag)
            {
                canLeadNullSymbols.Add(symbol);
            }
            return flag;
        }

        /// <summary>
        /// 判断是否是终结符
        /// </summary>
        private bool isTerminalSymbol(string str)
        {
            bool flag = false;
            if (tSymbols.Contains(str))
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 判断是否是非终结符
        /// </summary>
        private bool isNonterminalSymbol(string str)
        {
            bool flag = false;
            if (nSymbols.Contains(str))
            {
                flag = true;
            }
            return flag;
        }

        private void initnSymbolTable()
        {
            NonterminalSymbol nonSymbol;
            foreach (string str in nSymbols)
            {
                nonSymbol = new NonterminalSymbol(str);
                nSymbolTable.Add(str, nonSymbol);
            }
        }

        private void computeFirst()
        {
            initnSymbolTable();
            int[] firstCount = new int[nSymbolTable.Count];
            for (int i = 0; i < firstCount.Length; i++)
            {
                firstCount[i] = 0;
            }

            //while (true)
            //{
                foreach (Production p in productions)
                {
                    if (isNonterminalSymbol(p.Left))
                    {
                        if (isTerminalSymbol(p.Right[0]))
                        {
                            NonterminalSymbol nonSymbol = nSymbolTable[p.Left] as NonterminalSymbol;
                            nonSymbol.First.Add(p.Right[0]);
                        }
                    }  
                }
            //}

                foreach (DictionaryEntry de in nSymbolTable)
                {
                    Console.Write("symbol: " + de.Key + "; fist:");
                    NonterminalSymbol nonSymbol = de.Value as NonterminalSymbol;
                    foreach (string str in nonSymbol.First)
                    {
                        Console.Write(str + " ");
                    }
                    Console.WriteLine("");
                }
        }

    }
}
