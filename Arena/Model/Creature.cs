using System;

namespace Arena.Model
{
    public class Creature : Fighter
    {
        private static readonly Random Rnd = new Random();

        public int HealSelfMaxMax { get; set; }

        public Creature(string name, int health, int attackMax, int blockMax, int healSelfMax) : base(name, health, attackMax, blockMax)
        {
            HealSelfMaxMax = healSelfMax;
        }

        public int HealSelf()
        {
            return Rnd.Next(0, 1);
        }
    }
}
