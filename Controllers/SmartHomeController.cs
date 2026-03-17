using SmartHome.ControlLogic;
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

        private readonly HeaterStateMachine heaterFsm = new HeaterStateMachine(20.0, 23.0);
        private readonly LightStateMachine lightFsm = new LightStateMachine(30, 50);

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

            double? lastTemperature = null;
            int? lastLightLevel = null;

            foreach (var sensor in sensors)
            {
                var value = sensor.ReadValue();
                Console.WriteLine($"[{sensor.Name}] value: {value}");

                if (sensor is TemperatureSensor)
                    lastTemperature = value;


                if( sensor is LightSensor)
                {
                    lastLightLevel = (int)Math.Round(value);
                }
            }

            if (lastTemperature.HasValue)
            {
                heaterFsm.Update(lastTemperature.Value);
            }

            if( lastLightLevel.HasValue)
            {
                lightFsm.Update(lastLightLevel.Value);
            }


            foreach (var heater in devices.OfType<Heater>())
            {
                if( heaterFsm.State == HeaterState.Heating && !heater.IsOn)
                {
                    heater.TurnOn();
                }
                else if (heaterFsm.State == HeaterState.Off && heater.IsOn)
                {
                    heater.TurnOff();
                }
            }

            foreach(var light in devices.OfType<Light>())
            {
                if( lightFsm.State == LightState.On && !light.IsOn)
                {
                    light.TurnOn();
                }
                else if( lightFsm.State == LightState.Off && light.IsOn)
                {
                    light.TurnOff();
                }
            }

        }
    }
}
