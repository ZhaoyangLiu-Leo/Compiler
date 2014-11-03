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
            this.index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.symbolName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.symbolIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importButton = new System.Windows.Forms.Button();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.grammerTabpage = new System.Windows.Forms.TabPage();
            this.gramResDataGridView = new System.Windows.Forms.DataGridView();
            this.productionIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.left = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productionContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectSet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.followSet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstSet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gramSymbolGroupBox = new System.Windows.Forms.GroupBox();
            this.nSymbolLabel = new System.Windows.Forms.Label();
            this.tSymbolLabel = new System.Windows.Forms.Label();
            this.nSymbolListBox = new System.Windows.Forms.ListBox();
            this.tSymbolListBox = new System.Windows.Forms.ListBox();
            this.gramAnalyseButton = new System.Windows.Forms.Button();
            this.importGramButton = new System.Windows.Forms.Button();
            this.grammerGroupBox = new System.Windows.Forms.GroupBox();
            this.gramContentRichTextBox = new System.Windows.Forms.RichTextBox();
            this.analyseTabPage = new System.Windows.Forms.TabPage();
            this.senAnalyseButton = new System.Windows.Forms.Button();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.发射点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scannerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grammerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tokenDataGridView)).BeginInit();
            this.codeGroupBox.SuspendLayout();
            this.errorGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorDataGridView)).BeginInit();
            this.symbolGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.symbolDataGridView)).BeginInit();
            this.mainTabControl.SuspendLayout();
            this.grammerTabpage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gramResDataGridView)).BeginInit();
            this.gramSymbolGroupBox.SuspendLayout();
            this.grammerGroupBox.SuspendLayout();
            this.analyseTabPage.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // indexRichTextBox
            // 
            this.indexRichTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.indexRichTextBox.Location = new System.Drawing.Point(9, 20);
            this.indexRichTextBox.Name = "indexRichTextBox";
            this.indexRichTextBox.ReadOnly = true;
            this.indexRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.indexRichTextBox.Size = new System.Drawing.Size(33, 306);
            this.indexRichTextBox.TabIndex = 1;
            this.indexRichTextBox.Text = "";
            // 
            // contentRichTextBox
            // 
            this.contentRichTextBox.BackColor = System.Drawing.SystemColors.Desktop;
            this.contentRichTextBox.ForeColor = System.Drawing.Color.Yellow;
            this.contentRichTextBox.Location = new System.Drawing.Point(48, 20);
            this.contentRichTextBox.Name = "contentRichTextBox";
            this.contentRichTextBox.Size = new System.Drawing.Size(501, 306);
            this.contentRichTextBox.TabIndex = 0;
            this.contentRichTextBox.Text = "";
            this.contentRichTextBox.VScroll += new System.EventHandler(this.contentRichTextBox_VScroll);
            this.contentRichTextBox.TextChanged += new System.EventHandler(this.contentRichTextBox_TextChanged);
            // 
            // resGroupBox
            // 
            this.resGroupBox.Controls.Add(this.tokenDataGridView);
            this.resGroupBox.Location = new System.Drawing.Point(694, 16);
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
            this.resetButton.Location = new System.Drawing.Point(586, 136);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(93, 23);
            this.resetButton.TabIndex = 1;
            this.resetButton.Text = "重置";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // compileButton
            // 
            this.compileButton.Location = new System.Drawing.Point(586, 213);
            this.compileButton.Name = "compileButton";
            this.compileButton.Size = new System.Drawing.Size(93, 23);
            this.compileButton.TabIndex = 2;
            this.compileButton.Text = "词法分析";
            this.compileButton.UseVisualStyleBackColor = true;
            this.compileButton.Click += new System.EventHandler(this.compileButton_Click);
            // 
            // codeGroupBox
            // 
            this.codeGroupBox.Controls.Add(this.contentRichTextBox);
            this.codeGroupBox.Controls.Add(this.indexRichTextBox);
            this.codeGroupBox.Location = new System.Drawing.Point(6, 16);
            this.codeGroupBox.Name = "codeGroupBox";
            this.codeGroupBox.Size = new System.Drawing.Size(565, 345);
            this.codeGroupBox.TabIndex = 7;
            this.codeGroupBox.TabStop = false;
            this.codeGroupBox.Text = "文本编辑区";
            // 
            // errorGroupBox
            // 
            this.errorGroupBox.Controls.Add(this.errorDataGridView);
            this.errorGroupBox.Location = new System.Drawing.Point(6, 394);
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
            this.symbolGroupBox.Location = new System.Drawing.Point(694, 394);
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
            this.symbolDataGridView.Location = new System.Drawing.Point(6, 20);
            this.symbolDataGridView.Name = "symbolDataGridView";
            this.symbolDataGridView.RowTemplate.Height = 23;
            this.symbolDataGridView.Size = new System.Drawing.Size(389, 143);
            this.symbolDataGridView.TabIndex = 0;
            // 
            // index
            // 
            this.index.HeaderText = "序号";
            this.index.Name = "index";
            this.index.Width = 120;
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
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(586, 59);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(93, 23);
            this.importButton.TabIndex = 0;
            this.importButton.Text = "导入";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.grammerTabpage);
            this.mainTabControl.Controls.Add(this.analyseTabPage);
            this.mainTabControl.Location = new System.Drawing.Point(12, 27);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(1117, 624);
            this.mainTabControl.TabIndex = 0;
            // 
            // grammerTabpage
            // 
            this.grammerTabpage.Controls.Add(this.gramResDataGridView);
            this.grammerTabpage.Controls.Add(this.gramSymbolGroupBox);
            this.grammerTabpage.Controls.Add(this.gramAnalyseButton);
            this.grammerTabpage.Controls.Add(this.importGramButton);
            this.grammerTabpage.Controls.Add(this.grammerGroupBox);
            this.grammerTabpage.Location = new System.Drawing.Point(4, 22);
            this.grammerTabpage.Name = "grammerTabpage";
            this.grammerTabpage.Padding = new System.Windows.Forms.Padding(3);
            this.grammerTabpage.Size = new System.Drawing.Size(1109, 598);
            this.grammerTabpage.TabIndex = 1;
            this.grammerTabpage.Text = "文法规则";
            this.grammerTabpage.UseVisualStyleBackColor = true;
            // 
            // gramResDataGridView
            // 
            this.gramResDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gramResDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productionIndex,
            this.left,
            this.productionContent,
            this.selectSet,
            this.followSet,
            this.firstSet});
            this.gramResDataGridView.Location = new System.Drawing.Point(24, 312);
            this.gramResDataGridView.Name = "gramResDataGridView";
            this.gramResDataGridView.RowTemplate.Height = 23;
            this.gramResDataGridView.Size = new System.Drawing.Size(1067, 264);
            this.gramResDataGridView.TabIndex = 4;
            // 
            // productionIndex
            // 
            this.productionIndex.HeaderText = "编号";
            this.productionIndex.Name = "productionIndex";
            // 
            // left
            // 
            this.left.HeaderText = "左部";
            this.left.Name = "left";
            // 
            // productionContent
            // 
            this.productionContent.HeaderText = "产生式";
            this.productionContent.Name = "productionContent";
            this.productionContent.Width = 200;
            // 
            // selectSet
            // 
            this.selectSet.HeaderText = "select集合";
            this.selectSet.Name = "selectSet";
            this.selectSet.Width = 210;
            // 
            // followSet
            // 
            this.followSet.HeaderText = "follow集合";
            this.followSet.Name = "followSet";
            this.followSet.Width = 210;
            // 
            // firstSet
            // 
            this.firstSet.HeaderText = "first集合";
            this.firstSet.Name = "firstSet";
            this.firstSet.Width = 210;
            // 
            // gramSymbolGroupBox
            // 
            this.gramSymbolGroupBox.Controls.Add(this.nSymbolLabel);
            this.gramSymbolGroupBox.Controls.Add(this.tSymbolLabel);
            this.gramSymbolGroupBox.Controls.Add(this.nSymbolListBox);
            this.gramSymbolGroupBox.Controls.Add(this.tSymbolListBox);
            this.gramSymbolGroupBox.Location = new System.Drawing.Point(658, 21);
            this.gramSymbolGroupBox.Name = "gramSymbolGroupBox";
            this.gramSymbolGroupBox.Size = new System.Drawing.Size(433, 271);
            this.gramSymbolGroupBox.TabIndex = 3;
            this.gramSymbolGroupBox.TabStop = false;
            this.gramSymbolGroupBox.Text = "文法符号";
            // 
            // nSymbolLabel
            // 
            this.nSymbolLabel.AutoSize = true;
            this.nSymbolLabel.Location = new System.Drawing.Point(218, 23);
            this.nSymbolLabel.Name = "nSymbolLabel";
            this.nSymbolLabel.Size = new System.Drawing.Size(65, 12);
            this.nSymbolLabel.TabIndex = 1;
            this.nSymbolLabel.Text = "非终结符：";
            // 
            // tSymbolLabel
            // 
            this.tSymbolLabel.AutoSize = true;
            this.tSymbolLabel.Location = new System.Drawing.Point(6, 23);
            this.tSymbolLabel.Name = "tSymbolLabel";
            this.tSymbolLabel.Size = new System.Drawing.Size(53, 12);
            this.tSymbolLabel.TabIndex = 1;
            this.tSymbolLabel.Text = "终结符：";
            // 
            // nSymbolListBox
            // 
            this.nSymbolListBox.BackColor = System.Drawing.SystemColors.Window;
            this.nSymbolListBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.nSymbolListBox.FormattingEnabled = true;
            this.nSymbolListBox.ItemHeight = 12;
            this.nSymbolListBox.Location = new System.Drawing.Point(289, 20);
            this.nSymbolListBox.Name = "nSymbolListBox";
            this.nSymbolListBox.Size = new System.Drawing.Size(130, 244);
            this.nSymbolListBox.TabIndex = 0;
            // 
            // tSymbolListBox
            // 
            this.tSymbolListBox.BackColor = System.Drawing.SystemColors.Window;
            this.tSymbolListBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tSymbolListBox.FormattingEnabled = true;
            this.tSymbolListBox.ItemHeight = 12;
            this.tSymbolListBox.Location = new System.Drawing.Point(60, 20);
            this.tSymbolListBox.Name = "tSymbolListBox";
            this.tSymbolListBox.Size = new System.Drawing.Size(130, 244);
            this.tSymbolListBox.TabIndex = 0;
            // 
            // gramAnalyseButton
            // 
            this.gramAnalyseButton.Location = new System.Drawing.Point(554, 164);
            this.gramAnalyseButton.Name = "gramAnalyseButton";
            this.gramAnalyseButton.Size = new System.Drawing.Size(75, 23);
            this.gramAnalyseButton.TabIndex = 2;
            this.gramAnalyseButton.Text = "文法分析";
            this.gramAnalyseButton.UseVisualStyleBackColor = true;
            this.gramAnalyseButton.Click += new System.EventHandler(this.gramAnalyseButton_Click);
            // 
            // importGramButton
            // 
            this.importGramButton.Location = new System.Drawing.Point(554, 94);
            this.importGramButton.Name = "importGramButton";
            this.importGramButton.Size = new System.Drawing.Size(75, 23);
            this.importGramButton.TabIndex = 1;
            this.importGramButton.Text = "文法导入";
            this.importGramButton.UseVisualStyleBackColor = true;
            this.importGramButton.Click += new System.EventHandler(this.importGramButton_Click);
            // 
            // grammerGroupBox
            // 
            this.grammerGroupBox.Controls.Add(this.gramContentRichTextBox);
            this.grammerGroupBox.Location = new System.Drawing.Point(24, 21);
            this.grammerGroupBox.Name = "grammerGroupBox";
            this.grammerGroupBox.Size = new System.Drawing.Size(494, 271);
            this.grammerGroupBox.TabIndex = 0;
            this.grammerGroupBox.TabStop = false;
            this.grammerGroupBox.Text = "文法定义";
            // 
            // gramContentRichTextBox
            // 
            this.gramContentRichTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.gramContentRichTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gramContentRichTextBox.Location = new System.Drawing.Point(6, 20);
            this.gramContentRichTextBox.Name = "gramContentRichTextBox";
            this.gramContentRichTextBox.Size = new System.Drawing.Size(475, 245);
            this.gramContentRichTextBox.TabIndex = 0;
            this.gramContentRichTextBox.Text = "";
            // 
            // analyseTabPage
            // 
            this.analyseTabPage.Controls.Add(this.senAnalyseButton);
            this.analyseTabPage.Controls.Add(this.compileButton);
            this.analyseTabPage.Controls.Add(this.symbolGroupBox);
            this.analyseTabPage.Controls.Add(this.importButton);
            this.analyseTabPage.Controls.Add(this.errorGroupBox);
            this.analyseTabPage.Controls.Add(this.resetButton);
            this.analyseTabPage.Controls.Add(this.resGroupBox);
            this.analyseTabPage.Controls.Add(this.codeGroupBox);
            this.analyseTabPage.Location = new System.Drawing.Point(4, 22);
            this.analyseTabPage.Name = "analyseTabPage";
            this.analyseTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.analyseTabPage.Size = new System.Drawing.Size(1109, 598);
            this.analyseTabPage.TabIndex = 0;
            this.analyseTabPage.Text = "主面板";
            this.analyseTabPage.UseVisualStyleBackColor = true;
            // 
            // senAnalyseButton
            // 
            this.senAnalyseButton.Location = new System.Drawing.Point(586, 290);
            this.senAnalyseButton.Name = "senAnalyseButton";
            this.senAnalyseButton.Size = new System.Drawing.Size(93, 23);
            this.senAnalyseButton.TabIndex = 10;
            this.senAnalyseButton.Text = "语法制导翻译";
            this.senAnalyseButton.UseVisualStyleBackColor = true;
            this.senAnalyseButton.Click += new System.EventHandler(this.senAnalyseButton_Click);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.发射点ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1141, 24);
            this.mainMenuStrip.TabIndex = 1;
            this.mainMenuStrip.Text = "菜单";
            // 
            // 发射点ToolStripMenuItem
            // 
            this.发射点ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scannerToolStripMenuItem,
            this.grammerToolStripMenuItem});
            this.发射点ToolStripMenuItem.Name = "发射点ToolStripMenuItem";
            this.发射点ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.发射点ToolStripMenuItem.Text = "操作";
            // 
            // scannerToolStripMenuItem
            // 
            this.scannerToolStripMenuItem.Name = "scannerToolStripMenuItem";
            this.scannerToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.scannerToolStripMenuItem.Text = "词法分析";
            this.scannerToolStripMenuItem.Click += new System.EventHandler(this.scannerToolStripMenuItem_Click);
            // 
            // grammerToolStripMenuItem
            // 
            this.grammerToolStripMenuItem.Name = "grammerToolStripMenuItem";
            this.grammerToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.grammerToolStripMenuItem.Text = "文法规则";
            this.grammerToolStripMenuItem.Click += new System.EventHandler(this.grammerToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.descriptionToolStripMenuItem});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // descriptionToolStripMenuItem
            // 
            this.descriptionToolStripMenuItem.Name = "descriptionToolStripMenuItem";
            this.descriptionToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.descriptionToolStripMenuItem.Text = "系统说明";
            this.descriptionToolStripMenuItem.Click += new System.EventHandler(this.descriptionToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 660);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主界面";
            this.resGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tokenDataGridView)).EndInit();
            this.codeGroupBox.ResumeLayout(false);
            this.errorGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorDataGridView)).EndInit();
            this.symbolGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.symbolDataGridView)).EndInit();
            this.mainTabControl.ResumeLayout(false);
            this.grammerTabpage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gramResDataGridView)).EndInit();
            this.gramSymbolGroupBox.ResumeLayout(false);
            this.gramSymbolGroupBox.PerformLayout();
            this.grammerGroupBox.ResumeLayout(false);
            this.analyseTabPage.ResumeLayout(false);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage analyseTabPage;
        private System.Windows.Forms.TabPage grammerTabpage;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 发射点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scannerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grammerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descriptionToolStripMenuItem;
        private System.Windows.Forms.GroupBox grammerGroupBox;
        private System.Windows.Forms.RichTextBox gramContentRichTextBox;
        private System.Windows.Forms.Button importGramButton;
        private System.Windows.Forms.Button gramAnalyseButton;
        private System.Windows.Forms.GroupBox gramSymbolGroupBox;
        private System.Windows.Forms.Label tSymbolLabel;
        private System.Windows.Forms.ListBox tSymbolListBox;
        private System.Windows.Forms.Label nSymbolLabel;
        private System.Windows.Forms.ListBox nSymbolListBox;
        private System.Windows.Forms.DataGridView gramResDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn productionIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn left;
        private System.Windows.Forms.DataGridViewTextBoxColumn productionContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn selectSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn followSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstSet;
        private System.Windows.Forms.Button senAnalyseButton;
    }
}

