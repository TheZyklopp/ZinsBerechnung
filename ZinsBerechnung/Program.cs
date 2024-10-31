using System;

namespace ZinsBerechnung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double kapital = EingabeStartkapital();
            double zinssatz = EingabeZinssatz();
            int laufzeit = EingabeLaufzeit();
            double gewinn = BerechneZinsGewinn(kapital, zinssatz, laufzeit);

            // Hier können Sie die Zinsberechnung durchführen und das Ergebnis anzeigen
            Console.WriteLine($"Du hast nach der Laufzeit von {laufzeit} Jahren einen Gewinn von: {gewinn}€");
        }

        // Methode zur Eingabe des Startkapitals
        static double EingabeStartkapital()
        {
            Console.WriteLine("Bitte geben Sie das Startkapital in EUR ein:");
            double kapital;
            while (!double.TryParse(Console.ReadLine(), out kapital) || kapital <= 0)
            {
                Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine gültige Dezimalzahl größer als 0 ein:");
            }
            return kapital;
        }

        // Methode zur Eingabe des Zinssatzes
        static double EingabeZinssatz()
        {
            Console.WriteLine("Bitte geben Sie den Zinssatz in % ein:");
            double zinssatz;
            while (!double.TryParse(Console.ReadLine(), out zinssatz) || zinssatz <= 0)
            {
                Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine gültige Dezimalzahl größer als 0 ein:");
            }
            return zinssatz;
        }

        // Methode zur Eingabe der Laufzeit
        static int EingabeLaufzeit()
        {
            Console.WriteLine("Bitte geben Sie die Laufzeit in Jahren ein:");
            int laufzeit;
            while (!int.TryParse(Console.ReadLine(), out laufzeit) || laufzeit <= 0) //versuche in ganzzahl zu KOnvertieren Oder prüft ob die laufzeit 0 oder größer ist.
            {
                Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine gültige Ganzzahl größer als 0 ein:");
            }
            return laufzeit;
        }

        // Methode zur Berechnung des Zinsgewinns mit Zinseszins
        /// <summary>
        /// Berechnet den Zinsgewinn unter Berücksichtigung des Zinseszinses.
        /// </summary>
        /// <param name="kapital">Das Startkapital in EUR.</param>
        /// <param name="zinssatz">Der Zinssatz in Prozent.</param>
        /// <param name="laufzeit">Die Laufzeit in Jahren.</param>
        /// <returns>Der berechnete Zinsgewinn auf zwei Nachkommastellen gerundet.</returns>
        public static double BerechneZinsGewinn(double kapital, double zinssatz, int laufzeit)
        {
            double endkapital = kapital * Math.Pow(1 + zinssatz / 100, laufzeit); //Math.Pow hebt den Zinsfaktor auf die Potenz der Laufzeit.
            double gewinn = endkapital - kapital;
            return Math.Round(gewinn, 2); //rundet bis zur zweiten nachkommastelle.
        }
    }
}
