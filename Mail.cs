using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public abstract class Mail
    {
        // Attributes common to all types of mail
        internal double weight;
        internal string shippingMethod;
        internal string destinationAddress;
        

        // Constructor to initialize the common attributes
        public Mail(double weight, string shippingMethod, string destinationAddress)
        {
            this.weight = weight;
            this.shippingMethod = shippingMethod;
            this.destinationAddress = destinationAddress;
        }

        // Abstract method to calculate the postage for the specific type of mail
        public abstract double CalculatePostage();

        // Virtual method to check if the mail is valid
        public virtual bool IsValid()
        {
            return !string.IsNullOrEmpty(destinationAddress);
        }
    }

    // Derived Classes
    public class Letter : Mail
    {
        // Additional attribute specific to letters
        private string format;

        // Constructor to initialize the letter-specific attributes
        public Letter(double weight, string shippingMethod, string destinationAddress, string format)
            : base(weight, shippingMethod, destinationAddress)
        {
            this.format = format;
        }

        // Override the CalculatePostage method for letters
        public override double CalculatePostage()
        {
            double baseFare = format == "A4" ? 2.50 : 3.50;
            double amount = baseFare + (weight / 1000.0);
            return shippingMethod == "express" ? amount * 2 : amount;
        }
    }

    public class Parcel : Mail
    {
        // Additional attribute specific to parcels
        private double volume;

        // Constructor to initialize the parcel-specific attributes
        public Parcel(double weight, string shippingMethod, string destinationAddress, double volume)
            : base(weight, shippingMethod, destinationAddress)
        {
            this.volume = volume;
        }

        // Override the CalculatePostage method for parcels
        public override double CalculatePostage()
        {
            double amount = 0.25 * volume + (weight / 1000.0);
            return shippingMethod == "express" ? amount * 2 : amount;
        }

        // Override the IsValid method for parcels to include the volume check
        public override bool IsValid()
        {
            return base.IsValid() && volume <= 50;
        }
    }

    public class Advertisement : Mail
    {
        // Constructor to initialize the advertisement-specific attributes
        public Advertisement(double weight, string shippingMethod, string destinationAddress)
            : base(weight, shippingMethod, destinationAddress) { }

        // Override the CalculatePostage method for advertisements
        public override double CalculatePostage()
        {
            double amount = 5.0 * (weight / 1000.0);
            return shippingMethod == "express" ? amount * 2 : amount;
        }
    }
}
