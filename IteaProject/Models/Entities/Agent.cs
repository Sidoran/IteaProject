using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IteaProject.Models.Interfaces;

namespace IteaProject.Models.Entities
{
    public class Agent
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public string AccessToken { get; set;}
    }
}
