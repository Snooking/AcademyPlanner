using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PlanerAkademia
{
    public class SignInAndUpViewModel : BaseViewModel
    {
        #region PublicMembers

        /// <summary>
        /// Login of the user
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Password of the user
        /// </summary>
        public string Password { get; set; }

        #endregion

        #region PublicCommands

        /// <summary>
        /// Command to Login to ShowEventsPage
        /// </summary>
        public ICommand ContinueCommand { get; set; }

        /// <summary>
        /// Command to go to register page
        /// </summary>
        public ICommand RegisterCommand { get; set; }

        /// <summary>
        /// Command to create a new account
        /// </summary>
        public ICommand CreateAccountCommand { get; set; }

        /// <summary>
        /// Command to go to login page
        /// </summary>
        public ICommand GoToLoginPageCommand { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Base Cunstructor
        /// </summary>
        public SignInAndUpViewModel()
        {
            ContinueCommand = new RelayCommand(async () => await ShowEventsAsync());
            RegisterCommand = new RelayCommand(async () => await RegisterAsync());
            CreateAccountCommand = new RelayCommand(async () => await CreateAccountAsync());
            GoToLoginPageCommand = new RelayCommand(async () => await GoToLoginPageAsync());
        }

        #endregion

        #region Functions

        public async Task ShowEventsAsync()
        {
            if (DataBase.LogIn(Login, Password))
                ((MainWindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = AppPages.ShowEvents;
            else return;
            await Task.Delay(1);
        }

        public async Task RegisterAsync()
        {
            ((MainWindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = AppPages.SignUp;

            await Task.Delay(1);
        }
        public async Task GoToLoginPageAsync()
        {
            ((MainWindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = AppPages.SignIn;

            await Task.Delay(1);
        }

        public async Task CreateAccountAsync()
        {
            if (DataBase.Register(Login, Password))
                ((MainWindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = AppPages.ShowEvents;
            else return;
            await Task.Delay(1);
        }

        #endregion
    }
}
