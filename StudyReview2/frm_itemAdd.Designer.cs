namespace StudyReview2
{
    partial class frm_itemAdd
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
            components = new System.ComponentModel.Container();
            toolStrip1 = new ToolStrip();
            txt_selectItem = new ToolStripLabel();
            toolStripSeparator1 = new ToolStripSeparator();
            txt_itemCount = new ToolStripLabel();
            listView = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            contextMenuStrip1 = new ContextMenuStrip(components);
            deleteToolStripMenuItem = new ToolStripMenuItem();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            txt_image = new TextBox();
            btn_imgAdd1 = new Button();
            btn_color1 = new Button();
            txt_input1 = new TextBox();
            groupBox1 = new GroupBox();
            richBox1 = new RichTextBox();
            tabPage2 = new TabPage();
            txt_image2 = new TextBox();
            btn_imgAdd2 = new Button();
            button6 = new Button();
            txt_title = new TextBox();
            groupBox2 = new GroupBox();
            richBox2 = new RichTextBox();
            tabPage3 = new TabPage();
            btn_add = new Button();
            btn_edit = new Button();
            btn_cancle = new Button();
            txt_checkItem = new Label();
            toolStrip1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox1.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { txt_selectItem, toolStripSeparator1, txt_itemCount });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1120, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // txt_selectItem
            // 
            txt_selectItem.Name = "txt_selectItem";
            txt_selectItem.Size = new Size(125, 22);
            txt_selectItem.Text = "Selected Items : None";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // txt_itemCount
            // 
            txt_itemCount.Name = "txt_itemCount";
            txt_itemCount.Size = new Size(86, 22);
            txt_itemCount.Text = "Item Count : 0";
            // 
            // listView
            // 
            listView.CheckBoxes = true;
            listView.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6 });
            listView.ContextMenuStrip = contextMenuStrip1;
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.Location = new Point(6, 29);
            listView.Name = "listView";
            listView.Size = new Size(396, 483);
            listView.TabIndex = 1;
            listView.UseCompatibleStateImageBehavior = false;
            listView.View = View.Details;
            listView.MouseDoubleClick += listView_MouseDoubleClick;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "";
            columnHeader1.Width = 25;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Type";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            columnHeader2.Width = 65;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Title";
            columnHeader3.Width = 300;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { deleteToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(181, 48);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            contextMenuStrip1.Click += contextMenuStrip1_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(180, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(408, 29);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(705, 441);
            tabControl1.TabIndex = 2;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            tabControl1.TabIndexChanged += tabControl1_TabIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.White;
            tabPage1.Controls.Add(txt_image);
            tabPage1.Controls.Add(btn_imgAdd1);
            tabPage1.Controls.Add(btn_color1);
            tabPage1.Controls.Add(txt_input1);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(697, 413);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "단답식";
            // 
            // txt_image
            // 
            txt_image.Location = new Point(299, 265);
            txt_image.Name = "txt_image";
            txt_image.Size = new Size(300, 23);
            txt_image.TabIndex = 11;
            // 
            // btn_imgAdd1
            // 
            btn_imgAdd1.Location = new Point(603, 262);
            btn_imgAdd1.Name = "btn_imgAdd1";
            btn_imgAdd1.Size = new Size(88, 29);
            btn_imgAdd1.TabIndex = 6;
            btn_imgAdd1.Text = "이미지 등록";
            btn_imgAdd1.UseVisualStyleBackColor = true;
            btn_imgAdd1.Click += btn_imgAdd1_Click;
            // 
            // btn_color1
            // 
            btn_color1.BackColor = Color.Yellow;
            btn_color1.Location = new Point(4, 262);
            btn_color1.Name = "btn_color1";
            btn_color1.Size = new Size(32, 31);
            btn_color1.TabIndex = 2;
            btn_color1.UseVisualStyleBackColor = false;
            btn_color1.Click += btn_color1_Click;
            // 
            // txt_input1
            // 
            txt_input1.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            txt_input1.Location = new Point(4, 231);
            txt_input1.Name = "txt_input1";
            txt_input1.Size = new Size(687, 29);
            txt_input1.TabIndex = 1;
            txt_input1.Click += txt_input1_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(richBox1);
            groupBox1.Location = new Point(4, -4);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(687, 231);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // richBox1
            // 
            richBox1.BorderStyle = BorderStyle.None;
            richBox1.Font = new Font("맑은 고딕", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            richBox1.Location = new Point(5, 10);
            richBox1.Name = "richBox1";
            richBox1.Size = new Size(677, 215);
            richBox1.TabIndex = 6;
            richBox1.Text = "";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.White;
            tabPage2.Controls.Add(txt_image2);
            tabPage2.Controls.Add(btn_imgAdd2);
            tabPage2.Controls.Add(button6);
            tabPage2.Controls.Add(txt_title);
            tabPage2.Controls.Add(groupBox2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(697, 413);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "다관식";
            // 
            // txt_image2
            // 
            txt_image2.Location = new Point(301, 266);
            txt_image2.Name = "txt_image2";
            txt_image2.Size = new Size(300, 23);
            txt_image2.TabIndex = 10;
            // 
            // btn_imgAdd2
            // 
            btn_imgAdd2.Location = new Point(605, 263);
            btn_imgAdd2.Name = "btn_imgAdd2";
            btn_imgAdd2.Size = new Size(88, 29);
            btn_imgAdd2.TabIndex = 7;
            btn_imgAdd2.Text = "이미지 등록";
            btn_imgAdd2.UseVisualStyleBackColor = true;
            btn_imgAdd2.Click += btn_imgAdd2_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.Yellow;
            button6.Location = new Point(4, 263);
            button6.Name = "button6";
            button6.Size = new Size(32, 31);
            button6.TabIndex = 4;
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // txt_title
            // 
            txt_title.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            txt_title.Location = new Point(5, 6);
            txt_title.Name = "txt_title";
            txt_title.Size = new Size(687, 29);
            txt_title.TabIndex = 2;
            txt_title.Text = "중간에 들어갈 알맞은 답을 적으시오";
            txt_title.Click += txt_title_Click;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(richBox2);
            groupBox2.Location = new Point(5, 31);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(687, 231);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            // 
            // richBox2
            // 
            richBox2.BorderStyle = BorderStyle.None;
            richBox2.Font = new Font("맑은 고딕", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            richBox2.Location = new Point(5, 10);
            richBox2.Name = "richBox2";
            richBox2.Size = new Size(677, 215);
            richBox2.TabIndex = 6;
            richBox2.Text = "문제 A의 정답은 {B}입니다. B의 정답은 {C}입니다.";
            richBox2.Click += richBox2_Click;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.White;
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(697, 413);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "객관식";
            // 
            // btn_add
            // 
            btn_add.Location = new Point(1006, 472);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(107, 41);
            btn_add.TabIndex = 3;
            btn_add.Text = "추가하기";
            btn_add.UseVisualStyleBackColor = true;
            btn_add.Click += btn_add_Click;
            // 
            // btn_edit
            // 
            btn_edit.Location = new Point(897, 472);
            btn_edit.Name = "btn_edit";
            btn_edit.Size = new Size(107, 41);
            btn_edit.TabIndex = 4;
            btn_edit.Text = "수정하기";
            btn_edit.UseVisualStyleBackColor = true;
            btn_edit.Click += btn_edit_Click;
            // 
            // btn_cancle
            // 
            btn_cancle.Location = new Point(788, 472);
            btn_cancle.Name = "btn_cancle";
            btn_cancle.Size = new Size(107, 41);
            btn_cancle.TabIndex = 5;
            btn_cancle.Text = "취소하기";
            btn_cancle.UseVisualStyleBackColor = true;
            btn_cancle.Click += btn_cancle_Click;
            // 
            // txt_checkItem
            // 
            txt_checkItem.AutoSize = true;
            txt_checkItem.Location = new Point(408, 473);
            txt_checkItem.Name = "txt_checkItem";
            txt_checkItem.Size = new Size(106, 15);
            txt_checkItem.TabIndex = 7;
            txt_checkItem.Text = "Check Item : none";
            // 
            // frm_itemAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1120, 516);
            Controls.Add(txt_checkItem);
            Controls.Add(btn_cancle);
            Controls.Add(btn_edit);
            Controls.Add(btn_add);
            Controls.Add(tabControl1);
            Controls.Add(listView);
            Controls.Add(toolStrip1);
            Name = "frm_itemAdd";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Let's live a better tomorrow than today";
            FormClosed += frm_itemAdd_FormClosed;
            Load += frm_itemAdd_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            groupBox1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripLabel txt_selectItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel txt_itemCount;
        private ListView listView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button btn_add;
        private Button btn_edit;
        private Button btn_cancle;
        private TabPage tabPage3;
        private GroupBox groupBox1;
        private RichTextBox richBox1;
        private TextBox txt_input1;
        private Button btn_color1;
        private Button btn_imgAdd1;
        private Label txt_checkItem;
        private TextBox txt_title;
        private GroupBox groupBox2;
        private RichTextBox richBox2;
        private Button btn_imgAdd2;
        private Button button6;
        private Label txt_image1;
        //private TextBox txt_image1;
        private TextBox txt_image2;
        private TextBox txt_image;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem deleteToolStripMenuItem;
    }
}