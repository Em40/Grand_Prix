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
        private Track track;
        private List<Driver> drivers;

        public RaceTower()
        {
            this.drivers = new List<Driver>();
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
                this.drivers.Add(driver);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DriverBoxes(List<string> commandArgs)
        {
            //TODO: Add some logic here …
        }

        public string CompleteLaps(List<string> commandArgs)
        {
            //TODO: Add some logic here …
            return null;
        }

        public string GetLeaderboard()
        {
            //TODO: Add some logic here …
            return null;
        }

        public void ChangeWeather(List<string> commandArgs)
        {
            //TODO: Add some logic here …
        }
    }
}
