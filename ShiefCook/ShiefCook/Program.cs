namespace ShiefCook
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!\nWelcome in my Restaurant\n");

            Starter starter = new Starter();

            starter.Run();
        }
    }
}