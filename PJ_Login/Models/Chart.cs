using System;
using System.Collections.Generic;

#nullable disable

namespace PJ_Login.Models
{
    public partial class Chart
    {
        public double SourceIp { get; set; }
        public double DestinationIp { get; set; }
        public int? SourcePort { get; set; }
        public int? DistinationPort { get; set; }
        public string Action { get; set; }
    }
}
