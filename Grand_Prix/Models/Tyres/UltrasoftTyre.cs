namespace Grand_Prix.Models.Tyres
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UltrasoftTyre : Tyre
    {
        private double grip;
        private double degradation;

        public UltrasoftTyre(double hardness, double grip)
            :base("Ultrasoft", hardness)
        {
            this.Grip = grip;
        }

        public override double Degradation
        {
            get
            {
                return this.degradation;
            }
            set
            {
                if (value<30)
                {
                    throw new ArgumentException("Blown tyre");
                }
                this.degradation = value;
            }
        }

        public double Grip 
        {
            get 
            { 
                return this.grip; 
            }
            set 
            { 
                this.grip = value;
            }
        }

        public override void ReduceDegradation()
        {
            this.Degradation -= this.Hardness + this.Grip;
        }
    }
}
