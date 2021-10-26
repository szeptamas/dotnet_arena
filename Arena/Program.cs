using System;
using Arena.Model;

namespace Arena
{
    class Program
    {
        static void Main(string[] args)
        {

            Fighter warrior1 = new Fighter("Roland", 100, 30, 15);
            Creature creature1 = new Creature("Bálint", 100, 30, 15, 1);

            //TODO 1 öngyógyítást megvalósítani

            //TODO 2 refaktorálni a harcot

            Console.WriteLine($"1. harcos: {warrior1.Name}");
            Console.WriteLine($"2. harcos: {creature1.Name}");

            bool isGameOver = false;
            do
            {
                int damage;
                int block;

                damage = warrior1.Attack();
                block = creature1.Block();
                if (block > damage)
                {
                    block = damage;
                }

                creature1.Health -= damage - block;

                Console.WriteLine($"{warrior1.Name} támad. Sebzés: {damage}.");
                Console.WriteLine($"{creature1.Name} véd. Blokk: {block}.");
                Console.WriteLine($"{creature1.Name} élete: {creature1.Health}");
                Console.WriteLine();

                if (creature1.Health <= 0)
                {
                    isGameOver = true;
                }

                damage = creature1.Attack();
                block = warrior1.Block();
                if (block > damage)
                {
                    block = damage;
                }

                warrior1.Health -= damage - block;

                Console.WriteLine($"{creature1.Name} támad. Sebzés: {damage}.");
                Console.WriteLine($"{warrior1.Name} véd. Blokk: {block}.");
                Console.WriteLine($"{warrior1.Name} élete: {warrior1.Health}");
                Console.WriteLine();

                if (warrior1.Health <= 0)
                {
                    isGameOver = true;
                }
            } while (!isGameOver);

            Console.WriteLine("Játék vége");
            string nyertes = warrior1.Health > creature1.Health ? warrior1.Name : creature1.Name;
            Console.WriteLine($"A nyertes: {nyertes}");

        }
    }

}
