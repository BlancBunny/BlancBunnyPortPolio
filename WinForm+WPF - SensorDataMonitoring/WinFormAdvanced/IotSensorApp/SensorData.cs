using System;

namespace IotSensorApp
{
    internal class SensorData
    {
        public DateTime CurrTime { get; set; }
        public int Value { get; set; }
        public bool SimFlag { get; set; }
        public SensorData (DateTime currTime, int value, bool simFlag)
        {
            CurrTime = currTime;
            Value = value;
            SimFlag = simFlag;
        }
    }
}
