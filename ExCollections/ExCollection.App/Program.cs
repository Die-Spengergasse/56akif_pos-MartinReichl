using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ExCollection.App
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, SchoolClass> schoolClasses = new Dictionary<string, SchoolClass>();
            schoolClasses.Add("3AHIF", new SchoolClass() { Name = "3AHIF", KV = "KV1" });
            schoolClasses.Add("3BHIF", new SchoolClass() { Name = "3BHIF", KV = "KV2" });
            schoolClasses.Add("3CHIF", new SchoolClass() { Name = "3CHIF", KV = "KV3" });
            schoolClasses["3AHIF"].AddSchueler(new Student() { Id = 1001, FirstName = "VN1", LastName = "ZN1", MaximaleStudiendauer = 5 });
            schoolClasses["3AHIF"].AddSchueler(new Student() { Id = 1002, FirstName = "VN2", LastName = "ZN2", MaximaleStudiendauer = 2 });
            schoolClasses["3AHIF"].AddSchueler(new Student() { Id = 1003, FirstName = "VN3", LastName = "ZN3", MaximaleStudiendauer = 3 });
            schoolClasses["3BHIF"].AddSchueler(new Student() { Id = 1011, FirstName = "VN4", LastName = "ZN4", MaximaleStudiendauer = 7 });
            schoolClasses["3BHIF"].AddSchueler(new Student() { Id = 1012, FirstName = "VN5", LastName = "ZN5", MaximaleStudiendauer = 2 });
            schoolClasses["3BHIF"].AddSchueler(new Student() { Id = 1013, FirstName = "VN6", LastName = "ZN6", MaximaleStudiendauer = 7 });
            schoolClasses["3CHIF"].AddSchueler(new Teacher() { Id = 1014, FirstName = "Martin", LastName = "Reichl" });

            Student? s = schoolClasses["3AHIF"].Schuelers[0] as Student ?? new Student();
            Console.WriteLine($"s sitzt in der Klasse {s.KlasseNavigation.Name} mit dem KV {s.KlasseNavigation.KV}.");
            Console.WriteLine("3AHIF vor ChangeKlasse:");
            Console.WriteLine(JsonConvert.SerializeObject(schoolClasses["3AHIF"].Schuelers));
            s.ChangeKlasse(schoolClasses["3BHIF"]);
            Console.WriteLine("3AHIF nach ChangeKlasse:");
            Console.WriteLine(JsonConvert.SerializeObject(schoolClasses["3AHIF"].Schuelers));
            Console.WriteLine("3BHIF nach ChangeKlasse:");
            Console.WriteLine(JsonConvert.SerializeObject(schoolClasses["3BHIF"].Schuelers));
            Console.WriteLine($"s sitzt in der Klasse {s.KlasseNavigation.Name} mit dem KV {s.KlasseNavigation.KV}.");

            KuerzesteStudiendauer(schoolClasses["3AHIF"]);

            Console.WriteLine(schoolClasses["3CHIF"].Schuelers[0].FullName);
        }

        public static void KuerzesteStudiendauer(SchoolClass k)
        {
            // 1. Initialisierung mit Maximalwert
            // 2. Prüfung, ob nächste Dauer kleiner oder größer
            // 2.1 Wenn größer: nichts zu tun; zum nächsten Schüler gehen
            // 2.2 Wenn kleiner: ersten Wert mit neuem Minimum überschreiben

            int minWert = 7;

            foreach(Student s in k.Schuelers)
            {
                if (s.MaximaleStudiendauer < minWert && s is Student)
                {
                    minWert = s.MaximaleStudiendauer;
                }
            }

            Console.WriteLine($"Minimale Studiendauer in der {k?.Name ?? "unbekannt"} ist: {minWert}");
        }
    }
}
