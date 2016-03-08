using System;

namespace DigitalAlarmClock_B
{
    public class NumberDisplay
    {
        #region Fält

        private int _maxNumber;
        private int _number;

        #endregion

        #region Konstruktorer

        public NumberDisplay(int maxNumber)
            : this(maxNumber, 0)
        {
        }

        public NumberDisplay(int maxNumber, int number)
        {
            this.MaxNumber = maxNumber;
            this.Number = number;
        }

        #endregion

        #region Egenskaper

        public int MaxNumber
        {
            get { return this._maxNumber; }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Maxvärdet måste vara större än 0.");
                }
                this._maxNumber = value;
            }
        }

        public int Number
        {
            get { return this._number; }

            set
            {
                if (value < 0 || value > this._maxNumber)
                {
                    throw new ArgumentException(String.Format("Värdet är inte i intervallet 0-{0}.", this._maxNumber));
                }
                this._number = value;
            }
        }

        #endregion

        #region Instansmetoder

        public void Increment()
        {
            this.Number = (this.Number + 1) % (this._maxNumber + 1);
        }

        /// <summary>
        /// Konverterar värdet av det aktuella NumberDisplay-objektet till motsvarande 
        /// strängrepresentation med hjälp av det angivna formatet.
        /// </summary>
        /// <param name="format">En standardformatsträng för nummer.</param>
        /// <returns>En sträng representerande värdet av det aktuella NumberDisplay objektet.</returns>
        public string ToString(string format)
        {
            if (String.IsNullOrEmpty(format))
            {
                format = "G";
            }

            switch (format.ToUpperInvariant())
            {
                case "G":
                case "0":
                    return String.Format("{0}", this.Number);

                case "00":
                    return String.Format("{0:00}", this.Number);

                default:
                    throw new FormatException(String.Format("Formatsträngen {0} stöds inte.", format));
            }
        }

        #endregion

        #region Överskuggade instansmetoder

        /// <summary>
        /// Konverterar värdet av det aktuella NumberDisplay-objektet till motsvarande strängbeteckning.
        /// </summary>
        /// <returns>En sträng representerande värdet av det aktuella NumberDisplay-objektet.</returns>
        public override string ToString()
        {
            return this.ToString("G");
        }

        #endregion
    }
}
