namespace TestDevOpsApp.Tests
{
    public class DiscountTests
    {
        [Fact]
        public void CalculateDiscount_ShouldReturnCorrectValue()
        {
            var total = 100;
            var discount = 20;
            var expected = 70;

            var result = total - discount;

            Assert.Equal(expected, result); 
        }
    }
}