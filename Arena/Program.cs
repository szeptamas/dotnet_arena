using System.Collections.Generic;
using Arena.Model;
using Arena.UI;

namespace Arena
{
    internal class Program
    {
        private static readonly List<Fighter> Fighters = new List<Fighter>();
        private static int _actualAttackerPos = 0;
        private static int _actualDefenderPos = 1;
        private static Fighter _actualAttacker;
        private static Fighter _actualDefender;
        private static int _round = 0;

        private static void Main(string[] args)
        {
            InitFighters();
            FightUI.ShowFighters(Fighters);
            DoFight();
            FightUI.ShowEnd(_actualAttacker);
        }

        #region Fight related methods

        private static void InitFighters()
        {
            //TRY: kommentezd ki ezeket, hogy ne legyenek harcosok
            Fighters.Add(new Fighter("Roland", 60, 25, 15));
            Fighters.Add(new Creature("Bálint", 50, 30, 10, 3));
        }

        // A játékmenet főciklusa.
        private static void DoFight()
        {
            if (Fighters.Count <= 0) return;

            bool isGameOver = false;

            do
            {
                ++_round;
                FightUI.ShowRound(_round);

                _actualAttacker = Fighters[GetNextFighter(ref _actualAttackerPos)];
                _actualDefender = Fighters[GetNextFighter(ref _actualDefenderPos)];

                DoSelfHeals();

                var damage = _actualAttacker.Attack();
                var block = _actualDefender.Block(damage);

                _actualDefender.Health -= damage - block;

                FightUI.ShowFightResults(_actualAttacker, _actualDefender, damage, block);
                FightUI.ShowStatus(Fighters);

                isGameOver = _actualDefender.IsDead();
            } while (!isGameOver);

        }

        private static void DoSelfHeals()
        {
            foreach (var fighter in Fighters)
            {
                if (fighter is not Creature creature) continue;
                if (fighter.Health >= fighter.HealthMax) continue;
                int heal = creature.HealSelf();
                if (heal <= 0) continue;

                FightUI.ShowHeal(fighter, heal);
            }
        }

        private static int GetNextFighter(ref int fighter)
        {
            if (++fighter >= Fighters.Count)
            {
                fighter = 0;
            }
            return fighter;
        }
        #endregion

    }

}
