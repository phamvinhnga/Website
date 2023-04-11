﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Entity.Entities
{
    public class Teacher : BaseEntity<int>
    {
        [Required]
        [StringLength(64)]
        public string Surname { get; set; }
        [Required]
        [StringLength(64)]
        public string Name { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string Thumbnail { get; set; }
        public int SpecializedId { get; set; }
        [ForeignKey("SpecializedId")]
        public Specialized Specialized { get; set; }
        public virtual string FullName
        {
            get
            {
                return $"{this.Surname.Trim()} {this.Name.Trim()}";
            }
        }
    }
}
