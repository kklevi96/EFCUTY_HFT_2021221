using EFCUTY_HFT_2021221.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EFCUTY_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CountryStatController : ControllerBase
    {
        ICountryLogic cyl;
        public CountryStatController(ICountryLogic cyl)
        {
            this.cyl = cyl;
        }

        public IEnumerable<KeyValuePair<string, int>> PoorCountries()
        {
            return cyl.PoorCountries();
        }

        public IEnumerable<KeyValuePair<string, int>> Population()
        {
            return cyl.Population();
        }
    }
}
