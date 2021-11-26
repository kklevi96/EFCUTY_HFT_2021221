using EFCUTY_HFT_2021221.Logic;
using EFCUTY_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCUTY_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        ICountryLogic cyl;

        public CountryController(ICountryLogic cyl)
        {
            this.cyl = cyl;
        }


        // GET: /country
        [HttpGet]
        public IEnumerable<Country> Get()
        {
            return cyl.ReadAll();
        }

        // GET /country/[id]
        [HttpGet("{id}")]
        public Country Get(int id)
        {
            return cyl.Read(id);
        }

        // POST /country
        [HttpPost]
        public void Post([FromBody] Country value)
        {
            cyl.Create(value);
        }

        // PUT /country
        [HttpPut]
        public void Put([FromBody] Country value)
        {
            cyl.Update(value);
        }

        // /country/[id]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cyl.Delete(id);
        }
    }
}
