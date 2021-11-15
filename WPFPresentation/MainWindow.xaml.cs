using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataAccessFakes;
using DataAccessInterfaces;
using DataObjects;
using LogicLayer;

namespace WPFPresentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User _user = null;
        UserManager _userManager = null;
        CardManager _cardManager = null;
        //MainWindow newWindow = null;

        public MainWindow()
        {
            //_userManager = new UserManager();
            _userManager = new UserManager(new DataAccessFakes.UserAccessorFake());
            //newWindow = frmMainWindow;
            //_cardManager = new CardManager();
            _cardManager = new CardManager(new DataAccessFakes.CardAccessorFake());
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(btnLogin.Content.ToString() == "Login")
            {
                var logInOrSignup = new LoginOrSignup(_userManager);
                bool? result = logInOrSignup.ShowDialog();
                _user = logInOrSignup.getUser();
                if(result == true)
                {
                    MessageBox.Show("Welcome, " + _user.Username, "Login Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                    updateUIForLogin();
                }
                else
                {
                    _user = null;
                    updateUIForLogOut();
                }
            }
            else
            {
                updateUIForLogOut();
            }
        }

        private void hideAllButtons()
        {
            btnMyCards.Visibility = Visibility.Collapsed;
            btnMyDecks.Visibility = Visibility.Collapsed;
            btnMyMatches.Visibility = Visibility.Collapsed;
            btnWishlist.Visibility = Visibility.Collapsed;
        }

        private void showAllButtons()
        {
            btnMyCards.Visibility = Visibility.Visible;
            btnMyDecks.Visibility = Visibility.Visible;
            btnMyMatches.Visibility = Visibility.Visible;
            btnWishlist.Visibility = Visibility.Visible;
        }

        private void updateUIForLogOut()
        {
            _user = null;
            btnLogin.Content = "Login";
            hideAllButtons();
            btnHome.Focus();
        }

        private void updateUIForLogin()
        {
            staMessage.Content = "Welcome, " + _user.Username;
            btnLogin.Content = "Log out";
            showAllButtons();
        }

        private void hideAllStackPanels()
        {
            panHome.Visibility = Visibility.Collapsed;
            panCards.Visibility = Visibility.Collapsed;
        }
        
        private void frmMainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            hideAllButtons();
        }

        private void btnHome_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                hideAllStackPanels();
                panHome.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex);
            }
        }

        private void btnMyCards_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                hideAllStackPanels();
                panCards.Visibility = Visibility.Visible;
                datCards.ItemsSource = _cardManager.RetrieveCardsByPage(2);
            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex);
            }
        }
    }
}
