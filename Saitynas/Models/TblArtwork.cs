using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saitynas.Models
{
    public partial class TblArtwork
    {
        public int ArtworkId { get; set; }
        [ForeignKey("TblCreator")]
        public int ArtworkCreatorId { get; set; }
        public string ArtworkUrl { get; set; }
        [ForeignKey("TblUser")]
        public int ArtworkOwnerId { get; set; }
        public TblCreator Creator { get; set; }
        public TblUser User { get; set; }
    }
}
