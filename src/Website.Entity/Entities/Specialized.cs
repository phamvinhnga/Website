using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Entity.Entities
{
    public class Specialized : BaseEntity<int>
    {
        [Required]
        public string Name { get; set; }

        public ICollection<Teacher> Posts { get; }
    }
}
