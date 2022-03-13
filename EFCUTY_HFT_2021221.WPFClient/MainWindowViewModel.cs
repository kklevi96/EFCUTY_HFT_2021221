using EFCUTY_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCUTY_HFT_2021221.WPFClient
{
    public class MainWindowViewModel
    {
        public RestCollection<Country> Countries { get; set; }

        //public ICommand Create

        public MainWindowViewModel()
        {
            Countries = new RestCollection<Country>("http://localhost:54726/", "country");
        }
    }
}
