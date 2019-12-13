using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Saitynas.Models
{
    public partial class TblUser
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int UserRole { get; set; }
        public string Gender { get; set; }
    }
}
