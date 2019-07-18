using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAC.Models
{
    public class Device
    {
        public Guid DeviceId { get; set; }

        public string SerialNumber { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string FirmwareVersion { get; set; }

        public ICollection<Sensor> Sensors { get; set; }
    }
}
