namespace Grand_Prix.Models.Drivers
{
    using Grand_Prix.Models.Cars;

    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Driver
    {
        double speed;

        public Driver(string name, Car car, double fuelConsumptionPerKm)
        {
            this.Name = name;
            this.Car = car;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        }
        
        public string Name { get; set; }

        public double TotalTime { get; set; }

        public Car Car { get; set; }

        public double FuelConsumptionPerKm { get; set; }

        public virtual double Speed 
        {
            get
            {
                return this.speed;
            }
            set
            {
                value = (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;
            }
        }
        public void ReduceFuelAmount(int lenght)
        {
            this.Car.ReduceFuel(lenght, this.FuelConsumptionPerKm);
        }
    }
}
