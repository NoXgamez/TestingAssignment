using System.Security.Claims;
using NUnit.Framework;
using Moq;
using NUnit.Framework.Internal;
using System.Net.NetworkInformation;

namespace TestingAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public interface IDiscountService
    {
        double GetDiscount();
    }

    public class InsuranceService
    {
        private readonly IDiscountService _ds;

        public InsuranceService(IDiscountService discountService)
        {
            _ds = discountService;
        }

        public double CalcPremium(int age, string location)
        {
            double premium;

            if (location == "rural")
	            if ((age >= 18) && (age <= 30))
                    premium = 5.0;
                else if (age >= 31)
                    premium = 2.50;
                else
                    premium = 0.0;
            else if (location == "urban")
	            if ((age >= 18) && (age <= 35))
                    premium = 6.0;
                else if (age >= 36)
                    premium = 5.0;
                else
                    premium = 0.0;
            else
                premium = 0.0;

                //DiscountService ds = new DiscountService(null);
                double discount = _ds.GetDiscount();
                if (age >= 50)
                    premium = premium * discount;

            return premium;
        }
    }

}
