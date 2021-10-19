using System;

namespace Arena
{
    class Program
    {
        static void Main(string[] args)
        {

            // jöjjön létre 2 harcos
            Fighter warrior1 = new Fighter("Roland", 100, 10, 5);
            Fighter warrior2 = new Fighter("Bálint", 100, 10, 5);

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

    public class Fighter
    {
        private static Random random = new Random();

        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackMax { get; set; }
        public int BlockMax { get; set; }

        public Fighter(string name, int health, int attackMax, int blockMax)
        {
            Name = name;
            Health = health;
            AttackMax = attackMax;
            BlockMax = blockMax;
        }

        public int Attack()
        {
            return random.Next(0, AttackMax + 1);
        }

        public int Block()
        {
            return random.Next(0, BlockMax + 1);
        }
    }
}
