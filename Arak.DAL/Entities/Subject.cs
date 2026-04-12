using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Arak.DAL.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? BookUrl { get; set; }

        [ForeignKey("Semester")]
        public int? SemesterId { get; set; }
        [JsonIgnore]
        public Semester? Semester { get; set; }

        [ForeignKey("TimeTable")]
        public int? TimeTableId { get; set; }
        [JsonIgnore]
        public TimeTable? TimeTable { get; set; }

        [JsonIgnore]
        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();

        [JsonIgnore]
        public ICollection<StudentSubject> Students { get; set; } = new List<StudentSubject>();
    }
}
