namespace GymStream{


public class Membership
    {
        // Properties
        public string? Tier { get; set; }
        public int DurationInMonths { get; set; }
        public double BasePricePerMonth { get; set; }

        /// <summary>
        /// Task: Validate if Tier is (Basic/Premium/Elite) and Duration > 0.
        /// Throw InvalidTierException or standard Exception as needed.
        /// </summary>
        public bool ValidateEnrollment()
        {
            // TODO: Implement Tier validation
            if(Tier != "Basic" && Tier != "Premium" && Tier != "Elite")
            {
                throw new InvalidTierException("Tier not recognized. Please choose an available membership plan");
            }
            // TODO: Implement Duration validation
            if(DurationInMonths <= 0)
            {
                throw new Exception("Duration must be at least one month");
            }
            return true; // Placeholder
        }

        /// <summary>
        /// Task: Calculate total price based on:
        /// Basic: 2%, Premium: 7%, Elite: 12%
        /// Formula: (Duration * Price) - Discount
        /// </summary>
        public double CalculateTotalBill()
        {
            // TODO: Calculate and return final price
            double total = DurationInMonths * BasePricePerMonth;
            double discountPrice = 0;

        switch (Tier)
        {
            case "Basic":
                discountPrice = 0.02;
                break;
            case "Premium":
                discountPrice = 0.07;
                break;
            case "Elite":
                discountPrice = 0.12;
                break;
        }


            return total - (total * discountPrice);
        }
    }
}