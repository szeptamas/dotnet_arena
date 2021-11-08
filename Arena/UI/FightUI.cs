using System;
using Arena.Model;
using System.Collections.Generic;
using System.Linq;
using Arena.Helper;

namespace Arena.UI
{
    public class FightUI
    {
        public static void ShowFighters(List<Fighter> fighters)
        {
            UIHelper.ColorWriteLine("~0-= ~1ULTIMATE ~2ARENA ~3FIGHT ~0=-");
            UIHelper.ColorWriteLine("--------------------------");

            foreach (var fighter in fighters.Select((value, i) => new { i, value }))
            {
                UIHelper.ColorWriteLine($"{fighter.i + 1}. {fighter.value.Name}: {fighter.value.Species} | Tám.: ~1{fighter.value.AttackMax}~0 | Véd.: ~2{fighter.value.BlockMax}~0 | Erő: ~3{fighter.value.Health}~0");
            }
            UIHelper.ColorWriteLine("--------------------------");
            UIHelper.ColorWriteLine("   ~1Kezdődjön a harc!");
            Console.WriteLine();
        }

        public static void ShowRound(int round)
        {
            UIHelper.ColorWriteLine($"{round}. kör");
        }

        public static void ShowFightResults(Fighter actualAttacker, Fighter actualDefender, int damage, int block)
        {
            UIHelper.ColorWriteLine($"{actualAttacker.Name} támadja: {actualDefender.Name}. Sebzés: ~1{damage}~0");
            UIHelper.ColorWriteLine($"{actualDefender.Name} blokkol: ~2{block}~0, élete: ~3{actualDefender.Health}~0");
            UIHelper.ColorWriteLine("--------------------------");
        }

        public static void ShowHeal(Fighter fighter, int heal)
        {
            UIHelper.ColorWriteLine($"{fighter.Name} gyógyít magán: ~2{heal}~0, élete: ~3{fighter.Health}~0");
        }

        public static void ShowEnd(Fighter fighter)
        {
            UIHelper.ColorWrite("~3Játék vége! ~0");
            if (fighter != null)
            {
                UIHelper.ColorWrite($"A nyertes: ~2{fighter.Name}~0");
            }
            Console.WriteLine();
        }

        public static void ShowStatus(List<Fighter> fighters)
        {
            foreach (var fighter in fighters)
            {
                UIHelper.ColorWrite($"{fighter.Name}: ~3{fighter.Health}~0 | ");
            }
            Console.WriteLine();
            UIHelper.ColorWriteLine("========================");
            Console.WriteLine();
        }

    }
}
