using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Arak.DAL.Entities
{
    public class Parent 
    {
		public int Id { get; set; }

		[JsonIgnore]
        public ICollection<Student> Students { get; set; } = new List<Student>();

        [ForeignKey("ApplicationUser")]
        public string? ApplicationUserId { get; set; }
        [JsonIgnore]
        public ApplicationUser? ApplicationUser { get; set; }
	}
}
