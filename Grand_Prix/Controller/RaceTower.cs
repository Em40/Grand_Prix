namespace Grand_Prix.Controller
{
    using Grand_Prix.Factories;
    using Grand_Prix.Models.Cars;
    using Grand_Prix.Models.Drivers;
    using Grand_Prix.Models.Tracks;
    using Grand_Prix.Models.Tyres;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RaceTower
    {
        private const double PIT_STOP_TIME = 20;

        private Track track;
        private Dictionary<string, Driver> drivers;
        private Dictionary<Driver, string> dnfDrivers;
        public bool hasWinner;
        public Driver winner;


        public RaceTower()
        {
            this.drivers = new Dictionary<string, Driver>();
            this.dnfDrivers = new Dictionary<Driver, string>();
            this.hasWinner = false;
        }

        public void SetTrackInfo(int lapsNumber, int trackLength)
        {
            this.track = new Track(lapsNumber, trackLength);
        }

        public void RegisterDriver(List<string> commandArgs)
        {
            try
            {
                Tyre tyre = TyreFactory.CreateTyre(commandArgs.Skip(5).ToList());
                Car car = CarFactory.CreateCar(commandArgs.Skip(3).Take(2).ToList(), tyre);
                Driver driver = DriverFactory.CreateDriver(commandArgs.Skip(1).Take(2).ToList(), car);
                this.drivers.Add(commandArgs[2], driver);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        public void DriverBoxes(List<string> commandArgs)
        {
            string reason = commandArgs[1];
            Driver driver = this.drivers[commandArgs[2]];
            driver.TotalTime += PIT_STOP_TIME;
            switch (reason)
            {
                case "ChangeTyres":
                    Tyre newTyre = TyreFactory.CreateTyre(commandArgs.Skip(3).ToList());
                    driver.Car.ChangeTyres(newTyre);
                    break;
                case "Refuel":
                    driver.Car.Refuel(double.Parse(commandArgs[3]));
                    break;
            }
        }

        public string CompleteLaps(List<string> commandArgs)
        {
            int completeLap = int.Parse(commandArgs[1]);
            if (this.track.LapsNumber - completeLap < 0)
            {
                return $"There is no time! On lap {this.track.CurrentLap}.";
            }
            else //LOGIC FROM INTERNET
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < completeLap; i++)
                {
                    this.GetDriversTime();
                    this.DriversTakeALap();
                    this.RemoveDnfDrivers();
                    this.track.CurrentLap++;

                    List<Driver> standings = this.drivers.Values.OrderByDescending(d => d.TotalTime).ToList();
                    this.Overtaking(standings, sb);
                }

                if (this.track.CurrentLap == this.track.LapsNumber)
                {
                    this.hasWinner = true;
                    this.winner = this.drivers.Values.OrderBy(d => d.TotalTime).FirstOrDefault();
                }
                return sb.ToString().Trim();
            }
            
        }

        public string GetLeaderboard() //LOGIC FROM INTERNET
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Lap {this.track.CurrentLap}/{this.track.LapsNumber}");

            int position = 1;
            foreach (Driver driver in this.drivers.Values.OrderBy(d => d.TotalTime))
            {
                sb.AppendLine($"{position} {driver.Name} {driver.TotalTime:F3}");
                position++;
            }
            foreach (KeyValuePair<Driver, string> driver in this.dnfDrivers.Reverse())
            {
                sb.AppendLine($"{position} {driver.Key.Name} {driver.Value}");
                position++;
            }
            return sb.ToString().Trim();
        }

        public void ChangeWeather(List<string> commandArgs)
        {
            this.track.Weather = commandArgs[1];
        }

        private void GetDriversTime()
        {
            foreach (Driver driver in this.drivers.Values)
            {
                driver.TotalTime += 60 / (this.track.Length / driver.Speed);
            }
        }

        private void DriversTakeALap()
        {
            foreach (Driver driver in this.drivers.Values)
            {
                try
                {
                    driver.ReduceFuelAmount(this.track.Length);
                    driver.Car.Tyre.ReduceDegradation();
                }
                catch (ArgumentException ae)
                {
                    this.dnfDrivers.Add(driver, ae.Message);
                }
            }
        }
        private void RemoveDnfDrivers()
        {
            foreach (Driver dnfDriver in this.dnfDrivers.Keys)
            {
                if (this.drivers.ContainsKey(dnfDriver.Name))
                {
                    this.drivers.Remove(dnfDriver.Name);
                }
            }
        }

        private void Overtaking(List<Driver> standings, StringBuilder sb) //LOGIC FROM INTERNET
        {
            for (int i = 0; i < standings.Count - 1; i++)
            {
                Driver frontDriver = standings[i];
                Driver behindDriver = standings[i + 1];
                double gap = Math.Abs(frontDriver.TotalTime - behindDriver.TotalTime);
                int interval = 2;
                bool isCrashed = this.CheckConditions(frontDriver, ref interval);

                if (gap <= interval)
                {
                    if (isCrashed)
                    {
                        this.dnfDrivers.Add(frontDriver, "Crashed");
                        this.drivers.Remove(frontDriver.Name);
                        continue;
                    }
                    frontDriver.TotalTime -= interval;
                    behindDriver.TotalTime += interval;
                    sb.AppendLine($"{frontDriver.Name} has overtaken {behindDriver.Name} on lap {this.track.CurrentLap}.");
                }
            }
        }

        private bool CheckConditions(Driver frontDriver, ref int interval) //LOGIC FROM INTERNET
        {
            bool isCrashed = false;
            if (frontDriver.GetType().Name == "AggressiveDriver" && frontDriver.Car.Tyre.GetType().Name == "UltrasoftTyre")
            {
                interval = 3;
                if (this.track.Weather == "Foggy")
                {
                    isCrashed = true;
                }
            }
            if (frontDriver.GetType().Name == "EnduranceDriver" && frontDriver.Car.Tyre.GetType().Name == "HardTyre")
            {
                interval = 3;
                if (this.track.Weather == "Rainy")
                {
                    isCrashed = true;
                }
            }
            return isCrashed;
        }
    }
}
