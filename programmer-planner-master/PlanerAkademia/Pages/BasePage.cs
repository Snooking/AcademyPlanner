using System.Windows.Controls;

namespace PlanerAkademia
{
    public class BasePage<VM> : Page
        where VM : BaseViewModel, new()
    {
        #region PrivateMembers

        /// <summary>
        /// ViewModel associated with this page
        /// </summary>
        private VM mViewModel;

        #endregion

        #region PublicMembers

        /// <summary>
        /// ViewModel associated with this page
        /// </summary>
        public VM ViewModel
        {
            get
            {
                return mViewModel;
            }
            set
            {
                if (mViewModel == value)
                    return;
                mViewModel = value;
                DataContext = mViewModel;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Base Constructor
        /// </summary>
        public BasePage()
        {
            ViewModel = new VM();
        }

        #endregion
    }
}
