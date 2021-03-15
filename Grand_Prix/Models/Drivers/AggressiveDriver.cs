namespace Grand_Prix.Models.Drivers
{
    using Grand_Prix.Models.Cars;

    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AggressiveDriver : Driver
    {
        

        public AggressiveDriver(string name, Car car)
            :base(name, car, 2.7)
        {
           
        }

        //public override double Speed => base.Speed * 1.3;

        public override double Speed
        {
            get
            {
                return base.Speed;
            }
            set
            {
                base.Speed *= 1.3;
            }
        }

    }
}
