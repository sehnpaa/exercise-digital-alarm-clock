using System;

namespace DigitalAlarmClock_B
{
    class ClockDisplay
    {
        #region Fält

        private NumberDisplay _hourDisplay;
        private NumberDisplay _minuteDisplay;

        #endregion

        #region Konstruktorer

        public ClockDisplay()
            : this(0, 0)
        {
        }

        public ClockDisplay(int hour, int minute)
        {
            this._hourDisplay = new NumberDisplay(23, hour);
            this._minuteDisplay = new NumberDisplay(59, minute);
        }

        #endregion

        #region Egenskaper

        public int Hour
        {
            get { return this._hourDisplay.Number; }
            set { this._hourDisplay.Number = value; }
        }

        public int Minute
        {
            get { return this._minuteDisplay.Number; }
            set { this._minuteDisplay.Number = value; }
        }

        #endregion

        #region Instansmetoder

        public void Increment()
        {
            this._minuteDisplay.Increment();
            if (this._minuteDisplay.Number == 0)
            {
                this._hourDisplay.Increment();
            }
        }

        #endregion

        #region Överskuggade metoder

        public override string ToString()
        {
            return String.Format("{0}:{1}", this._hourDisplay, this._minuteDisplay.ToString("00"));
        }

        #endregion
    }
}
