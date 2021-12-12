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
        User _user;
        Deck _deck;
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

        private void populateControls()
        {
            if (_deck == null) 
            {
                grdDeckCreation.Visibility = Visibility.Visible;
                grdDeckUpdate.Visibility = Visibility.Collapsed;
                txtDeckName.Focus();
            }
            else if (_deck != null)
            {
                grdDeckUpdate.Visibility = Visibility.Visible;
                grdDeckCreation.Visibility = Visibility.Collapsed;
                txtNewDeckName.Text = _deck.DeckName;
                chkNewDeckPublic.IsChecked = _deck.IsPublic;
                txtNewDeckName.Focus();
                
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

    }
}
