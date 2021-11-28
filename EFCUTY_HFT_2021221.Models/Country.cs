using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCUTY_HFT_2021221.Models
{
    [Table("Countries")]
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountryID { get; set; }

        [NotMapped]
        public virtual ICollection<Settlement> Settlements { get; set; }

        [NotMapped]
        public virtual ICollection<Citizen> Citizens { get; set; }

        public string Name { get; set; }

        public int TotalGDPInMillionUSD { get; set; }

        public bool IsOECDMember { get; set; }

        public Country()
        {
            Settlements = new HashSet<Settlement>();
            Citizens = new HashSet<Citizen>();
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() * this.CountryID.GetHashCode() + this.TotalGDPInMillionUSD.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.GetHashCode().Equals(obj.GetHashCode());
        }
    }
}
