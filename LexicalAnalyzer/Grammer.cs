using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LexicalAnalyzer
{
    class Grammer
    {
        private List<Production> productions;           //产生式list
        private HashSet<string> tSymbols;               //终结符集合
        private HashSet<string> nSymbols;               //非终结符集合
        private Hashtable nSymbolTable;                 //非终结符映射非终结符类的hashtable
        private HashSet<string> canLeadNullSymbols;     //可推空的文法符号集合
        private Hashtable forecastTable;                //预测分析表

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
        public bool grammerAnalyse(string gramContent, out HashSet<string> outTSymbols,
            out HashSet<string> outNSymbols, out Hashtable outNSymbolTable, out List<Production> outProductions, out Hashtable outForecastTable)
        {
            Production p;
            List<string> right;
            bool flag = false;

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

            //计算first集、follow集、select集
            computeFirst();
            computeFollow();
            computeSelect();

            flag = isLL1Grammer();

            if (flag)
            {
                produceForecastTable();
            }
            outTSymbols = tSymbols;
            outNSymbols = nSymbols;
            outProductions = productions;
            outNSymbolTable = nSymbolTable;
            outForecastTable = forecastTable;
            return flag;
        }

        /// <summary>
        /// 判断符号是否能够推出空
        /// </summary>
        public bool isLeadNull(string symbol)
        {
            bool flag = false;
            if (isTerminalSymbol(symbol))
            {
                flag = false;
            }
            else if (symbol.Equals("$"))
            {
                flag = true;
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
                        //递归调用，判断符号是否可推出空
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
                //添加到可空符号表中
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

        /// <summary>
        /// 初始化非终结符的hash表，key：非终结符，value：非终结符对应的类
        /// </summary>
        private void initnSymbolTable()
        {
            NonterminalSymbol nonSymbol;
            foreach (string str in nSymbols)
            {
                nonSymbol = new NonterminalSymbol(str);
                nSymbolTable.Add(str, nonSymbol);
            }
        }

        /// <summary>
        /// 计算非终结符的first集合
        /// </summary>
        private void computeFirst()
        {
            NonterminalSymbol nonSymbol;
            //初始化非终结符hash表
            initnSymbolTable();

            //定义数组，记录各个first集合中符号的个数
            int[] firstCount = new int[nSymbolTable.Count];
            int countIndex;
            for (int i = 0; i < firstCount.Length; i++)
            {
                firstCount[i] = 0;
            }

            while (true)
            {
                //记录当前各个非终结符对应的first集合中符号的个数
                countIndex = 0;
                foreach (DictionaryEntry de in nSymbolTable)
                {
                    nonSymbol = de.Value as NonterminalSymbol;
                    firstCount[countIndex] = nonSymbol.First.Count;
                    countIndex++;
                }

                //迭代产生式
                foreach (Production p in productions)
                {
                    nonSymbol = nSymbolTable[p.Left] as NonterminalSymbol;

                    //右部为非终结符或空直接添加，如果为非终结符则进行集合并运算
                    if (isTerminalSymbol(p.Right[0]))
                    {
                        nonSymbol.First.Add(p.Right[0]);
                    }
                    else if (p.Right[0].Equals("$"))
                    {
                        nonSymbol.First.Add("$");
                    }
                    else
                    {
                        foreach (string rightStr in p.Right)
                        {
                            if (isTerminalSymbol(rightStr))
                            {
                                nonSymbol.First.Add(rightStr);
                            }
                            else
                            {
                                NonterminalSymbol nonSymbol2 = nSymbolTable[rightStr] as NonterminalSymbol;
                                nonSymbol.First.UnionWith(nonSymbol2.First);
                            }
                            if (!isLeadNull(rightStr))
                            {
                                break;
                            }
                        }

                        //排除first集并运算引入的$符号
                        nonSymbol.First.Remove("$");

                        //当前非终结符可推空，添加$符号
                        if (isLeadNull(p.Left))
                        {
                            nonSymbol.First.Add("$");
                        }
                    }
                }
                bool flag = true;
                countIndex = 0;

                //比较上一次迭代与此次迭代后，first集合中符号的个数差异
                foreach (DictionaryEntry de in nSymbolTable)
                {
                    nonSymbol = de.Value as NonterminalSymbol;
                    if (firstCount[countIndex] != nonSymbol.First.Count)
                    {
                        flag = false;
                    }
                    countIndex++;
                }
                //first集合中符号个数不再改变，迭代完成
                if (flag)
                {
                    break;
                }
            }

            //foreach (DictionaryEntry de in nSymbolTable)
            //{
            //    Console.Write("symbol: " + de.Key + "; fist:");
            //    nonSymbol = de.Value as NonterminalSymbol;
            //    foreach (string str in nonSymbol.First)
            //    {
            //        Console.Write(str + " ");
            //    }
            //    Console.WriteLine("");
            //}
        }

        /// <summary>
        /// get 文法符号的first集
        /// </summary>
        /// <param name="symbol">文法符号</param>
        /// <returns>文法符号的first集</returns>
        private HashSet<string> getFirst(string symbol)
        {
            HashSet<string> symbolSet = new HashSet<string>();
            if (isTerminalSymbol(symbol))
            {
                symbolSet.Add(symbol);
            }
            else if (isNonterminalSymbol(symbol))
            {
                NonterminalSymbol nSymbol = nSymbolTable[symbol] as NonterminalSymbol;
                symbolSet = nSymbol.First;
            }   
            else { }
            return symbolSet;
        }

        /// <summary>
        /// 计算follow集
        /// </summary>
        private void computeFollow()
        {
            NonterminalSymbol nonSymbol;

            //定义数组，记录各个follow集合中符号的个数
            int[] followCount = new int[nSymbolTable.Count];
            int countIndex;
            for (int i = 0; i < followCount.Length; i++)
            {
                followCount[i] = 0;
            }

            nonSymbol = nSymbolTable["S"] as NonterminalSymbol;
            nonSymbol.Follow.Add("@");

            while (true)
            {
                //记录当前各个非终结符对应的follow集合中符号的个数
                countIndex = 0;
                foreach (DictionaryEntry de in nSymbolTable)
                {
                    nonSymbol = de.Value as NonterminalSymbol;
                    followCount[countIndex] = nonSymbol.Follow.Count;
                    countIndex++;
                }

                //迭代产生式
                foreach (Production p in productions)
                {
                    for (int i = 0; i < p.Right.Count; i++)
                    {
                        if (isNonterminalSymbol(p.Right[i]))
                        {
                            nonSymbol = nSymbolTable[p.Right[i]] as NonterminalSymbol;
                            //计算非终结符后面文法符号串的first集
                            List<string> tempList = new List<string>();
                            for (int j = i + 1; j < p.Right.Count; j++)
                            {
                                tempList.Add(p.Right[j]);
                            }
                            nonSymbol.Follow.UnionWith(computeStrListFirst(tempList));

                            if ((computeStrListFirst(tempList).Contains("$") || tempList.Count == 0) && (!p.Left.Equals(p.Right[i])))
                            {
                                NonterminalSymbol nonSymbolLeft = nSymbolTable[p.Left] as NonterminalSymbol;
                                nonSymbol.Follow.UnionWith(nonSymbolLeft.Follow);
                            }
                        }
                    }
                }

                bool flag = true;
                countIndex = 0;
                //比较上一次迭代与此次迭代后follow集中符号个数的差异
                foreach (DictionaryEntry de in nSymbolTable)
                {
                    nonSymbol = de.Value as NonterminalSymbol;
                    if (followCount[countIndex] != nonSymbol.Follow.Count)
                    {
                        flag = false;
                        break;
                    }
                    countIndex++;
                }
                //迭代后follow集无变化，跳出迭代
                if (flag)
                {
                    break;
                }
            }

            //去除follow集中的$符号
            foreach (DictionaryEntry de in nSymbolTable)
            {
                Console.Write(de.Key + " follow:");
                nonSymbol = de.Value as NonterminalSymbol;
                nonSymbol.Follow.Remove("$");
                foreach (string str in nonSymbol.Follow)
                {
                    Console.Write(str + " ");
                }
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// 判断一个文法符号串是否可以推出空
        /// </summary>
        /// <param name="symbolList">文法符号串</param>
        /// <returns>可空，true；不可空，false</returns>
        private bool isSymbolListNull(List<string> symbolList)
        {
            bool flag = true;
            foreach (string str in symbolList)
            {
                if (!isLeadNull(str))
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

        /// <summary>
        /// 计算文法符号串的first集合
        /// </summary>
        /// <param name="symbolList">文法符号串</param>
        /// <returns>文法符号串的first集</returns>
        private HashSet<string> computeStrListFirst(List<string> symbolList)
        {
            HashSet<string> symbolSet = new HashSet<string>();
            foreach (string str in symbolList)
            {
                symbolSet.UnionWith(getFirst(str));
                if (!isLeadNull(str))
                {
                    break;
                }
            }
            //排除first集并运算引入的$符号
            symbolSet.Remove("$");

            //如果整个符号串可以推出空，则添加$符号到first集合中
            if (isSymbolListNull(symbolList))
            {
                symbolSet.Add("$");
            }
            return symbolSet;
        }

        /// <summary>
        /// 计算产生式的select集
        /// </summary>
        private void computeSelect()
        {
            NonterminalSymbol nonSymbol;
            foreach (Production p in productions)
            {
                nonSymbol = nSymbolTable[p.Left] as NonterminalSymbol;

                //如果右部的first集中包含$，将右部的first集添加到产生式的select集中
                if (!computeStrListFirst(p.Right).Contains("$"))
                {
                    p.SelectStr = computeStrListFirst(p.Right); ;
                }
                else
                {
                    //如果不包含，添加first集合和follow集合
                    p.SelectStr = computeStrListFirst(p.Right);
                    p.SelectStr.UnionWith(nonSymbol.Follow);
                    p.SelectStr.Remove("$");
                }
            }
            //foreach (Production p in productions)
            //{
            //    Console.Write(p + "; select: ");
            //    foreach (string str in p.SelectStr)
            //    {
            //        Console.Write(str + " ");
            //    }
            //    Console.WriteLine("");
            //}
        }

        /// <summary>
        /// 根据相同左部推出的select集是否相交，判断是否是LL(1)文法
        /// </summary>
        private bool isLL1Grammer()
        {
            bool flag = true;
            for (int i = 0; i < productions.Count; i++)
            {
                string leftStr = productions[i].Left;
                for (int j = i + 1; j < productions.Count; j++)
                {
                    if (productions[j].Left.Equals(leftStr))
                    {
                        HashSet<string> tempSet = new HashSet<string>(productions[i].SelectStr);
                        tempSet.IntersectWith(productions[j].SelectStr);
                        if (tempSet.Count != 0)
                        {
                            flag = false;
                            break;
                        }
                    }
                }
                if (!flag)
                {
                    break;
                }
            }
            return flag;
        }

        /// <summary>
        /// 生成预测分析表
        /// </summary>
        private void produceForecastTable()
        {
            List<string> tempList;
            string forecastKey;
            NonterminalSymbol nonSymbol;

            forecastTable = new Hashtable();
            //添加select集
            foreach (Production p in productions)
            {
                foreach (string str in p.SelectStr)
                {
                    forecastKey = p.Left + " " + str;
                    forecastTable.Add(forecastKey, p.Right);
                }
            }

            //将非终结符的follow集到添加同步集合符号
            foreach (DictionaryEntry de in nSymbolTable)
            {
                nonSymbol = de.Value as NonterminalSymbol;
                foreach (string str in nonSymbol.Follow)
                {
                    forecastKey = de.Key + " " + str;
                    if (!forecastTable.Contains(forecastKey))
                    {
                        tempList = new List<string>();
                        tempList.Add("synch");
                        forecastTable.Add(forecastKey, tempList);
                    }
                }
            }
            //foreach (DictionaryEntry de in forecastTable)
            //{
            //    tempList = de.Value as List<string>;
            //    Console.Write(de.Key + ":");
            //    foreach (string str in tempList)
            //    {
            //        Console.Write(str + " ");
            //    }
            //    Console.WriteLine("");
            //}
        }

    }
}
