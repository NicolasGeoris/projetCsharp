using System;
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

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace projet
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        public async void Commencer_jeu(object sender, RoutedEventArgs e)
        {
            if (saisie_nom.Text != "")
            {
                Application.Current.Resources["nom_joueur"] = saisie_nom.Text;
                Frame.Navigate(typeof(Page_1));
            }
            else
            {
                ContentDialog dialog = new ContentDialog
                {
                    Title = "YA PA DE PANO",
                    Content = "Entre ton nom!",
                    CloseButtonText = "OK"
                };

                ContentDialogResult result = await dialog.ShowAsync();
            }
        }
    }
}
