using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LexicalAnalyzer
{
    public partial class SenAnalyseResForm : Form
    {
        private Hashtable forecastTable;                    //预测分析表
        private List<SentenseResult> senAnalyseResList;     //句法分析结果
        private List<GrammerError> gramErrorList;           //句法错误
        private List<string> threeCodeList;                 //三地址码
        private List<SemanicError> semanicErrorList;        //错误信息
        private List<Symbol> symbolList;                    //符号表信息list

        public SenAnalyseResForm(Hashtable forecastTable, List<SentenseResult> senAnalyseResList, List<GrammerError> gramErrorList,
            List<string> threeCodeList, List<SemanicError> semanicErrorList, List<Symbol> symbolList)
        {
            InitializeComponent();
            senErrorDataGridView.ForeColor = Color.Red;
            semanicErrorDataGridView.ForeColor = Color.Red;
            this.forecastTable = forecastTable;
            this.senAnalyseResList = senAnalyseResList;
            this.gramErrorList = gramErrorList;
            this.threeCodeList = threeCodeList;
            this.semanicErrorList = semanicErrorList;
            this.symbolList = symbolList;
        }

        private void SenAnalyseRes_Load(object sender, EventArgs e)
        {
            //完善表格信息
            add2forecastTableDataGridView();
            add2senResDataGridView();
            add2senErrorDataGridView();
            add2threeCodeDataGridView();
            add2SymbolDataGridView();
            add2SemanicErrorDataGridView();
        }

        /// <summary>
        /// 将预测分析表添加到相应的表格中
        /// </summary>
        private void add2forecastTableDataGridView()
        {
            string keyStr;
            int index;
            string valueStr;
            List<string> valueList;

            foreach (DictionaryEntry de in forecastTable)
            {
                keyStr = de.Key as string;
                valueList = de.Value as List<string>;
                string[] tempArray = keyStr.Split(' ');
                valueStr = tempArray[0] + " -> ";
                foreach (string str in valueList)
                {
                    valueStr = valueStr + str + " ";
                }
                index = forecastTableDataGridView.Rows.Add();
                forecastTableDataGridView.Rows[index].Cells[0].Value = tempArray[0];
                forecastTableDataGridView.Rows[index].Cells[1].Value = tempArray[1];
                forecastTableDataGridView.Rows[index].Cells[2].Value = valueStr;
            }
        }

        /// <summary>
        /// 将句法分析的匹配信息和产生式调用信息添加到相应的表格中
        /// </summary>
        private void add2senResDataGridView()
        {
            int index;
            foreach(SentenseResult sr in senAnalyseResList)
            {
                index = senResDataGridView.Rows.Add();
                senResDataGridView.Rows[index].Cells[0].Value = sr.LineIndex;
                senResDataGridView.Rows[index].Cells[1].Value = sr.StackStr;
                senResDataGridView.Rows[index].Cells[2].Value = sr.InputStr;
                senResDataGridView.Rows[index].Cells[3].Value = sr.Action;
            }
        }

        /// <summary>
        /// 将句法分析的错误信息添加到相应的表格中
        /// </summary>
        private void add2senErrorDataGridView()
        {
            int index;
            foreach (GrammerError ge in gramErrorList)
            {
                index = senErrorDataGridView.Rows.Add();
                senErrorDataGridView.Rows[index].Cells[0].Value = ge.LineIndex;
                senErrorDataGridView.Rows[index].Cells[1].Value = ge.StackTopStr;
                senErrorDataGridView.Rows[index].Cells[2].Value = ge.TokenStr;
                senErrorDataGridView.Rows[index].Cells[3].Value = ge.ErrorInfo;
            }
        }

        /// <summary>
        /// 将三地址码序列添加到相应的表格中
        /// </summary>
        private void add2threeCodeDataGridView()
        {
            int index;
            string threeCodeStr;

            for (int i = 0; i < threeCodeList.Count; i++)
            {
                threeCodeStr = threeCodeList[i];
                index = threeCodeDataGridView.Rows.Add();
                threeCodeDataGridView.Rows[index].Cells[0].Value = i;
                threeCodeDataGridView.Rows[index].Cells[1].Value = threeCodeStr;
            }
        }

        /// <summary>
        /// 将符号表添加到相应的表格中
        /// </summary>
        private void add2SymbolDataGridView()
        {
            int index;

            foreach (Symbol s in symbolList)
            {
                index = symbolDataGridView.Rows.Add();
                symbolDataGridView.Rows[index].Cells[0].Value = s.MemIndex;
                symbolDataGridView.Rows[index].Cells[1].Value = s.SymbolName;
                symbolDataGridView.Rows[index].Cells[2].Value = s.Type;
                symbolDataGridView.Rows[index].Cells[3].Value = s.Offset;
            }
        }

        /// <summary>
        /// 将语义分析的错误信息添加到相应的表格中
        /// </summary>
        private void add2SemanicErrorDataGridView()
        {
            int index;

            foreach (SemanicError se in semanicErrorList)
            {
                index = semanicErrorDataGridView.Rows.Add();
                semanicErrorDataGridView.Rows[index].Cells[0].Value = se.LineIndex;
                semanicErrorDataGridView.Rows[index].Cells[1].Value = se.ErrorInfo;
            }
        }

    }
}
