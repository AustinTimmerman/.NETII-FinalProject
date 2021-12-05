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
        MatchManager _matchManager = null;
        private int rowCounter = 20;

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

            _matchManager = new MatchManager();
            //_matchManager = new MatchManager(new DataAccessFakes.MatchAccessorFake());

            InitializeComponent();
        }

        private void hideAllButtons()
        {
            btnCards.Visibility = Visibility.Collapsed;
            btnDecks.Visibility = Visibility.Collapsed;
            btnMatches.Visibility = Visibility.Collapsed;
            btnMyStuff.Visibility = Visibility.Collapsed;
            mnuStuff.Visibility = Visibility.Collapsed;
        }

        private void showAllButtons()
        {
            btnCards.Visibility = Visibility.Visible;
            btnDecks.Visibility = Visibility.Visible;
            btnMatches.Visibility = Visibility.Visible;
            btnMyStuff.Visibility = Visibility.Visible;
            mnuStuff.Visibility = Visibility.Visible;
        }

        private void updateUIForLogOut()
        {
            _user = null;
            btnLogin.Content = "Login";
            hideAllButtons();
            btnHome.Focus();
            datMyCards.ItemsSource = null;
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
            panMatchDecks.Visibility = Visibility.Collapsed;
            panMatchDeckCards.Visibility = Visibility.Collapsed;
            grdMyStuff.Visibility = Visibility.Collapsed;
            datMyCards.Visibility = Visibility.Collapsed;
            datMyDecks.Visibility = Visibility.Collapsed;
            datMyDeckCards.Visibility = Visibility.Collapsed;
            datMyMatches.Visibility = Visibility.Collapsed;
            datMyMatchDecks.Visibility = Visibility.Collapsed;
            datMyMatchDeckCards.Visibility = Visibility.Collapsed;
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
            if (panCards.Visibility == Visibility.Visible)
            {                                                           // the amount of cards / rows being retrieved 
                if (_cardManager.RetrieveCardsByPage(pageNumber).Count < rowCounter)
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
                if (_deckManager.RetrieveDecksByPage(pageNumber).Count < rowCounter)
                {
                    btnNextPage.IsEnabled = false;
                }
                else
                {
                    btnNextPage.IsEnabled = true;
                }
            }
            else if (panMatches.Visibility == Visibility.Visible)
            {
                if (_matchManager.RetrieveMatchesByPage(pageNumber).Count < rowCounter)
                {
                    btnNextPage.IsEnabled = false;
                }
                else
                {
                    btnNextPage.IsEnabled = true;
                }
            }
            else if (datMyCards.Visibility == Visibility.Visible)
            {
                if (_cardManager.RetrieveUserCardsByUserID(_user.UserID, pageNumber).Count < rowCounter)
                {
                    btnNextPage.IsEnabled = false;
                }
                else
                {
                    btnNextPage.IsEnabled = true;
                }
            }
            else if (datMyDecks.Visibility == Visibility.Visible)
            {
                if (_deckManager.RetrieveUserDecksByUserID(_user.UserID, pageNumber).Count < rowCounter)
                {
                    btnNextPage.IsEnabled = false;
                }
                else
                {
                    btnNextPage.IsEnabled = true;
                }
            }
            else if (datMyMatches.Visibility == Visibility.Visible)
            {
                if (_matchManager.RetrieveUserMatchesByUserID(_user.UserID, pageNumber).Count < rowCounter)
                {
                    btnNextPage.IsEnabled = false;
                }
                else
                {
                    btnNextPage.IsEnabled = true;
                }
            }
        }

        private void PrevNextPageClick_Helper()
        {
            pageChecker();
            if (panCards.Visibility == Visibility.Visible)
            {
                //datCards.ItemsSource = _cardManager.RetrieveCardsByPage(pageNumber);
                datCards.ItemsSource = createCardList();
            }
            else if (panDecks.Visibility == Visibility.Visible)
            {
                datDecks.ItemsSource = _deckManager.RetrieveDecksByPage(pageNumber);
            }
            else if (panMatches.Visibility == Visibility.Visible)
            {
                datMatches.ItemsSource = _matchManager.RetrieveMatchesByPage(pageNumber);
            }
            else if (datMyCards.Visibility == Visibility.Visible)
            {
                datMyCards.ItemsSource = _cardManager.RetrieveUserCardsByUserID(_user.UserID, pageNumber);
            }
            else if (datMyDecks.Visibility == Visibility.Visible)
            {
                datMyDecks.ItemsSource = _deckManager.RetrieveUserDecksByUserID(_user.UserID, pageNumber);
            }
            else if (datMyMatches.Visibility == Visibility.Visible)
            {
                datMyMatches.ItemsSource = _matchManager.RetrieveUserMatchesByUserID(_user.UserID, pageNumber);
            }
        }

        private void clearDataGrids()
        {
            datMyCards.ItemsSource = null;
            datMyDecks.ItemsSource = null;
            datMyMatches.ItemsSource = null;
        }

        private void loadDetailWindow(UserCard userCard)
        {
            var cardDetailWindow = new CardDetail(userCard);
            cardDetailWindow.ShowDialog();
        }

        private List<UserCard> createCardList()
        {
            List<UserCard> displayCards = new List<UserCard>();

            List<UserCard> userCards = _cardManager.RetrieveUserCardsByUserID(_user.UserID, 0);
            List<Cards> cards = _cardManager.RetrieveCardsByPage(pageNumber);

            foreach (Cards card in cards)
            {
                for (int i = 0; i <= userCards.Count; i++)
                {
                    if (i == userCards.Count)
                    {
                        displayCards.Add(new UserCard()
                        {
                            UserID = _user.UserID,
                            CardID = card.CardID,
                            CardName = card.CardName,
                            ImageID = card.ImageID,
                            CardDescription = card.CardDescription,
                            CardColorID = card.CardColorID,
                            CardConvertedManaCost = card.CardConvertedManaCost,
                            CardRarityID = card.CardRarityID,
                            CardTypeID = card.CardTypeID,
                            HasSecondaryCard = card.HasSecondaryCard,
                            CardSecondaryName = card.CardSecondaryName,
                            SecondaryImageID = card.SecondaryImageID,
                            CardSecondaryDescription = card.CardSecondaryDescription,
                            CardSecondaryColorID = card.CardSecondaryColorID,
                            CardSecondaryConvertedManaCost = card.CardSecondaryConvertedManaCost,
                            CardSecondaryRarityID = card.CardSecondaryRarityID,
                            CardSecondaryTypeID = card.CardSecondaryTypeID,
                            OwnedCard = false,
                            Wishlisted = false
                        });
                        break;
                    }
                    if (userCards[i].CardID == card.CardID)
                    {
                        displayCards.Add(userCards[i]);
                        break;
                    }
                }
            }

            return displayCards;
        }

        private List<UserCard> createCardList(Deck deck)
        {
            List<UserCard> displayCards = new List<UserCard>();

            List<UserCard> userCards = _cardManager.RetrieveUserCardsByUserID(_user.UserID, 0);
            List<DeckCard> cards = _deckManager.RetrieveDeckCards(deck.DeckID);


            foreach (DeckCard card in cards)
            {
                for (int i = 0; i <= userCards.Count; i++)
                {
                    if (i == userCards.Count)
                    {
                        displayCards.Add(new UserCard()
                        {
                            UserID = _user.UserID,
                            CardID = card.CardID,
                            CardName = card.CardName,
                            ImageID = card.ImageID,
                            CardDescription = card.CardDescription,
                            CardColorID = card.CardColorID,
                            CardConvertedManaCost = card.CardConvertedManaCost,
                            CardRarityID = card.CardRarityID,
                            CardTypeID = card.CardTypeID,
                            HasSecondaryCard = card.HasSecondaryCard,
                            CardSecondaryName = card.CardSecondaryName,
                            SecondaryImageID = card.SecondaryImageID,
                            CardSecondaryDescription = card.CardSecondaryDescription,
                            CardSecondaryColorID = card.CardSecondaryColorID,
                            CardSecondaryConvertedManaCost = card.CardSecondaryConvertedManaCost,
                            CardSecondaryRarityID = card.CardSecondaryRarityID,
                            CardSecondaryTypeID = card.CardSecondaryTypeID,
                            OwnedCard = false,
                            Wishlisted = false
                        });
                        break;
                    }
                    if (userCards[i].CardID == card.CardID)
                    {
                        displayCards.Add(userCards[i]);
                        break;
                    }
                }
            }


            return displayCards;
        }

        private List<UserCard> createCardList(MatchDeck deck)
        {
            List<UserCard> displayCards = new List<UserCard>();

            List<UserCard> userCards = _cardManager.RetrieveUserCardsByUserID(_user.UserID, 0);
            List<DeckCard> cards = _deckManager.RetrieveDeckCards(deck.DeckID);


            foreach (DeckCard card in cards)
            {
                for (int i = 0; i <= userCards.Count; i++)
                {
                    if (i == userCards.Count)
                    {
                        displayCards.Add(new UserCard()
                        {
                            UserID = _user.UserID,
                            CardID = card.CardID,
                            CardName = card.CardName,
                            ImageID = card.ImageID,
                            CardDescription = card.CardDescription,
                            CardColorID = card.CardColorID,
                            CardConvertedManaCost = card.CardConvertedManaCost,
                            CardRarityID = card.CardRarityID,
                            CardTypeID = card.CardTypeID,
                            HasSecondaryCard = card.HasSecondaryCard,
                            CardSecondaryName = card.CardSecondaryName,
                            SecondaryImageID = card.SecondaryImageID,
                            CardSecondaryDescription = card.CardSecondaryDescription,
                            CardSecondaryColorID = card.CardSecondaryColorID,
                            CardSecondaryConvertedManaCost = card.CardSecondaryConvertedManaCost,
                            CardSecondaryRarityID = card.CardSecondaryRarityID,
                            CardSecondaryTypeID = card.CardSecondaryTypeID,
                            OwnedCard = false,
                            Wishlisted = false
                        });
                        break;
                    }
                    if (userCards[i].CardID == card.CardID)
                    {
                        displayCards.Add(userCards[i]);
                        break;
                    }
                }
            }


            return displayCards;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (btnLogin.Content.ToString() == "Login")
            {
                var logInOrSignup = new LoginOrSignup(_userManager);
                bool? result = logInOrSignup.ShowDialog();
                _user = logInOrSignup.getUser();
                if (result == true)
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
                clearDataGrids();
            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex);
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
                //datCards.ItemsSource = _cardManager.RetrieveCardsByPage(pageNumber);
                datCards.ItemsSource = createCardList();
                clearDataGrids();
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
                PrevNextPageClick_Helper();
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
                PrevNextPageClick_Helper();
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
                clearDataGrids();
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

                //datDeckCards.ItemsSource = _deckManager.RetrieveDeckCards(deck.DeckID);
                datDeckCards.ItemsSource = createCardList(deck);
            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex);
            }

        }

        private void btnMatches_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                pageNumber = 1;
                hideAllStackPanels();
                panMatches.Visibility = Visibility.Visible;
                grdNextPrev.Visibility = Visibility.Visible;
                pageChecker();
                datMatches.ItemsSource = _matchManager.RetrieveMatchesByPage(pageNumber);
                clearDataGrids();
            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex);
            }
        }

        private void datMatches_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var match = (Match)datMatches.SelectedItem;

                hideAllStackPanels();
                panMatchDecks.Visibility = Visibility.Visible;

                datMatchDecks.ItemsSource = _matchManager.RetrieveMatchDecksByMatchID(match.MatchID);
            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex);
            }
        }

        private void datMatchDecks_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var deck = (MatchDeck)datMatchDecks.SelectedItem;

                hideAllStackPanels();
                panMatchDeckCards.Visibility = Visibility.Visible;

                //datMatchDeckCards.ItemsSource = _deckManager.RetrieveDeckCards(deck.DeckID);
                datMatchDeckCards.ItemsSource = createCardList(deck);
            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex);
            }
        }

        private void btnMyStuff_Click(object sender, RoutedEventArgs e)
        {
            mnuMyStuff.IsSubmenuOpen = true;
        }

        private void mnuMyCards_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                pageNumber = 1;
                hideAllStackPanels();
                grdMyStuff.Visibility = Visibility.Visible;
                datMyCards.Visibility = Visibility.Visible;
                grdNextPrev.Visibility = Visibility.Visible;
                pageChecker();
                datMyCards.ItemsSource = _cardManager.RetrieveUserCardsByUserID(_user.UserID, pageNumber);
            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex);
            }
        }

        private void mnuMyDecks_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                pageNumber = 1;
                hideAllStackPanels();
                grdMyStuff.Visibility = Visibility.Visible;
                datMyDecks.Visibility = Visibility.Visible;
                grdNextPrev.Visibility = Visibility.Visible;
                pageChecker();
                datMyDecks.ItemsSource = _deckManager.RetrieveUserDecksByUserID(_user.UserID, pageNumber);

            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex);
            }
        }

        private void datMyDecks_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var deck = (Deck)datMyDecks.SelectedItem;

                hideAllStackPanels();
                grdMyStuff.Visibility = Visibility.Visible;
                datMyDeckCards.Visibility = Visibility.Visible;

                //datMyDeckCards.ItemsSource = _deckManager.RetrieveDeckCards(deck.DeckID);
                datMyDeckCards.ItemsSource = createCardList(deck);
            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex);
            }
        }

        private void mnuMyMatches_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                pageNumber = 1;
                hideAllStackPanels();
                grdMyStuff.Visibility = Visibility.Visible;
                datMyMatches.Visibility = Visibility.Visible;
                grdNextPrev.Visibility = Visibility.Visible;
                pageChecker();
                datMyMatches.ItemsSource = _matchManager.RetrieveUserMatchesByUserID(_user.UserID, pageNumber);

            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex);
            }
        }

        private void datMyMatches_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var match = (Match)datMyMatches.SelectedItem;

                hideAllStackPanels();
                grdMyStuff.Visibility = Visibility.Visible;
                datMyMatchDecks.Visibility = Visibility.Visible;

                datMyMatchDecks.ItemsSource = _matchManager.RetrieveMatchDecksByMatchID(match.MatchID);
            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex);
            }
        }

        private void datMyMatchDecks_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var deck = (MatchDeck)datMyMatchDecks.SelectedItem;

                hideAllStackPanels();
                grdMyStuff.Visibility = Visibility.Visible;
                datMyMatchDeckCards.Visibility = Visibility.Visible;

                //datMyMatchDeckCards.ItemsSource = _deckManager.RetrieveDeckCards(deck.DeckID);
                datMyMatchDeckCards.ItemsSource = createCardList(deck);
            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex);
            }
        }

        //private void datCards_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    var card = (Cards)datCards.SelectedItem;
        //    UserCard userCard = new UserCard();

        //    List<UserCard> userCards = _cardManager.RetrieveUserCardsByUserID(_user.UserID, 0);

        //    foreach (UserCard item in userCards)
        //    {
        //        if (item.CardID == card.CardID)
        //        {
        //            userCard = item;
        //            break;
        //        }
        //        else
        //        {
        //            userCard = new UserCard()
        //            {
        //                UserID = _user.UserID,
        //                CardID = card.CardID,
        //                CardName = card.CardName,
        //                ImageID = card.ImageID,
        //                CardDescription = card.CardDescription,
        //                CardColorID = card.CardColorID,
        //                CardConvertedManaCost = card.CardConvertedManaCost,
        //                CardRarityID = card.CardRarityID,
        //                CardTypeID = card.CardTypeID,
        //                HasSecondaryCard = card.HasSecondaryCard,
        //                CardSecondaryName = card.CardSecondaryName,
        //                SecondaryImageID = card.SecondaryImageID,
        //                CardSecondaryDescription = card.CardSecondaryDescription,
        //                CardSecondaryColorID = card.CardSecondaryColorID,
        //                CardSecondaryConvertedManaCost = card.CardSecondaryConvertedManaCost,
        //                CardSecondaryRarityID = card.CardSecondaryRarityID,
        //                CardSecondaryTypeID = card.CardSecondaryTypeID,
        //                OwnedCard = false,
        //                Wishlisted = false
        //            };
        //        }
        //    }

        //    var cardDetailWindow = new CardDetail(userCard);
        //    cardDetailWindow.ShowDialog();
        //}

        private void datCards_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var userCard = (UserCard)datCards.SelectedItem;
            loadDetailWindow(userCard);
        }

        private void datDeckCards_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var userCard = (UserCard)datDeckCards.SelectedItem;
            loadDetailWindow(userCard);
        }

        private void datMatchDeckCards_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var userCard = (UserCard)datMatchDeckCards.SelectedItem;
            loadDetailWindow(userCard);
        }

        private void datMyCards_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var userCard = (UserCard)datMyCards.SelectedItem;
            loadDetailWindow(userCard);
        }

        private void datMyDeckCards_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var userCard = (UserCard)datMyDeckCards.SelectedItem;
            loadDetailWindow(userCard);
        }

        private void datMyMatchDeckCards_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var userCard = (UserCard)datMyMatchDeckCards.SelectedItem;
            loadDetailWindow(userCard);
        }
    }
}
