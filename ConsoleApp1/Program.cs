namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = 3;
            if (n % 2 == 0)
            {
                while (n % 2 == 0)
                {
                    n = n / 2;
                }
                if (n == 1)
                {
                    Console.WriteLine("wuvvetdir");
                }
                else
                {
                    Console.WriteLine("deyil");
                }
            }
            else
            {
                Console.WriteLine("deyildir");
            }
        }
    }
}