namespace Grand_Prix.Models.Cars
{
    using Grand_Prix.Models.Tyres;

    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Car
    {
        double fuelAmount;

        public Car(int hp, double fuelAmount, Tyre tyre)
        {
            this.Hp = hp;
            this.FuelAmount = fuelAmount;
            this.Tyre = tyre;
        }

        public int Hp { get; set; }

        public double FuelAmount 
        {
            get
            {
                return this.fuelAmount;
            }
            set
            {
                if (value>160)
                {
                    value = 160;
                }
                if (value<0)
                {
                    throw new ArgumentException("Out of fuel");
                }

                this.fuelAmount = value;
            } 
        }

        public Tyre Tyre { get; set; }

        public void Refuel(double liters)
        {
            this.FuelAmount += liters;
        }

        public void ChangeTyres(Tyre newTyre)
        {
            this.Tyre = newTyre;
        }

        public void ReduceFuel(int length, double fuelConsumptionPerKm)
        {
            this.FuelAmount -= length * fuelConsumptionPerKm;
        }
    }
}
