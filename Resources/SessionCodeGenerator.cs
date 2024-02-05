namespace GamblingBackDW.Resources
{
    public static class SessionCodeGenerator
    {
        private static readonly Random random = new Random();
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public static string GenerateSessionCode(int length)
        {
            char[] code = new char[length];

            for (int i = 0; i < length; i++)
            {
                code[i] = Chars[random.Next(Chars.Length)];
            }

            return new string(code);
        }
    }

}
