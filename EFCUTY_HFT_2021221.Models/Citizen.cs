using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EFCUTY_HFT_2021221.Models
{
    [Table("Citizens")]
    public class Citizen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int PersonID { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public bool HasCriminalRecord { get; set; }

        public int IncomeInUSD { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Country Citizenship { get; set; }

        [ForeignKey(nameof(Country))]
        public int CitizenshipID { get; set; }
        
        [NotMapped]
        [JsonIgnore]
        public virtual Settlement Settlement { get; set; }

        [ForeignKey(nameof(Models.Settlement))]
        public int SettlementID { get; set; }


        public override int GetHashCode()
        {
            return this.BirthDate.GetHashCode() * this.PersonID.GetHashCode() + this.Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.GetHashCode().Equals(obj.GetHashCode());
        }

    }
}
