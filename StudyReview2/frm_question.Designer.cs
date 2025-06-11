namespace StudyReview2
{
    partial class frm_question
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
            toolStrip1 = new ToolStrip();
            txt_count = new ToolStripLabel();
            toolStripSeparator1 = new ToolStripSeparator();
            txt_rate = new ToolStripLabel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            txt_numfail = new Label();
            txt_input = new TextBox();
            groupBox2 = new GroupBox();
            richQuestion1 = new RichTextBox();
            tabPage2 = new TabPage();
            txt_title = new TextBox();
            txt_numfail2 = new Label();
            txt_input2 = new TextBox();
            groupBox1 = new GroupBox();
            richQuestion2 = new RichTextBox();
            tabPage3 = new TabPage();
            toolStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox2.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { txt_count, toolStripSeparator1, txt_rate });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(765, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // txt_count
            // 
            txt_count.Name = "txt_count";
            txt_count.Size = new Size(63, 22);
            txt_count.Text = "Count 0/0";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // txt_rate
            // 
            txt_rate.Name = "txt_rate";
            txt_rate.Size = new Size(98, 22);
            txt_rate.Text = "Correct rate : 0%";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(0, 28);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(761, 393);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.White;
            tabPage1.Controls.Add(txt_numfail);
            tabPage1.Controls.Add(txt_input);
            tabPage1.Controls.Add(groupBox2);
            tabPage1.ForeColor = Color.FromArgb(192, 0, 0);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(753, 365);
            tabPage1.TabIndex = 0;
            // 
            // txt_numfail
            // 
            txt_numfail.AutoSize = true;
            txt_numfail.ForeColor = Color.FromArgb(192, 0, 0);
            txt_numfail.Location = new Point(582, 317);
            txt_numfail.Name = "txt_numfail";
            txt_numfail.Size = new Size(138, 15);
            txt_numfail.TabIndex = 2;
            txt_numfail.Text = "Number of failures : 0/5";
            txt_numfail.TextAlign = ContentAlignment.TopRight;
            // 
            // txt_input
            // 
            txt_input.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            txt_input.Location = new Point(33, 285);
            txt_input.Name = "txt_input";
            txt_input.Size = new Size(687, 29);
            txt_input.TabIndex = 3;
            txt_input.Click += txt_input_Click;
            txt_input.KeyDown += txt_input_KeyDown;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(richQuestion1);
            groupBox2.Location = new Point(33, 50);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(687, 231);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            // 
            // richQuestion1
            // 
            richQuestion1.BorderStyle = BorderStyle.None;
            richQuestion1.Font = new Font("맑은 고딕", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            richQuestion1.Location = new Point(5, 10);
            richQuestion1.Name = "richQuestion1";
            richQuestion1.Size = new Size(677, 215);
            richQuestion1.TabIndex = 6;
            richQuestion1.Text = "";
            richQuestion1.Click += richQuestion1_Click;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.White;
            tabPage2.Controls.Add(txt_title);
            tabPage2.Controls.Add(txt_numfail2);
            tabPage2.Controls.Add(txt_input2);
            tabPage2.Controls.Add(groupBox1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(753, 365);
            tabPage2.TabIndex = 1;
            // 
            // txt_title
            // 
            txt_title.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            txt_title.Location = new Point(33, 25);
            txt_title.Name = "txt_title";
            txt_title.Size = new Size(687, 29);
            txt_title.TabIndex = 5;
            // 
            // txt_numfail2
            // 
            txt_numfail2.AutoSize = true;
            txt_numfail2.ForeColor = Color.FromArgb(192, 0, 0);
            txt_numfail2.Location = new Point(582, 317);
            txt_numfail2.Name = "txt_numfail2";
            txt_numfail2.Size = new Size(138, 15);
            txt_numfail2.TabIndex = 4;
            txt_numfail2.Text = "Number of failures : 0/5";
            txt_numfail2.TextAlign = ContentAlignment.TopRight;
            // 
            // txt_input2
            // 
            txt_input2.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            txt_input2.Location = new Point(33, 285);
            txt_input2.Name = "txt_input2";
            txt_input2.Size = new Size(687, 29);
            txt_input2.TabIndex = 3;
            txt_input2.Click += txt_input2_Click;
            txt_input2.KeyDown += txt_input2_KeyDown;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(richQuestion2);
            groupBox1.Location = new Point(33, 50);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(687, 231);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            // 
            // richQuestion2
            // 
            richQuestion2.BorderStyle = BorderStyle.None;
            richQuestion2.Font = new Font("맑은 고딕", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            richQuestion2.Location = new Point(5, 10);
            richQuestion2.Name = "richQuestion2";
            richQuestion2.Size = new Size(677, 215);
            richQuestion2.TabIndex = 6;
            richQuestion2.Text = "";
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.White;
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(753, 365);
            tabPage3.TabIndex = 2;
            // 
            // frm_question
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(765, 424);
            Controls.Add(tabControl1);
            Controls.Add(toolStrip1);
            Name = "frm_question";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Let's live a better tomorrow than today";
            FormClosed += frm_question_FormClosed;
            Load += frm_question_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            groupBox2.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripLabel txt_count;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel txt_rate;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TextBox txt_input;
        private GroupBox groupBox2;
        private RichTextBox richQuestion1;
        private TextBox txt_input2;
        private GroupBox groupBox1;
        private RichTextBox richQuestion2;
        private Label txt_numfail;
        private Label txt_numfail2;
        private TextBox txt_title;
    }
}