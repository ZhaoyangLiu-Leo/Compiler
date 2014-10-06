using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            Point pos = new Point(0, 0);
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
            codeStr = contentRichTextBox.Text;
            Scanner scanner = new Scanner();
            scanner.analyzeCode(codeStr, out tokenResList, out errorList, out symbolList);
            for (int i = 0; i < tokenResList.Count; i++)
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
            }
        }
        
        
    }
}
