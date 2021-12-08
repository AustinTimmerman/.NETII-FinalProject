﻿using System;
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
    /// Interaction logic for CardDetail.xaml
    /// </summary>
    public partial class CardDetail : Window
    {
        private UserCard _card;
        private ICardManager _cardManager;
        private IDeckManager _deckManager;
        private IMatchManager _matchManager;
        public CardDetail()
        {
            InitializeComponent();
        }

        public CardDetail(UserCard userCard, ICardManager cardManager, IDeckManager deckManager, IMatchManager matchManager)
        {
            _card = userCard;
            _cardManager = cardManager;
            _deckManager = deckManager;
            _matchManager = matchManager;
            InitializeComponent();
            populateControls();
        }

        private void populateControls()
        {
            if (_card.HasSecondaryCard)
            {
                grdTwoCardDetail.Visibility = Visibility.Visible;
                grdOneCardDetail.Visibility = Visibility.Collapsed;
                populateTwoCardGrid();
            }
            else
            {
                grdOneCardDetail.Visibility = Visibility.Visible;
                grdTwoCardDetail.Visibility = Visibility.Collapsed;
                populateOneCardGrid();
            }
        }

        private void populateOneCardGrid()
        {
            try
            {
                lblCardName.Content = _card.CardName;
                //imgCardImage.Source = 
                txtCardDescription.Text = _card.CardDescription;
                lblCardRarity.Content = _card.CardRarityID;
                lblCardManaCost.Content = _card.CardConvertedManaCost;
                lblCardColor.Content = _card.CardColorID;
                lblCardType.Content = _card.CardTypeID;
                chkOneCardOwned.IsChecked = _card.OwnedCard;
                chkOneCardWishlisted.IsChecked = _card.Wishlisted;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex + " ");
            }
        }

        private void populateTwoCardGrid()
        {
            try
            {
                lblPrimaryCardName.Content = _card.CardName;
                //imgPrimaryCardImage.Source
                txtPrimaryCardDescription.Text = _card.CardDescription;
                lblPrimaryCardRarity.Content = _card.CardRarityID;
                lblPrimaryCardManaCost.Content = _card.CardConvertedManaCost;
                lblPrimaryCardColor.Content = _card.CardColorID;
                lblPrimaryCardType.Content = _card.CardTypeID;

                lblSecondaryCardName.Content = _card.CardSecondaryName;
                //imgSecondaryCardImage.Source
                txtSecondaryCardDescription.Text = _card.CardSecondaryDescription;
                lblSecondaryCardRarity.Content = _card.CardSecondaryRarityID;
                lblSecondaryCardManaCost.Content = _card.CardSecondaryConvertedManaCost;
                lblSecondaryCardColor.Content = _card.CardSecondaryColorID;
                lblSecondaryCardType.Content = _card.CardSecondaryTypeID;

                chkTwoCardOwned.IsChecked = _card.OwnedCard;
                chkTwoCardWishlisted.IsChecked = _card.Wishlisted;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex + " ");
            }
        }

        private void buttonHelper()
        {
            if (grdOneCardDetail.Visibility == Visibility.Visible)
            {
                if (_card.OwnedCard == chkOneCardOwned.IsChecked && _card.Wishlisted == chkOneCardWishlisted.IsChecked)
                {
                    btnOneCardSave.IsEnabled = false;
                    btnOneCardCloseCancel.Content = "Close";
                }
                else
                {
                    btnOneCardSave.IsEnabled = true;
                    btnOneCardCloseCancel.Content = "Cancel";
                }
            }
            else if(grdTwoCardDetail.Visibility == Visibility.Visible)
            {
                if (_card.OwnedCard == chkTwoCardOwned.IsChecked && _card.Wishlisted == chkTwoCardWishlisted.IsChecked)
                {
                    btnTwoCardSave.IsEnabled = false;
                    btnTwoCardCloseCancel.Content = "Close";
                }
                else
                {
                    btnTwoCardSave.IsEnabled = true;
                    btnTwoCardCloseCancel.Content = "Cancel";
                }
            }
        }

        private void chkOneCardOwned_Click(object sender, RoutedEventArgs e)
        {
            buttonHelper();
        }

        private void chkOneCardWishlisted_Click(object sender, RoutedEventArgs e)
        {
            buttonHelper();
        }

        private void chkTwoCardOwned_Click(object sender, RoutedEventArgs e)
        {
            buttonHelper();
        }

        private void chkTwoCardWishlisted_Click(object sender, RoutedEventArgs e)
        {
            buttonHelper();
        }

        private void btnOneCardSave_Click(object sender, RoutedEventArgs e)
        {
            UserCard userCard;
            userCard = _card;
            userCard.OwnedCard = (bool)chkOneCardOwned.IsChecked;
            userCard.Wishlisted = (bool)chkOneCardWishlisted.IsChecked;

            try
            {
                bool result = _cardManager.EditUserCard(_card, userCard);
                if (!result)
                {
                    _cardManager.CreateUserCard(userCard);
                }
            }
            catch (Exception)
            {

                throw;
            }
            _card = userCard;
            buttonHelper();
           
        }

        private void btnOneCardCloseCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (btnOneCardCloseCancel.Content.ToString() == "Close")
                {
                    this.Close();
                }
                else
                {
                    buttonHelper();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
