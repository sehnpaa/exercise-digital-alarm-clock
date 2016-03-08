using System;

namespace DigitalAlarmClock_B
{
    class AlarmClock
    {
        #region Fält

        private ClockDisplay _alarmTime;
        private ClockDisplay _time;

        #endregion

        #region Konstruktorer

        public AlarmClock()
            : this(0, 0)
        {
            // Tom!
        }

        public AlarmClock(int hour, int minute)
            : this(hour, minute, 0, 0)
        {
            // Tom!
        }

        public AlarmClock(int hour, int minute, int alarmHour, int alarmMinute)
        {
            this._time = new ClockDisplay(hour, minute);
            this._alarmTime = new ClockDisplay(alarmHour, alarmMinute);
        }

        #endregion

        #region Egenskaper

        public int AlarmHour
        {
            get { return this._alarmTime.Hour; }
            set { this._alarmTime.Hour = value; }
        }

        public int AlarmMinute
        {
            get { return this._alarmTime.Minute; }
            set { this._alarmTime.Minute = value; }
        }

        public int Hour
        {
            get { return this._time.Hour; }
            set { this._time.Hour = value; }
        }

        public int Minute
        {
            get { return this._time.Minute; }
            set { this._time.Minute = value; }
        }

        #endregion

        #region Instansmetoder

        public bool TickTock()
        {
            this._time.Increment();

            return this._time.ToString() == this._alarmTime.ToString();
        }

        #endregion

        #region Överskuggade instansmetoder

        public override string ToString()
        {
            return String.Format("{0,5} ({1})", this._time, this._alarmTime);
        }

        #endregion
    }
}

