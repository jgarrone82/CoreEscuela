using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreEscuela.Util
{
    public static class Printer
    {
        public static void DrawLine(int tam = 10)
        {
            System.Console.WriteLine("".PadLeft(tam, '='));
        }

        public static void PressENTER()
        {
             System.Console.WriteLine("Press ENTER to continue");
        }
        public static void WriteTitle(string title)
        {
            var size =title.Length + 4;
            DrawLine(size);
            System.Console.WriteLine($"| {title} |");
            DrawLine(size);
        }

        public static void Beep(int hz = 2000, int time=500, int amount =1)
        {
            while (amount-- > 0)
            {
                System.Console.Beep(hz, time);
            }
        }
    }
}