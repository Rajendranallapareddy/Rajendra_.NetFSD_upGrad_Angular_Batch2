using System;

namespace OCP_DiscountCalculation
{
    // Interface for discount strategy
    public interface IDiscountStrategy
    {
        double CalculateDiscount(double amount);
    }

    // Regular Customer: 5% discount
    public class RegularCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.05;
        }
    }

    // Premium Customer: 15% discount
    public class PremiumCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.15;
        }
    }

    // VIP Customer: 25% discount
    public class VipCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.25;
        }
    }

    // Class to calculate final price
    public class PriceCalculator
    {
        public double CalculateFinalPrice(double amount, IDiscountStrategy discountStrategy)
        {
            double discount = discountStrategy.CalculateDiscount(amount);
            return amount - discount;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PriceCalculator calculator = new PriceCalculator();
            double amount = 1000;

            Console.WriteLine($"Original Amount: ${amount}\n");

            IDiscountStrategy regular = new RegularCustomerDiscount();
            double regularPrice = calculator.CalculateFinalPrice(amount, regular);
            Console.WriteLine($"Regular Customer - Discount: 5%, Final Price: ${regularPrice}");

            IDiscountStrategy premium = new PremiumCustomerDiscount();
            double premiumPrice = calculator.CalculateFinalPrice(amount, premium);
            Console.WriteLine($"Premium Customer - Discount: 15%, Final Price: ${premiumPrice}");

            IDiscountStrategy vip = new VipCustomerDiscount();
            double vipPrice = calculator.CalculateFinalPrice(amount, vip);
            Console.WriteLine($"VIP Customer - Discount: 25%, Final Price: ${vipPrice}");

            Console.ReadLine();
        }
    }
}