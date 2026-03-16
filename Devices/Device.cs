using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Devices
{
    public abstract class Device
    {
        public string Name { get;private set; }
        public bool IsOn { get; protected set; }

        public Device(string name)
        {
            Name = name;
        }

        public abstract void TurnOn();
        public abstract void TurnOff();

        public void PrintStatus()
        {
            if( IsOn)
            {
                Console.WriteLine($"{Name} status -> Turn on");
            }
            else
            {
                Console.WriteLine($"{Name} status -> Turn off");
            }
        }
    }
}
