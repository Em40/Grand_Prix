namespace Grand_Prix.Models.Drivers
{
    using Grand_Prix.Models.Cars;

    using System;
    using System.Collections.Generic;
    using System.Text;

    public class EnduranceDriver : Driver
    {
        public EnduranceDriver(string name, Car car)
            :base(name, car, 1.5)
        {
                
        }
    }
}
