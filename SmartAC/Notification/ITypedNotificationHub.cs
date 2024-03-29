﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAC.Notification
{
    public interface ITypedNotificationHub
    {
        Task BroadcastMessage(string deviceId, string sensorId, string message);
    }
}
