using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyReview2
{
    public class Question
    {
        public int type { get; set; } 
        public object text { get; set; }
        public object result { get; set; }

        public object image { get; set; }

        public object highlightedText { get; set; }
    }
}
