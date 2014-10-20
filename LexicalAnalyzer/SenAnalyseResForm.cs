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

        public SenAnalyseResForm(Hashtable forecastTable, List<SentenseResult> senAnalyseResList, List<GrammerError> gramErrorList)
        {
            InitializeComponent();
            senErrorDataGridView.ForeColor = Color.Red;
            this.forecastTable = forecastTable;
            this.senAnalyseResList = senAnalyseResList;
            this.gramErrorList = gramErrorList;
        }

        private void SenAnalyseRes_Load(object sender, EventArgs e)
        {
            //完善表格信息
            add2forecastTableDataGridView();
            add2senResDataGridView();
            add2senErrorDataGridView();
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
    }
}
