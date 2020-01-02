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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace projet
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class Page_2 : Page
    {
        Storyboard ouverturePortes;
        public Page_2()
        {
            this.InitializeComponent();
            inventaire.ItemsSource = Application.Current.Resources["inventaire"];
            this.InitializeComponent();
            inventaire.ItemsSource = Application.Current.Resources["inventaire"];

            TranslateTransform versLaGauche = new TranslateTransform();
            versLaGauche.X = 0;
            versLaGauche.Y = 0;
            porteGauche.RenderTransform = versLaGauche;
            TranslateTransform versLaDroite = new TranslateTransform();
            versLaDroite.X = 0;
            versLaDroite.Y = 0;
            porteDroite.RenderTransform = versLaDroite;

            Duration duree = new Duration(TimeSpan.FromSeconds(1));

            DoubleAnimation animGauche = new DoubleAnimation();
            animGauche.Duration = duree;
            DoubleAnimation animDroite = new DoubleAnimation();
            animDroite.Duration = duree;

            ouverturePortes = new Storyboard();
            ouverturePortes.Duration = duree;
            ouverturePortes.Children.Add(animGauche);
            ouverturePortes.Children.Add(animDroite);
            Storyboard.SetTarget(animGauche, versLaGauche);
            Storyboard.SetTarget(animDroite, versLaDroite);
            Storyboard.SetTargetProperty(animGauche, "X");
            Storyboard.SetTargetProperty(animDroite, "X");
            animGauche.To = -75;
            animDroite.To = 75;

            this.Resources.Add("ouverturePortes", ouverturePortes);
        }

        public void Continuer(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Page_3));
        }

        public void ContinuerPerdu(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Page_Perdu));
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

        public void VerifReponse(object sender, RoutedEventArgs e)
        {
            if (reponse.Text == "40")
            {
                description.Text = "C'était ca ! La porte s'ouvre !";
                boutons_deplacement.Visibility = Visibility.Visible;
                ouverturePortes.Begin();
            }
        }
    }
}
