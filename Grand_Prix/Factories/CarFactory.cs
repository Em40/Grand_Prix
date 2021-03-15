namespace Grand_Prix.Factories
{
    using Grand_Prix.Models.Cars;
    using Grand_Prix.Models.Tyres;

    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CarFactory
    {
        public static Car CreateCar(List<string> arguments, Tyre tyre)
        {
            return new Car(int.Parse(arguments[0]), double.Parse(arguments[1]), tyre);
        }
    }
}
