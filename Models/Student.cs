using System.ComponentModel.DataAnnotations;

namespace ZawHtutTest.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public Guid UniqueKey { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
