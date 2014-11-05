using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LexicalAnalyzer
{
    //定义委托，模拟函数指针
    public delegate void ExcuteDelegate(Hashtable synRecordTable, Hashtable symbolTable,
        Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList);

    class ActionRecord
    {
        //定义委托数组，方便action的调用
        public static ExcuteDelegate[] excuteDelegates = { action0, action1, action2, action3, action4, action5, action6, action7, 
                                                           action8, action9, action10, action11, action12, action13, action14, 
                                                           action15, action16, action17, action18, action19, action20, action21,
                                                           action22, action23, action24, action25, action26, action27, action28,
                                                           action29, action30, action31, action32, action33, action34 };

        private static int offset;                  //全局编译量
        private static string t;                    //记录数据类型
        private static int w;                       //记录数据类型的宽度
        private static int tempCount = 0;           //记录临时变量的编号
        private static int begin;                   //记录while语句的开始位置
        private static int offBegin;                //记录else语句的开始位置
        private static Stack<string> tempStack = new Stack<string>();                           //记录四则运算的结果
        private static Stack<HashSet<int>> trueSetStack = new Stack<HashSet<int>>();            //记录布尔表达式的truelist
        private static Stack<HashSet<int>> falseSetStack = new Stack<HashSet<int>>();           //记录布尔表达式的falselist

        /// <summary>
        /// 执行action的总控程序，根据传入的字符串，判断调用的action
        /// </summary>
        /// <param name="actionName">action名</param>
        /// <param name="synRecordTable">综合属性hashtable</param>
        /// <param name="symbolTable">符号表</param>
        /// <param name="argsTable">参数表</param>
        /// <param name="threeCodeList">三地址码序列</param>
        /// <param name="semanicErrorList">错误序列</param>
        public static void excuteAction(string actionName, Hashtable synRecordTable,
            Hashtable symbolTable, Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            int actionIndex = Convert.ToInt32(actionName.Substring(4, actionName.Length - 4));
            Console.WriteLine("actionIndex: " + actionIndex);
            excuteDelegates[actionIndex](synRecordTable, symbolTable, argsTable, threeCodeList, semanicErrorList);
        }

        //action0-11，负责声明语句的语法制导翻译
        
        private static void action0(Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            //初始化全局偏移量
            offset = 0;
        }

        /// <summary>
        /// 将type的类型和宽度传递给IDN，同时填充符号表
        /// </summary>
        private static void action1(Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            try
            {
                string identifier = (argsTable["IDN"] as Stack<string>).Pop();
                SynRecord synRecord = synRecordTable["type"] as SynRecord;
                string type = synRecord.SynAttr["type"] as string;
                Symbol symbol = symbolTable[identifier] as Symbol;
                symbol.Type = type;
                symbol.Offset = offset;
                string width = synRecord.SynAttr["width"] as string;
                offset += Convert.ToInt32(width);
            }
            catch (Exception e)
            {
                Console.WriteLine("In actionOne: " + e);
            }
        }

        /// <summary>
        /// 将basic_type的类型传递给type
        /// </summary>
        private static void action2(Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            SynRecord synRecord = synRecordTable["basic_type"] as SynRecord;
            t = synRecord.SynAttr["type"] as string;
            w = Convert.ToInt32(synRecord.SynAttr["width"] as string);
        }

        /// <summary>
        /// 将type传递给array
        /// </summary>
        private static void action3(Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            SynRecord typeSynRecord = synRecordTable["type"] as SynRecord;
            SynRecord arraySynRecord = synRecordTable["array"] as SynRecord;
            add2Table(typeSynRecord.SynAttr, "type", arraySynRecord.SynAttr["type"] as string);
            add2Table(typeSynRecord.SynAttr, "width", arraySynRecord.SynAttr["width"] as string);
        }

        /// <summary>
        /// 用int赋值type
        /// </summary>
        private static void action4(Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            SynRecord synRecord = synRecordTable["basic_type"] as SynRecord;
            add2Table(synRecord.SynAttr, "type", "int");
            add2Table(synRecord.SynAttr, "width", "4");
        }

        /// <summary>
        /// 用short赋值type
        /// </summary>
        private static void action5(Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            SynRecord synRecord = synRecordTable["basic_type"] as SynRecord;
            add2Table(synRecord.SynAttr, "type", "short");
            add2Table(synRecord.SynAttr, "width", "2");
        }

        /// <summary>
        /// 用long赋值type
        /// </summary>
        private static void action6(Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            SynRecord synRecord = synRecordTable["basic_type"] as SynRecord;
            add2Table(synRecord.SynAttr, "type", "long");
            add2Table(synRecord.SynAttr, "width", "4");
        }

        /// <summary>
        /// 用char赋值type
        /// </summary>
        private static void action7(Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            SynRecord synRecord = synRecordTable["basic_type"] as SynRecord;
            add2Table(synRecord.SynAttr, "type", "char");
            add2Table(synRecord.SynAttr, "width", "1");
        }

        /// <summary>
        /// 用float赋值type
        /// </summary>
        private static void action8(Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            SynRecord synRecord = synRecordTable["basic_type"] as SynRecord;
            add2Table(synRecord.SynAttr, "type", "float");
            add2Table(synRecord.SynAttr, "width", "4");
        }

        /// <summary>
        /// 用double赋值type
        /// </summary>
        private static void action9(Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            SynRecord synRecord = synRecordTable["basic_type"] as SynRecord;
            add2Table(synRecord.SynAttr, "type", "double");
            add2Table(synRecord.SynAttr, "width", "8");
        }

        /// <summary>
        /// 给array赋值type属性和width属性
        /// </summary>
        private static void action10(
            Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            SynRecord synRecord = synRecordTable["array"] as SynRecord;
            add2Table(synRecord.SynAttr, "type", t);
            add2Table(synRecord.SynAttr, "width", w.ToString());
        }

        /// <summary>
        /// 对array的type属性和宽度的嵌套计算
        /// </summary>
        private static void action11(Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            string num = (argsTable["const"] as Stack<string>).Pop();
            SynRecord synRecord = synRecordTable["array"] as SynRecord;
            add2Table(synRecord.SynAttr, "type", "array(" + num + ", " + synRecord.SynAttr["type"] as string + ")");
            add2Table(synRecord.SynAttr, "width", (Convert.ToInt32(num) * Convert.ToInt32(synRecord.SynAttr["width"] as string)).ToString());
        }

        //action12-action21，赋值语句的指导翻译实现

        /// <summary>
        /// 将表达式结果赋值给标识符
        /// </summary>
        private static void action12(Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            string lineIndex = argsTable["lineIndex"] as string;
            string identifier = (argsTable["IDN"] as Stack<string>).Pop();
            SynRecord synRecord = synRecordTable["expression"] as SynRecord;
            string addr = synRecord.SynAttr["addr"] as string;
            if (addr == null)
            {
                SemanicError se = new SemanicError(lineIndex, "表达式错误");
                semanicErrorList.Add(se);
            }
            else
            {
                threeCodeList.Add(identifier + " = " + addr);
            }
        }

        /// <summary>
        /// 将expression'的属性赋值给expression
        /// </summary>
        private static void action13(Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            SynRecord synRecord = synRecordTable["expression"] as SynRecord;
            string addr = (synRecordTable["expression'"] as SynRecord).SynAttr["addr"] as string;
            add2Table(synRecord.SynAttr, "addr", addr);
        }

        private static void action14(Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            SynRecord synRecord = synRecordTable["expression'"] as SynRecord;
            string f2 = tempStack.Pop();
            string f1 = tempStack.Pop();
            threeCodeList.Add("t" + tempCount + " = " + f1 + " + " + f2);
            add2Table(synRecord.SynAttr, "addr", "t" + tempCount);
            tempStack.Push("t" + tempCount);
            tempCount++;
        }

        /// <summary>
        /// 将item的属性赋值给expression'
        /// </summary>
        private static void action15(Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            SynRecord synRecord = synRecordTable["expression'"] as SynRecord;
            string addr = (synRecordTable["item"] as SynRecord).SynAttr["addr"] as string;
            add2Table(synRecord.SynAttr, "addr", addr);
        }

        /// <summary>
        /// 将expression'的属性赋值给item
        /// </summary>
        private static void action16(Hashtable synRecordTable, Hashtable symbolTable,
           Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            SynRecord synRecord = synRecordTable["item"] as SynRecord;
            string addr = (synRecordTable["item'"] as SynRecord).SynAttr["addr"] as string;
            add2Table(synRecord.SynAttr, "addr", addr);
        }

        private static void action17(Hashtable synRecordTable, Hashtable symbolTable,
           Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            SynRecord itemSynRecord = synRecordTable["item"] as SynRecord;
            string f2 = tempStack.Pop();
            string f1 = tempStack.Pop();
            threeCodeList.Add("t" + tempCount + " = " + f1
                + " * " + f2);
            tempStack.Push("t" + tempCount);
            add2Table(itemSynRecord.SynAttr, "addr", "t" + tempCount);
            tempCount++;
        }

        private static void action18(Hashtable synRecordTable, Hashtable symbolTable,
           Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            SynRecord synRecord = synRecordTable["item'"] as SynRecord;
            string addr = (synRecordTable["factor"] as SynRecord).SynAttr["addr"] as string;
            add2Table(synRecord.SynAttr, "addr", addr);
        }

        private static void action19(Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            SynRecord synRecord = synRecordTable["factor"] as SynRecord;
            string addr = (synRecordTable["expression"] as SynRecord).SynAttr["addr"] as string;
            add2Table(synRecord.SynAttr, "addr", addr);
            tempStack.Push(addr);
        }

        /// <summary>
        /// 将IDN赋值给factor
        /// </summary>
        private static void action20(Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            string lineIndex = argsTable["lineIndex"] as string;
            string identifier = (argsTable["IDN"] as Stack<string>).Pop();
            if (identifier == null)
            {
                SemanicError se = new SemanicError(lineIndex, "赋值语句错误");
                semanicErrorList.Add(se);
            }
            else
            {
                if ((symbolTable[identifier] as Symbol).Type == null || (symbolTable[identifier] as Symbol).Type == "")
                {
                    SemanicError se = new SemanicError(lineIndex, "使用未声明的标识符: " + identifier);
                    semanicErrorList.Add(se);
                }
                SynRecord synRecord = synRecordTable["factor"] as SynRecord;
                add2Table(synRecord.SynAttr, "addr", identifier);
                tempStack.Push(identifier);
            }
        }

        /// <summary>
        /// 将常量赋值给factor
        /// </summary>
        private static void action21(Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            string lineIndex = argsTable["lineIndex"] as string;
            string num = (argsTable["const"] as Stack<string>).Pop();
            if (num == null)
            {
                SemanicError se = new SemanicError(lineIndex, "赋值语句错误");
                semanicErrorList.Add(se);
            }
            else
            {
                SynRecord synRecord = synRecordTable["factor"] as SynRecord;
                add2Table(synRecord.SynAttr, "addr", num);
                tempStack.Push(num);
            }
        }

        //action22-action34，负责控制流语句的制导翻译过程
        /// <summary>
        /// 维护布尔表达式的truelist
        /// </summary>
        private static void action22(Hashtable synRecordTable, Hashtable symbolTable,
           Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            HashSet<int> trueSet = trueSetStack.Pop();
            foreach (int i in trueSet)
            {
                threeCodeList[i - 1] = threeCodeList[i - 1] + (threeCodeList.Count + 1).ToString();
            }
        }


        private static void action23(Hashtable synRecordTable, Hashtable symbolTable,
           Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            begin = threeCodeList.Count + 1;
        }

        private static void action24(Hashtable synRecordTable, Hashtable symbolTable,
           Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            threeCodeList.Add("goto " + begin);
            HashSet<int> falseSet = falseSetStack.Pop();
            foreach (int i in falseSet)
            {
                threeCodeList[i - 1] = threeCodeList[i - 1] + (threeCodeList.Count + 1).ToString();
            }
        }

        private static void action25(Hashtable synRecordTable, Hashtable symbolTable,
           Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            HashSet<int> falseSet = falseSetStack.Pop();
            foreach (int i in falseSet)
            {
                threeCodeList[i - 1] = threeCodeList[i - 1] + (threeCodeList.Count + 1).ToString();
            }
        }

        private static void action26(Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            HashSet<int> trueSet = new HashSet<int>();
            HashSet<int> falseSet = new HashSet<int>();
            string relop = (synRecordTable["rel"] as SynRecord).SynAttr["value"] as string;
            string e2 = tempStack.Pop();
            string e1 = tempStack.Pop();
            trueSet.Add(threeCodeList.Count + 1);
            falseSet.Add(threeCodeList.Count + 2);
            trueSetStack.Push(trueSet);
            falseSetStack.Push(falseSet);
            threeCodeList.Add("if " + e1 + " " + relop + " " + e2 + " goto ");
            threeCodeList.Add("goto ");
        }

        private static void action27(Hashtable synRecordTable, Hashtable symbolTable,
           Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            HashSet<int> trueSet = new HashSet<int>();
            HashSet<int> falseSet = new HashSet<int>();
            string relop = (synRecordTable["rel"] as SynRecord).SynAttr["value"] as string;
            string e2 = tempStack.Pop();
            string e1 = tempStack.Pop();
            trueSet.Add(threeCodeList.Count + 2);
            falseSet.Add(threeCodeList.Count + 1);
            trueSetStack.Push(trueSet);
            falseSetStack.Push(falseSet);
            threeCodeList.Add("if " + e1 + " " + relop + " " + e2 + " goto ");
            threeCodeList.Add("goto ");
        }

        /// <summary>
        /// 回填带逻辑运算符的布尔表达式的truelist和falselist
        /// </summary>
        private static void action28(Hashtable synRecordTable, Hashtable symbolTable,
           Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            string bool_operator = (synRecordTable["bool_operator"] as SynRecord).SynAttr["value"] as string;
            if (bool_operator.Equals("||"))
            {
                HashSet<int> falseSet2 = falseSetStack.Pop();
                HashSet<int> falseSet1 = falseSetStack.Pop();
                HashSet<int> trueSet2 = trueSetStack.Pop();
                HashSet<int> trueSet1 = trueSetStack.Pop();
                SynRecord synRecord = synRecordTable["M"] as SynRecord;
                string quad = synRecord.SynAttr["quad"] as string;

                foreach (int i in falseSet1)
                {
                    threeCodeList[i - 1] = threeCodeList[i - 1] + quad;
                }
                trueSet1.UnionWith(trueSet2);
                trueSetStack.Push(trueSet1);
                falseSetStack.Push(falseSet2);

            }
            else if (bool_operator.Equals("&&"))
            {
                HashSet<int> trueSet2 = trueSetStack.Pop();
                HashSet<int> trueSet1 = trueSetStack.Pop();
                HashSet<int> falseSet2 = falseSetStack.Pop();
                HashSet<int> falseSet1 = falseSetStack.Pop();
                SynRecord synRecord = synRecordTable["M"] as SynRecord;
                string quad = synRecord.SynAttr["quad"] as string;

                foreach (int i in trueSet1)
                {
                    threeCodeList[i - 1] = threeCodeList[i - 1] + quad;
                }
                trueSetStack.Push(trueSet2);
                falseSet1.UnionWith(falseSet2);
                falseSetStack.Push(falseSet1);
            }
            else { } 

        }

        private static void action29(Hashtable synRecordTable, Hashtable symbolTable,
           Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            SynRecord synRecord = synRecordTable["M"] as SynRecord;
            add2Table(synRecord.SynAttr, "quad", (threeCodeList.Count + 1).ToString());
        }

        /// <summary>
        /// 布尔运算符的制导翻译
        /// </summary>
        private static void action30(Hashtable synRecordTable, Hashtable symbolTable,
           Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            SynRecord synRecord = synRecordTable["bool_operator"] as SynRecord;
            add2Table(synRecord.SynAttr, "value", "&&");
        }

        /// <summary>
        /// 布尔运算符的制导翻译
        /// </summary>
        private static void action31(Hashtable synRecordTable, Hashtable symbolTable,
           Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            SynRecord synRecord = synRecordTable["bool_operator"] as SynRecord;
            add2Table(synRecord.SynAttr, "value", "||");
        }

        /// <summary>
        /// 关系运算符的制导翻译
        /// </summary>
        private static void action32(Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            add2Relop(synRecordTable, argsTable);
        }

        private static void action33(Hashtable synRecordTable, Hashtable symbolTable,
           Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            offBegin = threeCodeList.Count;
            threeCodeList.Add("goto ");
        }

        /// <summary>
        /// 回填布尔表达式整体的结束
        /// </summary>
        private static void action34(Hashtable synRecordTable, Hashtable symbolTable,
           Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            threeCodeList[offBegin] += threeCodeList.Count + 1;
        }

        /// <summary>
        /// 根据总控程序传来的关系运算符，添加到综合属性table
        /// </summary>
        /// <param name="synRecordTable"></param>
        /// <param name="argsTable"></param>
        private static void add2Relop(Hashtable synRecordTable, Hashtable argsTable)
        {
            string relop = argsTable["relop"] as string;
            SynRecord synRecord = synRecordTable["rel"] as SynRecord;
            add2Table(synRecord.SynAttr, "value", relop);
        }



        /// <summary>
        /// 添加或者修改hashtable的属性
        /// </summary>
        private static void add2Table(Hashtable table, string key, string value)
        {
            if (table.Contains(key))
            {
                table[key] = value;
            }
            else
            {
                table.Add(key, value);
            }
        }
    }
}
