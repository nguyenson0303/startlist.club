﻿using System;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FlightJournal.Web.Models;

namespace FlightJournal.Web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ClubController : Controller
    {
        private FlightContext db = new FlightContext();

        public static Club CurrentClub
        {
            get {
                return GetCurrentClub();
            }
        }

        /// <summary>
        /// Method parameters allows for UnitTesting 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="routeData"></param>
        /// <returns></returns>
        public static Club GetCurrentClub(HttpContextBase context, RouteData routeData)
        {
            
            // Fetch from URL 
            var urlClubFilter = routeData.Values["club"] as string;

            // If in the direct access we can be dealing with /{ClubId}
            if (urlClubFilter == null && context.Request.Url != null)
            {
                var absolutePath = context.Request.Url.AbsolutePath;
                // Handle switching between one club to another
                if (absolutePath == "/Club/SetCurrentClub" && context.Request.UrlReferrer != null)
                {
                    urlClubFilter = context.Request.UrlReferrer.AbsolutePath.Split('/').FirstOrDefault(d => !string.IsNullOrWhiteSpace(d));
                    urlClubFilter = context.Server.UrlDecode(urlClubFilter);
                }
            }

            // Return Session Cache if set
            if (context.Items["CurrentClub"] != null)
            {
                var ghostClubSession = context.Items["CurrentClub"] as Club;
                if (ghostClubSession != null && Equals(ghostClubSession.ShortName, urlClubFilter))
                {
                    return ghostClubSession;
                }
            }

            // Read Url
            if (urlClubFilter != null && !string.IsNullOrWhiteSpace(urlClubFilter))
            {
                Club ghost = new Club();
                using (var shortDb = new FlightContext())
                {
                    var club = shortDb.Clubs.SingleOrDefault(d => d.ShortName == urlClubFilter);
                    if (club != null)
                    {
                        ghost = new Club();
                        ghost.LocationId = club.LocationId;
                        ghost.Location = club.Location; // for allowing country
                        ghost.ContactInformation = club.ContactInformation;
                        ghost.ShortName = club.ShortName;
                        ghost.Name = club.Name;
                        if (club.Website != null && (club.Website.StartsWith("http://") || club.Website.StartsWith("https://")))
                        {
                            ghost.Website = club.Website;
                        }
                        else if (club.Website != null)
                        {
                            ghost.Website = "http://" + club.Website;
                        }
                        ghost.ClubId = club.ClubId;
                    }
                }

                // Set Session Cache
                context.Items.Remove("CurrentClub");
                context.Items.Add("CurrentClub", ghost);

                // Return Current Club
                return ghost;
            }
            return new Club();
        }

        public static Club GetCurrentClub()
        {
            var context = new HttpContextWrapper(System.Web.HttpContext.Current);
            var routeData = RouteTable.Routes.GetRouteData(context);
            if (routeData == null)
            {
                // Return empty object for allowing more optimize linq request on the filtered data
                return new Club();
            }

            return GetCurrentClub(context, routeData);
        }

        /// <summary>
        /// Used by main layout for header switch between flight club filters
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public PartialViewResult ClubSelector()
        {
            return this.PartialView(db.Clubs.Where(p=>p.Visible).OrderBy(c=>c.Name).ToList());
        }

        /// <summary>
        /// Used by info page to present the club information and introduce the club filter
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public PartialViewResult ClubPresentation()
        {
            return this.PartialView(db.Clubs.OrderBy(c => c.Name).ToList());
        }

        /// <summary>
        /// Redirect the visitor to the actual path and adding the current club identifier to the Url
        /// </summary>
        /// <param name="shortName"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateInput(false)]
        public void SetCurrentClub(string shortName)
        {
            var club = this.db.Clubs.SingleOrDefault(d => d.ShortName == shortName);

            // Return to actual path
            if (club != null && this.Request.UrlReferrer != null && this.Request.UrlReferrer.AbsolutePath != "/Club/SetCurrentClub")
            {
                if (CurrentClub != null && !string.IsNullOrWhiteSpace(CurrentClub.ShortName))
                {
                    // HACK: the original implementation has a bug because UrlPathEncode sends back encoded danish characters with little c instead of big C like from the original raw request, so we dont match (avoid this implementation). 
                    /// var redirectPath = this.Request.UrlReferrer.AbsolutePath.Replace(this.Server.UrlPathEncode(CurrentClub.ShortName), club.ShortName);
                    // Find the first url element 
                    var currentClubUrl = this.Request.UrlReferrer.AbsolutePath.Split('/').FirstOrDefault(d => !string.IsNullOrWhiteSpace(d));
                    if (!string.IsNullOrWhiteSpace(currentClubUrl))
                    {
                        // Redirect on the same path as was allready filtered but with another clubfilter.
                        var redirectPath = this.Request.UrlReferrer.AbsolutePath.Replace(currentClubUrl, club.ShortName);
                        this.Response.Redirect(redirectPath, true);
                        return;
                    }
                    else
                    {
                        // handle any parsing errors by falling back to the primary club page url
                        this.Response.Redirect(string.Concat("/",club.ShortName), true);
                        return;
                    }
                }
                // Redirecting from empty to club filtered path
                var liveRedirectPath = string.Format("/{0}{1}", club.ShortName, this.Request.UrlReferrer.AbsolutePath);
                this.Response.Redirect(liveRedirectPath, true);
                return;
            }
            else if (string.IsNullOrWhiteSpace(shortName))
            {
                // We are redirecting from an actual club to an empty club - remove the club part of the url
                var currentClubUrl = this.Request.UrlReferrer.AbsolutePath.Split('/').FirstOrDefault(d => !string.IsNullOrWhiteSpace(d));
                if (currentClubUrl != null)
                {
                    var redirectPath = this.Request.UrlReferrer.AbsolutePath.Replace("/" + currentClubUrl, string.Empty);
                    this.Response.Redirect(redirectPath, true);
                }
            }
        }

        //
        // GET: /Club/
        public ViewResult Index()
        {
            return View(db.Clubs.Where(c=> c.ClubId > 0).ToList()); // hide system club for missing -2 or unknown club -1
        }

        //
        // GET: /Club/Details/5
        public ViewResult Details(int id)
        {
            Club club = db.Clubs.Find(id);
            return View(club);
        }

        //
        // GET: /Club/Create
        public ActionResult Create()
        {
            this.ViewBag.LocationId = new SelectList(this.db.Locations.OrderBy(p => p.Name), "LocationId", "Name");
            return View();
        }

        //
        // POST: /Club/Create

        [HttpPost]
        public ActionResult Create(Club club)
        {
            if (ModelState.IsValid)
            {
                db.Clubs.Add(club);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(club);
        }

        //
        // GET: /Club/Edit/5
        public ActionResult Edit(int id)
        {
            Club club = db.Clubs.Find(id);
            this.ViewBag.LocationId = new SelectList(this.db.Locations.OrderBy(p => p.Name), "LocationId", "Name", (club == null) ? (object)null : club.LocationId);
            return View(club);
        }

        //
        // POST: /Club/Edit/5

        [HttpPost]
        public ActionResult Edit(Club club)
        {
            if (ModelState.IsValid)
            {
                db.Entry(club).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(club);
        }

        //
        // GET: /Club/Delete/5
        public ActionResult Delete(int id)
        {
            Club club = db.Clubs.Find(id);
            this.ViewBag.LocationId = new SelectList(this.db.Locations.OrderBy(p => p.Name), "LocationId", "Name", (club == null) ? (object)null : club.LocationId);
            return View(club);
        }

        //
        // POST: /Club/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Club club = db.Clubs.Find(id);
            db.Clubs.Remove(club);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}