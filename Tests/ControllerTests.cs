using SmartHome.Controllers;
using SmartHome.Devices;
using SmartHome.Sensors;

namespace SmartHome_Tests.Tests
{
    public class ControllerTests
    {
        [Fact]
        public void HeaterTurnsOn_WhenTemperatureIsBelow20()
        {
            //Arrange
            var controller = new SmartHomeController();
            var heater = new Heater("Heating");
            var sensor = new FakeSensor("FakeTemp", 15.0);


            controller.AddDevice(heater);
            controller.AddSensor(sensor);

            //Act
            controller.Update();

            //Assert
            Assert.True(heater.IsOn);
   
        }

        [Fact]
        public void HeaterTurnsOff_WhenTemperatureAbove23()
        {
            //Arrange
            var controller = new SmartHomeController();
            var heater = new Heater("Heating");
            var sensor = new FakeSensor("FakeTemp", 24.0);

            heater.TurnOn();

            controller.AddDevice(heater);
            controller.AddSensor(sensor);

            //Act
            controller.Update();

            //Assert
            Assert.False(heater.IsOn);

        }
    }
}