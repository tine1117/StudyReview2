using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyReview2
{
    public class Setting
    {
        public bool[] GameTypes { get; set; } //문제 타입 주관식, 다관식, 객관식

        public string AnswerType { get; set; } //랜덤, 순차
        public string SolveType { get; set; }  // 전체풀기, 선택풀기
        public int ProblemCount { get; set; } //순차풀기 일시 문제 풀이 개수
        public bool IsRetryWrong { get; set; } //재풀이 여부
        public string [] Database { get; set; } 


    }
}
