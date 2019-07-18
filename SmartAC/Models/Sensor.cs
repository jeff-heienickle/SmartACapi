using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAC.Models
{
    public class Sensor
    {
        public Guid SensorId { get; set; }

        public Guid DeviceId { get; set; }

        public ICollection<DataReading> DataReadings { get; set; }


    }
}
