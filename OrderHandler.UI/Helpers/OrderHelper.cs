
namespace OrderHandler.UI.Helpers
{
    public static class OrderHelper
    {
        public static long GetOrderSum(int articlePrice, int articleAmount)
        {
            long sum = articlePrice * articleAmount;

            return sum;
        }
    }
}
