using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LexicalAnalyzer
{
    public delegate void ExcuteDelegate(Hashtable comRecordTable, Hashtable synRecordTable, Hashtable symbolTable,
        Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList);

    class ActionRecord
    {
        public static ExcuteDelegate[] excuteDelegates = { action0, action1, action2, action3, action4, action5, action6, action7, 
                                                           action8, action9, action10, action11, action12, action13, action14, action15, action16, 
                                                           action17, action18, action19, action20, action21};
        private static int offset;
        private static string t;
        private static int w;
        private static int tempCount = 0;
        private static Stack<string> tempStack = new Stack<string>();

        public static void excuteAction(string actionName, Hashtable comRecordTable, Hashtable synRecordTable,
            Hashtable symbolTable, Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            int actionIndex = Convert.ToInt32(actionName.Substring(4, actionName.Length - 4));
            Console.WriteLine("actionIndex: " + actionIndex);
            excuteDelegates[actionIndex](comRecordTable, synRecordTable, symbolTable, argsTable, threeCodeList, semanicErrorList);
        }

        private static void action0(Hashtable comRecordTable, Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            offset = 0;
        }

        private static void action1(Hashtable comRecordTable, Hashtable synRecordTable, Hashtable symbolTable,
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

        private static void action2(Hashtable comRecordTable, Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            SynRecord synRecord = synRecordTable["basic_type"] as SynRecord;
            t = synRecord.SynAttr["type"] as string;
            w = Convert.ToInt32(synRecord.SynAttr["width"] as string);
        }

        private static void action3(Hashtable comRecordTable, Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            SynRecord typeSynRecord = synRecordTable["type"] as SynRecord;
            SynRecord arraySynRecord = synRecordTable["array"] as SynRecord;
            add2Table(typeSynRecord.SynAttr, "type", arraySynRecord.SynAttr["type"] as string);
            add2Table(typeSynRecord.SynAttr, "width", arraySynRecord.SynAttr["width"] as string);
        }

        private static void action4(Hashtable comRecordTable, Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            SynRecord synRecord = synRecordTable["basic_type"] as SynRecord;
            add2Table(synRecord.SynAttr, "type", "int");
            add2Table(synRecord.SynAttr, "width", "4");
        }

        private static void action5(Hashtable comRecordTable, Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            SynRecord synRecord = synRecordTable["basic_type"] as SynRecord;
            add2Table(synRecord.SynAttr, "type", "short");
            add2Table(synRecord.SynAttr, "width", "2");
        }

        private static void action6(Hashtable comRecordTable, Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            SynRecord synRecord = synRecordTable["basic_type"] as SynRecord;
            add2Table(synRecord.SynAttr, "type", "long");
            add2Table(synRecord.SynAttr, "width", "4");
        }

        private static void action7(Hashtable comRecordTable, Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            SynRecord synRecord = synRecordTable["basic_type"] as SynRecord;
            add2Table(synRecord.SynAttr, "type", "char");
            add2Table(synRecord.SynAttr, "width", "1");
        }

        private static void action8(Hashtable comRecordTable, Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            SynRecord synRecord = synRecordTable["basic_type"] as SynRecord;
            add2Table(synRecord.SynAttr, "type", "float");
            add2Table(synRecord.SynAttr, "width", "4");
        }

        private static void action9(Hashtable comRecordTable, Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            SynRecord synRecord = synRecordTable["basic_type"] as SynRecord;
            add2Table(synRecord.SynAttr, "type", "double");
            add2Table(synRecord.SynAttr, "width", "8");
        }

        private static void action10(Hashtable comRecordTable, Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            SynRecord synRecord = synRecordTable["array"] as SynRecord;
            add2Table(synRecord.SynAttr, "type", t);
            add2Table(synRecord.SynAttr, "width", w.ToString());
        }

        private static void action11(Hashtable comRecordTable, Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            string num = (argsTable["const"] as Stack<string>).Pop();
            SynRecord synRecord = synRecordTable["array"] as SynRecord;
            add2Table(synRecord.SynAttr, "type", "array(" + num + ", " + synRecord.SynAttr["type"] as string + ")");
            add2Table(synRecord.SynAttr, "width", (Convert.ToInt32(num) * Convert.ToInt32(synRecord.SynAttr["width"] as string)).ToString());
        }

        private static void action12(Hashtable comRecordTable, Hashtable synRecordTable, Hashtable symbolTable,
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

        private static void action13(Hashtable comRecordTable, Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            SynRecord synRecord = synRecordTable["expression"] as SynRecord;
            string addr = (synRecordTable["expression'"] as SynRecord).SynAttr["addr"] as string;
            add2Table(synRecord.SynAttr, "addr", addr);
        }

        private static void action14(Hashtable comRecordTable, Hashtable synRecordTable, Hashtable symbolTable,
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

        private static void action15(Hashtable comRecordTable, Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            SynRecord synRecord = synRecordTable["expression'"] as SynRecord;
            string addr = (synRecordTable["item"] as SynRecord).SynAttr["addr"] as string;
            add2Table(synRecord.SynAttr, "addr", addr);
        }

        private static void action16(Hashtable comRecordTable, Hashtable synRecordTable, Hashtable symbolTable,
           Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            SynRecord synRecord = synRecordTable["item"] as SynRecord;
            string addr = (synRecordTable["item'"] as SynRecord).SynAttr["addr"] as string;
            add2Table(synRecord.SynAttr, "addr", addr);
        }

        private static void action17(Hashtable comRecordTable, Hashtable synRecordTable, Hashtable symbolTable,
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

        private static void action18(Hashtable comRecordTable, Hashtable synRecordTable, Hashtable symbolTable,
           Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            SynRecord synRecord = synRecordTable["item'"] as SynRecord;
            string addr = (synRecordTable["factor"] as SynRecord).SynAttr["addr"] as string;
            add2Table(synRecord.SynAttr, "addr", addr);
        }

        private static void action19(Hashtable comRecordTable, Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {
            SynRecord synRecord = synRecordTable["factor"] as SynRecord;
            string addr = (synRecordTable["expression"] as SynRecord).SynAttr["addr"] as string;
            add2Table(synRecord.SynAttr, "addr", addr);
            tempStack.Push(addr);
        }

        private static void action20(Hashtable comRecordTable, Hashtable synRecordTable, Hashtable symbolTable,
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

        private static void action21(Hashtable comRecordTable, Hashtable synRecordTable, Hashtable symbolTable,
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

        private static void action22(Hashtable comRecordTable, Hashtable synRecordTable, Hashtable symbolTable,
            Hashtable argsTable, List<string> threeCodeList, List<SemanicError> semanicErrorList)
        {

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
