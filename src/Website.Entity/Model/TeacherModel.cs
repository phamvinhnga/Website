using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Entity.Entities;

namespace Website.Entity.Model
{
    public class TeacherInputModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(64)]
        public string Surname { get; set; }
        [Required]
        [StringLength(64)]
        public string Name { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public int SpecializedId { get; set; }
        public FileModel Thumbnail { get; set; }
    }

    public class TeacherOutputModel
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public int SpecializedId { get; set; }
        public FileModel Thumbnail { get; set; }
        public SpecializedModel Specialized { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUser { get; set; }
    }
}
