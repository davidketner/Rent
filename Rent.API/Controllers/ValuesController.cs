using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rent.Data;
using Rent.Data.Entity;

namespace Rent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IRentService Svc;
        private readonly string userId = "davidketner";

        public ValuesController(IRentService svc)
        {
            Svc = svc;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            //Service Testing //

            // Create Languages
            var l1 = new Language { Shortname = "CZ", Name = "Čeština" };
            var l2 = new Language { Shortname = "AJ", Name = "Angličtina" };
            var l3 = new Language { Shortname = "NJ", Name = "Němčina" };
            Svc.CreateLanguage(l1, userId);
            Svc.CreateLanguage(l2, userId);
            Svc.CreateLanguage(l3, userId);

            // Create LanguageLevels
            var ll1 = new LanguageLevel { Name = "A1", Level = 1 };
            var ll2 = new LanguageLevel { Name = "A2", Level = 2 };
            var ll3 = new LanguageLevel { Name = "B1", Level = 3 };
            var ll4 = new LanguageLevel { Name = "B2", Level = 4 };
            var ll5 = new LanguageLevel { Name = "C1", Level = 5 };
            Svc.CreateLanguageLevel(ll1, userId);
            Svc.CreateLanguageLevel(ll2, userId);
            Svc.CreateLanguageLevel(ll3, userId);
            Svc.CreateLanguageLevel(ll4, userId);
            Svc.CreateLanguageLevel(ll5, userId);

            // Create Expertises
            var e1 = new Expertise { Name = "Snowbord", Shortname = "SNB" };
            var e2 = new Expertise { Name = "Lyžování", Shortname = "SKI" };
            Svc.CreateExpertise(e1, userId);
            Svc.CreateExpertise(e2, userId);

            // Create ExpertiseLevels
            var el1 = new ExpertiseLevel { Name = "Začátečník", Shortname = "ZA", Level = 1 };
            var el2 = new ExpertiseLevel { Name = "Mírně pokročilý", Shortname = "MP", Level = 2 };
            var el3 = new ExpertiseLevel { Name = "Pokročilý", Shortname = "PO", Level = 3 };
            Svc.CreateExpertiseLevel(el1, userId);
            Svc.CreateExpertiseLevel(el2, userId);
            Svc.CreateExpertiseLevel(el3, userId);

            // Create WageRates
            var wr1 = new WageRate { Name = "Hodinová standart", Rate = 160, Percental = false };
            var wr2 = new WageRate { Name = "Procentuální standart", Rate = 10, Percental = true };
            Svc.CreateWageRate(wr1, userId);
            Svc.CreateWageRate(wr2, userId);
            //

            // Create Company
            var company = new Company { Name = "Ski Rychleby", UniqueIndex = 46 };
            Svc.CreateCompany(company, userId);
            //

            // Create Rentals 
            var r1 = new Rental { Name = "Travná", Shortname = "Travná", City = "Travná", Company = company, Country = "Česká republika" };
            var r2 = new Rental { Name = "Zálesí", Shortname = "Zálesí", City = "Zálesí", Company = company, Country = "Česká republika" };
            Svc.CreateRental(r1, userId);
            Svc.CreateRental(r2, userId);
            //

            // Create Tickets
            var t1 = new Ticket { Name = "Celosezónní", Rental = r1 };
            var t2 = new Ticket { Name = "Dopolední", Rental = r1 };
            var t3 = new Ticket { Name = "Celosezónní", Rental = r2 };
            Svc.CreateTicket(t1, userId);
            Svc.CreateTicket(t2, userId);
            Svc.CreateTicket(t3, userId);
            //

            Svc.Commit();

            // Create Rental Places
            var rp1 = new RentalPlace { Name = "U sjezdovky", Description = "Místo pro sraz", RentalId = r1.Id };
            var rp2 = new RentalPlace { Name = "U vleku", RentalId = r1.Id };
            Svc.CreateRentalPlace(rp1, userId);
            Svc.CreateRentalPlace(rp2, userId);
            Svc.Commit();
            //

            // Create Instructor
            var i = new Instructor { Firstname = "David", Surname = "Tománek", Email = "lakomyd@seznam.cz", MobilPhone = "777555111" };
            i.WageRates.Add(new InstructorWageRate { Default = true, WageRateId = wr1.Id });
            i.WageRates.Add(new InstructorWageRate { Default = false, WageRateId = wr2.Id });
            i.Expertises.Add(new InstructorExpertise { ExpertiseId = e2.Id, ExpertiseLevelId = el2.Id });
            i.Expertises.Add(new InstructorExpertise { ExpertiseId = e2.Id, ExpertiseLevelId = el3.Id });
            i.Rentals.Add(new InstructorRental { RentalId = r1.Id });
            i.Rentals.Add(new InstructorRental { RentalId = r2.Id });
            i.Tickets.Add(new InstructorTicket { TicketId = t1.Id, From = DateTime.Now, To = DateTime.Now.AddDays(50) });
            i.Tickets.Add(new InstructorTicket { TicketId = t3.Id, From = DateTime.Now, To = DateTime.Now.AddDays(50) });
            i.Languages.Add(new InstructorLanguage { LanguageId = l2.Id, LanguageLevelId = ll2.Id });
            i.Languages.Add(new InstructorLanguage { LanguageId = l3.Id, LanguageLevelId = ll1.Id });
            i.Languages.Add(new InstructorLanguage { LanguageId = l2.Id, LanguageLevelId = ll4.Id });
            i.Languages.Add(new InstructorLanguage { LanguageId = l2.Id, LanguageLevelId = ll5.Id });
            Svc.CreateInstructor(i, userId);
            Svc.Commit();
            //

            // Create Availabilities
            var a1 = new InstructorAvailability { InstructorId = i.Id, From = new DateTime(2018, 9, 6, 8, 0, 0), To = new DateTime(2018, 9, 9, 16, 30, 0) };
            var a2 = new InstructorAvailability { InstructorId = i.Id, From = new DateTime(2018, 9, 11, 10, 0, 0), To = new DateTime(2018, 9, 11, 16, 0, 0) };
            var avais = new List<InstructorAvailability>() { a1, a2 };
            Svc.CreateInstructorAvailability(avais, userId);
            Svc.Commit();
            //

            // Create Courses
            var c1 = new Course { Name = "Ovesný - děti", From = new DateTime(2018, 9, 6, 8, 0, 0), To = new DateTime(2018, 9, 6, 10, 0, 0), ExpertiseId = e2.Id, ExpertiseLevelId = el2.Id, RentalId = r1.Id, LanguageId = l2.Id, RentalPlaceId = rp1.Id };
            var c2 = new Course { Name = "Toman - děti", From = new DateTime(2018, 9, 6, 9, 0, 0), To = new DateTime(2018, 9, 6, 11, 0, 0), ExpertiseId = e2.Id, ExpertiseLevelId = el2.Id, RentalId = r1.Id, LanguageId = l2.Id, RentalPlaceId = rp1.Id };
            var c3 = new Course { Name = "Dominik", From = new DateTime(2018, 9, 6, 10, 0, 0), To = new DateTime(2018, 9, 6, 11, 0, 0), ExpertiseId = e2.Id, ExpertiseLevelId = el2.Id, RentalId = r1.Id, LanguageId = l2.Id, RentalPlaceId = rp1.Id };
            var c4 = new Course { Name = "Lubos - děti", From = new DateTime(2018, 9, 5, 8, 0, 0), To = new DateTime(2018, 9, 5, 10, 0, 0), ExpertiseId = e2.Id, ExpertiseLevelId = el2.Id, RentalId = r1.Id, LanguageId = l2.Id, RentalPlaceId = rp1.Id };
            c1.Instructors.Add(new InstructorCourse { InstructorId = i.Id });
            c2.Instructors.Add(new InstructorCourse { InstructorId = i.Id });
            c3.Instructors.Add(new InstructorCourse { InstructorId = i.Id });
            c4.Instructors.Add(new InstructorCourse { InstructorId = i.Id });
            Svc.CreateCourse(c1, userId);
            Svc.Commit();
            Svc.CreateCourse(c2, userId);
            Svc.Commit();
            Svc.CreateCourse(c3, userId);
            Svc.Commit();
            Svc.CreateCourse(c4, userId);
            Svc.Commit();
            //

            // End Testing //
            return "[value1, value2]";
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
