using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BalmeetPassion_Project.Models.ViewModels
{
    public class ShowArtist
    {
        // a selected artist
        public virtual Artist artist { get; set; }
        
        //list of poetries written by an artist
        public List<poetry> poetries { get; set; }

        //showing drop down of all poetries on show artist page 
        public List<poetry> all_poetries { get; set; }
    }
}