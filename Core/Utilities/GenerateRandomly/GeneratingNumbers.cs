namespace Core.Utilities.GenerateRandomly
{
    public class GeneratingNumbers
    {
        public static int Generate(int number)
        {
            Random random = new Random();

            int minValue = (int)Math.Pow(10, number - 1);
            int maxValue = (int)Math.Pow(10, number) - 1;

            int randomNumber = random.Next(minValue, maxValue + 1);

            return randomNumber;
        }
    }
}
