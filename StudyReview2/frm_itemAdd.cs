using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;

namespace StudyReview2
{
    public partial class frm_itemAdd : Form
    {
        string JSON_PATH = "";
        int CHECK_ITEM = 0;
        bool PROCESS_EDIT = false;

        public frm_itemAdd(string path)
        {
            JSON_PATH = path;
            InitializeComponent();
            this.tabControl1.Selecting += tabControl1_Selecting;
        }
        private void json_exists(string path)
        {
            //파일 유무 체크, 파일 없으면 생성
        }
        private void list_refresh() //문제 출력 리스트 초기화
        {
            /*JSON 파일 구조 : 
             * type : 0 (단답식) 1 (다관식)
             * text : 단답식은 문제, 다관식은 [0]은 타이틀 [1]은 문제
             * result : 단답식은 [0] 답 다관식은 [array]
             */
            if (File.Exists(JSON_PATH))
            {
                var jsonData = File.ReadAllText(JSON_PATH);
                if (!string.IsNullOrEmpty(jsonData))
                {
                    var questions = JsonConvert.DeserializeObject<List<Question>>(jsonData);

                    listView.Items.Clear();

                    foreach (var question in questions)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Checked = false;

                        string typeName = (question.type == 0) ? "단답식" : "다관식";
                        item.SubItems.Add(typeName);


                        /* 타이틀 설정 */
                        string title = "";
                        string result = "";
                        string image = "";
                        string highlightedText = "";

                        if (question.type == 0) //단답식 
                        {
                            title = question.text.ToString();
                            result = question.result.ToString();

                        }

                        else if (question.type == 1)
                        {
                            string emptyData = question.text.ToString();
                            List<string> textArray = JsonConvert.DeserializeObject<List<string>>(emptyData);
                            //title = textArray[0] +  textArray[1];
                            title = string.Concat(textArray[0], '|', textArray[1]);
                            result = question.result.ToString();
                        }

                        //image = question.image.ToString();
                        image = string.IsNullOrEmpty(question.image?.ToString()) ? "" : question.image.ToString();
                        highlightedText = string.IsNullOrEmpty(question.highlightedText?.ToString()) ? "" : question.highlightedText.ToString();

                        item.SubItems.Add(title);
                        item.SubItems.Add(result);
                        item.SubItems.Add(image);
                        item.SubItems.Add(highlightedText);
                        listView.Items.Add(item);
                    }
                }
            }
            else
            {
                MessageBox.Show("경로에서 JSON파일을 찾을 수 없습니다.", "");
                //경로에 JSON파일이 없음. main에서 생성해서 넘기기 때문에 무시
            }

        }

        private void frm_itemAdd_Load(object sender, EventArgs e)
        {
            /* 기본 도구 설정 */
            btn_add.Enabled = true;
            btn_edit.Enabled = false;
            btn_cancle.Enabled = false;


            list_refresh();
            eventReset();
            txt_itemCount.Text = "Item Count " + listView.Items.Count;
            txt_selectItem.Text = $"Selected Items : {JSON_PATH}";
            PROCESS_EDIT = false;
        }

