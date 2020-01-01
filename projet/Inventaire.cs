using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text.Json;

namespace projet
{
    class Inventaire : ObservableCollection<Objet>
    {
        public async void Charger()
        {
            //Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFolder storageFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            Windows.Storage.StorageFile sampleFile = await storageFolder.GetFileAsync("inventaire.json");
            //Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync("inventaire.json", Windows.Storage.CreationCollisionOption.ReplaceExisting);
            //await Windows.Storage.FileIO.WriteTextAsync(sampleFile, "[{ \"Nom\": \"torche\"},{ \"Nom\": \"livre\"},{\"Nom\": \"manteau\"}]");
            string text = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
            Inventaire tmp = JsonSerializer.Deserialize<Inventaire>(text);
            //Inventaire tmp = new Inventaire();
            this.Clear();
            foreach (Objet objet in tmp)
            {
                this.Add(objet);
            }
        }

        public void AddObjet(string nom, string description)
        {
            Objet nouvelObj = new Objet()
            {
                Nom = nom,
                Description = description
            };
            Add(nouvelObj);
        }
    }
}
