using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Entity.Entities
{
    public class Parent : BaseEntity<int>
    {
        [Required]
        [StringLength(64)]
        public string Surname { get; set; }
        [Required]
        [StringLength(64)]
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public string Profession { get; set; }
        public string Feedback { get; set; }

        public virtual string FullName
        {
            get
            {
                return $"{this.Surname.Trim()} {this.Name.Trim()}";
            }
        }
    }
}
