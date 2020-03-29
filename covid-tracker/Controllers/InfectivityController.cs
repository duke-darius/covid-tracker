using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using covid_tracker.Data;
using covid_tracker.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace covid_tracker.Controllers
{
    [Authorize]
    public class InfectivityController : Controller
    {
        public ApplicationDbContext ctx { get; set; }
        public ApplicationUser User { get; set; }

        public InfectivityController(ApplicationDbContext _ctx, IHttpContextAccessor httpContextAccessor)
        {
            ctx = _ctx;
            var uid = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (uid != null)
            {
                User = ctx.Users.FirstOrDefault(x => x.Id == uid);
            }
            User.AgeInYears = 22;
            ctx.SaveChanges();
        }

        // GET: Infectivity
        public ActionResult Index()
        {
            return View(User);
        }


        public ActionResult Update([FromQuery] string isConfirmed, [FromQuery] string confirmationDate, [FromQuery] string isSymptomatic, [FromQuery] string symptomStartDate)
        {
            User.IsConfirmed = (isConfirmed == "on");
            if (!string.IsNullOrEmpty(confirmationDate))
            {
                var cd = confirmationDate.Split("-");
                User.ConfirmationDate = new DateTime(int.Parse(cd[0]), int.Parse(cd[1]), int.Parse(cd[2]));
            }


            User.IsSymptomatic = (isSymptomatic == "on");
            if (!string.IsNullOrEmpty(symptomStartDate))
            {
                var cd = symptomStartDate.Split("-");
                User.SymptomStartDate = new DateTime(int.Parse(cd[0]), int.Parse(cd[1]), int.Parse(cd[2]));
            }

            ctx.SaveChanges();

            return Redirect("/Infectivity");
        }

    }
}