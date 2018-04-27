using System.Windows;
using System.Windows.Input;

namespace PlanerAkademia
{
    class MainWindowViewModel : BaseViewModel
    {

        #region PrivateMembers

        /// <summary>
        /// Window we're working on
        /// </summary>
        private Window window;


        /// <summary>
        /// Padding of the main content
        /// </summary>
        private int ContentPadding { get; set; } = 6;

        /// <summary>
        /// Value of margin to allow the drop shadow
        /// </summary>
        private int OuterMarginValue { get; set; } = 10;

        /// <summary>
        /// Value of radius of the edges of the window
        /// </summary>
        private int WindowRadiusValue { get; set; } = 10;

        #endregion

        #region PublicMembers

        /// <summary>
        /// Width that window can't have less than
        /// </summary>
        public int WindowWidth { get; set; } = 600;

        /// <summary>
        /// Height that window can't have less than
        /// </summary>
        public int WindowHeight { get; set; } = 600;

        /// <summary>
        /// Height of the title bar
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        /// <summary>
        /// Padding of the main content
        /// </summary>
        public Thickness ContentPaddingThickness { get { return new Thickness(ContentPadding); } }

        /// <summary>
        /// Thickness of Margin to allow drop shadow
        /// </summary>
        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginValue); } }

        /// <summary>
        /// CornerRadius of the window
        /// </summary>
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadiusValue); } }

        /// <summary>
        /// GridLength of the title bar
        /// </summary>
        public GridLength TitleHeightGrid { get { return new GridLength(TitleHeight); } }

        /// <summary>
        /// Information about which page is the user at
        /// </summary>
        public AppPages CurrentPage { get; set; } = AppPages.SignIn;
        
        #endregion

        #region PublicCommands

        /// <summary>
        /// The command to minimize the window
        /// </summary>
        public ICommand Minimize { get; set; }

        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand Close { get; set; }

        /// <summary>
        /// The command to open icon menu bar
        /// </summary>
        public ICommand IconButtonCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Basic creator
        /// </summary>
        /// <param name="window">Window we're working on</param>
        public MainWindowViewModel(Window window)
        {
            this.window = window;

            Minimize = new RelayCommand(() => window.WindowState = WindowState.Minimized);
            Close = new RelayCommand(() => window.Close());
            IconButtonCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(window, GetMousePosition()));
        }

        #endregion

        #region Helpers
        /// <summary>
        /// Helper to get the current mouse position
        /// </summary>
        /// <returns>Mouse position</returns>
        private Point GetMousePosition()
        {

            var position = Mouse.GetPosition(window);

            return new Point(position.X + window.Left, position.Y + window.Top);
        }

        #endregion
    }
}
