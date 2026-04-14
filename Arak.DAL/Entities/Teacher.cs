using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Arak.DAL.Entities
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        public string TeacherName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public int Experience { get; set; }
        public DateTime DateJoined { get; set; }
        public string Education { get; set; }
        public string? About { get; set; }
        public string? PhotoUrl { get; set; }

        [ForeignKey("Subject")]
        public int? SubjectId { get; set; }
        [JsonIgnore]
        public Subject? Subject { get; set; }

        [ForeignKey("TimeTable")]
        public int? TimeTableId { get; set; }
        [JsonIgnore]
        public TimeTable? TimeTable { get; set; }

        [JsonIgnore]
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

        [JsonIgnore]
        public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

        [JsonIgnore]
        public ICollection<TeacherClass> Classes { get; set; } = new List<TeacherClass>();

        [JsonIgnore]
        public ICollection<TeacherSemester> Semesters { get; set; } = new List<TeacherSemester>();

        [JsonIgnore]
        public ApplicationUser ApplicationUser { get; set; }

    }
}
