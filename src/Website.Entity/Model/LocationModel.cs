﻿
using System.ComponentModel.DataAnnotations;

namespace Website.Entity.Model
{
    public class LocationBasePageInputModel : BasePageInputModel
    {
        public int ParentId { get; set; }
        public string Type { get; set; }
    }

    public class LocationInputModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Status { get; set; }
        public int ParentId { get; set; }
    }

    public class LocationOutputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public int ParentId { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUser { get; set; }
    }
}
