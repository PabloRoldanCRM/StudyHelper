using System;
using System.Collections.Generic;
using System.Text;

namespace StudyHelperApp.Model
{
     public class Question
    {
        public int Id { get; set; }
        public string TheQuestion { get; set; }
        public string RawAnswers { get; set; }
        public List<string> Answers { get; set; }
        public string Answer { get; set; }
    }
}
