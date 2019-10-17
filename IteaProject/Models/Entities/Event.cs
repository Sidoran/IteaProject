using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IteaProject.Models.Entities
{
    public class Event
    {
        [Key] public int Id { get; set; }
        [ForeignKey("AgentId")] public Agent  Agent {get;set;}
        public string EventText { get; set; }
        public DateTime EventDate { get; private set; } = DateTime.UtcNow;
    }
}
