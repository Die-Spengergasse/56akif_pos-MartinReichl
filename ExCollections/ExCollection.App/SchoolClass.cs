using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ExCollection.App
{
    public class SchoolClass
    {
        // TODO: Erstelle ein Property Schuelers, welches alle Schüler der Klasse in einer
        //       Liste speichert.
        public List<Person> Schuelers { get; private set; } = new();
        public string Name { get; set; }
        public string KV { get; set; }

        /// <summary>
        /// Fügt den Schüler zur Liste hinzu und setzt das Property KlasseNavigation
        /// des Schülers korrekt auf die aktuelle Instanz.
        /// Es werden nur Studenten in die Klasse aufgenommen.
        /// </summary>
        /// <param name="s"></param>
        public void AddSchueler(Person s)
        {
            // HIER DEN CODE EINFÜGEN
            if(s is null)
            {
                throw new ArgumentNullException(nameof(s), "Schüler ist NULL!");
            }

            if (Schuelers.Contains(s))
            {
                throw new ArgumentException(nameof(s), "Schüler ist bereits in der Klasse!");
            }

            Student? student = s as Student;

            if (student is not null)
            {
                student.KlasseNavigation = this;
                Schuelers.Add(s);
            }   
        }
    }
}
