using System;

namespace PlanerAkademia {
    public class Event {
        #region PublicMembers

        public string Name { get; set; }

        public string Year { get; set; }

        public string Month { get; set; }

        public string Day { get; set; }

        public string Hours { get; set; }

        public string Minutes { get; set; }

        public string Seconds { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public string Description { get; set; }

        public string InsertedDateTime { get; set; }

        #endregion

        #region Converters

        private string CheckIfTimeIsLow(int timeValue)
        {
            string stringToGo = "";
            if (timeValue < 10)
            {
                stringToGo += "0";
            }
            stringToGo += timeValue.ToString();
            return stringToGo;
        }

        private void ConvertToDateString()
        {
            Date = "";

            Date += Year;

            Date += "-";

            Date += Month;

            Date += "-";

            Date += Day;
        }

        private void ConvertToTimeString()
        {
            Time = "";

            Time += Hours;

            Time += ":";

            Time += Minutes;

            Time += ":";

            Time += Seconds;
        }

        private void ConvertToInsertedDateTime()
        {

            InsertedDateTime = "";

            //Add Date
            InsertedDateTime += Date;

            InsertedDateTime += " ";

            //Add Time
            InsertedDateTime += Time;
        }

        public void InsertedDateTimeToVariables ()
        {
            Day = InsertedDateTime.Substring(0, 2);
            Month = InsertedDateTime.Substring(3, 2);
            Year = InsertedDateTime.Substring(6, 4);
            Hours = InsertedDateTime.Substring(11, 2);
            Minutes = InsertedDateTime.Substring(14, 2);
            Seconds = InsertedDateTime.Substring(17, 2);

            ConvertToDateString();
            ConvertToTimeString();
        }

        #endregion

        #region Constructor

        public Event(string Name, int Year, int Month, int Day, int Hours, int Minutes, int Seconds, string Description) {
            this.Name = Name;

            this.Year = Year.ToString();
            this.Month = CheckIfTimeIsLow(Month);
            this.Day = CheckIfTimeIsLow(Day);
            this.Hours = CheckIfTimeIsLow(Hours);
            this.Minutes = CheckIfTimeIsLow(Minutes);
            this.Seconds = CheckIfTimeIsLow(Seconds);

            this.Description = Description;

            ConvertToDateString();
            ConvertToTimeString();
            ConvertToInsertedDateTime();
        }

        public Event()
        {

        }

        #endregion
    }
}
