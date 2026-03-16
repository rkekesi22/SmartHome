using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Sensors
{
    public class LightSensor : ISensor
    {
        public string Name { get;private set; }

        public LightSensor(string name)
        {
            Name = name;
        }

        //Szimulált fényerő
        public double ReadValue()
        {
            return new Random().Next(0, 100);
        }
    }
}
