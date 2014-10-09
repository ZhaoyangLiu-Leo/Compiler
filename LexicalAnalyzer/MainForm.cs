using System;
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
        private List<TokenResult> tokenResList;
        private List<Error> errorList;
        private List<Symbol> symbolList;
        
        public MainForm()
        {
            InitializeComponent();
            indexRichTextBox.Text = "1";
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
            //for (int i = 0; i < tokenResList.Count; i++)
            //{
            //    Console.WriteLine(tokenResList[i]);
            //}
            //Console.WriteLine("*************************************");
            //for (int i = 0; i < symbolList.Count; i++)
            //{
            //    Console.WriteLine(symbolList[i]);
            //}
            //Console.WriteLine("*************************************");
            //for (int i = 0; i < errorList.Count; i++)
            //{
            //    Console.WriteLine(errorList[i]);
            //}
            this.add2TokenDataGridView();
            this.add2ErrorDataGridView();
            this.add2SymbolDataGridList();
        }

        private void add2TokenDataGridView()
        {

            int index = 0;
            for (int i = 0; i < tokenResList.Count; i++)
            {
                index = tokenDataGridView.Rows.Add();

                tokenDataGridView.Rows[index].Cells[0].Value = tokenResList[i].Token.ToString();
                tokenDataGridView.Rows[index].Cells[1].Value = tokenResList[i].TypeNum;
                tokenDataGridView.Rows[index].Cells[2].Value = tokenResList[i].ClassName;
                tokenDataGridView.Rows[index].Cells[3].Value = tokenResList[i].LineIndex;
            }
        }

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
            string fileName = "";
            
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "C 文件 (*.c)|*.c";
            fd.RestoreDirectory = true;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                fileName = fd.FileName;
                try
                {
                    StreamReader objReader = new StreamReader(fileName);
                    string programCode = objReader.ReadToEnd();
                    contentRichTextBox.Text = programCode;
                }
                catch (IOException ex)
                {
                    MessageBox.Show("文件打开异常");
                    return;
                }
            }

        }
        
    }
}
