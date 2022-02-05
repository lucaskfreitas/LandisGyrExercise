﻿using LandisGyrExercise.Controller;
using LandisGyrExercise.Enumerables;
using LandisGyrExercise.Model;
using System;

namespace LandisGyrExercise.UserInterface
{
    public class ConsoleInterface : IUserInterface
    {
        private MainController _controller = null;

        public void SetController(MainController controller)
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
                    Console.WriteLine("An exception has occurred:");
                    Console.WriteLine(e.Message);
                }
            }
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

        private static UserAction QueryAction()
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

            string userInput = Console.ReadLine();
            return Enum.Parse<UserAction>(userInput);
        }

        public string QueryMeterFirmwareVersion()
        {
            Console.WriteLine("What is the meter firmware version?");
            return Console.ReadLine();
        }

        public int QueryMeterModelId()
        {
            Console.WriteLine("What is the meter model ID?");
            return int.Parse(Console.ReadLine());
        }

        public int QueryMeterNumber()
        {
            Console.WriteLine("What is the meter number?");
            return int.Parse(Console.ReadLine());
        }

        public string QuerySerialNumber()
        {
            Console.WriteLine("What is the serial number?");
            return Console.ReadLine();
        }

        public SwitchState QuerySwitchState()
        {
            Console.WriteLine("Select a switch state: 0 = Disconnected, 1 = Connected, 2 = Armed");
            int choice = int.Parse(Console.ReadLine());
            return (SwitchState)choice;
        }
    }
}
