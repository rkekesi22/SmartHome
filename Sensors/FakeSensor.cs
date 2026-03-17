using SmartHome.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Sensors
{
    public class FakeSensor : ISensor
    {
        public string Name { get; }
        private double _value;

        public FakeSensor(string name, double value)
        {
            Name = name;
            _value = value;
        }

        public void SetValue(double value)
        {
            _value = value;
        }

        public double ReadValue() => _value;

    }
}
