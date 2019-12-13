using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saitynas.Models
{
    public partial class TblRating
    {
        public int RatingId { get; set; }
        public int RatingCreatorId { get; set; }
        public int RatingValue { get; set; }
        [ForeignKey("TblCreator")]
        public TblCreator Creator { get; set; }
    }
}