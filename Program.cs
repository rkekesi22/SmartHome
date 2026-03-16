namespace SmartHome
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new SmartHomeController();

            controller.AddSensor(new TemperatureSensor("TemperatureSensor 1"));
            controller.AddSensor(new LightSensor("LightSensor 1"));

            controller.AddDevice(new Heater("Heater"));
            controller.AddDevice(new Light("Light"));

            for( int i = 0; i < 5; i++ )
            {
                Console.WriteLine($"Ciklus: {i+1}");
                controller.Update();
                Thread.Sleep(1000);
            }


            Console.ReadKey();
        }
    }
}
