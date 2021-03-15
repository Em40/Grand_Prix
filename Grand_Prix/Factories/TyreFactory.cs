namespace Grand_Prix.Factories
{
    using Grand_Prix.Models.Tyres;

    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TyreFactory
    {
        public static Tyre CreateTyre(List<string> arguments)
        {
            string tyreType = arguments[0];

            switch (tyreType)
            {
                case "Hard":
                    return new HardTyre(double.Parse(arguments[1]));
                case "Ultrasoft":
                    return new UltrasoftTyre(double.Parse(arguments[1]), double.Parse(arguments[2]));
                default:
                    throw new ArgumentException();
            }
        }
    }
}
