namespace LexicalAnalyzer
{
    partial class SenAnalyseResForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.forecastTableDataGridView = new System.Windows.Forms.DataGridView();
            this.nSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.symbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.production = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.senResDataGridView = new System.Windows.Forms.DataGridView();
            this.tableGroupBox = new System.Windows.Forms.GroupBox();
            this.resGroupBox = new System.Windows.Forms.GroupBox();
            this.errorGroupBox = new System.Windows.Forms.GroupBox();
            this.senErrorDataGridView = new System.Windows.Forms.DataGridView();
            this.analyseResGroupBox = new System.Windows.Forms.GroupBox();
            this.errorLineIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorStackStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorInputStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lineIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stackStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.forecastTableDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.senResDataGridView)).BeginInit();
            this.tableGroupBox.SuspendLayout();
            this.resGroupBox.SuspendLayout();
            this.errorGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.senErrorDataGridView)).BeginInit();
            this.analyseResGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // forecastTableDataGridView
            // 
            this.forecastTableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.forecastTableDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nSymbol,
            this.symbol,
            this.production});
            this.forecastTableDataGridView.Location = new System.Drawing.Point(6, 20);
            this.forecastTableDataGridView.Name = "forecastTableDataGridView";
            this.forecastTableDataGridView.RowTemplate.Height = 23;
            this.forecastTableDataGridView.Size = new System.Drawing.Size(450, 409);
            this.forecastTableDataGridView.TabIndex = 0;
            // 
            // nSymbol
            // 
            this.nSymbol.HeaderText = "非终结符";
            this.nSymbol.Name = "nSymbol";
            this.nSymbol.Width = 80;
            // 
            // symbol
            // 
            this.symbol.HeaderText = "文法符号";
            this.symbol.Name = "symbol";
            this.symbol.Width = 80;
            // 
            // production
            // 
            this.production.HeaderText = "产生式";
            this.production.Name = "production";
            this.production.Width = 300;
            // 
            // senResDataGridView
            // 
            this.senResDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.senResDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lineIndex,
            this.stackStr,
            this.inputStr,
            this.action});
            this.senResDataGridView.Location = new System.Drawing.Point(17, 20);
            this.senResDataGridView.Name = "senResDataGridView";
            this.senResDataGridView.RowTemplate.Height = 23;
            this.senResDataGridView.Size = new System.Drawing.Size(434, 168);
            this.senResDataGridView.TabIndex = 2;
            // 
            // tableGroupBox
            // 
            this.tableGroupBox.Controls.Add(this.forecastTableDataGridView);
            this.tableGroupBox.Location = new System.Drawing.Point(27, 12);
            this.tableGroupBox.Name = "tableGroupBox";
            this.tableGroupBox.Size = new System.Drawing.Size(470, 442);
            this.tableGroupBox.TabIndex = 3;
            this.tableGroupBox.TabStop = false;
            this.tableGroupBox.Text = "预测分析表";
            // 
            // resGroupBox
            // 
            this.resGroupBox.Controls.Add(this.errorGroupBox);
            this.resGroupBox.Controls.Add(this.analyseResGroupBox);
            this.resGroupBox.Location = new System.Drawing.Point(532, 12);
            this.resGroupBox.Name = "resGroupBox";
            this.resGroupBox.Size = new System.Drawing.Size(476, 442);
            this.resGroupBox.TabIndex = 4;
            this.resGroupBox.TabStop = false;
            this.resGroupBox.Text = "预测分析结果";
            // 
            // errorGroupBox
            // 
            this.errorGroupBox.Controls.Add(this.senErrorDataGridView);
            this.errorGroupBox.Location = new System.Drawing.Point(6, 235);
            this.errorGroupBox.Name = "errorGroupBox";
            this.errorGroupBox.Size = new System.Drawing.Size(462, 194);
            this.errorGroupBox.TabIndex = 3;
            this.errorGroupBox.TabStop = false;
            this.errorGroupBox.Text = "错误信息";
            // 
            // senErrorDataGridView
            // 
            this.senErrorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.senErrorDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.errorLineIndex,
            this.errorStackStr,
            this.errorInputStr,
            this.errorInfo});
            this.senErrorDataGridView.Location = new System.Drawing.Point(17, 20);
            this.senErrorDataGridView.Name = "senErrorDataGridView";
            this.senErrorDataGridView.RowTemplate.Height = 23;
            this.senErrorDataGridView.Size = new System.Drawing.Size(434, 168);
            this.senErrorDataGridView.TabIndex = 2;
            // 
            // analyseResGroupBox
            // 
            this.analyseResGroupBox.Controls.Add(this.senResDataGridView);
            this.analyseResGroupBox.Location = new System.Drawing.Point(6, 20);
            this.analyseResGroupBox.Name = "analyseResGroupBox";
            this.analyseResGroupBox.Size = new System.Drawing.Size(462, 194);
            this.analyseResGroupBox.TabIndex = 3;
            this.analyseResGroupBox.TabStop = false;
            this.analyseResGroupBox.Text = "调用过程";
            // 
            // errorLineIndex
            // 
            this.errorLineIndex.HeaderText = "错误行号";
            this.errorLineIndex.Name = "errorLineIndex";
            this.errorLineIndex.Width = 80;
            // 
            // errorStackStr
            // 
            this.errorStackStr.HeaderText = "栈顶符号";
            this.errorStackStr.Name = "errorStackStr";
            this.errorStackStr.Width = 80;
            // 
            // errorInputStr
            // 
            this.errorInputStr.HeaderText = "输入符号";
            this.errorInputStr.Name = "errorInputStr";
            this.errorInputStr.Width = 80;
            // 
            // errorInfo
            // 
            this.errorInfo.HeaderText = "错误信息";
            this.errorInfo.Name = "errorInfo";
            this.errorInfo.Width = 200;
            // 
            // lineIndex
            // 
            this.lineIndex.HeaderText = "行号";
            this.lineIndex.Name = "lineIndex";
            this.lineIndex.Width = 80;
            // 
            // stackStr
            // 
            this.stackStr.HeaderText = "栈顶信息";
            this.stackStr.Name = "stackStr";
            this.stackStr.Width = 80;
            // 
            // inputStr
            // 
            this.inputStr.HeaderText = "输入符号";
            this.inputStr.Name = "inputStr";
            this.inputStr.Width = 80;
            // 
            // action
            // 
            this.action.HeaderText = "动作";
            this.action.Name = "action";
            this.action.Width = 200;
            // 
            // SenAnalyseResForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 466);
            this.Controls.Add(this.resGroupBox);
            this.Controls.Add(this.tableGroupBox);
            this.Name = "SenAnalyseResForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "句法分析结果";
            this.Load += new System.EventHandler(this.SenAnalyseRes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.forecastTableDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.senResDataGridView)).EndInit();
            this.tableGroupBox.ResumeLayout(false);
            this.resGroupBox.ResumeLayout(false);
            this.errorGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.senErrorDataGridView)).EndInit();
            this.analyseResGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView forecastTableDataGridView;
        private System.Windows.Forms.DataGridView senResDataGridView;
        private System.Windows.Forms.GroupBox tableGroupBox;
        private System.Windows.Forms.GroupBox resGroupBox;
        private System.Windows.Forms.GroupBox errorGroupBox;
        private System.Windows.Forms.DataGridView senErrorDataGridView;
        private System.Windows.Forms.GroupBox analyseResGroupBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn nSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn symbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn production;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorLineIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorStackStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorInputStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn stackStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn action;
    }
}