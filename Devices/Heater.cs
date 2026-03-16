using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Devices
{
    public class Heater : Device
    {
        public Heater(string name) : base(name)
        {
        }

        public override void TurnOff()
        {
            IsOn = false;
            Console.WriteLine($"{Name} -> Heating turn off.");
        }

        public override void TurnOn()
        {
            IsOn = true;
            Console.WriteLine($"{Name} -> Heating turn on.");
        }
    }
}
