using System.Linq;
using System;
using EFCUTY_HFT_2021221.Models;

namespace EFCUTY_HFT_2021221.Client
{
    //todo project reference data DELETE !! now it is added for testing only
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);

            RestService rest = new("http://localhost:5000");

            var countries = rest.Get<Country>("country");
            var settlements = rest.Get<Settlement>("settlement");
            var citizens = rest.Get<Citizen>("citizen");
            Console.WriteLine("hello world");
            ;
            Console.ReadKey();
        }
    }
}
