using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BalmeetPassion_Project.Models
{
    public class Comments
    {
        /* 
            Comments are described with commentID and commentDescription take as commentDesc
         */
        [Key]
        public int commentID { get; set; }
        public string commentDesc { get; set; }
        //foreign key poetryID
        public int poetryID { get; set; }
        [ForeignKey("poetryID")]

        //representing many comments to poetries
        public virtual poetry Poetries { get; set; }
    }
}