using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PlanerAkademia
{
    public class ShowEventViewModel : BaseViewModel
    {

        #region PublicMembers

        public List<Event> Events { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Command to Log out
        /// </summary>
        public ICommand LogOutCommand { get; set; }

        /// <summary>
        /// Command to Go to Page of Event Adding
        /// </summary>
        public ICommand AddEventCommand { get; set; }

        #endregion

        #region Constructor

        public ShowEventViewModel()
        {
            //Commands
            LogOutCommand = new RelayCommand(async () => await LogOutAsync());
            AddEventCommand = new RelayCommand(async () => await AddEventAsync());

            Events = DataBase.ShowEvents();
        }

        #endregion

        #region Functions


        public async Task AddEventAsync()
        {
            ((MainWindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = AppPages.AddEvents;

            await Task.Delay(1);
        }

        public async Task LogOutAsync()
        {
            DataBase.UserID = 0;
            ((MainWindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = AppPages.SignIn;

            await Task.Delay(1);
        }

        #endregion
    }
}
