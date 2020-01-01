﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace projet
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class Page_1 : Page
    {

        public Page_1()
        {
            this.InitializeComponent();
            inventaire.ItemsSource = Application.Current.Resources["inventaire"];
        }

        public void BonBouton(object sender, RoutedEventArgs e)
        {
            boutons_choix.Visibility = Visibility.Collapsed;
            boutons_deplacement.Visibility = Visibility.Visible;
            description.Text = "Oh! La porte s'ouvre !";
            //Ici on met une belle animation de porte tavu
        }

        public void MauvaisBouton(object sender, RoutedEventArgs e)
        {
            description.Text = "Visiblement ca n'était pas ce bouton là. J'espère que rien ne va se passer!";
        }

        public async void AfficheInfos(object sender, RoutedEventArgs e)
        {
            Objet selectionne = (Objet)((ListBox)sender).SelectedItem;
            ContentDialog dialog = new ContentDialog
            {
                Title = selectionne.Nom,
                Content = selectionne.Description,
                CloseButtonText = "OK"
            };

            ContentDialogResult result = await dialog.ShowAsync();
        }

        public void Continuer(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Page_2));
        }

        public void ContinuerPerdu(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Page_Perdu));
        }
    }
}
