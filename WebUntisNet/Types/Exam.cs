using System;
using System.Collections.Generic;

namespace WebUntisNet.Types
{
    public class Exam
    {
        public int Id { get; set; }
        public List<int> ClassesIds { get; set; }
        public List<int> TeacherIds { get; set; }
        public List<int> StudentIds { get; set; }
        public int SubjectId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
