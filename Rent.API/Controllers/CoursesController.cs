using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rent.Data;
using Rent.Data.Entity;

namespace Rent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IRentService Svc;
        private readonly string userId;

        public CoursesController(IRentService svc)
        {
            Svc = svc;
            userId = "ketnda00";//User.Identity.Name;
        }

        [HttpGet("{id}")]
        public ActionResult<Course> Get(int id)
        {
            return Svc.Courses.Items
                .Include(x => x.Instructors)
                    .ThenInclude(x => x.Instructor)
                .Include(x => x.Language)
                .Include(x => x.LanguageLevel)
                .Include(x => x.Expertise)
                .Include(x => x.ExpertiseLevel)
                .Include(x => x.RentalPlace)
                .FirstOrDefault(x => x.Id == id);
        }


    }
}