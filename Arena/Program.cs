using System;
using System.Collections.Generic;
using Arena.Interfaces;
using Arena.Model;

namespace Arena
{
    class Program
    {
        static List<Fighter> fighters = new List<Fighter>();
        static int actualFighter = 0;

        static void Main(string[] args)
        {
            InitFighters();
            ShowFighters();

            //TODO öngyógyítást megvalósítani

            bool isGameOver = false;
            Fighter actualAttacker;
            Fighter actualDefender;

            // A játékmenet főciklusa.
            do
            {
                actualAttacker = fighters[getNextFighter(actualFighter, 0)];
                actualDefender = fighters[getNextFighter(actualFighter, 1)];

                var damage = actualAttacker.Attack();
                var block = actualDefender.Block();

                if (block > damage)
                {
                    block = damage;
                }

                actualDefender.Health -= damage - block;

                //ShowActionResult()
                Console.WriteLine($"{actualAttacker.Name} támad. Sebzés: {damage}.");
                Console.WriteLine($"{actualDefender.Name} véd. Blokk: {block}.");
                Console.WriteLine($"{actualDefender.Name} élete: {actualDefender.Health}");
                Console.WriteLine();

                if (actualDefender.Health <= 0)
                {
                    isGameOver = true;
                }
            } while (!isGameOver);

            Console.WriteLine("Játék vége");
            Console.WriteLine($"A nyertes: {actualAttacker.Name}");

        }

        private static void ShowFighters()
        {
            foreach (var fighter in fighters)
            {
                Console.WriteLine($"Harcos: {fighter.Name}, Támadás: {fighter.AttackMax}, Védés: {fighter.BlockMax}");
            }
        }

        private static void InitFighters()
        {
            fighters.Add(new Fighter("Roland", 100, 30, 15));
            fighters.Add(new Creature("Bálint", 100, 30, 15, 1));
        }

        private static int getNextFighter(int actFighter, int step)
        {
            actFighter = actualFighter + step;
            if (actFighter >= fighters.Count)
            {
                actFighter = 0;
            }

            actualFighter = actFighter;
            return actFighter;
        }
    }

}
