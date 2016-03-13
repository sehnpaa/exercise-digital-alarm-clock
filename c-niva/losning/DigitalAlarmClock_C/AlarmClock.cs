using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigitalAlarmClock_C
{
    /// <summary>
    /// Representerar en digital väckarklocka med flera
    /// alarmtider.
    /// </summary>
    class AlarmClock
    {
        #region Fält

        /// <summary>
        /// Alarmtider.
        /// </summary>
        private ClockDisplay[] _alarmTimes;

        /// <summary>
        /// Aktuell tid.
        /// </summary>
        private ClockDisplay _time;

        #endregion

        #region Konstruktorer

        /// <summary>
        /// Initierar en ny instans av AlarmClock.
        /// </summary>
        public AlarmClock()
            : this(0, 0)
        {
            // Tom!
        }

        /// <summary>
        /// Initierar en ny instans av ClockDisplay med angiven tid.
        /// </summary>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        public AlarmClock(int hour, int minute)
            : this(hour, minute, 0, 0)
        {
            // Tom!
        }

        /// <summary>
        /// Initierar en ny instans av ClockDisplay med angiven tid och alarmtid.
        /// </summary>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="alarmHour"></param>
        /// <param name="alarmMinute"></param>
        public AlarmClock(int hour, int minute, int alarmHour, int alarmMinute)
        {
            this._time = new ClockDisplay(hour, minute);
            this._alarmTimes = new ClockDisplay[] { new ClockDisplay(alarmHour, alarmMinute) };
        }

        /// <summary>
        /// Initierar en ny instans av ClockDisplay med angiven tid och alarmtider.
        /// </summary>
        /// <param name="time"></param>
        /// <param name="alarmTimes"></param>
        public AlarmClock(string time, params string[] alarmTimes)
        {
            this._time = new ClockDisplay(time);
            this.AlarmTimes = alarmTimes;
        }

        #endregion

        #region Egenskaper

        /// <summary>
        /// Hämtar eller tilldelar aktuellt AlarmClock-objekts alarmtider.
        /// </summary>
        public string[] AlarmTimes
        {
            get
            {
                return this._alarmTimes.Select(alarmTime => alarmTime.Time).ToArray();
            }

            set
            {
                this._alarmTimes = value.Select(alarmTime => new ClockDisplay(alarmTime)).ToArray();
            }
        }

        /// <summary>
        /// Hämtar eller tilldelar aktuellt AlarmClock-objekts tid.
        /// </summary>
        public string Time
        {
            get { return this._time.Time; }
            set { this._time.Time = value; }
        }

        #endregion

        #region Instansmetoder

        /// <summary>
        /// Lägger till en minut till aktuellt AlamrClock-objektet.
        /// </summary>
        /// <returns></returns>
        public bool TickTock()
        {
            this._time.Increment();
            return this._alarmTimes.Contains(_time);
        }

        #endregion

        #region Överskuggade instansmetoder

        /// <summary>
        /// Returnerar ett värde som anger om denna instans är lika med ett angivet objekt.
        /// </summary>
        /// <param name="obj">Objektet att jämföra denna instans med.</param>
        /// <returns>true om värdet är en instans av AlarmClock motsvarar värdet av denna instans; annars false.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is AlarmClock))
            {
                return false;
            }

            AlarmClock other = (AlarmClock)obj;

            return this.ToString() == other.ToString();
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
        /// Konverterar värdet av det aktuella AlarmClock-objektet till motsvarande strängbeteckning.
        /// </summary>
        /// <returns>En sträng representerande värdet av det aktuella AlarmClock-objektet.</returns>
        public override string ToString()
        {
            return String.Format("{0,5} ({1})", this.Time,
                String.Join(", ", this.AlarmTimes)); //.OrderBy(time => time).ToArray()));
        }

        #endregion

        #region Överlagring av operatorer

        /// <summary>
        /// Avgör om två instanser av AlarmClock är lika.
        /// </summary>
        /// <param name="a">Första objektet att jämföra.</param>
        /// <param name="b">Andra objektet att jämföra.</param>
        /// <returns>true om a och b representerar samma nummer; annars false.</returns>
        public static bool operator ==(AlarmClock a, AlarmClock b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Avgör om två instanser av AlarmClock inte är lika.
        /// </summary>
        /// <param name="a">Första objektet att jämföra.</param>
        /// <param name="b">Andra objektet att jämföra.</param>
        /// <returns>true om a och b inte representerar samma nummer; annars false.</returns>
        public static bool operator !=(AlarmClock a, AlarmClock b)
        {
            return !a.Equals(b);
        }

        #endregion
    }
}
