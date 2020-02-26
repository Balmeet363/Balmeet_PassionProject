using System;
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
using BalmeetPassion_Project.Models.ViewModels;

using System.Diagnostics;
using System.IO;

namespace BalmeetPassion_Project.Controllers
{
    public class ArtistController : Controller
    {
        // GET: Artist
        private passionproject db = new passionproject();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            
            // query to get all the artists and display them as an list
            string query = "Select * from artists";
            List<Artist> artists = db.Artists.SqlQuery(query).ToList();
            return View(artists);

        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        // query ro add artist into database
        public ActionResult Add(string ArtistName, string ArtistDOB, string ArtistEmail, string ArtistContact)
        {
            string query = "insert into artists (Name, DOB, Contact, Email) values (@ArtistName,@ArtistDOB,@ArtistContact,@ArtistEmail)";
            Debug.WriteLine("I am pulling data of :"+ArtistEmail + " " + ArtistDOB + " " + ArtistEmail + " " + ArtistContact);
            SqlParameter[] sqlparams = new SqlParameter[4];//sql parameter with sze 4
            sqlparams[0] = new SqlParameter("@ArtistName", ArtistName);//ist item
            sqlparams[1] = new SqlParameter("@ArtistDOB", ArtistDOB);//2nd item
            sqlparams[2] = new SqlParameter("@ArtistEmail", ArtistEmail);//3rd item
            sqlparams[3] = new SqlParameter("@ArtistContact", ArtistContact);//4th item

            db.Database.ExecuteSqlCommand(query, sqlparams);
            //after inserting redirecting to list page
            return RedirectToAction("List");
        }
        // update function to refill data in the form
        public ActionResult Update(int id)
        {
            string query = "select * from artists where artistid = @id";
            var parameter = new SqlParameter("@id", id);
            Artist selectedartist = db.Artists.SqlQuery(query, parameter).FirstOrDefault();

            return View(selectedartist);
        }
        //query to update data
        [HttpPost]
        public ActionResult Update(int id, string ArtistName, string ArtistDOB, string ArtistEmail, string ArtistContact)
        {
            string query = "update artists set Name = @ArtistName,DOB = @ArtistDOB,Email = @ArtistEmail, Contact = @ArtistContact where artistid = @id";
            Debug.WriteLine("I am pulling data of :" + ArtistEmail + " " + ArtistDOB + " " + ArtistEmail + " " + ArtistContact);
            SqlParameter[] sqlparams = new SqlParameter[5];//sql parameter array with size 5
            sqlparams[0] = new SqlParameter("@ArtistName", ArtistName);//1st item
            sqlparams[1] = new SqlParameter("@ArtistDOB", ArtistDOB);//2nd item
            sqlparams[2] = new SqlParameter("@ArtistEmail", ArtistEmail);//3rd item
            sqlparams[3] = new SqlParameter("@ArtistContact", ArtistContact);//4th item
            sqlparams[4] = new SqlParameter("@id", id);//5th item
            db.Database.ExecuteSqlCommand(query, sqlparams);

            return RedirectToAction("List");
        }


        public ActionResult DeleteConfirm(int id)
        {
            //query to select artistID matches with id
            string query = "select * from artists where artistID=@id";
            SqlParameter param = new SqlParameter("@id", id);
            Artist selectedartist = db.Artists.SqlQuery(query, param).FirstOrDefault();
            return View(selectedartist);
        }
        //function to delete an artist
        [HttpPost]
        public ActionResult Delete(int id)
        {
            string query = "delete from artists where artistid=@id";
            SqlParameter param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);

            return RedirectToAction("List");
        }
        // showing an artist
        public ActionResult Show(int id)
        {
            //query to select an particular artist
            string query = "select * from artists where artistid = @id";
            var parameter = new SqlParameter("@id", id);
            Artist selectedartist = db.Artists.SqlQuery(query, parameter).FirstOrDefault();

            // query to inner join poetryArtists in order to recieve poetries written by an artist
            string aside_query = "select * from artists inner join poetryArtists on artists.artistID = poetryArtists.artist_artistID where poetryArtists.poetry_poetryID=@id";
            var parameter1 = new SqlParameter("@id", id);
            List<poetry> poetrieswritten = db.Poetries.SqlQuery(aside_query, parameter1).ToList();

            //query to select all the artists
            string all_poetries_query = "select * from poetries";
            List<poetry> AllPoetries = db.Poetries.SqlQuery(all_poetries_query).ToList();

            //creating viewmodel
            ShowArtist viewmodel = new ShowArtist();
            viewmodel.artist = selectedartist;//gathering a selected clicked artist
            viewmodel.poetries = poetrieswritten;//gathering poetries written by artist
            viewmodel.all_poetries = AllPoetries;//collecting all the poetries in database
            return View(viewmodel);
        }
    }
}