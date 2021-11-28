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
        DeckManager _deckManager = null;
        private int pageNumber;
        //MainWindow newWindow = null;

        public MainWindow()
        {
            _userManager = new UserManager();
            //_userManager = new UserManager(new DataAccessFakes.UserAccessorFake());
            //newWindow = frmMainWindow;

            _cardManager = new CardManager();
            //_cardManager = new CardManager(new DataAccessFakes.CardAccessorFake());

            _deckManager = new DeckManager();
            //_deckManager = new DeckManager(new DataAccessFakes.DeckAccessorFake());

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
            btnCards.Visibility = Visibility.Collapsed;
            btnDecks.Visibility = Visibility.Collapsed;
            btnMatches.Visibility = Visibility.Collapsed;
            btnWishlist.Visibility = Visibility.Collapsed;
        }

        private void showAllButtons()
        {
            btnCards.Visibility = Visibility.Visible;
            btnDecks.Visibility = Visibility.Visible;
            btnMatches.Visibility = Visibility.Visible;
            btnWishlist.Visibility = Visibility.Visible;
        }

        private void updateUIForLogOut()
        {
            _user = null;
            btnLogin.Content = "Login";
            hideAllButtons();
            btnHome.Focus();
            staMessage.Content = "Welcome. Please log in to continue.";
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
            grdNextPrev.Visibility = Visibility.Collapsed;
            panDecks.Visibility = Visibility.Collapsed;
            panDeckCards.Visibility = Visibility.Collapsed;
            panMatches.Visibility = Visibility.Collapsed;
            panWishlist.Visibility = Visibility.Collapsed;
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

        private void pageChecker()
        {
            if (pageNumber == 1)
            {
                btnPrevPage.IsEnabled = false;
            }
            else
            {
                btnPrevPage.IsEnabled = true;
            }
            // the amount of cards / rows being retrieved 
            if (panCards.Visibility == Visibility.Visible)
            {
                if (_cardManager.RetrieveCardsByPage(pageNumber).Count < 20)
                {
                    btnNextPage.IsEnabled = false;
                }
                else
                {
                    btnNextPage.IsEnabled = true;
                }
            }
            else if (panDecks.Visibility == Visibility.Visible)
            {
                if (_deckManager.RetrieveDecksByPage(pageNumber).Count < 20)
                {
                    btnNextPage.IsEnabled = false;
                }
                else
                {
                    btnNextPage.IsEnabled = true;
                }
            }
        }

        private void btnCards_GotFocus(object sender, RoutedEventArgs e)
        {
                try
                {
                    pageNumber = 1;
                    hideAllStackPanels();
                    panCards.Visibility = Visibility.Visible;
                    grdNextPrev.Visibility = Visibility.Visible;
                    pageChecker();
                    datCards.ItemsSource = _cardManager.RetrieveCardsByPage(pageNumber);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("" + ex);
                }
        }

        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                pageNumber++;
                pageChecker();
                if (panCards.Visibility == Visibility.Visible)
                {
                    datCards.ItemsSource = _cardManager.RetrieveCardsByPage(pageNumber);
                }
                else if (panDecks.Visibility == Visibility.Visible)
                {
                    datDecks.ItemsSource = _deckManager.RetrieveDecksByPage(pageNumber);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void btnPrevPage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                pageNumber--;
                pageChecker();
                datCards.ItemsSource = _cardManager.RetrieveCardsByPage(pageNumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void btnDecks_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                pageNumber = 1;
                hideAllStackPanels();
                panDecks.Visibility = Visibility.Visible;
                grdNextPrev.Visibility = Visibility.Visible;
                pageChecker();
                datDecks.ItemsSource = _deckManager.RetrieveDecksByPage(pageNumber);

            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex);
            }
        }

        private void datDecks_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var deck = (Deck)datDecks.SelectedItem;

                hideAllStackPanels();
                panDeckCards.Visibility = Visibility.Visible;

                datDeckCards.ItemsSource = _deckManager.RetrieveDeckCards(deck.DeckID);
            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex);
            }

        }
    }
}
