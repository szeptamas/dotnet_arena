using System;

namespace Arena.Helper
{
    public class UIHelper
    {
        public static void ColorWriteLine(string s)
        {
            ColorWrite(s);
            Console.WriteLine();
        }

        public static void ColorWrite(string s)
        {
            ConsoleColor originalColor = Console.ForegroundColor;

            int i = 0;
            while (i < s.Length)
            {
                // ha szín kezdet jelölés van
                if (s[i] == '~')
                {
                    // köv. karakter: színt jelölő szám
                    ++i;
                    if (i >= s.Length) break;
                    int color = int.Parse(s[i].ToString());

                    // szín beállítása
                    switch (color)
                    {
                        case 0:
                            Console.ForegroundColor = originalColor;
                            break;
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case 3:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            break;
                    }
                    ++i;
                }
                if (i >= s.Length) break;

                // kiírjuk az aktuális karaktert
                Console.Write(s[i].ToString());

                ++i;
            }

            Console.ForegroundColor = originalColor;
        }
    }
}
