using System;

namespace DigitalAlarmClock_C
{
    class Program
    {
        private static readonly string HorizontalLine = new String('═', 79);

        static void Main(string[] args)
        {
            Console.Title = "Digital väckarklocka - nivå C";

            //// Initial test: Klockan går 8 minuter från 9:54. Larmtider ställda på 9:57 och 10:00
            //AlarmClock ac2 = new AlarmClock("9:54", "9:57", "10:00");
            //Run(ac2, 8);
            //return;

            // Test 1.
            // Kontrollerar standardkonstruktor.
            ViewTestHeader("Test 1.\nTest av standardkonstruktorn.");
            AlarmClock ac = new AlarmClock();
            Console.WriteLine(ac);

            // Test 2.
            // Kontrollera konstruktor med två parametrar av typen int.
            ViewTestHeader("Test 2.\nTest av konstruktorn med två parametrar, (9, 42).");
            Console.ResetColor();
            ac = new AlarmClock(9, 42);
            Console.WriteLine(ac);

            // Test 3.
            // Kontrollerar konstruktor med fyra parametrar.
            ViewTestHeader("Test 3.\nTest av konstruktorn med fyra parametrar, (13, 24, 7, 35).");
            ac = new AlarmClock(13, 24, 7, 35);
            Console.WriteLine(ac);

            // Test 4.
            // Kontrollerar konstruktor med variabelt antal, dock minst två, parametrar av typen string. 
            ViewTestHeader("Test 4.\nTest av konstruktorn med minst två parametrar av typen string, (\"7:07\", \"7:10\", \"7:15\", \"7:30\").");
            ac = new AlarmClock("7:07", "7:10", "7:15", "7:30");
            Console.WriteLine(ac);

            // Test 5.
            // Kontrollerar att klockan går som den ska beträffande timmar och minuter. Går från 23:58 till 0:11.
            ViewTestHeader("Test 5.\nStäller befintligt AlarmClock-objekt till 23:58 och låter den gå 13 minuter.");
            ac.Time = "23:58";
            Run(ac, 13);

            // Test 6.
            // Kontrollera att alarmtiden fungerar.
            ViewTestHeader("Test 6.\nStäller befintligt AlarmClock-objekt till tiden 6:12 och alarmtiden till 6:15\noch låter den gå 6 minuter.");
            ac.Time = "6:12";
            ac.AlarmTimes = new string[] { "6:15" };
            Run(ac, 6);

            // Test 7.
            // Kontrollerar att det inte går att initiera eller tilldela ett objekt felaktiga värden via egenskaper.
            ViewTestHeader("Test 7.\nTestar egenskaperna så att undantag kastas då tid och alarmtid tilldelas \nfelaktiga värden.");

            try
            {
                ac.Time = "24:89";
            }
            catch (Exception ex)
            {
                ViewErrorMessage(ex.Message);
            }

            try
            {
                ac.AlarmTimes = new string[] { "7:69" };
            }
            catch (Exception ex)
            {
                ViewErrorMessage(ex.Message);
            }


            // Test 8.
            // Kontrollerar att det inte går att initiera eller tilldela ett objekt felaktiga värden via konstruktorer.
            ViewTestHeader("Test 8.\nTestar konstruktorer så att undantag kastas då tid och alarmtider tilldelas \nfelaktiga värden.");

            try
            {
                new AlarmClock("32:03", "7:00");
            }
            catch (Exception ex)
            {
                ViewErrorMessage(ex.Message);
            }

            try
            {
                new AlarmClock("0:00", "6:10", "27:00");
            }
            catch (Exception ex)
            {
                ViewErrorMessage(ex.Message);
            }
        }

        private static void Run(AlarmClock ac, int minutes)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ╔═════════════════════════════════════╗ ");
            Console.WriteLine(" ║      Väckarklockan URLED (TM)       ║ ");
            Console.Write(" ║       ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Modellnr.: 1DV024S2C");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("          ║ ");
            Console.WriteLine(" ╚═════════════════════════════════════╝ ");
            Console.ResetColor();

            for (int i = 0; i < minutes; i++)
            {
                if (ac.TickTock())
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" ♫ {0,5}   BEEP! BEEP! BEEP! BEEP!", ac);
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("   {0,5}", ac);
                }

            }
            Console.WriteLine();
        }

        private static void ViewErrorMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static void ViewTestHeader(string header)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine(HorizontalLine);
            Console.WriteLine(header);
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
