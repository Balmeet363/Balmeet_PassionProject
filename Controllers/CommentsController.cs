using System;
using System.Collections.Generic;
using System.Data;
//required for SqlParameter class
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BalmeetPassion_Project.Data;
using BalmeetPassion_Project.Models;
using System.Diagnostics;
using System.IO;

namespace BalmeetPassion_Project.Controllers
{
    public class CommentsController : Controller
    {
        // GET: Comments
        private passionproject db = new passionproject();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
           // Selecting all the poetries and displaying them in a list so that a particular comment can be applied to
            List<Comments> comments = db.comments.SqlQuery("select * from poetries").ToList();
            return View(comments);
        }

        //Adding an comment
        public ActionResult Add()
        {
            return View();
        }
        //deleting an comment
        public ActionResult DeleteConfirm()
        {
            return View();
        }

        //updatinf comment
        public ActionResult Update()
        {

            return View();
        }

        //Showing a comment
        public ActionResult Show()
        {
            return View();
        }

    }
}