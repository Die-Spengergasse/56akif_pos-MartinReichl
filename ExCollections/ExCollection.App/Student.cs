using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ExCollection.App
{
    public class Student : Person
    {
        private int _maximaleStudiendauer;

        // TODO: Erstelle ein Proeprty KlasseNavigation vom Typ Klasse, welches auf
        //       die Klasse des Schülers zeigt.
        [JsonIgnore]
        public SchoolClass KlasseNavigation { get; set; }  
        // Füge dann über das Proeprty die Zeile
        // [JsonIgnore]
        // ein, damit der JSON Serializer das Objekt ausgeben kann.

        public int MaximaleStudiendauer
        {
            get { return _maximaleStudiendauer; }

            set 
            {
                if (value >= 1 && value <= 7)
                {
                    _maximaleStudiendauer = value; 
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Liegt nicht im gültigen Bereich!");
                }
            }
        }

        public Student() : this(12) { }

        public Student(int id) : base(id)
        {

        }

        public new string GetAllInfo()
        {
            return $"{Id} | FN: {FirstName} | LN: {LastName}";
        }

        /// <summary>
        /// Ändert die Klassenzugehörigkeit, indem der Schüler
        /// aus der alten Klasse, die in KlasseNavigation gespeichert ist, entfernt wird.
        /// Danach wird der Schüler in die neue Klasse mit der korrekten Navigation eingefügt.
        /// </summary>
        /// <param name="k"></param>
        public void ChangeKlasse(SchoolClass k)
        {
            // HIER DEN CODE EINFÜGEN
            if (k is not null)
            {
                KlasseNavigation.Schuelers.Remove(this);
                k.AddSchueler(this);
            }
        }

        public override string GetArriveType()
        {
            return "Reist meist öffentlich oder mit dem Fahrrad an.";
        }
    }
}
