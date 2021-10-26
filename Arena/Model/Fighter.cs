using System;
using Arena.Interfaces;

namespace Arena.Model
{
    public class Fighter : IFighter
    {
        private static readonly Random Rnd = new Random();

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
            return Rnd.Next(0, AttackMax + 1);
        }

        public int Block()
        {
            return Rnd.Next(0, BlockMax + 1);
        }
    }
}