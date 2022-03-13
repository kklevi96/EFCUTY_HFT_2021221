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
    public class CitizenController : ControllerBase
    {
        ICitizenLogic ctl;
        private readonly IHubContext<SignalRHub> hub;

        public CitizenController(ICitizenLogic ctl, IHubContext<SignalRHub> hub)
        {
            this.ctl = ctl;
            this.hub = hub;
        }


        // GET: /citizen
        [HttpGet]
        public IEnumerable<Citizen> Get()
        {
            return ctl.ReadAll();
        }

        // GET /citizen/[id]
        [HttpGet("{id}")]
        public Citizen Get(int id)
        {
            return ctl.Read(id);
        }

        // POST /citizen
        [HttpPost]
        public void Post([FromBody] Citizen value)
        {
            ctl.Create(value);
        }

        // PUT /citizen
        [HttpPut]
        public void Put([FromBody] Citizen value)
        {
            ctl.Update(value);
        }

        // /citizen/[id]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ctl.Delete(id);
        }
    }
}
