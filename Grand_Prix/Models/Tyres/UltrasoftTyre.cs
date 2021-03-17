namespace Grand_Prix.Models.Tyres
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UltrasoftTyre : Tyre
    {
        private const string TYRE_EXCEPTION = "Blown tyre";
        private const double ULTRASOFT_TYRE_MIN_DEGRADATION = 30;

        private double grip;
        private double degradation;

        public UltrasoftTyre(double hardness, double grip)
            : base("Ultrasoft", hardness)
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
                if (value < ULTRASOFT_TYRE_MIN_DEGRADATION)
                {
                    throw new ArgumentException(TYRE_EXCEPTION);
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
