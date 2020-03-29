using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace covid_tracker.Data.Dto
{
    public class InfectivityUpdate
    {
        public bool IsSymptomatic { get; set; }
        public DateTime SymptomStartDate { get; set; }

        public bool IsConfirmed { get; set; }
        public DateTime ConfirmationDate { get; set; }
    }
}
