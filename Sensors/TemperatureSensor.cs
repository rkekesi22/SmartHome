using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Sensors
{
    public class TemperatureSensor : ISensor
    {
        public string Name { get;private set; }


        public TemperatureSensor(string name)
        {
            Name = name;
        }


        //Szimulált érték
        public double ReadValue()
        {
            return 18.5 + new Random().NextDouble() * 5;
        }
    }
}
