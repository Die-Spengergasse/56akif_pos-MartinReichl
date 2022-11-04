using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ExCollection.App
{
    public class Klasse
    {
        // TODO: Erstelle ein Property Schuelers, welches alle Schüler der Klasse in einer
        //       Liste speichert.
        public List<Schueler> Schuelers { get; private set; } = new();
        public string Name { get; set; }
        public string KV { get; set; }

        /// <summary>
        /// Fügt den Schüler zur Liste hinzu und setzt das Property KlasseNavigation
        /// des Schülers korrekt auf die aktuelle Instanz.
        /// </summary>
        /// <param name="s"></param>
        public void AddSchueler(Schueler s)
        {
            // HIER DEN CODE EINFÜGEN
            if(s != null)
            {
                Schuelers.Add(s);
                s.KlasseNavigation = this;
            }
        }
    }
}
