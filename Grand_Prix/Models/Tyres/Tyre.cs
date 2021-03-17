namespace Grand_Prix.Models.Tyres
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Tyre
    {
        private const string TYRE_EXCEPTION = "Blown tyre";

        private string name;
        private double hardness;
        private double degradation;

        public Tyre(string name, double hardness)
        {
            this.Name = name;
            this.Hardness = hardness;
            this.Degradation = 100;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public double Hardness
        {
            get
            {
                return this.hardness;
            }
            set
            {
                this.hardness = value;
            }
        }

        public virtual double Degradation
        {
            get
            {
                return this.degradation;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(TYRE_EXCEPTION);
                }
                this.degradation = value;
            }
        }

        public virtual void ReduceDegradation()
        {
            this.Degradation -= this.Hardness;
        }
    }
}
