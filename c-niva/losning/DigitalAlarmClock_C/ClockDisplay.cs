using System;
using System.Text.RegularExpressions;

namespace DigitalAlarmClock_C
{
    /// <summary>
    /// Representerar en digital klockdisplay för timmar
    /// och minuter.
    /// </summary>
    class ClockDisplay
    {
        #region Fält

        /// <summary>
        /// Display för timmar.
        /// </summary>
        private NumberDisplay _hourDisplay;

        /// <summary>
        /// Display för minuter.
        /// </summary>
        private NumberDisplay _minuteDisplay;

        #endregion

        #region Konstruktorer

        /// <summary>
        /// Initierar en ny instans av ClockDisplay.
        /// </summary>
        public ClockDisplay()
            : this(0, 0)
        {
            // Tom!
        }

        /// <summary>
        /// Initierar en ny instans av ClockDisplay med angiven timme och minut.
        /// </summary>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        public ClockDisplay(int hour, int minute)
        {
            this._hourDisplay = new NumberDisplay(23, hour);
            this._minuteDisplay = new NumberDisplay(59, minute);
        }

        /// <summary>
        /// Initierar en ny instans av ClockDisplay med angiven tid.
        /// </summary>
        /// <param name="time">En tid uttyckt som sträng enligt formatet HH:mm.</param>
        public ClockDisplay(string time)
        {
            this._hourDisplay = new NumberDisplay(23);
            this._minuteDisplay = new NumberDisplay(59);
            Time = time;
        }

        #endregion

        #region Egenskaper

        /// <summary>
        /// Hämtar eller tilldelar aktuellt ClockDisplay-objekts en tid.
        /// </summary>
        public string Time
        {
            get { return this.ToString(); }
            set
            {
                if (!Regex.IsMatch(value, "^(([0-1]?[0-9])|([2][0-3])):([0-5][0-9])$"))
                {
                    throw new FormatException(String.Format("Strängen '{0}' kan inte tolkas som en tid på formatet HH:mm.", value));
                }

                string[] split = value.Split(':');

                this._hourDisplay.Number = int.Parse(split[0]);
                this._minuteDisplay.Number = int.Parse(split[1]);
            }
        }

        #endregion

        #region Instansmetoder

        /// <summary>
        /// Lägger till en minut till aktuellt ClockDisplay-objektet.
        /// </summary>
        public void Increment()
        {
            this._minuteDisplay.Increment();
            if (this._minuteDisplay.Number == 0)
            {
                this._hourDisplay.Increment();
            }
        }

        #endregion

        #region Överskuggade instansmetoder

        /// <summary>
        /// Returnerar ett värde som anger om denna instans är lika med ett angivet objekt.
        /// </summary>
        /// <param name="obj">Objektet att jämföra denna instans med.</param>
        /// <returns>true om värdet är en instans av ClockDisplay motsvarar värdet av denna instans; annars false.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is ClockDisplay))
            {
                return false;
            }

            ClockDisplay other = (ClockDisplay)obj;

            return this._hourDisplay == other._hourDisplay &&
                this._minuteDisplay == other._minuteDisplay;
        }

        /// <summary>
        /// Returnerar hashkoden för denna instans.
        /// </summary>
        /// <returns>Ett 32-bitars heltal hashkod.</returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        /// <summary>
        /// Konverterar värdet av det aktuella ClockDisplay-objektet till motsvarande strängbeteckning.
        /// </summary>
        /// <returns>En sträng representerande värdet av det aktuella ClockDisplay-objektet.</returns>
        public override string ToString()
        {
            return String.Format("{0}:{1}",
                this._hourDisplay, this._minuteDisplay.ToString("00"));
        }

        #endregion

        #region Överlagring av operatorer

        /// <summary>
        /// Avgör om två instanser av ClockDisplay är lika.
        /// </summary>
        /// <param name="a">Första objektet att jämföra.</param>
        /// <param name="b">Andra objektet att jämföra.</param>
        /// <returns>true om a och b representerar samma nummer; annars false.</returns>
        public static bool operator ==(ClockDisplay a, ClockDisplay b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Avgör om två instanser av ClockDisplay inte är lika.
        /// </summary>
        /// <param name="a">Första objektet att jämföra.</param>
        /// <param name="b">Andra objektet att jämföra.</param>
        /// <returns>true om a och b inte representerar samma nummer; annars false.</returns>
        public static bool operator !=(ClockDisplay a, ClockDisplay b)
        {
            return !a.Equals(b);
        }

        #endregion
    }
}
