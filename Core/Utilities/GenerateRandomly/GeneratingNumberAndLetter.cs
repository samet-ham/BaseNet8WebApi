using System;

namespace Core.Utilities.GenerateRandomly
{
    public class GeneratingNumberAndLetter
    {
        public static string Generate(int number)
        {
            Random random = new Random();

            string characterPool = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

            string randomCharacter = new string(
            Enumerable.Repeat(characterPool, number)
                      .Select(s => s[random.Next(s.Length)])
                      .ToArray()
                       );

            return randomCharacter;
        }
    }
}
