﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinancialAccounting.Models;
using FinancialAccounting.Data;

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

        // Creat/Edit
        //[HttpPost]
        //public JsonResult CreateEdit(SiteRegistration siteRegistration)
        //{
        //    if (siteRegistration.Id == 0)
        //    {
        //        _context.Registrations.Add(siteRegistration);
        //    }
        //    else
        //    {
        //        var registrationInDb = _context.Registrations.Find(siteRegistration);

        //        if (registrationInDb == null)
        //            return new JsonResult(NotFound());
        //        registrationInDb = siteRegistration;
        //    }

        //    _context.SaveChanges();
        //    return new JsonResult(Ok(siteRegistration));
        //}

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
                registrationInDb.Property1 = siteRegistration.Property1; // пример замены свойств
                                                                         // Добавьте сюда присваивание остальных свойств
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
