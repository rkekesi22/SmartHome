using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Sensors
{
    public interface ISensor
    {
        string Name { get; }
        double ReadValue();
    }
}
