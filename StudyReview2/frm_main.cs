using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;

namespace StudyReview2
{
    public partial class frm_start : Form
    {
        string SET_DATABASE = "";
        public frm_start()
        {
            InitializeComponent();
        }

        private void frm_start_Load(object sender, EventArgs e)
        {
            refresh_main();
            txt_cb1.Text = "Sequential";
            txt_cb2.Text = "��üǮ��";
        }
        private void refresh_main()
        {
            listview_maintitle.Items.Clear();
            string path_default = @"Data";
            DirectoryInfo di = new DirectoryInfo(path_default);

            if (Directory.Exists(di.FullName))
            {
                foreach (DirectoryInfo sub_dir in di.GetDirectories())
                {
                    ListViewItem item = new ListViewItem(sub_dir.Name);
                    item.SubItems.Add(subtitle_itemCount(sub_dir.Name));
                    listview_maintitle.Items.Add(item);
                }
            }
        }
        private string subtitle_itemCount(string path)
        {
            int count = 0;
            DirectoryInfo di = new DirectoryInfo(@"Data\" + path);
            foreach (FileInfo File in di.GetFiles())
            {
                count++;
            }
            return count.ToString();
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void groupAddToolStripMenuItem_Click(object sender, EventArgs e) //���� ����Ʈ �߰�
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Add Group", "newGroup");
            if (!string.IsNullOrEmpty(input))
            {
                bool boolName = true;
                foreach (ListViewItem item in listview_maintitle.Items)
                {
                    if (input == item.SubItems[0].Text)
                    {
                        boolName = false;
                    }
                }
                if (boolName)
                {
                    try
                    {
                        string path = @"Data\" + input;
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                            refresh_main();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}", ": )", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("�̹� �ߺ��� �׷��� �ֽ��ϴ�", ": )", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }



        private void groupDeleteToolStripMenuItem_Click(object sender, EventArgs e) //�׷� ����
        {
            List<string> fileList = new List<string>();
            string path_group = @"Data\";
            foreach (ListViewItem item in listview_maintitle.Items)
            {
                if (item.Selected)
                {
                    path_group += item.SubItems[0].Text;
                }
            }

            try
            {
                if (Directory.Exists(path_group))
                {
                    string[] files = Directory.GetFiles(path_group);
                    fileList.AddRange(files);
                }

                string message = $"�׷� <{path_group}> ���� �׸����� {Environment.NewLine}{string.Join(", ", fileList)} �׸��� �ֽ��ϴ� ���� �Ͻðڽ��ϱ�?";
                if (DialogResult.OK == MessageBox.Show(message, "OO", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                {
                    Directory.Delete(path_group, true);
                }
            }
            catch (Exception ex)
            {
                //���� ó��
            }
            refresh_main();
            listview_subtitle.Items.Clear();
        }

        private void listview_maintitle_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            refresh_subtitle();
        }
        private void refresh_subtitle()
        {
            if (listview_maintitle.SelectedItems.Count == 1)
            {
                listview_subtitle.Items.Clear();
                var lvitem = listview_maintitle.SelectedItems[0];
                var dir = new DirectoryInfo(Path.Combine("Data", lvitem.Text));
                SET_DATABASE = lvitem.Text;
                int sentenceCount = 0;
                foreach (FileInfo fi in dir.GetFiles("*.json"))
                {
                    string json = File.ReadAllText(fi.FullName, Encoding.UTF8);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        JArray arr = JArray.Parse(json);
                        sentenceCount = arr.Count;
                    }
                    else
                    {
                        sentenceCount = 0;
                    }

                    // ListViewItem ����
                    var subitem = new ListViewItem("");
                    subitem.SubItems.Add(Path.GetFileNameWithoutExtension(fi.Name));
                    subitem.SubItems.Add(sentenceCount.ToString());

                    listview_subtitle.Items.Add(subitem);
                }
            }
        }

        private void studyAddToolStripMenuItem_Click(object sender, EventArgs e) //���� �߰�
        {
            if (listview_maintitle.SelectedItems.Count > 0)
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("add Item", "example");
                var title = SET_DATABASE;
                var fileName = $"{input}.json";
                string path = Path.Combine("Data", title, fileName);

                if (!File.Exists(path) && input != "")
                {
                    File.Create(path).Close();
                    frm_itemAdd frm = new frm_itemAdd(path);
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("�̹� ���� �̸��� �׸��� �����մϴ�.", "Study Review 2", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("�׷��� üũ���ּ���", "Study Review 2", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            refresh_subtitle();
        }
        private void showEdit(string path)
        {
            if (File.Exists(path))
            {
                foreach (ListViewItem item in listview_subtitle.CheckedItems)
                {
                    if (item.Checked) { path = item.SubItems[1].Text; }
                }
                //path =

            }
            frm_itemAdd frm = new frm_itemAdd(path);
            frm.Show();
            this.Hide();
        }

        private void frm_start_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void studyEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = "";
            string fileName = "";
            if (listview_subtitle.CheckedItems.Count == 1)
            {
                foreach (ListViewItem item in listview_subtitle.CheckedItems)
                {
                    if (item.Checked) { fileName = $"{item.SubItems[1].Text}.json"; }
                }
                var title = SET_DATABASE;
                path = Path.Combine("Data", title, fileName);
                frm_itemAdd frm = new frm_itemAdd(path);
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("������ �׸��� ����� �����ߴ��� Ȯ���ϼ���", ": )", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void studyDeleteToolStripMenuItem_Click(object sender, EventArgs e) //���� JSON ����
        {
            string path = Path.Combine("Data", SET_DATABASE);
            foreach (ListViewItem item in listview_subtitle.Items)
            {
                if (item.Checked)
                {
                    DialogResult result = MessageBox.Show($"���� {item.SubItems[1].Text}�� ���� �Ͻðڽ��ϱ�?", "StudyReview 2", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);

                    if (result == DialogResult.OK)
                    {
                        string tempPath = Path.Combine(path, $"{item.SubItems[1].Text}.json");
                        File.Delete(tempPath);
                    }
                }
            }
            refresh_subtitle();
            refresh_main();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (!cb1.Checked && !cb2.Checked && !cb3.Checked)
            {
                MessageBox.Show("���� Ǯ�� ������ �����ϼ���", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txt_cb1.Text) || string.IsNullOrEmpty(txt_cb2.Text))
            {
                MessageBox.Show("���� Ǯ�� ����� �����ϼ���", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txt_cb2.Text == "����Ǯ��" && txt_count.Text == "")
            { 
                MessageBox.Show("���� �õ� ������ �Է��ϼ���", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int i = 0; 
            string title = SET_DATABASE;
            List<string> tempPaths = new List<string>();

            foreach (ListViewItem item in this.listview_subtitle.Items)
            {
                if (item.Checked)
                {
                    if (item.SubItems[2].Text == "0")
                    {
                        item.Checked = false;
                    }
                    else
                    {
                        tempPaths.Add(Path.Combine(title, item.SubItems[1].Text));
                    }
                }
            }
            string[] database_path = tempPaths.ToArray();
            if (database_path.Length == 0) { return; }

            Setting setting = new Setting
            {
                GameTypes = new bool[3],
                AnswerType = txt_cb1.Text,
                SolveType = txt_cb2.Text,
                ProblemCount = cb2.Text == "����Ǯ��" ? Convert.ToInt32(txt_count.Text) : 0,
                IsRetryWrong = check_wrong.Checked,
                Database = database_path


            };
            setting.GameTypes[0] = cb1.Checked;
            setting.GameTypes[1] = cb2.Checked;
            setting.GameTypes[2] = cb3.Checked;

            frm_question frmMain = new frm_question(setting);
            frmMain.Show();
            this.Hide();
        }
    }
}