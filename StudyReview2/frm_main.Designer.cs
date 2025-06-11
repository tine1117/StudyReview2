namespace StudyReview2
{
    partial class frm_start
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            groupBox1 = new GroupBox();
            listview_subtitle = new ListView();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            contextMenuStrip2 = new ContextMenuStrip(components);
            studyAddToolStripMenuItem = new ToolStripMenuItem();
            studyEditToolStripMenuItem = new ToolStripMenuItem();
            studyDeleteToolStripMenuItem = new ToolStripMenuItem();
            listview_maintitle = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            contextMenuStrip1 = new ContextMenuStrip(components);
            groupAddToolStripMenuItem = new ToolStripMenuItem();
            groupDeleteToolStripMenuItem = new ToolStripMenuItem();
            groupBox2 = new GroupBox();
            txt_totalCount = new Label();
            txt_select = new Label();
            btn_start = new Button();
            check_wrong = new CheckBox();
            txt_count = new TextBox();
            txt_cb2 = new ComboBox();
            txt_cb1 = new ComboBox();
            cb3 = new CheckBox();
            cb2 = new CheckBox();
            cb1 = new CheckBox();
            groupBox1.SuspendLayout();
            contextMenuStrip2.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listview_subtitle);
            groupBox1.Controls.Add(listview_maintitle);
            groupBox1.Location = new Point(9, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(562, 353);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // listview_subtitle
            // 
            listview_subtitle.CheckBoxes = true;
            listview_subtitle.Columns.AddRange(new ColumnHeader[] { columnHeader3, columnHeader4, columnHeader5, columnHeader6 });
            listview_subtitle.ContextMenuStrip = contextMenuStrip2;
            listview_subtitle.GridLines = true;
            listview_subtitle.Location = new Point(247, 12);
            listview_subtitle.Name = "listview_subtitle";
            listview_subtitle.Size = new Size(310, 335);
            listview_subtitle.TabIndex = 1;
            listview_subtitle.UseCompatibleStateImageBehavior = false;
            listview_subtitle.View = View.Details;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "";
            columnHeader3.Width = 25;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Subtitle";
            columnHeader4.TextAlign = HorizontalAlignment.Center;
            columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Item";
            columnHeader5.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Last Time";
            columnHeader6.Width = 70;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Items.AddRange(new ToolStripItem[] { studyAddToolStripMenuItem, studyEditToolStripMenuItem, studyDeleteToolStripMenuItem });
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(144, 70);
            // 
            // studyAddToolStripMenuItem
            // 
            studyAddToolStripMenuItem.Name = "studyAddToolStripMenuItem";
            studyAddToolStripMenuItem.Size = new Size(143, 22);
            studyAddToolStripMenuItem.Text = "Study Add";
            studyAddToolStripMenuItem.Click += studyAddToolStripMenuItem_Click;
            // 
            // studyEditToolStripMenuItem
            // 
            studyEditToolStripMenuItem.Name = "studyEditToolStripMenuItem";
            studyEditToolStripMenuItem.Size = new Size(143, 22);
            studyEditToolStripMenuItem.Text = "Study Edit";
            studyEditToolStripMenuItem.Click += studyEditToolStripMenuItem_Click;
            // 
            // studyDeleteToolStripMenuItem
            // 
            studyDeleteToolStripMenuItem.Name = "studyDeleteToolStripMenuItem";
            studyDeleteToolStripMenuItem.Size = new Size(143, 22);
            studyDeleteToolStripMenuItem.Text = "Study Delete";
            studyDeleteToolStripMenuItem.Click += studyDeleteToolStripMenuItem_Click;
            // 
            // listview_maintitle
            // 
            listview_maintitle.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            listview_maintitle.ContextMenuStrip = contextMenuStrip1;
            listview_maintitle.GridLines = true;
            listview_maintitle.Location = new Point(5, 12);
            listview_maintitle.Name = "listview_maintitle";
            listview_maintitle.Size = new Size(237, 335);
            listview_maintitle.TabIndex = 0;
            listview_maintitle.UseCompatibleStateImageBehavior = false;
            listview_maintitle.View = View.Details;
            listview_maintitle.MouseDoubleClick += listview_maintitle_MouseDoubleClick;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Main Title";
            columnHeader1.Width = 172;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Item";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { groupAddToolStripMenuItem, groupDeleteToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(146, 48);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // groupAddToolStripMenuItem
            // 
            groupAddToolStripMenuItem.Name = "groupAddToolStripMenuItem";
            groupAddToolStripMenuItem.Size = new Size(145, 22);
            groupAddToolStripMenuItem.Text = "Group Add";
            groupAddToolStripMenuItem.Click += groupAddToolStripMenuItem_Click;
            // 
            // groupDeleteToolStripMenuItem
            // 
            groupDeleteToolStripMenuItem.Name = "groupDeleteToolStripMenuItem";
            groupDeleteToolStripMenuItem.Size = new Size(145, 22);
            groupDeleteToolStripMenuItem.Text = "Group Delete";
            groupDeleteToolStripMenuItem.Click += groupDeleteToolStripMenuItem_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txt_totalCount);
            groupBox2.Controls.Add(txt_select);
            groupBox2.Controls.Add(btn_start);
            groupBox2.Controls.Add(check_wrong);
            groupBox2.Controls.Add(txt_count);
            groupBox2.Controls.Add(txt_cb2);
            groupBox2.Controls.Add(txt_cb1);
            groupBox2.Controls.Add(cb3);
            groupBox2.Controls.Add(cb2);
            groupBox2.Controls.Add(cb1);
            groupBox2.Location = new Point(576, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(221, 353);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            // 
            // txt_totalCount
            // 
            txt_totalCount.AutoSize = true;
            txt_totalCount.Location = new Point(6, 282);
            txt_totalCount.Name = "txt_totalCount";
            txt_totalCount.Size = new Size(116, 15);
            txt_totalCount.TabIndex = 8;
            txt_totalCount.Text = "Total Item Count : 0";
            // 
            // txt_select
            // 
            txt_select.AutoSize = true;
            txt_select.Location = new Point(5, 265);
            txt_select.Name = "txt_select";
            txt_select.Size = new Size(102, 15);
            txt_select.TabIndex = 2;
            txt_select.Text = "Select Subtitle : 0";
            // 
            // btn_start
            // 
            btn_start.Location = new Point(6, 304);
            btn_start.Name = "btn_start";
            btn_start.Size = new Size(209, 43);
            btn_start.TabIndex = 7;
            btn_start.Text = "Let's Start !";
            btn_start.UseVisualStyleBackColor = true;
            btn_start.Click += btn_start_Click;
            // 
            // check_wrong
            // 
            check_wrong.AutoSize = true;
            check_wrong.Checked = true;
            check_wrong.CheckState = CheckState.Checked;
            check_wrong.Location = new Point(8, 245);
            check_wrong.Name = "check_wrong";
            check_wrong.Size = new Size(112, 19);
            check_wrong.TabIndex = 2;
            check_wrong.Text = "Retry the wrong";
            check_wrong.UseVisualStyleBackColor = true;
            // 
            // txt_count
            // 
            txt_count.Location = new Point(85, 77);
            txt_count.Name = "txt_count";
            txt_count.Size = new Size(120, 23);
            txt_count.TabIndex = 2;
            txt_count.Text = "100";
            // 
            // txt_cb2
            // 
            txt_cb2.DropDownStyle = ComboBoxStyle.DropDownList;
            txt_cb2.FormattingEnabled = true;
            txt_cb2.Items.AddRange(new object[] { "전체풀기", "선택풀기" });
            txt_cb2.Location = new Point(85, 49);
            txt_cb2.Name = "txt_cb2";
            txt_cb2.Size = new Size(120, 23);
            txt_cb2.TabIndex = 6;
            // 
            // txt_cb1
            // 
            txt_cb1.DropDownStyle = ComboBoxStyle.DropDownList;
            txt_cb1.FormattingEnabled = true;
            txt_cb1.Items.AddRange(new object[] { "Random", "Sequential" });
            txt_cb1.Location = new Point(85, 22);
            txt_cb1.Name = "txt_cb1";
            txt_cb1.Size = new Size(120, 23);
            txt_cb1.TabIndex = 5;
            // 
            // cb3
            // 
            cb3.AutoSize = true;
            cb3.Location = new Point(14, 60);
            cb3.Name = "cb3";
            cb3.Size = new Size(62, 19);
            cb3.TabIndex = 4;
            cb3.Text = "객관식";
            cb3.UseVisualStyleBackColor = true;
            // 
            // cb2
            // 
            cb2.AutoSize = true;
            cb2.Checked = true;
            cb2.CheckState = CheckState.Checked;
            cb2.Location = new Point(14, 41);
            cb2.Name = "cb2";
            cb2.Size = new Size(62, 19);
            cb2.TabIndex = 3;
            cb2.Text = "다관식";
            cb2.UseVisualStyleBackColor = true;
            // 
            // cb1
            // 
            cb1.AutoSize = true;
            cb1.Checked = true;
            cb1.CheckState = CheckState.Checked;
            cb1.Location = new Point(14, 22);
            cb1.Name = "cb1";
            cb1.Size = new Size(62, 19);
            cb1.TabIndex = 2;
            cb1.Text = "단답식";
            cb1.UseVisualStyleBackColor = true;
            // 
            // frm_start
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(807, 357);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Location = new Point(8, -1);
            Name = "frm_start";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StudyReview 2";
            FormClosed += frm_start_FormClosed;
            Load += frm_start_Load;
            groupBox1.ResumeLayout(false);
            contextMenuStrip2.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ListView listview_maintitle;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ListView listview_subtitle;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private GroupBox groupBox2;
        private CheckBox cb3;
        private CheckBox cb2;
        private CheckBox cb1;
        private TextBox txt_count;
        private ComboBox txt_cb2;
        private ComboBox txt_cb1;
        private Button btn_start;
        private CheckBox check_wrong;
        private Label txt_totalCount;
        private Label txt_select;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem groupAddToolStripMenuItem;
        private ToolStripMenuItem groupDeleteToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem studyAddToolStripMenuItem;
        private ToolStripMenuItem studyEditToolStripMenuItem;
        private ToolStripMenuItem studyDeleteToolStripMenuItem;
    }
}
