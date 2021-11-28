using EFCUTY_HFT_2021221.Logic;
using EFCUTY_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCUTY_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CitizenStatController : ControllerBase
    {
        ICitizenLogic ctl;

        public CitizenStatController(ICitizenLogic ctl)
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
