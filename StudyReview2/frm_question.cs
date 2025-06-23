using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyReview2
{
    public partial class frm_question : Form
    {
        private Setting _setting;
        private List<Question> allQuestions = new List<Question>();
        private List<Question> failQuestions = new List<Question>();
        private List<Question> randQuestions = new List<Question>(); //추후 랜덤 풀이 업데이트
        private Random random = new Random();
        private Form imageForm;

        private int MAX_FAILD = 5; //최대 실패 개수
        private int NOW_FAILD = 0; //틀린 개수
        private int ALL_FAILD = 0; //전체 틀린 개수

        private int GAME_MAX_COUNT = 0; //문제 풀이 개수
        private int GAME_TURN = 0;
        private int GAME_INDEX = 0;

        public frm_question(Setting setting)
        {
            InitializeComponent();
            _setting = setting;
            LoadSettings();
        }
        private void LoadSettings()
        {
            if (_setting != null)
            {
                if (_setting.SolveType == "선택풀기")
                {
                    GAME_MAX_COUNT = _setting.ProblemCount;
                }
            }
        }

        private void LoadJsonQuestion()
        {
            foreach (var path in _setting.Database)
            {
                string jsonPath = Path.Combine("Data", $"{path}.json");
                var jsonData = File.ReadAllText(jsonPath);
                var question = JsonConvert.DeserializeObject<List<Question>>(jsonData);
                allQuestions.AddRange(question);
            }
        }

        private void frm_question_Load(object sender, EventArgs e)
        {
            LoadJsonQuestion();
            startQuestion();
        }

        private void startQuestion()
        {
            //재도전이면 재도전 호출할때 먼저 allQuestions에다가 failQuestions 옴기고 시작
            GAME_MAX_COUNT = (GAME_MAX_COUNT == 0) ? allQuestions.Count : GAME_MAX_COUNT;
            
            //게임 종료 체크
            if (GAME_TURN >= GAME_MAX_COUNT)
            {
                MessageBox.Show($"문제 풀이가 종료되었습니다, Correct rate : {CorrectProcess()}%", "♥", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GAME_TURN = 0;
                GAME_INDEX = 0;
                GAME_MAX_COUNT = 0;
                ALL_FAILD = 0;
                if (_setting.IsRetryWrong == true && failQuestions.Count > 0)
                {
                    MessageBox.Show("틀린 문제를 재풀이 합니다", ": )", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    allQuestions.Clear();
                    allQuestions.AddRange(failQuestions);
                    failQuestions.Clear();
                    startQuestion();
                }
                else
                {
                    //마지막 시간 체크
                    this.Close();
                }
            }
            else
            {
                if (imageForm != null && !imageForm.IsDisposed)
                {
                    imageForm.Close();
                }
                printUI();
                showQuestion();
            }
        }
        private void showQuestion()
        {
            if (_setting.AnswerType == "Random") //랜덤
            {

            }
            else //순차방식
            {
                //수정 필요 없음 정답 체크시 순차 방식이면 index 추가
            }
            var selectedQuestion = allQuestions[GAME_INDEX];
            switch (selectedQuestion.type)
            {
                case 0: //단답식
                    tabControl1.SelectedIndex = 0;
                    richQuestion1.Text = selectedQuestion.text.ToString();
                    highlightedTextSet(richQuestion1);
                    break;

                case 1: //주관식
                    tabControl1.SelectedIndex = 1;
                    string emptyData = selectedQuestion.text.ToString();
                    List<string> textArray = JsonConvert.DeserializeObject<List<string>>(emptyData);
                    txt_title.Text = textArray[0];
                    richQuestion2.Text = TransQuestion(textArray[1]);
                    highlightedTextSet(richQuestion2);
                    break;
            }
            if (selectedQuestion.image != null)
            {
                string imagePath = selectedQuestion.image.ToString();
                if (File.Exists(imagePath))
                {
                    ShowImageForm(imagePath);
                }
            }

        }
        
        private void ShowImageForm(string imagePath)
        {
            Image image = Image.FromFile(imagePath);

            int imageWidth = image.Width;
            int imageHeight = image.Height;

            Form frmQuestion = this;
            int frmQuestionX = frmQuestion.Location.X;
            int frmQuestionY = frmQuestion.Location.Y;

            int frmQuestionWidth = frmQuestion.Width;
            int frmQuestionHeight = frmQuestion.Height;

            // 이미지 폼 크기 설정
            imageForm = new Form
            {
                Size = new Size(imageWidth, imageHeight),
                StartPosition = FormStartPosition.Manual,
                Location = new Point(frmQuestionX + frmQuestionWidth, frmQuestionY + (frmQuestionHeight - imageHeight) / 2)
            };

            PictureBox pictureBox = new PictureBox
            {
                Image = image,
                SizeMode = PictureBoxSizeMode.Zoom,  
                Dock = DockStyle.Fill  
            };

            imageForm.Controls.Add(pictureBox);
            imageForm.Show();
            if (tabControl1.SelectedIndex == 0) { txt_input.Focus(); }
            else if (tabControl1.SelectedIndex == 1) { txt_input2.Focus(); }
            //추후 객관식 추가를 위해 else if 로 처리

        }


        private string TransQuestion(string input) //다관식 
        {
            //정규식 { } 검사
            Regex regex = new Regex(@"{(.*?)}");
            MatchCollection matches = regex.Matches(input);

            List<string> names = new List<string>();

            foreach (Match match in matches)
            {
                names.Add(match.Groups[1].Value);
                //알파벳 치환
                char alpabet = (char)('A' + names.Count - 1);
                input = input.Replace(match.Value, $"({alpabet})");
            }
            return input;
        }
        private void highlightedTextSet(RichTextBox richBox)
        {
            if (allQuestions[GAME_INDEX].highlightedText == null)
            {
                return;
            }
            var json = allQuestions[GAME_INDEX].highlightedText.ToString();
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

        private void frm_question_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (imageForm != null && !imageForm.IsDisposed)
            {
                imageForm.Close();
            }
            frm_start frm_start = new frm_start();
            frm_start.Show();
        }
        private void printUI(Label txt_fail = null)
        {
            txt_count.Text = $"Count {GAME_TURN + 1}/{GAME_MAX_COUNT}";
            txt_rate.Text = $"Correct rage : {CorrectProcess()}%";
            if (txt_fail != null) { txt_fail.Text = $"Number of failures : {NOW_FAILD}/{MAX_FAILD}"; }
        }
        private double CorrectProcess()
        {
            if (GAME_TURN <= 1) { return 100; }
            else
            {
                int correctAnswers = (GAME_TURN-1) - ALL_FAILD;
                double accuracyPercentage = (double)correctAnswers / (GAME_TURN - 1) * 100;
                accuracyPercentage = Math.Round(accuracyPercentage, 2);
                return accuracyPercentage;
            }
        }

        private void txt_input2_Click(object sender, EventArgs e)
        {
            txt_input2.Text = "";
        }

        private void txt_input2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //List<string> textArray = JsonConvert.DeserializeObject<List<string>>(emptyData);
                //var json_answer = allQuestions[GAME_INDEX].result as List<object>;
                List<string> json_answer = JsonConvert.DeserializeObject<List<string>>(allQuestions[GAME_INDEX].result.ToString());
                if (json_answer != null || json_answer.Count == 0)
                {
                    /* 정답을 찾지 못함 */
                    Debug.WriteLine($"{GAME_INDEX} 항목에 정답이 없습니다");
                }
                List<string> correctAnswer = json_answer
                    .Select(a => a.ToString().Replace(" ", "").ToUpper())
                    .ToList();
                string input = txt_input2.Text.Replace(" ", "").ToUpper();
                List<string> inputAnswers = input.Split(',').Select(s => s.Trim()).ToList();

                bool isCorrect;
                if (inputAnswers.Count != correctAnswer.Count)
                {
                    isCorrect = false;
                }
                else
                {
                    isCorrect = inputAnswers.SequenceEqual(correctAnswer);
                }

                if (isCorrect)
                {
                    NOW_FAILD = 0;
                    GAME_TURN++;
                    txt_input2.Text = "";
                    if(_setting.AnswerType == "Sequential") { GAME_INDEX++; }
                    startQuestion();
                }
                else
                {
                    NOW_FAILD++;
                    if (NOW_FAILD >= 5)
                    {
                        MessageBox.Show($"{NOW_FAILD}회 실패. 정답은 < {string.Join(", ", json_answer)} > 입니다.", "문제 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (NOW_FAILD == 5)
                        {
                            failQuestions.Add(allQuestions[GAME_INDEX]);
                            ALL_FAILD++;
                        }
                    }
                    txt_input2.Text = "";
                }
            }
            printUI(txt_numfail2);
        }

        private void richQuestion1_Click(object sender, EventArgs e)
        {

        }

        private void txt_input_Click(object sender, EventArgs e)
        {
            txt_input.Text = "";
        }

        private void txt_input_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string json_answer = allQuestions[GAME_INDEX].result.ToString();
                string answer = json_answer.Replace(" ", "").ToUpper(); //공백, 영문 처리
                string input = txt_input.Text.Replace(" ", "").ToUpper();
                if (input == answer) //정답
                {
                    NOW_FAILD = 0;
                    GAME_TURN++;
                    txt_input.Text = "";
                    if (_setting.AnswerType == "Sequential") { GAME_INDEX++; } 
                    startQuestion();
                }
                else //오답
                {
                    NOW_FAILD++;
                    if (NOW_FAILD >= 5)
                    {
                        MessageBox.Show($"{NOW_FAILD}회 실패 정답은 < {json_answer} > 입니다.", "");
                        if (NOW_FAILD == 5)
                        {
                            failQuestions.Add(allQuestions[GAME_INDEX]);
                            ALL_FAILD++;
                        }
                    }
                    txt_input.Text = "";
                }
                printUI(txt_numfail);
            }
        }
    }
}
