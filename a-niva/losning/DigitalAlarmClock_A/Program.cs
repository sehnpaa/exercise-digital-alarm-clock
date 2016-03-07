using System;

namespace DigitalAlarmClock_A
{
    class Program
    {
        private static readonly string HorizontalLine = new String('═', 79);

        static void Main(string[] args)
        {
            Console.Title = "Digital väckarklocka - nivå A";

            // Klockan går 8 minuter från 9:54. Larmtiden ställd på 10:00
            AlarmClock ac2 = new AlarmClock(9, 54, 10, 0);
            Run(ac2, 8);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            
            // Test 1: 
            // Kontrollera att konstruktor #1 fungerar.
            ViewTestHeader("Test 1.\nTest av standardkonstruktorn.");
            AlarmClock ac = new AlarmClock();
            Console.WriteLine(ac);

            // Test 2: 
            // Kontrollera att konstruktor #2 fungerar.
            ViewTestHeader("Test 2.\nTest av konstruktorn med två parametrar, (9, 42).");
            Console.ResetColor();
            ac = new AlarmClock(9, 42);
            Console.WriteLine(ac);

            // Test 3: 
            // Kontrollera att konstruktor #3 fungerar.
            ViewTestHeader("Test 3.\nTest av konstruktorn med fyra parametrar, (13, 24, 7, 35).");
            ac = new AlarmClock(13, 24, 7, 35);
            Console.WriteLine(ac);

            // Test 4:
            // Kontrollera att klockan går som den ska beträffande timmar och minuter. 
            // Gå från 23:58 till 0:11
            ViewTestHeader("Test 4.\nStäller befintligt AlarmClock-objekt till 23:58 och låter den gå 13 minuter.");
            ac.Hour = 23;
            ac.Minute = 58;
            Run(ac, 13);

            // Test 5:
            // Kontrollera att alarmtiden fungerar.
            ViewTestHeader("Test 5.\nStäller befintligt AlarmClock-objekt till tiden 6:12 och alarmtiden till 6:15\noch låter den gå 6 minuter.");
            ac.Hour = 6;
            ac.Minute = 12;
            ac.AlarmHour = 6;
            ac.AlarmMinute = 15;
            Run(ac, 6);

            // Test 6:
            // Kontrollera att det inte går att initiera eller tilldela ett objekt felaktiga värden.
            ViewTestHeader("Test 6.\nTestar egenskaperna så att undantag kastas då tid och alarmtid tilldelas \nfelaktiga värden.");

            try     // Egenskap Hour.
            {
                ac.Hour = 24;
            }
            // Fånga undantagsobjekt (i detta fall ArgumentException) som ev. kastas i klassen AlarmClock.
            catch (Exception ex)
            {
                // Skriv ut dess "inbyggda" meddelande som genererats i klassen AlarmClock.
                ViewErrorMessage(ex.Message);
            }

            try     // Egenskap Minute.
            {
                ac.Minute = 60;
            }
            catch (Exception ex)
            {
                ViewErrorMessage(ex.Message);
            }

            try     // Egenskap AlarmHour.
            {
                ac.AlarmHour = 24;
            }
            catch (Exception ex)
            {
                ViewErrorMessage(ex.Message);
            }

            try     // Egenskap AlarmMinute.
            {
                ac.AlarmMinute = 60;
            }
            catch (Exception ex)
            {
                ViewErrorMessage(ex.Message);
            }

            // Test 7:
            // Kontrollera att det inte går att initiera eller tilldela ett objekt felaktiga värden.
            ViewTestHeader("Test 7.\nTestar konstruktorer så att undantag kastas då tid och alarmtid tilldelas \nfelaktiga värden.");

            try      // Konstruktorn med två parametrar.
            {
                new AlarmClock(25, 89);
            }
            catch (Exception ex)
            {
                ViewErrorMessage(ex.Message);
            }

            try      // Konstruktorn med fyra parametrar.
            {
                new AlarmClock(0, 0, 25, 89);
            }
            catch (Exception ex)
            {
                ViewErrorMessage(ex.Message);
            }

            //// Skapar en ny digital väckarklocka och gör slumpmässig test.
            //ac = new AlarmClock(23, 59);
            //Run(ac, 10);

            //try
            //{
            //    ac.Hour = new Random().Next(24, 1000);
            //}
            //catch (Exception ex)
            //{
            //    Console.BackgroundColor = ConsoleColor.Red;
            //    Console.ForegroundColor = ConsoleColor.White;
            //    Console.WriteLine(ex.Message);
            //    Console.ResetColor();
            //}

        }

        private static void Run(AlarmClock ac, int minutes)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ╔═════════════════════════════════════╗ ");
            Console.WriteLine(" ║      Väckarklockan URLED (TM)       ║ ");
            Console.Write(" ║       ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Modellnr.: 1DV024S2A");
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
                    Console.WriteLine(" ♫ {0}   BEEP! BEEP! BEEP! BEEP!", ac);
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("   {0}", ac);
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