        private void btn_color1_Click(object sender, EventArgs e)
        {
            AddHighlightedText(richBox1);

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            //문제 추가
            QuestionItemAdd();
            PROCESS_EDIT = false;
        }
        private void eventReset()
        {
            //CHECK_ITEM = 0;
            list_refresh();
            //txt_checkItem.Text = "Check Item : none";
            //이미지 경로 설정
            txt_image.Text = "";
            txt_image2.Text = "";
            //정답 초기화
            txt_input1.Text = "정답";
            //문제 초기화
            richBox1.Text = "";
            richBox2.Text = "문제 A의 정답은 {B}입니다. B의 정답은 {C}입니다.";
            txt_title.Text = "중간에 들어갈 알맞은 답을 적으시오";

            //버튼 활성화 초기화
            btn_add.Enabled = true;
            btn_edit.Enabled = false;
            btn_cancle.Enabled = false;

        }
        private void QuestionItemAdd()
        {
            int selectedTab = tabControl1.SelectedIndex;
            try
            {
                switch (selectedTab)
                {
                    case 0:
                        if (string.IsNullOrEmpty(txt_input1.Text)) { MessageBox.Show("정답을 입력하세요 !", "StudyReview 2", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                        if (string.IsNullOrEmpty(richBox1.Text)) { MessageBox.Show("문제를 입력하세요 !", "StudyReview 2", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                        AddShortAnswerQuestion();
                        break;

                    case 1:
                        if (string.IsNullOrEmpty(txt_title.Text)) { MessageBox.Show("제목을 입력하세요 !", "StudyReview 2", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                        if (string.IsNullOrEmpty(richBox2.Text)) { MessageBox.Show("문제를 입력하세요 !", "StudyReview 2", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                        AddMultipleChoiceQuestion();
                        break;
                }
                //아이템 초기화
                eventReset();
            }
            catch (Exception e)
            {
                Debug.Write($"QuestionItemAdd : {e}");
            }
        }
        private void AddMultipleChoiceQuestion() //다관식 문제 추가
        {
            string jsonPath = JSON_PATH;
            var existingQuestions = LoadQuestionsFromJson(jsonPath);

            if (existingQuestions == null)
            {
                existingQuestions = new List<Dictionary<string, object>>();
            }
            var newQuestion = new Dictionary<string, object>();
            string titleText = txt_title.Text;
            string problemText = richBox2.Text;

            var highlightedText = GetHighlightedText(richBox2);
            List<string> answers = MultipleAnswerOutput(problemText);

            newQuestion["type"] = 1;
            newQuestion["text"] = new List<object> { titleText, problemText };

            if (highlightedText != null && highlightedText.Count > 0)
            {
                newQuestion["highlightedText"] = highlightedText;
            }

            newQuestion["result"] = answers;

            string imagePath = txt_image2.Text;
            if (!string.IsNullOrEmpty(imagePath))
            {
                newQuestion["image"] = imagePath;
            }
            existingQuestions.Add(newQuestion);
            SaveQuestionsToJson(jsonPath, existingQuestions);
        }

        private List<string> MultipleAnswerOutput(string problemText)
        {
            List<string> answers = new List<string>();
            var matches = Regex.Matches(problemText, @"\{(.*?)\}");
            foreach (Match match in matches)
            {
                answers.Add(match.Groups[1].Value);
            }
            return answers;
        }

        private void AddShortAnswerQuestion() //단답식 문제 추가
        {
            string jsonPath = JSON_PATH;
            var existingQuestions = LoadQuestionsFromJson(jsonPath);

            if (existingQuestions == null)
            {
                existingQuestions = new List<Dictionary<string, object>>();
            }

            var newQuestion = new Dictionary<string, object>();

            string richText = richBox1.Text;
            var highlightedText = GetHighlightedText(richBox1);

            newQuestion["type"] = 0;
            newQuestion["text"] = richText;
            if (highlightedText != null && highlightedText.Count > 0)
            {
                newQuestion["highlightedText"] = highlightedText;
            }

            newQuestion["result"] = txt_input1.Text;

            string imagePath = txt_image.Text;
            if (!string.IsNullOrEmpty(imagePath))
            {
                newQuestion["image"] = imagePath;
            }


            existingQuestions.Add(newQuestion);
            SaveQuestionsToJson(jsonPath, existingQuestions);

        }
        private void EditShortAnswerQuestion() //단답식 문제 수정
        {
            try
            {
                var exisitQuestions = LoadQuestionsFromJson(JSON_PATH);

                if (CHECK_ITEM < 0 || CHECK_ITEM >= exisitQuestions.Count)
                {
                    MessageBox.Show("수정할 항목을 찾을 수 없습니다.", "StudyReview 2", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedQuestion = exisitQuestions[CHECK_ITEM];

                selectedQuestion["text"] = richBox1.Text;
                selectedQuestion["result"] = txt_input1.Text;

                var highlightedText = GetHighlightedText(richBox1);
                if (highlightedText != null && highlightedText.Count > 0)
                {
                    selectedQuestion["highlightedText"] = highlightedText;
                }

                SaveQuestionsToJson(JSON_PATH, exisitQuestions);
                list_refresh();
                eventReset();

            }
            catch (Exception e)
            {
                MessageBox.Show("수정 중 오류가 발생했습니다.", "StudyReview 2", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EditMultiAnswerQuestion()
        {
            try
            {
                var exisitQuestions = LoadQuestionsFromJson(JSON_PATH);

                if (CHECK_ITEM < 0 || CHECK_ITEM >= exisitQuestions.Count)
                {
                    MessageBox.Show("수정할 항목을 찾을 수 없습니다.", "StudyReview 2", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var selectedQuestion = exisitQuestions[CHECK_ITEM];

                selectedQuestion["text"] = new List<object> { txt_title.Text, richBox2.Text };

                var highlightedText = GetHighlightedText(richBox2);
                List<string> answers = MultipleAnswerOutput(richBox2.Text);

                if (highlightedText != null && highlightedText.Count > 0)
                {
                    selectedQuestion["highlightedText"] = highlightedText;
                    selectedQuestion["result"] = answers;

                    string imagePath = txt_image2.Text;
                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        selectedQuestion["image"] = imagePath;
                    }
                    SaveQuestionsToJson(JSON_PATH, exisitQuestions);
                    list_refresh();
                    eventReset();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("수정 중 오류가 발생했습니다.", "StudyReview 2", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<string> GetHighlightedText(RichTextBox richTextBox)
        {
            List<string> highlighedText = new List<string>();
            for (int i = 0; i < richTextBox.TextLength; i++)
            {
                richTextBox.Select(i, 1);
                Color backColor = richTextBox.SelectionBackColor;

                if (backColor == Color.Yellow)
                {
                    int start = i;
                    int length = 0;

                    while (i < richTextBox.TextLength && richTextBox.SelectionBackColor == Color.Yellow)
                    {
                        i++;
                        length++;
                        richTextBox.Select(i, 1);
                    }
                    string highlighted = richTextBox.Text.Substring(start, length);
                    highlighedText.Add(highlighted);
                }
            }
            return highlighedText;
        }

        //Json Read
        private List<Dictionary<string, object>> LoadQuestionsFromJson(string jsonPath)
        {
            if (File.Exists(jsonPath))
            {
                string json = File.ReadAllText(jsonPath);
                return JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);
            }
            return new List<Dictionary<string, object>>();
        }
        //Json Save
        private void SaveQuestionsToJson(string jsonPath, List<Dictionary<string, object>> questions)
        {
            string json = JsonConvert.SerializeObject(questions, Formatting.Indented);
            File.WriteAllText(jsonPath, json);
        }

        private void btn_imgAdd1_Click(object sender, EventArgs e)
        {
            openImageDialog();
        }

        private void openImageDialog() //문제 이미지 가져오기
        {
            //이미지 저장할때 프로그램 폴더 경로로 옴겨야함
            int selectedTab = tabControl1.SelectedIndex;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg; *.jpeg; *.png;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string originalFilePath = ofd.FileName;
                //MessageBox.Show("orgin : " +  originalFilePath);

                //파일이동
                string savePath = Path.Combine(Path.GetDirectoryName(JSON_PATH), "images");
                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                savePath = Path.Combine(savePath, Path.GetFileName(originalFilePath));
                File.Copy(originalFilePath, savePath, true);



                //MessageBox.Show(savePath);

                switch (selectedTab)
                {
                    case 0:
                        txt_image.Text = savePath;
                        break;
                    case 1:
                        txt_image2.Text = savePath;
                        break;
                }
            }
        }

        private void btn_imgAdd2_Click(object sender, EventArgs e)
        {
            openImageDialog();
        }

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (PROCESS_EDIT == true)
            {
                MessageBox.Show("기존에 수정중인 작업을 취소해주세요", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            /* 리스트뷰 체크 이벤트 */
            listView.BeginUpdate();
            //CheckBox 초기화
            foreach (ListViewItem item in listView.Items)
            {
                item.Checked = false;
            }

            listView.EndUpdate();

            if (listView.SelectedItems.Count == 1)
            {
                ListViewItem lvItem = listView.SelectedItems[0];
                string type = lvItem.SubItems[1].Text;


                if (type == "단답식")
                {
                    tabControl1.SelectedIndex = 0;
                    richBox1.Text = lvItem.SubItems[2].Text;
                    txt_input1.Text = lvItem.SubItems[3].Text;
                    txt_image.Text = lvItem.SubItems[4].Text;
                    if (!string.IsNullOrEmpty(lvItem.SubItems[5].Text))
                    {
                        highlightedTextSet(richBox1, lvItem.SubItems[5].Text);
                    }

                    //도구 관리
                    editBtn_event(lvItem);
                }
                else if (type == "다관식")
                {
                    tabControl1.SelectedIndex = 1;
                    string[] questEmpty = lvItem.SubItems[2].Text.Split('|');
                    txt_title.Text = questEmpty[0];
                    richBox2.Text = questEmpty[1];
                    if (!string.IsNullOrEmpty(lvItem.SubItems[5].Text))
                    {
                        highlightedTextSet(richBox2, lvItem.SubItems[5].Text);
                    }
                    editBtn_event(lvItem);
                }
                PROCESS_EDIT = true;
            }
        }
        private void editBtn_event(ListViewItem lvItem)
        {
            CHECK_ITEM = (lvItem.Index);
            //도구 관리
            txt_checkItem.Text = "Check Item : " + (lvItem.Index + 1).ToString();
            btn_edit.Enabled = true;
            btn_cancle.Enabled = true;
            btn_add.Enabled = false;
        }
        private void highlightedTextSet(RichTextBox richBox, string json)
        {
            //MessageBox.Show(json);
            var parsedData = JsonConvert.DeserializeObject<List<string>>(json);

            foreach (var text in parsedData)
            {
                int startIndex = richBox.Text.IndexOf(text);
                while (startIndex != -1)
                {
                    richBox.Select(startIndex, text.Length);
                    richBox.SelectionBackColor = Color.Yellow;

                    startIndex = richBox.Text.IndexOf(text, startIndex + text.Length);
                }

            }

        }


        private void btn_cancle_Click(object sender, EventArgs e)
        {
            eventReset();
            PROCESS_EDIT = false;
            //txt_input1.Text = "정답";
            //txt_checkItem.Text = "Check Item : none";
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0: //단답식 문제 수정
                    EditShortAnswerQuestion();
                    break;
                case 1: //다관식 문제 수정
                    EditMultiAnswerQuestion();
                    break;
            }
            PROCESS_EDIT = false;
        }



        private void txt_input1_Click(object sender, EventArgs e)
        {
            if (txt_input1.Text == "정답") { txt_input1.Text = ""; }
        }

        private void button6_Click(object sender, EventArgs e) //다관식 하아라이트
        {
            AddHighlightedText(richBox2);
            RemoveMultQuestionHighlighted();
        }
        private void RemoveMultQuestionHighlighted() //{}정답은 하이라이트 처리 예외
        {
            //문제 출력할때 먼저 하이퍼라이트 적용하고 나서 (A), (B) 기호로 변경해야 할 듯


            string text = richBox2.Text;
            int startIndex = 0;
            while ((startIndex = text.IndexOf("{", startIndex)) != -1)
            {
                int endIndex = text.IndexOf("}", startIndex);
                if (endIndex != -1)
                {
                    richBox2.Select(startIndex, endIndex - startIndex + 1);
                    richBox2.SelectionBackColor = System.Drawing.Color.Transparent;
                    startIndex = endIndex + 1;
                }
            }
        }
        private void AddHighlightedText(RichTextBox richBox)
        {
            if (richBox.SelectionLength > 0)
            {
                if (richBox.SelectionBackColor == System.Drawing.Color.Yellow)
                {
                    richBox.SelectionBackColor = System.Drawing.Color.Transparent;
                }
                else
                {
                    richBox.SelectionBackColor = System.Drawing.Color.Yellow;
                }

            }
            else
            {
                //선택된 텍스트가 없습니다.
            }
        }

        private void txt_title_Click(object sender, EventArgs e)
        {
            if (txt_title.Text.Equals("중간에 들어갈 알맞은 답을 적으시오")) { txt_title.Clear(); }
        }

        private void richBox2_Click(object sender, EventArgs e)
        {
            if (richBox2.Text.Equals("문제 A의 정답은 {B}입니다. B의 정답은 {C}입니다.")) { richBox2.Clear(); }
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            eventReset();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            // PROCESS_EDIT이 true면 탭 변경 금지
            if (PROCESS_EDIT)
            {
                MessageBox.Show("편집 중에는 탭을 변경할 수 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;  // 탭 전환 취소
            }
            else
            {
                eventReset();
            }
        }

        private void frm_itemAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_start frm = new frm_start();
            frm.Show();
        }
    }
}
