using System;
using System.Collections.Generic;

namespace TaurusSoftware.WebUntisNet.Types
{
    public class Period
    {
        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int Id { get; set; }

        public List<int> ClassIds { get; set; }
        public List<int> RoomIds { get; set; }
        public List<int> SubjectIds { get; set; }
        public List<int> TeacherIds { get; set; }

        public LessonType LessonType { get; set; }
        public string Text { get; internal set; }

        public string StatisticalFlags { get; set; }
        public Code? Code { get; internal set; }

        //public string code { get; set; }
        //public string statflags { get; set; }
    }
}
