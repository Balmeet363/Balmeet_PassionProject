using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BalmeetPassion_Project.Models;
namespace BalmeetPassion_Project.Data
{
    public class passionproject:DbContext
    {
        public passionproject():base("name=passionproject")
        {

        }

        public System.Data.Entity.DbSet<BalmeetPassion_Project.Models.Artist> Artists { get; set; }

        public System.Data.Entity.DbSet<BalmeetPassion_Project.Models.poetry> Poetries { get; set; }

        public System.Data.Entity.DbSet<BalmeetPassion_Project.Models.Comments> comments { get; set; }

    }
}