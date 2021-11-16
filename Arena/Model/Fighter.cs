using System;
using Arena.Interfaces;

namespace Arena.Model
{
    public class Fighter : IFighter
    {
        private static readonly Random Rnd = new Random();

        public Fighter(string name, int healthMax, int attackMax, int blockMax)
        {
            if (attackMax < 1)
            {
                throw new ArgumentException("Attack value must be minimum 1.");
            }

            Species = "Ember";
            Name = name;
            HealthMax = healthMax;
            Health = healthMax;
            AttackMax = attackMax;
            BlockMax = blockMax;
        }

        public string Species { get; set; }
        public string Name { get; set; }
        public int HealthMax { get; set; }
        public int Health { get; set; }
        public int AttackMax { get; set; }
        public int BlockMax { get; set; }

        public int Attack()
        {
            return Rnd.Next(1, AttackMax + 1);
        }

        public int Block(int damage)
        {
            int dmg = Rnd.Next(0, BlockMax + 1);
            return dmg > damage ? damage : dmg;
        }

        public bool IsDead()
        {
            return Health <= 0;
        }
    }
}