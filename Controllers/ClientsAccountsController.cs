using Microsoft.AspNetCore.Mvc;
using FinancialAccounting.Models;
using FinancialAccounting.Data;
namespace FinancialAccounting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsAccountsController : ControllerBase
    {
        // GET: api/<ClientsAccountsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ClientsAccountsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ClientsAccountsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ClientsAccountsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClientsAccountsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
