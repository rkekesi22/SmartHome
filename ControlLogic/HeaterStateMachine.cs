using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.ControlLogic
{
    public enum HeaterState
    {
        Off,
        Heating
    }
    public class HeaterStateMachine
    {
        private double onThreshold; //pl :20 fok alatt kapcsoljon be
        private double offThreshold; //pl :23 fok felett kapcsoljon be

        public double OnThresHold {
            get => onThreshold;
            set => onThreshold = value;
        }
        public double OffThresHold
        {
            get => offThreshold;
            set => offThreshold = value;
        }

        public HeaterState State { get; private set; } = HeaterState.Off;
        
        public HeaterStateMachine(double onThreshold = 20.0, double offThreshold = 23.0)
        {
            if( offThreshold <= onThreshold)
            {
                throw new ArgumentException("offthreshold > onthreshold");
            }

            this.onThreshold = onThreshold;
            this.offThreshold = offThreshold;
        }

        public void Update(double temperature)
        {
            switch (State)
            {
                case HeaterState.Off:
                    if (temperature < onThreshold)
                        State = HeaterState.Heating;
                    break;

                case HeaterState.Heating:
                    if( temperature > offThreshold) 
                        State = HeaterState.Off; 
                    break;
            }
        }
    }
}
