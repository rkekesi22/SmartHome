using SmartHome.Devices;
using SmartHome.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Controllers
{
    public class SmartHomeController
    {
        
        private readonly List<ISensor> sensors = new();
        private readonly List<Device> devices = new();

        public void AddSensor(ISensor sensor)
        {
            sensors.Add(sensor);
        }

        public void AddDevice(Device device)
        {
            devices.Add(device);
        }

        
        public void Update()
        {
            foreach (var sensor in sensors)
            {
                double value = sensor.ReadValue();
                Console.WriteLine($"[{sensor.Name}] value: {value}");

                if (sensor is TemperatureSensor && value < 20)
                {
                    //OfType - Only Heater type select
                    devices.OfType<Heater>().ToList().ForEach(d => d.TurnOn());
                }
                else if (sensor is TemperatureSensor && value > 23)
                {
                    devices.OfType<Heater>().ToList().ForEach(d => d.TurnOff());
                }

                if( sensor is LightSensor && value < 30)
                {
                    //OfType - Only Light type select
                    devices.OfType<Light>().ToList().ForEach(d => d.TurnOn());
                }
                else if ( sensor is LightSensor && value > 50)
                {
                    devices.OfType<Light>().ToList().ForEach (d => d.TurnOff());
                }
            }
        }
    }
}
