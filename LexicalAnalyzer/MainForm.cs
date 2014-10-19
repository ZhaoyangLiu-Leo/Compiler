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
        private string codeStr;
        private string gramStr = "";
        private List<TokenResult> tokenResList;
        private List<Error> errorList;
        private List<Symbol> symbolList;
        private HashSet<string> tSymbols;
        private HashSet<string> nSymbols;
        private List<Production> productions;
        private Hashtable nSymbolTable;
        private List<SentenseResult> sentenseResList;
        private Hashtable forecastTable;
        private bool isLL1Grammer;
        private List<GrammerError> grammerErrorList;
        private Grammer grammer;

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

            Console.WriteLine("LastLine:" + lastLine);

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
            this.mainTabControl.SelectedTab = scannerTabPage;
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
            isLL1Grammer = grammer.grammerAnalyse(gramStr, out tSymbols, out nSymbols, out nSymbolTable, out productions, out forecastTable);
            if (isLL1Grammer)
            {
                MessageBox.Show("该文法符合LL(1)文法，终结符个数：" + tSymbols.Count + "； 非终结符个数：" + nSymbols.Count, "Success");
            }
            else
            {
                MessageBox.Show("该文法不符合LL(1)文法", "Fail");
                return;
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
            if (productions.Count == 0)
            {
                MessageBox.Show("请先到文法规则页面，生成文法规则");
                mainTabControl.SelectedTab = grammerTabpage;
                return;
            }
            else if (tokenResList.Count == 0)
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
                SenAnalyseResForm senForm = new SenAnalyseResForm(forecastTable, sentenseResList, grammerErrorList);
                senForm.Show();
            }
        }

        private void forecastAnalyse()
        {
            int tokenIndex = 0;
            sentenseResList = new List<SentenseResult>();
            grammerErrorList = new List<GrammerError>();
            GrammerError gramError;
            SentenseResult senRes;

            Stack<string> symbolStack = new Stack<string>();
            string forecastKey;
            string inputStr;
            List<string> tempList;
            string actionStr;

            symbolStack.Push("@");
            symbolStack.Push("S");
            string symbol = symbolStack.Peek();
            Token token = new Token("@", "_");
            tokenResList.Add(new TokenResult("@", token, -1, null, -1));

            while (!symbol.Equals("@") && tokenIndex < tokenResList.Count)
            {
                inputStr = tokenResList[tokenIndex].Token.TokenName;
                forecastKey = symbol + " " + inputStr;
                if (symbol.Equals(inputStr))
                {
                    senRes = new SentenseResult(symbol, inputStr, "匹配 " + inputStr);
                    sentenseResList.Add(senRes);
                    symbolStack.Pop();
                    tokenIndex++;
                }
                else if (tSymbols.Contains(symbol))
                {
                    gramError = new GrammerError(symbol, inputStr, "栈顶出现不匹配的终结符");
                    grammerErrorList.Add(gramError);
                    symbolStack.Pop();
                }
                else if (!forecastTable.Contains(forecastKey))
                {
                    //if (grammer.isLeadNull(symbol))
                    //{
                    //    symbolStack.Pop();
                    //}
                    //else
                    //{
                        gramError = new GrammerError(symbol, inputStr, "当前输入符号不在栈顶元素的select集或follow集中");
                        grammerErrorList.Add(gramError);
                        tokenIndex++;
                    //}
                }
                else if (forecastTable.Contains(forecastKey))
                {
                    tempList = forecastTable[forecastKey] as List<string>;
                    if (tempList[0].Equals("synch"))
                    {
                        gramError = new GrammerError(symbol, inputStr, "当前输入符号不在栈顶元素的select集中但在follow集中");
                        grammerErrorList.Add(gramError);
                        symbolStack.Pop();
                    }
                    else if (tempList[0].Equals("$"))
                    {
                        senRes = new SentenseResult(symbol, inputStr, "输出 " + symbol + " -> $");
                        sentenseResList.Add(senRes);
                        symbolStack.Pop();
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
                        senRes = new SentenseResult(symbol, inputStr, "输出 " + symbol + " -> " + actionStr);
                        sentenseResList.Add(senRes);
                    }
                }
                else { }
                symbol = symbolStack.Peek();
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
