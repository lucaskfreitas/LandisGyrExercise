using LandisGyrTest.Model;
using LandisGyrTest.Enumerables;
using System;

namespace LandisGyrTest.UserInterface
{
    class ConsoleInterface : IUserInterface
    {
        public bool ConfirmAction()
        {
            Console.WriteLine("Are you sure? (y/n)");

            return Console.ReadLine() switch
            {
                "y" or "Y" => true,
                "n" or "N" => false,
                _ => throw new InvalidOperationException(),
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

        public UserAction QueryAction()
        {
            Console.WriteLine("");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("Possible actions:");
            Console.WriteLine("1 - Add a new endpoint");
            Console.WriteLine("2 - Edit an existing endpoint");
            Console.WriteLine("3 - Delete an endpoint");
            Console.WriteLine("4 - List all endpoint");
            Console.WriteLine("5 - Find an endpoint");
            Console.WriteLine("6 - Exit");
            Console.WriteLine("");

            return Console.ReadLine() switch
            {
                "1" => UserAction.AddEndpoint,
                "2" => UserAction.EditEndpoint,
                "3" => UserAction.DeleteEndpoint,
                "4" => UserAction.ListAllEndpoints,
                "5" => UserAction.FindEndpointBySerialNumber,
                "6" => UserAction.Exit,
                _ => throw new InvalidOperationException(),
            };
        }

        public string QueryMeterFirmwareVersion()
        {
            Console.WriteLine("Firmware version");
            return Console.ReadLine();
        }

        public int QueryMeterModelId()
        {
            Console.WriteLine("Meter model ID");
            return int.Parse(Console.ReadLine());
        }

        public int QueryMeterNumber()
        {
            Console.WriteLine("Meter number");
            return int.Parse(Console.ReadLine());
        }

        public string QuerySerialNumber()
        {
            Console.WriteLine("Serial number");
            return Console.ReadLine();
        }

        public SwitchState QuerySwitchState()
        {
            Console.WriteLine("Switch state (0 = Disconnected, 1 = Connected, 2 = Armed)");
            int choice = int.Parse(Console.ReadLine());
            return (SwitchState)choice;
        }

        public void ShowError(Exception e)
        {
            Console.WriteLine("ERROR");
            Console.WriteLine(e.Message);
        }
    }
}
