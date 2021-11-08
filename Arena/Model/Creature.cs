using System;

namespace Arena.Model
{
    public class Creature : Fighter
    {
        private static readonly Random Rnd = new Random();

        public int HealSelfMax { get; set; }

        public Creature(string name, int health, int attackMax, int blockMax, int healSelfMax) : base(name, health, attackMax, blockMax)
        {
            Species = "Lény";
            HealSelfMax = healSelfMax;
        }

        public int HealSelf()
        {
            int heal = Rnd.Next(0, HealSelfMax + 1);
            Health = Health + heal > HealthMax ? HealthMax : Health + heal;
            return heal;
        }
    }
}
