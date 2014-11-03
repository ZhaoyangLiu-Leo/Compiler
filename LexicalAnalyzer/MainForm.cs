using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LexicalAnalyzer
{
    public partial class MainForm : Form
    {
        private string codeStr;                         //待分析的程序代码
        private string gramStr = "";                    //待分析的文法
        private List<TokenResult> tokenResList;         //token分析结果list
        private List<Error> errorList;                  //词法分析错误信息list
        private List<Symbol> symbolList;                //符号表信息list
        private Hashtable symbolTable;

        private HashSet<string> tSymbols;               //终结符集合
        private HashSet<string> nSymbols;               //非终结符集合
        private List<Production> productions;           //不带语义动作的产生式集合
        private List<Production> actionProductions;     //带语义动作的产生式list
        private Hashtable nSymbolTable;                 //非终结符映射非终结符类的hashtable
        private List<SentenseResult> sentenseResList;   //句法分析结果list
        private Hashtable forecastTable;                //预测分析表
        private bool isLL1Grammer;                      //标志位，记录文法是否是LL(1)文法
        private List<GrammerError> grammerErrorList;    //句法分析错误list
        private Grammer grammer;                        //句法分析类

        private Hashtable synRecordTable;               //综合属性
        private Hashtable argsTable;                    //参数列表，存储标识符和常量
        private List<string> threeCodeList;
        private List<SemanicError> semanicErrorList;

        public MainForm()
        {
            InitializeComponent();
            indexRichTextBox.Text = "1";
            isLL1Grammer = false;
        }

        /// <summary>
        /// richtextbox内容发生修改，即更新行号
        /// </summary>
        private void contentRichTextBox_TextChanged(object sender, EventArgs e)
        {
            updateLabelRowIndex();
        }

        /// <summary>
        /// 纵向滚动条响应事件，同时更新行号
        /// </summary>
        private void contentRichTextBox_VScroll(object sender, EventArgs e)
        {
            updateLabelRowIndex();
        }

        /// <summary>
        /// 更新行号处理函数
        /// </summary>
        private void updateLabelRowIndex()
        {
            indexRichTextBox.Clear();       //清空行号

            //获取第一个可见的字符的位置和行号
            Point pos = new Point(1, 1);
            int firstIndex = this.contentRichTextBox.GetCharIndexFromPosition(pos);
            int firstLine = this.contentRichTextBox.GetLineFromCharIndex(firstIndex);

            //获取用户区大小，并获得最后一行的行号
            pos.Y += this.contentRichTextBox.ClientRectangle.Height;
            int lastIndex = this.contentRichTextBox.GetCharIndexFromPosition(pos);
            int lastLine = this.contentRichTextBox.GetLineFromCharIndex(lastIndex);

            //Console.WriteLine("LastLine:" + lastLine);

            for (int i = firstLine; i <= lastLine; i++)
            {
                indexRichTextBox.Text += i + 1 + "\r\n";
            }
        }

        /// <summary>
        /// 编译按钮处理函数
        /// </summary>
        private void compileButton_Click(object sender, EventArgs e)
        {
            clearDataGridViews();
            codeStr = contentRichTextBox.Text;
            Scanner scanner = new Scanner();
            scanner.analyzeCode(codeStr, out tokenResList, out errorList, out symbolList);
            /*for (int i = 0; i < tokenResList.Count; i++)
            {
                Console.WriteLine(tokenResList[i]);
            }
            Console.WriteLine("*************************************");
            for (int i = 0; i < symbolList.Count; i++)
            {
                Console.WriteLine(symbolList[i]);
            }
            Console.WriteLine("*************************************");
            for (int i = 0; i < errorList.Count; i++)
            {
                Console.WriteLine(errorList[i]);
            }*/
            this.add2TokenDataGridView();
            this.add2ErrorDataGridView();
            this.add2SymbolDataGridList();
            computeSymbolTable();
        }

        /// <summary>
        /// 生成符号表的hashtable
        /// </summary>
        private void computeSymbolTable()
        {
            symbolTable = new Hashtable();
            foreach (Symbol symbol in symbolList)
            {
                symbolTable.Add(symbol.SymbolName, symbol);
            }
        }

        /// <summary>
        /// 将token识别的结果添加到相应的表格 
        /// </summary>
        private void add2TokenDataGridView()
        {

            int index = 0;
            for (int i = 0; i < tokenResList.Count; i++)
            {
                index = tokenDataGridView.Rows.Add();
                tokenDataGridView.Rows[index].Cells[0].Value = tokenResList[i].Word;
                tokenDataGridView.Rows[index].Cells[1].Value = tokenResList[i].Token.ToString();
                tokenDataGridView.Rows[index].Cells[2].Value = tokenResList[i].TypeNum;
                tokenDataGridView.Rows[index].Cells[3].Value = tokenResList[i].ClassName;
                tokenDataGridView.Rows[index].Cells[4].Value = tokenResList[i].LineIndex;
            }
        }

        /// <summary>
        /// 将错误识别结果添加到相应的表格
        /// </summary>
        private void add2ErrorDataGridView()
        {
            int index = 0;
            for (int i = 0; i < errorList.Count; i++)
            {
                index = errorDataGridView.Rows.Add();
                errorDataGridView.Rows[index].Cells[0].Value = errorList[i].ErrorType;
                errorDataGridView.Rows[index].Cells[1].Value = errorList[i].ErrorWord;
                errorDataGridView.Rows[index].Cells[2].Value = errorList[i].ErrorLine;
            }
        }

        /// <summary>
        /// 将符号表识别的结果添加到相应的表格
        /// </summary>
        private void add2SymbolDataGridList()
        {
            int index = 0;
            for (int i = 0; i < symbolList.Count; i++)
            {
                index = symbolDataGridView.Rows.Add();
                symbolDataGridView.Rows[index].Cells[0].Value = symbolList[i].MemIndex;
                symbolDataGridView.Rows[index].Cells[1].Value = symbolList[i].SymbolName;
                symbolDataGridView.Rows[index].Cells[2].Value = symbolList[i].LineIndex;
            }
        }
        /// <summary>
        /// 重置按钮处理函数
        /// </summary>
        private void resetButton_Click(object sender, EventArgs e)
        {
            contentRichTextBox.Clear();
            clearDataGridViews();
        }

        /// <summary>
        ///清空dataGridView控件 
        /// </summary>
        private void clearDataGridViews()
        {
            tokenDataGridView.Rows.Clear();
            errorDataGridView.Rows.Clear();
            symbolDataGridView.Rows.Clear();
        }

        /// <summary>
        /// 导入按钮处理函数
        /// </summary>
        private void importButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "C 文件 (*.c)|*.c";
            fd.RestoreDirectory = true;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                string fileName = fd.FileName;
                contentRichTextBox.Text = importFile(fileName);
            }
        }

        /// <summary>
        /// 词法分析菜单项处理函数
        /// </summary>
        private void scannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mainTabControl.SelectedTab = analyseTabPage;
        }

        /// <summary>
        /// 系统说明菜单项处理函数
        /// </summary>
        private void descriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("系统包含：\n1. 词法分析器        \n2. 句法分析器       \n3. 语义分析器\n\n@author: by 刘兆洋");
        }

        /// <summary>
        /// 文法规则菜单项处理函数
        /// </summary>
        private void grammerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mainTabControl.SelectedTab = grammerTabpage;
        }

        /// <summary>
        /// 文法导入按钮处理函数
        /// </summary>
        private void importGramButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "TXT 文件 (*.txt)|*.txt";
            fd.RestoreDirectory = true;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                string fileName = fd.FileName;
                gramContentRichTextBox.Text = importFile(fileName);
            }
        }

        /// <summary>
        /// 文件导入
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <returns>文件内容</returns>
        private string importFile(string fileName)
        {
            string fileContent;
            try
            {
                StreamReader objReader = new StreamReader(fileName);
                fileContent = objReader.ReadToEnd();
                objReader.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("文件打开异常");
                fileContent = "";
            }
            return fileContent;
        }

        /// <summary>
        /// 文法分析按钮处理函数
        /// </summary>
        private void gramAnalyseButton_Click(object sender, EventArgs e)
        {
            grammer = new Grammer();
            gramStr = gramContentRichTextBox.Text;
            isLL1Grammer = grammer.grammerAnalyse(gramStr, out tSymbols, out nSymbols, out nSymbolTable, out productions, 
                out forecastTable, out actionProductions);
            if (isLL1Grammer)
            {
                MessageBox.Show("该文法符合LL(1)文法，终结符个数：" + tSymbols.Count + "； 非终结符个数：" + nSymbols.Count, "Success");
            }
            else
            {
                MessageBox.Show("该文法不符合LL(1)文法", "Fail");
                //return;
            }
            add2TSymbolListBox();
            add2NSymbolListBox();
            add2GramResDataGridView();
        }

        /// <summary>
        /// 将终结符集合添加到listbox
        /// </summary>
        private void add2TSymbolListBox()
        {
            foreach (string str in tSymbols)
            {
                tSymbolListBox.Items.Add(str);
            }
        }

        /// <summary>
        /// 将非终结符集合添加到listbox
        /// </summary>
        private void add2NSymbolListBox()
        {
            foreach (string str in nSymbols)
            {
                nSymbolListBox.Items.Add(str);
            }
        }

        /// <summary>
        /// 将文法规则的分析结果添加到相应表格中
        /// </summary>
        private void add2GramResDataGridView()
        {
            int index;
            string tempStr;
            NonterminalSymbol nonSymbol;
            foreach (Production p in productions)
            {
                tempStr = "";
                index = gramResDataGridView.Rows.Add();
                gramResDataGridView.Rows[index].Cells[0].Value = index;
                gramResDataGridView.Rows[index].Cells[1].Value = p.Left;
                gramResDataGridView.Rows[index].Cells[2].Value = p.ToString();

                //添加select集
                foreach(string str in p.SelectStr)
                {
                    tempStr = tempStr + str + " ";
                }
                gramResDataGridView.Rows[index].Cells[3].Value = tempStr;

                //添加follow集
                tempStr = "";
                nonSymbol = nSymbolTable[p.Left] as NonterminalSymbol;
                foreach(string str in nonSymbol.Follow)
                {
                    tempStr = tempStr + str + " ";
                }
                gramResDataGridView.Rows[index].Cells[4].Value = tempStr;

                //添加first集
                tempStr = "";
                foreach(string str in nonSymbol.First)
                {
                    tempStr = tempStr + str + " ";
                }
                gramResDataGridView.Rows[index].Cells[5].Value = tempStr;
            }
        }

        //文法分析按钮处理函数
        private void senAnalyseButton_Click(object sender, EventArgs e)
        {
            if (productions == null || productions.Count == 0)
            {
                MessageBox.Show("请先到文法规则页面，生成文法规则");
                return;
            }
            else if (tokenResList == null || tokenResList.Count == 0)
            {
                MessageBox.Show("请先进行词法分析");
                return;
            }
            else
            {
                if (!isLL1Grammer)
                {
                    MessageBox.Show("文法规则不符合LL(1)文法，请重新设计文法");
                    return;
                }

                forecastAnalyse();
                SenAnalyseResForm senForm = new SenAnalyseResForm(forecastTable, sentenseResList, grammerErrorList, 
                    threeCodeList, semanicErrorList, symbolList);
                senForm.Show();
            }
        }

        /// <summary>
        /// 预测分析过程处理函数
        /// </summary>
        private void forecastAnalyse()
        {
            int tokenIndex = 0;
            int lineIndex = 0;
            sentenseResList = new List<SentenseResult>();
            grammerErrorList = new List<GrammerError>();
            GrammerError gramError;
            SentenseResult senRes;

            Stack<string> symbolStack = new Stack<string>();
            string forecastKey;
            string inputStr;           
            string actionStr;

            synRecordTable = new Hashtable();
            argsTable = new Hashtable();
            threeCodeList = new List<string>();
            semanicErrorList = new List<SemanicError>();
            argsTable.Add("IDN", new Stack<string>());
            argsTable.Add("const", new Stack<string>());
            argsTable.Add("lineIndex", "");
            argsTable.Add("relop", "");

            symbolStack.Push("@");
            symbolStack.Push("S");
            synRecordTable.Add("S", new SynRecord("S"));
            string symbol = symbolStack.Peek();
            Token token = new Token("@", "_");
            tokenResList.Add(new TokenResult("@", token, -1, null, tokenResList[tokenResList.Count - 1].LineIndex));

            while (!(symbol.Equals("@") || symbol.Equals(""))&& tokenIndex < tokenResList.Count)
            {
                inputStr = tokenResList[tokenIndex].Token.TokenName;
                lineIndex = tokenResList[tokenIndex].LineIndex;
                argsTable["lineIndex"] = lineIndex.ToString();
                forecastKey = symbol + " " + inputStr;
                //匹配，弹栈，输入带指针移动
                if (symbol.Equals(inputStr))
                {
                    senRes = new SentenseResult(lineIndex, symbol, inputStr, "匹配 " + inputStr);
                    sentenseResList.Add(senRes);
                    if (symbol.Equals("IDN"))
                    {
                        Stack<string> IDNStack = argsTable["IDN"] as Stack<string>;
                        IDNStack.Push(tokenResList[tokenIndex].Token.TokenValue);
                    }
                    if (symbol.Equals("INT10"))
                    {
                        Stack<string> constStack = argsTable["const"] as Stack<string>;
                        constStack.Push(tokenResList[tokenIndex].Token.TokenValue);
                    }
                    if (ConstTable.isRelop(symbol))
                    {
                        argsTable["relop"] = symbol;
                    }
                    symbolStack.Pop();
                    tokenIndex++;
                }
                else if (tSymbols.Contains(symbol))
                {
                    //栈顶出现终结符，弹出栈顶元素
                    gramError = new GrammerError(lineIndex, symbol, inputStr, "栈顶出现不匹配的终结符");
                    grammerErrorList.Add(gramError);
                    symbolStack.Pop();
                }
                else if (symbol[0].ToString().Equals("#"))
                {
                    ActionRecord.excuteAction(symbol, synRecordTable, symbolTable, argsTable, threeCodeList, semanicErrorList);
                    symbolStack.Pop();
                }
                else if (nSymbols.Contains(symbol))
                {
                    if (!synRecordTable.Contains(symbol))
                    {
                        synRecordTable.Add(symbol, new SynRecord(symbol));
                    }

                    if (!forecastTable.Contains(forecastKey))
                    {
                        //预测分析表中不存在
                        gramError = new GrammerError(lineIndex, symbol, inputStr, "当前输入符号不在栈顶元素的select集或follow集中");
                        grammerErrorList.Add(gramError);
                        tokenIndex++;
                    }
                    else    
                    {
                        List<string> tempList = forecastTable[forecastKey] as List<string>;
                        if (tempList[0].Equals("synch"))
                        {
                            gramError = new GrammerError(lineIndex, symbol, inputStr, "输入符号为当前栈顶符号的同步记号");
                            grammerErrorList.Add(gramError);
                            symbolStack.Pop();
                        }
                        else if (tempList[0].Equals("$"))
                        {                          
                            //文法符号推空的话，直接弹栈
                            senRes = new SentenseResult(lineIndex, symbol, inputStr, "输出 " + symbol + " -> $");
                            sentenseResList.Add(senRes);
                            symbolStack.Pop();
                            if (tempList.Count > 1)
                            {
                                symbolStack.Push(tempList[1]);
                            }
                        }
                        else
                        {
                            symbolStack.Pop();
                            for (int i = tempList.Count - 1; i >= 0; i--)
                            {
                                symbolStack.Push(tempList[i]);
                            }
                            actionStr = "";
                            foreach (string str in tempList)
                            {
                                actionStr = actionStr + " " + str;
                            }
                            senRes = new SentenseResult(lineIndex, symbol, inputStr, "输出 " + symbol + " -> " + actionStr);
                            sentenseResList.Add(senRes);
                        }
                    }
                }                
                else { }
                symbol = symbolStack.Peek();
            }



            foreach (Symbol s in symbolList)
            {
                Console.WriteLine(s);
            }

            foreach (string str in threeCodeList)
            {
                Console.WriteLine(str);
            }

            //foreach (SentenseResult senResult in sentenseResList)
            //{
            //    Console.WriteLine(senResult);
            //}

            //foreach (GrammerError grammerError in grammerErrorList)
            //{
            //    Console.WriteLine(grammerError);
            //}
        }

    }
}
