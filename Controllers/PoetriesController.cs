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
    public class PoetriesController : Controller
    {
        // GET: Poetry
        private passionproject db = new passionproject();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
           //query to select all poetries
            string query = "Select * from poetries";
            
            List<poetry> poetries = db.Poetries.SqlQuery(query).ToList();
            //displaying all the poetries 
            return View(poetries);
        }
        public ActionResult Add()
        {
            return View();
        }
        //Adding a poetry into database
        [HttpPost]
        public ActionResult Add(string PoetryName, string PoetryDate, string PoetryDesc)
        {
            string query = "insert into poetries (poetryName, poetryDate, poetryDescription) values (@PoetryName, @PoetryDate, @PoetryDesc)";
            Debug.WriteLine("I am pulling data of :" + PoetryName + " " + PoetryDate + " " + PoetryDesc);
            SqlParameter[] sqlparams = new SqlParameter[3]; //sql parameter of size 3
            
            sqlparams[0] = new SqlParameter("@PoetryName", PoetryName);//1st item poetryname
            sqlparams[1] = new SqlParameter("@PoetryDate", PoetryDate);//2nd item poetrtDate
            sqlparams[2] = new SqlParameter("@PoetryDesc", PoetryDesc);//3rd item poetryDesc


            db.Database.ExecuteSqlCommand(query, sqlparams);

            return RedirectToAction("List");
        }

        // Showing details of poetry

        public ActionResult Show(int id)
        {
            string query = "select * from poetries where poetryid = @id";
            var parameter = new SqlParameter("@id", id);
            poetry selectedpoetry = db.Poetries.SqlQuery(query, parameter).FirstOrDefault();

            return View(selectedpoetry);
        }
        
        //updating a poetry
        public ActionResult Update(int id)
        {
            //query to select selected poetry and displaying data in form
            string query = "select * from poetries where poetryid = @id";
            var parameter = new SqlParameter("@id", id);
            poetry selectedpoetry = db.Poetries.SqlQuery(query, parameter).FirstOrDefault();

            return View(selectedpoetry);
        }
        //function to update poetry upon clicking of button
        [HttpPost]
        public ActionResult Update(int id, string PoetryName, string PoetryDate, string PoetryDesc)
        {
            string query = "update poetries set poetryName = @PoetryName,poetryDate = @PoetryDate,poetryDescription = @PoetryDesc where poetryid = @id";
            Debug.WriteLine("I am pulling data of :" + PoetryName + " " + PoetryDate + " " + PoetryDesc);
            SqlParameter[] sqlparams = new SqlParameter[4];//sql parameter with size 4
            sqlparams[0] = new SqlParameter("@PoetryName", PoetryName);//1st item poetryName
            sqlparams[1] = new SqlParameter("@PoetryDate", PoetryDate);//2nd item poetryDate
            sqlparams[2] = new SqlParameter("@PoetryDesc", PoetryDesc);//3rd item poetryDesc
            sqlparams[3] = new SqlParameter("@id", id);//4th item id
            db.Database.ExecuteSqlCommand(query, sqlparams);
            //redirecting to list page afer updsating
            return RedirectToAction("List");
        }
        //function deleteConfirm
        public ActionResult DeleteConfirm(int id)
        {
            string query = "select * from poetries where poetryid=@id";
            SqlParameter param = new SqlParameter("@id", id);
            poetry selectedpoetry = db.Poetries.SqlQuery(query, param).FirstOrDefault();
            return View(selectedpoetry);
        }

        //function Delete
        [HttpPost]
        public ActionResult Delete(int id)
        {
            string query = "delete from poetries where poetryid=@id";
            SqlParameter param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);
            return RedirectToAction("List");
        }

    }
}