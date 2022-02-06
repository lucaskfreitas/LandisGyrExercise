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
                    switch (QueryAction())
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
                            if (ConfirmAction())
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
            newEndpoint.MeterModelId = AskUserForMeterModel();

            newEndpoint.MeterNumber = AskUserForMeterNumber();

            Console.WriteLine("What is the meter firmware version?");
            newEndpoint.MeterFirmwareVersion = Console.ReadLine();

            newEndpoint.SwitchState = AskUserForSwitchState();
        }

        public string AskUserForSerialNumber()
        {
            Console.WriteLine("What is the serial number?");
            return Console.ReadLine();
        }

        public SwitchState AskUserForSwitchState()
        {
            bool validInput = false;
            int switchState = 0;

            while (!validInput)
            {
                Console.WriteLine("Select a switch state: 0 = Disconnected, 1 = Connected, 2 = Armed");

                try
                {
                    if (!int.TryParse(Console.ReadLine(), out switchState))
                        throw new ArgumentException();

                    if (!Enum.IsDefined(typeof(SwitchState), switchState))
                        throw new ArgumentException();

                    validInput = true;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid option.");
                }
            }

            return (SwitchState)switchState;
        }

        private static int AskUserForMeterNumber()
        {
            bool validInput = false;
            int meterNumber = 0;

            while (!validInput)
            {
                Console.WriteLine("What is the meter number?");

                try
                {
                    if (!int.TryParse(Console.ReadLine(), out meterNumber))
                        throw new ArgumentException();

                    validInput = true;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid number.");
                }
            }

            return meterNumber;
        }

        private static MeterModel AskUserForMeterModel()
        {
            bool validInput = false;
            int meterModel = 0;

            while (!validInput)
            {
                Console.WriteLine("What is the meter model ID?");

                try
                {
                    if (!int.TryParse(Console.ReadLine(), out meterModel))
                        throw new ArgumentException();

                    if (!Enum.IsDefined(typeof(MeterModel), meterModel))
                        throw new ArgumentException();

                    validInput = true;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid number.");
                }
            }

            return (MeterModel)meterModel;
        }

        private static UserAction QueryAction()
        {
            StringBuilder stringBuilder = new("");
            stringBuilder.AppendLine("What do you want to do?");
            stringBuilder.AppendLine("Possible actions:");
            stringBuilder.AppendLine("1 - Add a new endpoint");
            stringBuilder.AppendLine("2 - Edit an existing endpoint");
            stringBuilder.AppendLine("3 - Delete an endpoint");
            stringBuilder.AppendLine("4 - List all endpoint");
            stringBuilder.AppendLine("5 - Find an endpoint");
            stringBuilder.AppendLine("6 - Exit");
            stringBuilder.AppendLine("");

            bool validInput = false;
            int userInput = 0;

            while (!validInput)
            {
                Console.Write(stringBuilder.ToString());

                try
                {
                    if (!int.TryParse(Console.ReadLine(), out userInput))
                        throw new ArgumentException();

                    if (!Enum.IsDefined(typeof(UserAction), userInput))
                        throw new ArgumentException();

                    validInput = true;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid option.");
                }
            }

            return (UserAction)userInput;
        }

        private static bool ConfirmAction()
        {
            Console.WriteLine("Are you sure? (y/n)");

            return Console.ReadLine() switch
            {
                "y" or "Y" => true,
                "n" or "N" => false,
                _ => throw new InvalidOperationException(),
            };
        }
    }
}
