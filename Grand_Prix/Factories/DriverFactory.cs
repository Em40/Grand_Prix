namespace Grand_Prix.Factories
{
    using Grand_Prix.Models.Cars;
    using Grand_Prix.Models.Drivers;

    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DriverFactory
    {
        public static Driver CreateDriver(List<string> arguments, Car car)
        {
            string type = arguments[0];

            switch (type)
            {
                case "Aggressive":
                    return new AggressiveDriver(arguments[1], car);
                case "Endurance":
                    return new EnduranceDriver(arguments[1], car);
                default:
                    throw new ArgumentException();
            }
        }
    }
}
