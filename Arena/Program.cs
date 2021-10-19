using System;

namespace Arena
{
    class Program
    {
        static void Main(string[] args)
        {

            // jöjjön létre 2 harcos
            Fighter warrior1 = new Fighter("Roland", 100, 30, 15);
            Fighter warrior2 = new Fighter("Bálint", 100, 30, 15);

            // írjuk ki a harcosok tulajdonságait
            Console.WriteLine($"1. harcos: {warrior1.Name}");
            Console.WriteLine($"2. harcos: {warrior2.Name}");


            // harcoljanak halálig
            while (true)
            {
                int damage;
                int block;

                damage = warrior1.Attack();
                block = warrior2.Block();
                if (block > damage)
                {
                    block = damage;
                }
                warrior2.Health -= damage - block;

                Console.WriteLine($"{warrior1.Name} támad. Sebzés: {damage}.");
                Console.WriteLine($"{warrior2.Name} véd. Blokk: {block}.");
                Console.WriteLine($"{warrior2.Name} élete: {warrior2.Health}");
                Console.WriteLine();

                if (warrior2.Health <= 0)
                {
                    break;
                }

                damage = warrior2.Attack();
                block = warrior1.Block();
                if (block > damage)
                {
                    block = damage;
                }
                warrior1.Health -= damage - block;

                Console.WriteLine($"{warrior2.Name} támad. Sebzés: {damage}.");
                Console.WriteLine($"{warrior1.Name} véd. Blokk: {block}.");
                Console.WriteLine($"{warrior1.Name} élete: {warrior1.Health}");
                Console.WriteLine();

                if (warrior1.Health <= 0)
                {
                    break;
                }
            }

            // írjuk ki hogy ki nyert
            Console.WriteLine("Játék vége");
            string nyertes = warrior1.Health > warrior2.Health ? warrior1.Name : warrior2.Name;
            Console.WriteLine($"A nyertes: {nyertes}");

        }
    }

}
