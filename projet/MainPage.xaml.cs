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
            JouerSon();
            Inventaire inventaire_init = new Inventaire();
            inventaire_init.Charger();
            Application.Current.Resources["inventaire"] = inventaire_init;
        }

        public async void Commencer_jeu(object sender, RoutedEventArgs e)
        {
            if (saisie_nom.Text != "")
            {
                Application.Current.Resources["nom joueur"] = saisie_nom.Text;
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

        public async void JouerSon()
        {
            var element = new MediaElement();
            var folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            Console.WriteLine(folder.Path);
            var file = await folder.GetFileAsync("musique.mp3");
            var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
            element.SetSource(stream, "");
            element.Play();
        }
    }
}
