using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Deck.Resources;

namespace Deck
{
    public partial class MainPage : PhoneApplicationPage
    {
        int[] baraja = new int[40];
        int cartasSacadas = 0;
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sacarCarta();
        }

        private void ContentPanel_Loaded(object sender, RoutedEventArgs e)
        {
            barajarCartas();
            sacarCarta();
        }

        private void sacarCarta()
        {
            int sacado = baraja[cartasSacadas];
            cartasSacadas++;
            if (cartasSacadas == 39)
            {
                Boton.Content = "Barajar";
            }
            if (cartasSacadas == 40)
            {
                barajarCartas();
            }
            NumeroCarta.Text = getValor((sacado % 10) + 1);
            Palocarta.Text = getPalo(sacado / 10);
        }

        private void barajarCartas()
        {
            int[] barajaInicial = new int[40];
            for (int i = 0; i < 40; i++)
            {
                barajaInicial[i] = i;
            }
            Random random = new Random();
            int randomNumber;
            for (int j = 40; j > 0; j--)
            {
                randomNumber = random.Next(0, j);
                baraja[j-1] = barajaInicial[randomNumber];
                for (int k = randomNumber; k < j-1; k++)
                {
                    barajaInicial[k] = barajaInicial[k + 1];
                }
            }
            cartasSacadas = 0;
            Boton.Content = "Sacar carta";
        }

        private string getPalo(int i)
        {
            String toReturn = "";
            switch (i)
            {
                case 0: toReturn = "🔆 Oros"; break;
                case 1: toReturn = "🏆 Copas"; break;
                case 2: toReturn = "🔪 Espadas"; break;
                case 3: toReturn = "🍡 Bastos"; break;
            }
            return toReturn;
        }

        private string getValor(int i)
        {
            if (i >= 1 && i <= 7) return i.ToString();
            else return (i + 2).ToString();
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}