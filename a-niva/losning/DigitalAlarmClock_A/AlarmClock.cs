using System;

namespace DigitalAlarmClock_A
{
    class AlarmClock
    {
        private int _alarmHour;
        private int _alarmMinute;
        private int _hour;
        private int _minute;

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
            Hour = hour;
            Minute = minute;
            AlarmHour = alarmHour;
            AlarmMinute = alarmMinute;
        }

        public int AlarmHour
        {
            get { return _alarmHour; }
            set
            {
                if (value < 0 || value > 23)
                {
                    throw new ArgumentException("Alarmtimmen är inte i intervallet 0-23.");
                }

                _alarmHour = value;
            }
        }

        public int AlarmMinute
        {
            get { return _alarmMinute; }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentException("Alarmminuten är inte i intervallet 0-59.");
                }

                _alarmMinute = value;
            }
        }

        public int Hour
        {
            get { return _hour; }
            set
            {
                if (value < 0 || value > 23)
                {
                    throw new ArgumentException("Timmen är inte i intervallet 0-23.");
                }

                _hour = value;
            }
        }

        public int Minute
        {
            get { return _minute; }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentException("Minuten är inte i intervallet 0-59.");
                }

                _minute = value;
            }
        }

        public bool TickTock()
        {
            if (Minute < 59)
            {
                Minute++;
            }
            else
            {
                Minute = 0;
                if (Hour < 23)
                {
                    Hour++;
                }
                else
                {
                    Hour = 0;
                }
            }

            return Hour == AlarmHour && Minute == AlarmMinute;
        }

        public override string ToString()
        {
            return String.Format("{0,2}:{1:00} ({2}:{3:00})", Hour, Minute, AlarmHour, AlarmMinute);
        }
    }
}
