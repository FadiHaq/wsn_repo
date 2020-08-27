using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrafficWebService
{
    public class Vehicle
    {
        public String sensorId { get; set; }
        public string vclass { get; set; }
        public int vspeed { get; set; }
        public string detectionDate { get; set; }
        public string detectionTime { get; set; }
    }  
}
 