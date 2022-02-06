using LandisGyrExercise.Controller;
using LandisGyrExercise.Enumerables;
using LandisGyrExercise.Model;
using System;
using System.Text;

namespace LandisGyrExercise.UserInterface
{
    public class ConsoleInterface : IUserInterface
    {
        private IController _controller = null;

        public void SetController(IController controller)
        {
            _controller = controller;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    switch (AskUserAction())
                    {
                        case UserAction.AddEndpoint:
                            _controller.AddEndpoint();
                            break;

                        case UserAction.EditEndpoint:
                            _controller.EditEndpoint();
                            break;

                        case UserAction.DeleteEndpoint:
                            _controller.DeleteEndpoint();
                            break;

                        case UserAction.ListAllEndpoints:
                            _controller.ListAllEndpoints();
                            break;

                        case UserAction.FindEndpointBySerialNumber:
                            _controller.FindEndpointBySerialNumber();
                            break;

                        case UserAction.Exit:
                            if (ConfirmAction("Are you sure you want to quit the application?"))
                                return;
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Something went wrong");
                    Console.WriteLine(e.Message);
                }
            }
        }

        public bool ConfirmAction(string message)
        {
            Console.WriteLine($"{message} (y/n)");

            return Console.ReadLine() switch
            {
                "y" or "Y" => true,
                _ => false
            };
        }

        public void PrintEndpointData(Endpoint endpoint)
        {
            Console.WriteLine("");
            Console.WriteLine("ENDPOINT DATA");
            Console.WriteLine($"-> Serial number: {endpoint.SerialNumber}");
            Console.WriteLine($"-> Meter model ID: {endpoint.MeterModelId}");
            Console.WriteLine($"-> Meter number: {endpoint.MeterNumber}");
            Console.WriteLine($"-> Meter firmware version: {endpoint.MeterFirmwareVersion}");
            Console.WriteLine($"-> Switch state: {endpoint.SwitchState}");
            Console.WriteLine("");
        }

        public void AskUserForEndpointData(Endpoint newEndpoint)
        {
            newEndpoint.MeterModelId = AskUserForMeterModelId();
            newEndpoint.MeterNumber = AskUserForMeterNumber();
            newEndpoint.MeterFirmwareVersion = AskUserForFirmwareVersion();
            newEndpoint.SwitchState = AskUserForSwitchState();
        }

        public string AskUserForSerialNumber()
        {
            Console.WriteLine("What is the endpoint serial number?");
            return Console.ReadLine();
        }

        public SwitchState AskUserForSwitchState()
        {
            return AskUserFor<SwitchState>("Select a switch state: 0 = Disconnected, 1 = Connected, 2 = Armed");
        }

        private static MeterModel AskUserForMeterModelId()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine("What is the meter model ID?");
            stringBuilder.AppendLine("Valid values:");
            foreach (var a in Enum.GetValues(typeof(MeterModel)))
                stringBuilder.AppendLine($"-> {(int)a} = model {a}");

            return AskUserFor<MeterModel>(stringBuilder.ToString());
        }

        private static int AskUserForMeterNumber()
        {
            int meterNumber = 0;

            while (meterNumber <= 0)
            {
                Console.WriteLine("What is the meter number?");

                try
                {
                    if (!int.TryParse(Console.ReadLine(), out meterNumber))
                        throw new ArgumentException();
                    if (meterNumber <= 0)
                        throw new ArgumentException();
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid argument. Please type a number greater than zero.");
                }
            }

            return meterNumber;
        }

        private static string AskUserForFirmwareVersion()
        {
            Console.WriteLine("What is the meter firmware version?");
            return Console.ReadLine();
        }

        private static UserAction AskUserAction()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("What do you want to do?");
            stringBuilder.AppendLine("Possible actions:");
            stringBuilder.AppendLine("1 - Add a new endpoint");
            stringBuilder.AppendLine("2 - Edit an existing endpoint");
            stringBuilder.AppendLine("3 - Delete an endpoint");
            stringBuilder.AppendLine("4 - List all endpoint");
            stringBuilder.AppendLine("5 - Find an endpoint");
            stringBuilder.Append("6 - Exit");

            return AskUserFor<UserAction>(stringBuilder.ToString());
        }

        private static T AskUserFor<T>(string message) where T : Enum
        {
            bool validInput = false;
            int meterModel = 0;

            while (!validInput)
            {
                Console.WriteLine(message);

                try
                {
                    if (!int.TryParse(Console.ReadLine(), out meterModel))
                        throw new ArgumentException();

                    if (!Enum.IsDefined(typeof(T), meterModel))
                        throw new ArgumentException();

                    validInput = true;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid option.");
                }
            }

            return (T)Enum.Parse(typeof(T), meterModel.ToString());
        }
    }
}
