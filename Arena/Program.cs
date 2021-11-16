using Arena.BL;

namespace Arena
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BLFight.InitFighters();
            BLFight.DoFight();
        }
    }
}
