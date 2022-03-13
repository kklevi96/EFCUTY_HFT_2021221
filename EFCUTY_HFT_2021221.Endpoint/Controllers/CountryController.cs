using EFCUTY_HFT_2021221.Logic;
using EFCUTY_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCUTY_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        ICountryLogic cyl;
        private readonly IHubContext<SignalRHub> hub;

        public CountryController(ICountryLogic cyl, IHubContext<SignalRHub> hub)
        {
            this.cyl = cyl;
            this.hub = hub;
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
