using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCUTY_HFT_2021221.Models
{
    public class Country
    {
        [Key]
        public int CountryID { get; set; }

        [NotMapped]
        public virtual ICollection<Settlement> Settlements { get; set; }

        [NotMapped]
        public virtual ICollection<Citizen> Citizens { get; set; }

        public string Name { get; set; }

        public double HDI { get; set; }

        public Country()
        {
            Settlements = new HashSet<Settlement>();
            Citizens = new HashSet<Citizen>();
        }
    }
}
