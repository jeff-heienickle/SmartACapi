using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAC.Models
{
    public class DataReading
    {
        public long Id { get; set; }

        public Guid DeviceId { get; set; }

        public Guid SensorId { get; set; }

        public double Temperature { get; set; }

        public double Humidity { get; set; }

        public double CarbonMonoxideLevel { get; set; }

        public string Status { get; set; }

        public DateTime ReadingDate { get; set; }
    }
}
