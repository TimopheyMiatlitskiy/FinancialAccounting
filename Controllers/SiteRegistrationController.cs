using Microsoft.AspNetCore.Mvc;
using FinancialAccounting.Models;
using FinancialAccounting.Data;
using Microsoft.EntityFrameworkCore;

namespace FinancialAccounting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteRegistrationController : ControllerBase
    {
        private readonly ApiContext _context;

        public SiteRegistrationController(ApiContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateEdit(SiteRegistration siteRegistration)
        {
            if (siteRegistration.Id == 0)
            {
                _context.Registrations.Add(siteRegistration);
            }
            else
            {
                var registrationInDb = _context.Registrations.Find(siteRegistration.Id);

                if (registrationInDb == null)
                    return NotFound();
                registrationInDb.Id = siteRegistration.Id;
            }

            _context.SaveChanges();
            return Ok(siteRegistration);
        }

        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Registrations.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Registrations.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            _context.Registrations.Remove(result);
            _context.SaveChanges();
            return new JsonResult(NoContent());
        }
    }
}