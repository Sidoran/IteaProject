using IteaProject.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IteaProject.Models.Database
{
    public class ProjectDbContext:DbContext
    {
        public  DbSet<Agent> Agents { get; set; }
        public DbSet<RunBook> RunBooks { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<RunTask> RunTasks { get; set; }
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {
        }
    }
}
