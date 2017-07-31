using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReviewSite.Models
{
    public class Reviewer
    {
        [Key]
        public int ReviewerID { get; set; }
        public string Name { get; set; }
        public DateTime DateJoined { get; set; }
        public string ReviewerImage { get; set; }
        public string ReviewerBio { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}