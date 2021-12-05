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
    /// Interaction logic for CardDetail.xaml
    /// </summary>
    public partial class CardDetail : Window
    {
        private UserCard _card;
        public CardDetail()
        {
            InitializeComponent();
        }

        public CardDetail(UserCard userCard)
        {
            _card = userCard;
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
    }
}
