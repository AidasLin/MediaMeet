using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Saitynas.Models
{
    public partial class TblCreator
    {
        [Key]
        public int CreatorId { get; set; }
        public string Name { get; set; }
        public string Pseudonym { get; set; }
        public string City { get; set; }
        public string Department { get; set; }
    }
}
