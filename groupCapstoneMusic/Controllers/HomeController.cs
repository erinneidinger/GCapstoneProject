using groupCapstoneMusic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace groupCapstoneMusic.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
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
        //public jsonresult sendrating(string r, string s, string id, string url)
        //{
        //    int autoid = 0;
        //    int16 thisvote = 0;
        //    int16 sectionid = 0;
        //    int16.tryparse(s, out sectionid);
        //    int16.tryparse(r, out thisvote);
        //    int.tryparse(id, out autoid);

        //    if (!user.identity.isauthenticated)
        //    {
        //        return json("not authenticated!");
        //    }

        //    if (autoid.equals(0))
        //    {
        //        return json("sorry, record to vote doesn't exists");
        //    }

        //    switch (s)
        //    {
        //        case "5": // user voting
        //                  // check if he has already voted
        //        var isIt = db.VoteModels.Where(v => v.SectionId == sectionId &&
        //            v.UserName.Equals(User.Identity.Name, StringComparison.CurrentCultureIgnoreCase) && v.VoteForId == autoId).FirstOrDefault();
        //        if (isIt != null)
        //        {
        //            // keep the school voting flag to stop voting by this member
        //            HttpCookie cookie = new HttpCookie(url, "true");
        //            Response.Cookies.Add(cookie);
        //            return Json("<br />You have already rated this post, thanks !");
        //        }

        //        var sch = db.SchoolModels.Where(sc => sc.AutoId == autoId).FirstOrDefault();
        //        if (sch != null)
        //        {
        //            object obj = sch.Votes;

        //            string updatedVotes = string.Empty;
        //            string[] votes = null;
        //            if (obj != null && obj.ToString().Length > 0)
        //            {
        //                string currentVotes = obj.ToString(); // votes pattern will be 0,0,0,0,0
        //                votes = currentVotes.Split(',');
        //                // if proper vote data is there in the database
        //                if (votes.Length.Equals(5))
        //                {
        //                    // get the current number of vote count of the selected vote, always say -1 than the current vote in the array 
        //                    int currentNumberOfVote = int.Parse(votes[thisVote - 1]);
        //                    // increase 1 for this vote
        //                    currentNumberOfVote++;
        //                    // set the updated value into the selected votes
        //                    votes[thisVote - 1] = currentNumberOfVote.ToString();
        //                }
        //                else
        //                {
        //                    votes = new string[] { "0", "0", "0", "0", "0" };
        //                    votes[thisvote - 1] = "1";
        //                }
        //                //concatenate all arrays now
        //                foreach (string ss in votes)
        //                {
        //                    updatedvotes += ss + ",";
        //                }
        //                updatedvotes = updatedvotes.substring(0, updatedvotes.length - 1);

        //                db.entry(sch).state = entitystate.modified;
        //                sch.votes = updatedvotes;
        //                db.savechanges();

        //                votemodel vm = new votemodel()
        //                {
        //                    active = true,
        //                    sectionid = int16.parse(s),
        //                    username = user.identity.name,
        //                    vote = thisvote,
        //                    voteforid = autoid
        //                };

        //                db.votemodels.add(vm);

        //                db.savechanges();

        //                // keep the school voting flag to stop voting by this member
        //                httpcookie cookie = new httpcookie(url, "true");
        //                response.cookies.add(cookie);
        //            }
        //            break;
        //        default:
        //            break;
        //    }
        //    return json("<br />you rated " + r + " star(s), thanks !");
        //}
    }
}