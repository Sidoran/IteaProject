using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IteaProject.Models.Entities
{
    public class RunBook
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime WhenCreated { get; set; }
        public DateTime WhenChanged { get; set; }
        public bool IsActive { get; set; }
        public List<RunTask> Tasks { get; set; }

    }
}
