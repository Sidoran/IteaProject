using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IteaProject.Models.Entities
{
    public class RunTask
    {
        [Key] public int Id { get; set; }
        [ForeignKey("RunBookId")] public RunBook RunBook { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime WhenCreated { get; set; }
        public DateTime WhenChanged { get; set; }
        public bool IsActive { get; set; }
        public int RunbookOrder { get; set; }
    }
}
