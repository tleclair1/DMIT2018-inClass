using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSchool
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("name=SchoolDb")
        {

        }
        public DbSet<Course> Courses { get; set; }
    }
    [Table("Courses")]
    public class Course
    {
        public int CourseID { get; set; } // EF will accept this as a PK, by its default convention
        [StringLength(10)]
        public string CatalogNumber { get; set; }
        [StringLength(82)]
        public string Name { get; set; }
        public int Hours { get; set; }
    }
}
