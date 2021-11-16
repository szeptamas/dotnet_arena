using Arena.Model;
using Arena.UI;
using System.Collections.Generic;
using System.Linq;

namespace Arena.BL
{
    public static class BLFight
    {
        private static readonly List<Fighter> Fighters = new List<Fighter>();
        private static int _actualAttackerPos = -1;
        private static int _actualDefenderPos = 0;
        private static Fighter _actualAttacker;
        private static Fighter _actualDefender;
        private static int _round = 0;

        public static void InitFighters()
        {
            Fighters.Add(new Fighter("Roland", 40, 13, 7));
            Fighters.Add(new Creature("Bálint", 35, 10, 5, 1));
            Fighters.Add(new Creature("Tamás", 30, 11, 2, 1));
            Fighters.Add(new Fighter("Eszter", 45, 15, 4));
            Fighters.Add(new Fighter("Csilla", 50, 18, 5));

            FightUI.ShowFighters(Fighters);
        }

        // A játékmenet főciklusa.
        public static void DoFight()
        {
            if (Fighters.Count <= 0) return;

            bool isGameOver = false;

            do
            {
                ++_round;
                FightUI.ShowRound(_round);

                _actualAttacker = Fighters[GetNextFighter(ref _actualAttackerPos)];
                do
                {
                    _actualDefender = Fighters[GetNextFighter(ref _actualDefenderPos)];
                } while (_actualAttackerPos == _actualDefenderPos);

                DoSelfHeals();

                var damage = _actualAttacker.Attack();
                var block = _actualDefender.Block(damage);

                _actualDefender.Health -= damage - block;

                FightUI.ShowFightResults(_actualAttacker, _actualDefender, damage, block);
                FightUI.ShowStatus(Fighters);

                isGameOver = (from item in Fighters
                              where !item.IsDead()
                              select item).Count() == 1;
            } while (!isGameOver);

            FightUI.ShowEnd(_actualAttacker);
        }

        private static void DoSelfHeals()
        {
            foreach (var fighter in Fighters)
            {
                if (fighter is not Creature creature) continue;
                if (fighter.IsDead()) continue;
                if (fighter.Health >= fighter.HealthMax) continue;
                int heal = creature.HealSelf();
                if (heal <= 0) continue;

                FightUI.ShowHeal(fighter, heal);
            }
        }

        private static int GetNextFighter(ref int fighter)
        {
            int counter = 0;
            do
            {
                fighter++;
                counter++;
                if (fighter >= Fighters.Count)
                {
                    fighter = 0;
                }

            } while (Fighters[fighter].IsDead() || counter <= Fighters.Count);

            return fighter;
        }

    }
}
