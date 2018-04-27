using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PlanerAkademia {
    public class AddEventViewModel : BaseViewModel {
        #region PrivateMembers

        /// <summary>
        /// Hour of the event
        /// </summary>
        private int hour {
            get {
                int bHour;
                int.TryParse(mHour, out bHour);
                if (bHour < 0) return 0;
                if (bHour > 23) return 23;
                return bHour;
            }
            set {

            }
        }

        /// <summary>
        /// Minute of the event
        /// </summary>
        private int minute {
            get {
                int bMinute;
                int.TryParse(mMinute, out bMinute);
                if (bMinute < 0) return 0;
                if (bMinute > 59) return 59;
                return bMinute;
            }
            set {

            }
        }

        /// <summary>
        /// Second of the event
        /// </summary>
        private int second {
            get {
                int bSecond;
                int.TryParse(mSecond, out bSecond);
                if (bSecond < 0) return 0;
                if (bSecond > 59) return 59;
                return bSecond;
            }
            set {

            }
        }

        /// <summary>
        /// Day of the event
        /// </summary>
        private int day {
            get {
                return mDate.Day;
            }
            set {

            }
        }

        /// <summary>
        /// Month of the event
        /// </summary>
        private int month {
            get {
                return mDate.Month;
            }
            set {

            }
        }

        /// <summary>
        /// Year of the event
        /// </summary>
        private int year {
            get {
                return mDate.Year;
            }
            set {

            }
        }

        #endregion

        #region PublicMembers

        /// <summary>
        /// Name of the event
        /// </summary>
        public string name { get; set; }

        public string mHour { get; set; }

        public string mMinute { get; set; }

        public string mSecond { get; set; }

        public DateTime mDate { get; set; } = DateTime.Now;

        public DateTime bDate { get; set; }

        ///<summary>
        ///Full Event - prepared for everything
        ///</summary>
        public Event mainEvent {
            get {
                //just let it all go into Event Constructor fucker
                return new Event(name, year, month, day, hour, minute, second, description);
            }
        }

        /// <summary>
        /// Description of the event
        /// </summary>
        public string description { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Command to accept the event and send it to database
        /// </summary>
        public ICommand AcceptCommand { get; set; }

        /// <summary>
        /// Command to cancel the event and delete all informations
        /// </summary>
        public ICommand CancelCommand { get; set; }

        #endregion

        #region Constructor

        public AddEventViewModel() {
            AcceptCommand = new RelayCommand(async () => await AcceptAsync());
            CancelCommand = new RelayCommand(async () => await CancelAsync());
        }

        #endregion

        #region Fuctions

        /// <summary>
        /// Function that execute, when the cancel button is pressed
        /// </summary>
        public async Task CancelAsync() {
            ((MainWindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = AppPages.ShowEvents;

            await Task.Delay(1);
        }

        /// <summary>
        /// Function that execute, when the accept button is pressed
        /// </summary>
        public async Task AcceptAsync() {
            if (name == null || description == null || mHour == null || mMinute == null || mSecond == null || mDate == null) return;
            DataBase.AddEvent(mainEvent);
            ((MainWindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = AppPages.ShowEvents;

            await Task.Delay(1);
        }

        #endregion
    }
}
