namespace LexicalAnalyzer
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.indexRichTextBox = new System.Windows.Forms.RichTextBox();
            this.contentRichTextBox = new System.Windows.Forms.RichTextBox();
            this.resGroupBox = new System.Windows.Forms.GroupBox();
            this.tokenDataGridView = new System.Windows.Forms.DataGridView();
            this.Word = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.token = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.className = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lineIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resetButton = new System.Windows.Forms.Button();
            this.compileButton = new System.Windows.Forms.Button();
            this.codeGroupBox = new System.Windows.Forms.GroupBox();
            this.errorGroupBox = new System.Windows.Forms.GroupBox();
            this.errorDataGridView = new System.Windows.Forms.DataGridView();
            this.errorType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorWord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.symbolGroupBox = new System.Windows.Forms.GroupBox();
            this.symbolDataGridView = new System.Windows.Forms.DataGridView();
            this.importButton = new System.Windows.Forms.Button();
            this.index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.symbolName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.symbolIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tokenDataGridView)).BeginInit();
            this.codeGroupBox.SuspendLayout();
            this.errorGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorDataGridView)).BeginInit();
            this.symbolGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.symbolDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // indexRichTextBox
            // 
            this.indexRichTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.indexRichTextBox.Location = new System.Drawing.Point(9, 20);
            this.indexRichTextBox.Name = "indexRichTextBox";
            this.indexRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.indexRichTextBox.Size = new System.Drawing.Size(33, 306);
            this.indexRichTextBox.TabIndex = 1;
            this.indexRichTextBox.Text = "";
            // 
            // contentRichTextBox
            // 
            this.contentRichTextBox.BackColor = System.Drawing.SystemColors.Desktop;
            this.contentRichTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.contentRichTextBox.Location = new System.Drawing.Point(48, 20);
            this.contentRichTextBox.Name = "contentRichTextBox";
            this.contentRichTextBox.Size = new System.Drawing.Size(501, 306);
            this.contentRichTextBox.TabIndex = 2;
            this.contentRichTextBox.Text = "";
            this.contentRichTextBox.VScroll += new System.EventHandler(this.contentRichTextBox_VScroll);
            this.contentRichTextBox.TextChanged += new System.EventHandler(this.contentRichTextBox_TextChanged);
            // 
            // resGroupBox
            // 
            this.resGroupBox.Controls.Add(this.tokenDataGridView);
            this.resGroupBox.Location = new System.Drawing.Point(669, 33);
            this.resGroupBox.Name = "resGroupBox";
            this.resGroupBox.Size = new System.Drawing.Size(401, 345);
            this.resGroupBox.TabIndex = 3;
            this.resGroupBox.TabStop = false;
            this.resGroupBox.Text = "词法分析结果";
            // 
            // tokenDataGridView
            // 
            this.tokenDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tokenDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Word,
            this.token,
            this.typeNum,
            this.className,
            this.lineIndex});
            this.tokenDataGridView.Location = new System.Drawing.Point(6, 20);
            this.tokenDataGridView.Name = "tokenDataGridView";
            this.tokenDataGridView.RowTemplate.Height = 23;
            this.tokenDataGridView.Size = new System.Drawing.Size(389, 306);
            this.tokenDataGridView.TabIndex = 0;
            // 
            // Word
            // 
            this.Word.HeaderText = "单词";
            this.Word.Name = "Word";
            this.Word.Width = 80;
            // 
            // token
            // 
            this.token.HeaderText = "Token";
            this.token.Name = "token";
            this.token.Width = 80;
            // 
            // typeNum
            // 
            this.typeNum.HeaderText = "种别码";
            this.typeNum.Name = "typeNum";
            this.typeNum.Width = 65;
            // 
            // className
            // 
            this.className.HeaderText = "类别";
            this.className.Name = "className";
            this.className.Width = 80;
            // 
            // lineIndex
            // 
            this.lineIndex.HeaderText = "行号";
            this.lineIndex.Name = "lineIndex";
            this.lineIndex.Width = 60;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(583, 195);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 4;
            this.resetButton.Text = "重置";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // compileButton
            // 
            this.compileButton.Location = new System.Drawing.Point(583, 286);
            this.compileButton.Name = "compileButton";
            this.compileButton.Size = new System.Drawing.Size(75, 23);
            this.compileButton.TabIndex = 5;
            this.compileButton.Text = "编译";
            this.compileButton.UseVisualStyleBackColor = true;
            this.compileButton.Click += new System.EventHandler(this.compileButton_Click);
            // 
            // codeGroupBox
            // 
            this.codeGroupBox.Controls.Add(this.contentRichTextBox);
            this.codeGroupBox.Controls.Add(this.indexRichTextBox);
            this.codeGroupBox.Location = new System.Drawing.Point(12, 33);
            this.codeGroupBox.Name = "codeGroupBox";
            this.codeGroupBox.Size = new System.Drawing.Size(565, 345);
            this.codeGroupBox.TabIndex = 7;
            this.codeGroupBox.TabStop = false;
            this.codeGroupBox.Text = "文本编辑区";
            // 
            // errorGroupBox
            // 
            this.errorGroupBox.Controls.Add(this.errorDataGridView);
            this.errorGroupBox.Location = new System.Drawing.Point(12, 396);
            this.errorGroupBox.Name = "errorGroupBox";
            this.errorGroupBox.Size = new System.Drawing.Size(565, 169);
            this.errorGroupBox.TabIndex = 8;
            this.errorGroupBox.TabStop = false;
            this.errorGroupBox.Text = "错误列表";
            // 
            // errorDataGridView
            // 
            this.errorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.errorDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.errorType,
            this.errorWord,
            this.errorLine});
            this.errorDataGridView.Location = new System.Drawing.Point(9, 20);
            this.errorDataGridView.Name = "errorDataGridView";
            this.errorDataGridView.RowTemplate.Height = 23;
            this.errorDataGridView.Size = new System.Drawing.Size(540, 143);
            this.errorDataGridView.TabIndex = 0;
            // 
            // errorType
            // 
            this.errorType.HeaderText = "错误类型";
            this.errorType.Name = "errorType";
            this.errorType.Width = 200;
            // 
            // errorWord
            // 
            this.errorWord.HeaderText = "错误单词";
            this.errorWord.Name = "errorWord";
            this.errorWord.Width = 150;
            // 
            // errorLine
            // 
            this.errorLine.HeaderText = "错误行";
            this.errorLine.Name = "errorLine";
            this.errorLine.Width = 150;
            // 
            // symbolGroupBox
            // 
            this.symbolGroupBox.Controls.Add(this.symbolDataGridView);
            this.symbolGroupBox.Location = new System.Drawing.Point(669, 396);
            this.symbolGroupBox.Name = "symbolGroupBox";
            this.symbolGroupBox.Size = new System.Drawing.Size(401, 169);
            this.symbolGroupBox.TabIndex = 9;
            this.symbolGroupBox.TabStop = false;
            this.symbolGroupBox.Text = "符号表";
            // 
            // symbolDataGridView
            // 
            this.symbolDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.symbolDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.index,
            this.symbolName,
            this.symbolIndex});
            this.symbolDataGridView.Location = new System.Drawing.Point(26, 20);
            this.symbolDataGridView.Name = "symbolDataGridView";
            this.symbolDataGridView.RowTemplate.Height = 23;
            this.symbolDataGridView.Size = new System.Drawing.Size(369, 143);
            this.symbolDataGridView.TabIndex = 0;
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(583, 104);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(75, 23);
            this.importButton.TabIndex = 10;
            this.importButton.Text = "导入";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // memIndex
            // 
            this.index.HeaderText = "序号";
            this.index.Name = "index";
            // 
            // symbolName
            // 
            this.symbolName.HeaderText = "名称";
            this.symbolName.Name = "symbolName";
            this.symbolName.Width = 120;
            // 
            // symbolIndex
            // 
            this.symbolIndex.HeaderText = "首次出现行号";
            this.symbolIndex.Name = "symbolIndex";
            this.symbolIndex.Width = 110;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 577);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.symbolGroupBox);
            this.Controls.Add(this.errorGroupBox);
            this.Controls.Add(this.codeGroupBox);
            this.Controls.Add(this.compileButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.resGroupBox);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "词法分析器";
            this.resGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tokenDataGridView)).EndInit();
            this.codeGroupBox.ResumeLayout(false);
            this.errorGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorDataGridView)).EndInit();
            this.symbolGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.symbolDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox indexRichTextBox;
        private System.Windows.Forms.RichTextBox contentRichTextBox;
        private System.Windows.Forms.GroupBox resGroupBox;
        private System.Windows.Forms.DataGridView tokenDataGridView;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button compileButton;
        private System.Windows.Forms.GroupBox codeGroupBox;
        private System.Windows.Forms.GroupBox errorGroupBox;
        private System.Windows.Forms.DataGridView errorDataGridView;
        private System.Windows.Forms.GroupBox symbolGroupBox;
        private System.Windows.Forms.DataGridView symbolDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorType;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorWord;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorLine;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Word;
        private System.Windows.Forms.DataGridViewTextBoxColumn token;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn className;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn index;
        private System.Windows.Forms.DataGridViewTextBoxColumn symbolName;
        private System.Windows.Forms.DataGridViewTextBoxColumn symbolIndex;
    }
}

