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
using System.Windows.Shapes;
using DataAccessFakes;
using DataAccessInterfaces;
using DataObjects;
using LogicLayer;

namespace WPFPresentation
{
    /// <summary>
    /// Interaction logic for Creation.xaml
    /// </summary>
    public partial class Creation : Window
    {
        UserCard _card;
        User _user;
        Deck _deck;
        List<Deck> _userDecks;
        ICardManager _cardManager;
        IDeckManager _deckManager;
        IMatchManager _matchManager;

        public Creation(User user, ICardManager cardManager, IDeckManager deckManager, IMatchManager matchManager)
        {
            _user = user;
            _cardManager = cardManager;
            _deckManager = deckManager;
            _matchManager = matchManager;
            InitializeComponent();
            populateControls();
        }

        public Creation(User user, Deck deck, ICardManager cardManager, IDeckManager deckManager, IMatchManager matchManager)
        {
            _user = user;
            _deck = deck;
            _cardManager = cardManager;
            _deckManager = deckManager;
            _matchManager = matchManager;
            InitializeComponent();
            populateControls();
        }

        public Creation(UserCard card, ICardManager cardManager, IDeckManager deckManager, IMatchManager matchManager)
        {
            _card = card;
            _cardManager = cardManager;
            _deckManager = deckManager;
            _matchManager = matchManager;
            InitializeComponent();
            populateControls();
        }

        private void populateControls()
        {
            if (_deck == null && _card == null) 
            {
                grdDeckCreation.Visibility = Visibility.Visible;
                grdDeckUpdate.Visibility = Visibility.Collapsed;
                grdDeckCardCreation.Visibility = Visibility.Collapsed;
                txtDeckName.Focus();
            }
            else if (_deck != null)
            {
                grdDeckUpdate.Visibility = Visibility.Visible;
                grdDeckCreation.Visibility = Visibility.Collapsed;
                grdDeckCardCreation.Visibility = Visibility.Collapsed;
                txtNewDeckName.Text = _deck.DeckName;
                chkNewDeckPublic.IsChecked = _deck.IsPublic;
                txtNewDeckName.Focus();
            }
            else if(_user == null)
            {
                grdDeckCardCreation.Visibility = Visibility.Visible;
                grdDeckCreation.Visibility = Visibility.Collapsed;
                grdDeckUpdate.Visibility = Visibility.Collapsed;
                try
                {
                    _userDecks = _deckManager.RetrieveUserDecksByUserID(_card.UserID);
                    cboDeckNames.ItemsSource = from m in _userDecks
                                               orderby m.DeckName
                                               select m.DeckName;
                }
                catch (Exception)
                {

                    MessageBox.Show("User decks not retrieved.");
                }
            }
        }

        private void btnDeckSave_Click(object sender, RoutedEventArgs e)
        {
            if(txtDeckName.Text == "")
            {
                MessageBox.Show("Please fill out the deck name.");
                txtDeckName.Focus();
                return;
            }
            if(txtDeckName.Text.Length > 50)
            {
                MessageBox.Show("Deck name cannot be greater than 50 characters");
                txtDeckName.Focus();
                return;
            }

            string deckName = txtDeckName.Text.ToString();
            bool isPublic = (bool)chkDeckPublic.IsChecked;
            try
            {
                _deckManager.CreateDeck(deckName, _user.UserID, isPublic);
                DialogResult = true;
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cancelHelper()
        {
            DialogResult = false;
            this.Close();
        }

        private void btnDeckCancel_Click(object sender, RoutedEventArgs e)
        {
            cancelHelper();
        }

        private void btnNewDeckUpdate_Click(object sender, RoutedEventArgs e)
        {
            Deck newDeck = new Deck() {
                DeckID = _deck.DeckID,
                DeckName = txtNewDeckName.Text.ToString(),
                UserID = _deck.UserID,
                IsPublic = (bool)chkNewDeckPublic.IsChecked
            };
            if (txtNewDeckName.Text == "")
            {
                MessageBox.Show("Please fill out the deck name.");
                txtDeckName.Focus();
                return;
            }
            if (txtNewDeckName.Text.Length > 50)
            {
                MessageBox.Show("Deck name cannot be greater than 50 characters");
                txtDeckName.Focus();
                return;
            }

            string deckName = txtNewDeckName.Text.ToString();
            bool isPublic = (bool)chkDeckPublic.IsChecked;
            try
            {
                _deckManager.EditDeck(_deck, newDeck);
                DialogResult = true;
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnNewDeckCancel_Click(object sender, RoutedEventArgs e)
        {
            cancelHelper();
        }

        private void btnNewDeckCardSave_Click(object sender, RoutedEventArgs e)
        {
            int amount = 0;
            if(cboDeckNames.SelectedItem == null)
            {
                MessageBox.Show("You must select a deck name.");
                cboDeckNames.Focus();
                return;
            }
            try
            {
                amount = Int32.Parse(txtCardAmount.Text.Trim());
            }
            catch (Exception)
            {
                MessageBox.Show("Card Amount must be a number.");
                txtCardAmount.Focus();
                return;
            }
            int deckID = _userDecks.First(m => m.DeckName == cboDeckNames.Text.ToString()).DeckID;
            DeckCard card = new DeckCard()
            {
                DeckID = deckID,
                CardID = _card.CardID,
                CardCount = amount,
                CardName = _card.CardName,
                ImageID = _card.ImageID,
                CardDescription = _card.CardDescription,
                CardColorID = _card.CardColorID,
                CardConvertedManaCost = _card.CardConvertedManaCost,
                CardTypeID = _card.CardTypeID,
                CardRarityID = _card.CardRarityID,
                HasSecondaryCard = _card.HasSecondaryCard,
                CardSecondaryName = _card.CardSecondaryName,
                SecondaryImageID = _card.SecondaryImageID,
                CardSecondaryDescription = _card.CardSecondaryDescription,
                CardSecondaryColorID = _card.CardSecondaryColorID,
                CardSecondaryConvertedManaCost = _card.CardSecondaryConvertedManaCost,
                CardSecondaryTypeID = _card.CardSecondaryTypeID,
                CardSecondaryRarityID = _card.CardSecondaryRarityID
            };
            try
            {
                _deckManager.CreateDeckCard(card);
                DialogResult = true;
                this.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Card is already in this deck");
            }
        }

        private void btnNewDeckCardCancel_Click(object sender, RoutedEventArgs e)
        {
            cancelHelper();
        }
    }
}
