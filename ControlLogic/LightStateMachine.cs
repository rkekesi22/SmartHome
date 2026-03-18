using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.ControlLogic
{
    public enum LightState
    {
        Off,
        On
    }
    public class LightStateMachine
    {
        private int onThreshold; // 30 alatt kapcsoljon be
        private int offThreshold; // 50 felett kapcsoljon ki

        public LightState State { get; private set; } = LightState.Off;

        public LightStateMachine(int onThreshold = 30, int offThreshold = 50)
        {
            if (offThreshold <= onThreshold)
            {
                throw new ArgumentException("offthreshold > onthreshold");
            }

            this.onThreshold = onThreshold;
            this.offThreshold = offThreshold;
        }

        public void Update(int lightLevel)
        {
            switch (State)
            {
                case LightState.Off:
                    if (lightLevel < onThreshold)
                        State = LightState.On;
                    break;

                case LightState.On:
                    if (lightLevel > offThreshold)
                        State = LightState.Off;
                    break;
            }
        }
    }
}
