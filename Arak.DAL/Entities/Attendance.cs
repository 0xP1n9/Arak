using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Arak.DAL.Entities
{
    public class Attendance
    {

        public int Id { get; set; }
        public AttendanceStatus Status { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public DateTime Date { get; set; } = DateTime.Today;
        public TimeSpan ArrivalTime { get; set; } = DateTime.Now.TimeOfDay;
        public TimeSpan DepartureTime { get; set; } = DateTime.Now.TimeOfDay;


        [ForeignKey("Class")]
        public int? ClassId { get; set; }
        [JsonIgnore]
        public Class? Class { get; set; }

        [ForeignKey("semester")]
        public int? SemesterId { get; set; }
        [JsonIgnore]
        public Semester? Semester { get; set; }

        [ForeignKey("Teacher")]
        public int? TeacherId { get; set; }
        [JsonIgnore]
        public Teacher? Teacher { get; set; }

        [JsonIgnore]
        public ICollection<StudentAttendance> Students { get; set; } = new List<StudentAttendance>();

        public enum AttendanceStatus
        {
            Present = 1,
            Absent = 2,
            Late = 3
        }
    }
}
