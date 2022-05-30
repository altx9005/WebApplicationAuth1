using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationAuth1.Models;

namespace WebApplicationAuth1.Controllers
{
    public class HomeController : Controller
    {

        private TopicsDBContext db = new TopicsDBContext();


        [HttpGet]
        public ActionResult AddTopic(string NameTopic, string Text)
        {
            try
            {

                db.Topics.Add(new Topic { NameTopic = NameTopic, UserName = User.Identity.Name });
                db.Posts.Add( new Post { Text = Text, Author = User.Identity.Name});
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
            


        }
        [HttpGet]
        public ActionResult ViewTopic(int Id)
        {
            var table = from p in db.Posts
                        where p.TopicId == Id
                        select p;
            var nt = from t in db.Topics
                     where t.Id == Id
                     select t;
                             
            ViewBag.Post = table;
            foreach (var st in nt)
            {
                ViewBag.NameTopic = st.NameTopic;
                ViewBag.TopicId = Id;
            }

            //ViewBag.CurrentUser = User.Identity.Name;


            return View("~/Views/Home/ViewTopic.cshtml");
        }

        [HttpGet]
        public ActionResult AddPost(string Text, int TopicId)
        {
            
            
            db.Posts.Add(new Post { Text = Text, Author = User.Identity.Name, TopicId = TopicId });
            db.SaveChanges();
            //ViewTopic(TopicId);

            var table = from p in db.Posts
                        where p.TopicId == TopicId
                        select p;
            var nt = from t in db.Topics
                     where t.Id == TopicId
                     select t;

            ViewBag.Post = table;
            foreach (var st in nt)
            {
                ViewBag.NameTopic = st.NameTopic;
                ViewBag.TopicId = TopicId;
            }

            return View("~/Views/Home/ViewTopic.cshtml");

        }

        public ActionResult EditTopic(int Id, int TopicId)
        {
            var table = from p in db.Posts
                        where p.Id == Id && p.TopicId == TopicId
                        select p;
            //ViewBag.Post = table;
            foreach (var st in table)
            {
                ViewBag.Text = st.Text;
                ViewBag.TopicId = TopicId;
                ViewBag.Id = Id;
            }

            return View("~/Views/Home/ViewTopicEdit.cshtml");

        }

        [HttpGet]
        public ActionResult SaveEditPost(string Text, int TopicId, int Id)
        {
            var table = from p in db.Posts
                        where p.Id == Id && p.TopicId == TopicId
                        select p;
            foreach (var st in table)
            {
                st.Text = Text; 
            }
            db.SaveChanges();

            var table2 = from p in db.Posts
                        where p.TopicId == TopicId
                        select p;
            var nt = from t in db.Topics
                     where t.Id == TopicId
                     select t;

            ViewBag.Post = table2;
            foreach (var st in nt)
            {
                ViewBag.NameTopic = st.NameTopic;
                ViewBag.TopicId = TopicId;
            }

            return View("~/Views/Home/ViewTopic.cshtml");

        }


        public ActionResult Index()
        {
            IEnumerable<Topic> Topics = db.Topics;
            ViewBag.Topics = Topics;
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}