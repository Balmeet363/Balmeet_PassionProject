using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BalmeetPassion_Project.Models
{
    public class poetry
    {

            /* 
                poetries can be described as poetryID,poetryName,PoetryDescription,poetryDate
             */
            public int poetryID { get; set; }
            public string poetryName { get; set; }
            public string poetryDescription { get; set; }
            public string poetryDate { get; set; }
           //representing many artists to many poetries
            public ICollection<Artist> Artists { get; set; }
         
            //reperesenting many comments to poetries
            public ICollection<Comments>Comments { get; set; }

    }
}
