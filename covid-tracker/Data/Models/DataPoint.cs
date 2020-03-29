using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace covid_tracker.Data.Models
{
    public class DataPoint
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime Timestamp { get; set; }
        public DateTime TimestampExit { get; set; }

        public Point Location { get; set; }
        

        public int Accuracy { get; set; }
        public int Altitude { get; set; }

        public int VerticalAccuracy { get; set; }

        public ApplicationUser User { get; set; }

        public List<DataActivity> Activities { get; set; }
    }
}
