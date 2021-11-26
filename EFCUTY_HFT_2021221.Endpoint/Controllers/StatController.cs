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
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        ICitizenLogic ctl;

        public StatController(ICitizenLogic ctl)
        {
            this.ctl = ctl;
        }

        [HttpGet]
        public IEnumerable<Citizen> PoorOldPeople()
        {
            return ctl.PoorOldPeople();
        }

        [HttpGet]
        public IEnumerable<Citizen> DevelopedCriminals()
        {
            return ctl.DevelopedCriminals();
        }
    }
}
