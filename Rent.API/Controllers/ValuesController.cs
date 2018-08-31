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
            Svc.Commit();

            // Create Instructor
            var i = new Instructor { Firstname = "David", Surname = "Tománek", Email = "lakomyd@seznam.cz", MobilPhone = "777555111" };
            i.WageRates.Add(new InstructorWageRate { Default = true, WageRateId = wr1.Id });
            i.WageRates.Add(new InstructorWageRate { Default = false, WageRateId = wr2.Id });
            i.Expertises.Add(new InstructorExpertise { ExpertiseId = e2.Id, ExpertiseLevelId = el2.Id });

            Svc.Commit();
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
