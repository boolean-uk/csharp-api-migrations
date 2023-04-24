using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_api_migrations.Main.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Lecturer Lecturer { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();

    }
}
