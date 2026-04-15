using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Arak.DAL.Entities
{
    public class Semester
    {
        public int Id { get; set; }
        public SemesterName Name { get; set; }
        public string AcademicYear { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("TimeTable")]
        public int? TimeTableId { get; set; }
        [JsonIgnore]
        public TimeTable? TimeTable { get; set; }

        [JsonIgnore]
        public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

        [JsonIgnore]
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

        [JsonIgnore]
        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();

        [JsonIgnore]
        public ICollection<TeacherSemester> Teachers { get; set; } = new List<TeacherSemester>();

        public enum SemesterName
        {
            First = 1,
            Second = 2,
            Summer = 3
        }
    }
}
