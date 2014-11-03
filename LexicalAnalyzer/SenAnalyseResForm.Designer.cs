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
            this.lineIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stackStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableGroupBox = new System.Windows.Forms.GroupBox();
            this.resGroupBox = new System.Windows.Forms.GroupBox();
            this.errorGroupBox = new System.Windows.Forms.GroupBox();
            this.senErrorDataGridView = new System.Windows.Forms.DataGridView();
            this.errorLineIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorStackStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorInputStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.analyseResGroupBox = new System.Windows.Forms.GroupBox();
            this.semanicGroupBox = new System.Windows.Forms.GroupBox();
            this.semanicErrorDataGridView = new System.Windows.Forms.DataGridView();
            this.symbolDataGridView = new System.Windows.Forms.DataGridView();
            this.symbolIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.symbolName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.offset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorInfoLabel = new System.Windows.Forms.Label();
            this.symbolLabel = new System.Windows.Forms.Label();
            this.threeCodeLabel = new System.Windows.Forms.Label();
            this.threeCodeDataGridView = new System.Windows.Forms.DataGridView();
            this.index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.threeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.semanicErrorIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.semanicErrorInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.forecastTableDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.senResDataGridView)).BeginInit();
            this.tableGroupBox.SuspendLayout();
            this.resGroupBox.SuspendLayout();
            this.errorGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.senErrorDataGridView)).BeginInit();
            this.analyseResGroupBox.SuspendLayout();
            this.semanicGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.semanicErrorDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.symbolDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.threeCodeDataGridView)).BeginInit();
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
            this.forecastTableDataGridView.Size = new System.Drawing.Size(450, 388);
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
            // tableGroupBox
            // 
            this.tableGroupBox.Controls.Add(this.forecastTableDataGridView);
            this.tableGroupBox.Location = new System.Drawing.Point(27, 12);
            this.tableGroupBox.Name = "tableGroupBox";
            this.tableGroupBox.Size = new System.Drawing.Size(470, 422);
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
            this.resGroupBox.Size = new System.Drawing.Size(476, 422);
            this.resGroupBox.TabIndex = 4;
            this.resGroupBox.TabStop = false;
            this.resGroupBox.Text = "预测分析结果";
            // 
            // errorGroupBox
            // 
            this.errorGroupBox.Controls.Add(this.senErrorDataGridView);
            this.errorGroupBox.Location = new System.Drawing.Point(6, 220);
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
            // semanicGroupBox
            // 
            this.semanicGroupBox.Controls.Add(this.semanicErrorDataGridView);
            this.semanicGroupBox.Controls.Add(this.symbolDataGridView);
            this.semanicGroupBox.Controls.Add(this.errorInfoLabel);
            this.semanicGroupBox.Controls.Add(this.symbolLabel);
            this.semanicGroupBox.Controls.Add(this.threeCodeLabel);
            this.semanicGroupBox.Controls.Add(this.threeCodeDataGridView);
            this.semanicGroupBox.Location = new System.Drawing.Point(27, 440);
            this.semanicGroupBox.Name = "semanicGroupBox";
            this.semanicGroupBox.Size = new System.Drawing.Size(981, 209);
            this.semanicGroupBox.TabIndex = 5;
            this.semanicGroupBox.TabStop = false;
            this.semanicGroupBox.Text = "语义分析结果";
            // 
            // semanicErrorDataGridView
            // 
            this.semanicErrorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.semanicErrorDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.semanicErrorIndex,
            this.semanicErrorInfo});
            this.semanicErrorDataGridView.Location = new System.Drawing.Point(701, 20);
            this.semanicErrorDataGridView.Name = "semanicErrorDataGridView";
            this.semanicErrorDataGridView.RowTemplate.Height = 23;
            this.semanicErrorDataGridView.Size = new System.Drawing.Size(270, 183);
            this.semanicErrorDataGridView.TabIndex = 3;
            // 
            // symbolDataGridView
            // 
            this.symbolDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.symbolDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.symbolIndex,
            this.symbolName,
            this.type,
            this.offset});
            this.symbolDataGridView.Location = new System.Drawing.Point(330, 20);
            this.symbolDataGridView.Name = "symbolDataGridView";
            this.symbolDataGridView.RowTemplate.Height = 23;
            this.symbolDataGridView.Size = new System.Drawing.Size(328, 183);
            this.symbolDataGridView.TabIndex = 2;
            // 
            // symbolIndex
            // 
            this.symbolIndex.HeaderText = "序号";
            this.symbolIndex.Name = "symbolIndex";
            this.symbolIndex.Width = 60;
            // 
            // symbolName
            // 
            this.symbolName.HeaderText = "符号名";
            this.symbolName.Name = "symbolName";
            this.symbolName.Width = 80;
            // 
            // type
            // 
            this.type.HeaderText = "类型";
            this.type.Name = "type";
            // 
            // offset
            // 
            this.offset.HeaderText = "偏移地址";
            this.offset.Name = "offset";
            // 
            // errorInfoLabel
            // 
            this.errorInfoLabel.Location = new System.Drawing.Point(677, 20);
            this.errorInfoLabel.Name = "errorInfoLabel";
            this.errorInfoLabel.Size = new System.Drawing.Size(18, 53);
            this.errorInfoLabel.TabIndex = 1;
            this.errorInfoLabel.Text = "错误信息";
            // 
            // symbolLabel
            // 
            this.symbolLabel.Location = new System.Drawing.Point(306, 20);
            this.symbolLabel.Name = "symbolLabel";
            this.symbolLabel.Size = new System.Drawing.Size(18, 53);
            this.symbolLabel.TabIndex = 1;
            this.symbolLabel.Text = "符号表";
            // 
            // threeCodeLabel
            // 
            this.threeCodeLabel.Location = new System.Drawing.Point(6, 20);
            this.threeCodeLabel.Name = "threeCodeLabel";
            this.threeCodeLabel.Size = new System.Drawing.Size(18, 53);
            this.threeCodeLabel.TabIndex = 1;
            this.threeCodeLabel.Text = "三地址码";
            // 
            // threeCodeDataGridView
            // 
            this.threeCodeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.threeCodeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.index,
            this.threeCode});
            this.threeCodeDataGridView.Location = new System.Drawing.Point(30, 20);
            this.threeCodeDataGridView.Name = "threeCodeDataGridView";
            this.threeCodeDataGridView.RowTemplate.Height = 23;
            this.threeCodeDataGridView.Size = new System.Drawing.Size(270, 183);
            this.threeCodeDataGridView.TabIndex = 0;
            // 
            // index
            // 
            this.index.HeaderText = "序号";
            this.index.Name = "index";
            // 
            // threeCode
            // 
            this.threeCode.HeaderText = "三地址码";
            this.threeCode.Name = "threeCode";
            this.threeCode.Width = 150;
            // 
            // semanicErrorIndex
            // 
            this.semanicErrorIndex.HeaderText = "行号";
            this.semanicErrorIndex.Name = "semanicErrorIndex";
            this.semanicErrorIndex.Width = 60;
            // 
            // semanicErrorInfo
            // 
            this.semanicErrorInfo.HeaderText = "错误信息";
            this.semanicErrorInfo.Name = "semanicErrorInfo";
            this.semanicErrorInfo.Width = 200;
            // 
            // SenAnalyseResForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 661);
            this.Controls.Add(this.semanicGroupBox);
            this.Controls.Add(this.resGroupBox);
            this.Controls.Add(this.tableGroupBox);
            this.Name = "SenAnalyseResForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "语法制导翻译结果";
            this.Load += new System.EventHandler(this.SenAnalyseRes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.forecastTableDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.senResDataGridView)).EndInit();
            this.tableGroupBox.ResumeLayout(false);
            this.resGroupBox.ResumeLayout(false);
            this.errorGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.senErrorDataGridView)).EndInit();
            this.analyseResGroupBox.ResumeLayout(false);
            this.semanicGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.semanicErrorDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.symbolDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.threeCodeDataGridView)).EndInit();
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
        private System.Windows.Forms.GroupBox semanicGroupBox;
        private System.Windows.Forms.DataGridView semanicErrorDataGridView;
        private System.Windows.Forms.DataGridView symbolDataGridView;
        private System.Windows.Forms.Label errorInfoLabel;
        private System.Windows.Forms.Label symbolLabel;
        private System.Windows.Forms.Label threeCodeLabel;
        private System.Windows.Forms.DataGridView threeCodeDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn symbolIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn symbolName;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn offset;
        private System.Windows.Forms.DataGridViewTextBoxColumn index;
        private System.Windows.Forms.DataGridViewTextBoxColumn threeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn semanicErrorIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn semanicErrorInfo;
    }
}