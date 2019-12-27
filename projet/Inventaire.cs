using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;

namespace projet
{
    class Inventaire : ObservableCollection<Objet>
    {
        public void Charger()
        {
            FileStream stream = File.Open(@"..\..\..\..\inventaire.json", FileMode.Open);
            DataContractJsonSerializer serial = new DataContractJsonSerializer(typeof(Inventaire));
            Inventaire tmp = (Inventaire)serial.ReadObject(stream);
            this.Clear();
            foreach (Objet objet in tmp)
            {
                this.Add(objet);
            }
        }
    }
}
