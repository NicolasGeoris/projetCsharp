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
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace projet
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class Page_intro : Page
    {
        public Page_intro()
        {
            this.InitializeComponent();
            inventaire.ItemsSource = Application.Current.Resources["inventaire"];
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
            Frame.Navigate(typeof(Page_1));
        }
    }
}
