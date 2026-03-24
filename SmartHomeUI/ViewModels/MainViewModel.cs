using SmartHome.Controllers;
using SmartHome.Devices;
using SmartHome.Sensors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace SmartHomeUI.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly SmartHomeController _smartHomeController;
        private readonly DispatcherTimer _timer;

        private double _temperature;
        public double Temperature
        {
            get => _temperature;
            set
            {
                _temperature = value;
                OnPropertyChanged();
            }
        }

        private bool _isHeating;
        public bool IsHeating
        {
            get => _isHeating;
            set
            {
                _isHeating = value;
                OnPropertyChanged();
            }
        }

        public double OnThresHold
        {
            get => _smartHomeController.HeaterOnThresHold;
            set
            {
                if( value < OffThresHold)
                {
                    _smartHomeController.HeaterOnThresHold = value;
                    OnPropertyChanged();
                }
                
            }
        }

        public double OffThresHold
        {
            get => _smartHomeController.HeaterOffThresHold;
            set
            {
                _smartHomeController.HeaterOffThresHold = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            _smartHomeController = new SmartHomeController();

            _smartHomeController.AddSensor(new TemperatureSensor("TemperatureSensor 1"));
            _smartHomeController.AddDevice(new Heater("Heater"));

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += (s, e) => Update();
            _timer.Start();
        }

        private void Update()
        {
            _smartHomeController?.Update();

            var tempSensor = _smartHomeController.Sensors.OfType<TemperatureSensor>().FirstOrDefault();

            if (tempSensor != null)
            {
                Temperature = tempSensor.ReadValue();
            }

            var heater = _smartHomeController.Devices.OfType<Heater>().FirstOrDefault();
            if (heater != null)
            {
                IsHeating = heater.IsOn;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
