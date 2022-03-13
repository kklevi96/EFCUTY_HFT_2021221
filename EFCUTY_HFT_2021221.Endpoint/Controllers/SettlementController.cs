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
    public class SettlementController : ControllerBase
    {
        ISettlementLogic sl;
        private readonly IHubContext<SignalRHub> hub;

        public SettlementController(ISettlementLogic sl, IHubContext<SignalRHub> hub)
        {
            this.sl = sl;
            this.hub = hub;
        }


        // GET: /settlement
        [HttpGet]
        public IEnumerable<Settlement> Get()
        {
            return sl.ReadAll();
        }

        // GET /settlement/[id]
        [HttpGet("{id}")]
        public Settlement Get(int id)
        {
            return sl.Read(id);
        }

        // POST /settlement
        [HttpPost]
        public void Post([FromBody] Settlement value)
        {
            sl.Create(value);
        }

        // PUT /settlement
        [HttpPut]
        public void Put([FromBody] Settlement value)
        {
            sl.Update(value);
        }

        // /settlement/[id]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            sl.Delete(id);
        }
    }
}
