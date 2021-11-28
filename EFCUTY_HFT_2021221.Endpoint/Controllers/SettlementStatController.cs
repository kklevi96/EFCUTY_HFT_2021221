﻿using EFCUTY_HFT_2021221.Logic;
using EFCUTY_HFT_2021221.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCUTY_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SettlementStatController : ControllerBase
    {
        ISettlementLogic sl;

        public SettlementStatController(ISettlementLogic sl)
        {
            this.sl = sl;
        }

        [HttpGet]
        public IEnumerable<Settlement> GoodSettlements()
        {
            return sl.GoodSettlements();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AvgHDIByCountries()
        {
            return sl.AvgHDIByCountries();
        }
    }
}