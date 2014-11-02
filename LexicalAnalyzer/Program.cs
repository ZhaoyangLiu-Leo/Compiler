using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LexicalAnalyzer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ActionRecord actionRecord = new ActionRecord();
            //actionRecord.excuteAction("act0");
            Application.Run(new MainForm());
        }
    }
}
