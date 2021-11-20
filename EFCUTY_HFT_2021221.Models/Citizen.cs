using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCUTY_HFT_2021221.Models
{
    [Table("Citizens")]
    public class Citizen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonID { get; set; }

        public string Name { get; set; }

        [NotMapped]
        public virtual Country Citizenship { get; set; }

        [ForeignKey(nameof(Country))]
        public int CitizenshipID { get; set; }
        
        [NotMapped]
        public virtual Settlement HomeSettlement { get; set; }

        [ForeignKey(nameof(Settlement))]
        public int SettlementID { get; set; }

        public DateTime BirthDate { get; set; }


    }
}
