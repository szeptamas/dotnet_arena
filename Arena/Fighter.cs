using System;

namespace Arena
{
    public class Fighter
    {
        private static Random random = new Random();

        public Fighter(string name, int health, int attackMax, int blockMax)
        {
            Name = name;
            Health = health;
            AttackMax = attackMax;
            BlockMax = blockMax;
        }

        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackMax { get; set; }
        public int BlockMax { get; set; }

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