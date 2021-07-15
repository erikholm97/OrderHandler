using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderHandler.UI.Helpers;

namespace OrderHandler.Tests
{
    [TestClass]
    public class OrderHelperTests
    {
        [TestMethod]
        public void GetOrderSum_ArticlePriceArticleAmount_ReturnOrderSum20()
        {
           long actualResult = OrderHelper.GetOrderSum(10, 2);
           
           long expectedResult = 20;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetOrderSum_ArticlePriceArticleAmount_ReturnWrongOrderSum()
        {
            long actualResult = OrderHelper.GetOrderSum(10, 2);

            long expectedResult = 100;

            Assert.AreNotEqual(expectedResult, actualResult);
        }
    }
}
