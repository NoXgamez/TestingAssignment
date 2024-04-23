using Moq;
using NUnit.Framework;
using TestingAssignment;
namespace TestingAssignment.Test
{
    
    [TestFixture]
    public class InsuranceServiceTests
    {
        [Test]
        public void InsuranceExists()
        {
            var mockDiscountService = new Mock<IDiscountService>();
            InsuranceService _is = new InsuranceService(mockDiscountService.Object);

            Assert.That(_is, Is.Not.Null);
        }

        [Test]
        public void InsuranceUnderFifty()
        {
            Assert.That(false, Is.False);

            var mockDiscountService = new Mock<IDiscountService>();
            mockDiscountService.Setup(x => x.GetDiscount()).Returns(0.8);
            InsuranceService _is = new InsuranceService(mockDiscountService.Object);

            double res = _is.CalcPremium(19, "rural");

            Assert.That(res, Is.EqualTo(5));
        }

        [Test]
        public void InsuranceAboveFifty()
        {
            Assert.That(false, Is.False);

            var mockDiscountService = new Mock<IDiscountService>();
            mockDiscountService.Setup(x => x.GetDiscount()).Returns(0.8);
            InsuranceService _is = new InsuranceService(mockDiscountService.Object);

            double res = _is.CalcPremium(68, "urban");

            Assert.That(res, Is.EqualTo(4));
        }

        [Test]
        public void InsuranceFails()
        {
            Assert.That(false, Is.False);

            var mockDiscountService = new Mock<IDiscountService>();
            mockDiscountService.Setup(x => x.GetDiscount()).Returns(0.8);
            InsuranceService _is = new InsuranceService(mockDiscountService.Object);

            double res = _is.CalcPremium(19, "denmark");

            Assert.That(res, Is.EqualTo(0));
        }
    }
}
