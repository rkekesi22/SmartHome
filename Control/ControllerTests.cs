using SmartHome.Controllers;
using SmartHome.ControlLogic;
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


        [Fact]
        public void HeaterFSM()
        {
            var fsm = new HeaterStateMachine(20, 23);

            fsm.Update(21.0);

            Assert.Equal(HeaterState.Off,fsm.State);

            fsm.Update(19.0);

            Assert.Equal(HeaterState.Heating,fsm.State);

            fsm.Update(22.0);

            Assert.Equal(HeaterState.Heating,fsm.State);

            fsm.Update(24.0);

            Assert.Equal(HeaterState.Off, fsm.State);
        }

        [Fact]
        public void LightFSM()
        {
            var fsm = new LightStateMachine(25, 55);

            fsm.Update(26);

            Assert.Equal(LightState.Off, fsm.State);

            fsm.Update(10);

            Assert.Equal(LightState.On, fsm.State);

            fsm.Update(60);

            Assert.Equal(LightState.Off, fsm.State);
        }
    }
}