namespace Grand_Prix.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class Engine
    {
        public static void Run()
        {
            RaceTower raceTower = new RaceTower();

            int lapsNumber = int.Parse(Console.ReadLine());
            int trackLenght = int.Parse(Console.ReadLine());

            raceTower.SetTrackInfo(lapsNumber, trackLenght);

            string input = Console.ReadLine();
            while (true)
            {
                List<string> arguments = input.Split(' ').ToList();

                string command = arguments[0];
                arguments.Skip(1).ToList();

                switch (command)
                {
                    case "RegisterDriver":
                        raceTower.RegisterDriver(arguments);
                        break;
                    case "Leaderboard":
                        Console.WriteLine(raceTower.GetLeaderboard());
                        break;
                    case "Box":
                        raceTower.DriverBoxes(arguments);
                        break;
                    case "ChangeWeather":
                        raceTower.ChangeWeather(arguments);
                        break;
                    case "CompleteLaps":
                        string result = raceTower.CompleteLaps(arguments);
                        if (result != string.Empty)
                        {
                            Console.WriteLine(result);
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
