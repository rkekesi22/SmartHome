using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Devices
{
    public class Light : Device
    {
        public Light(string name) : base(name) { }
        public override void TurnOff()
        {
            IsOn = false;
            Console.WriteLine($"{Name} -> Turn off.");
        }

        public override void TurnOn()
        {
            IsOn = true;
            Console.WriteLine($"{Name} -> Turn on.");
        }
    }
}
