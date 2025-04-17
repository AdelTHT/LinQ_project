using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Voiture> voitures = new List<Voiture>
        {
            new Voiture { Marque = "Ferrari", Modele = "LaFerrari", Puissance = 950, VitesseMax = 352 },
            new Voiture { Marque = "Bugatti", Modele = "Chiron", Puissance = 1500, VitesseMax = 420 },
            new Voiture { Marque = "McLaren", Modele = "P1", Puissance = 916, VitesseMax = 350 },
            new Voiture { Marque = "Lamborghini", Modele = "Aventador", Puissance = 690, VitesseMax = 350 },
            new Voiture { Marque = "Mercedes-Benz", Modele = "AMG GT Black Series", Puissance = 730, VitesseMax = 325 },
            new Voiture { Marque = "Mercedes-Benz", Modele = "AMG GT 63 S E", Puissance = 831, VitesseMax = 316 },
            new Voiture { Marque = "BMW", Modele = "M5 CS", Puissance = 635, VitesseMax = 305 },
            new Voiture { Marque = "BMW", Modele = "M8 Competition", Puissance = 625, VitesseMax = 305 },
            new Voiture { Marque = "Audi", Modele = "RS e-tron GT", Puissance = 637, VitesseMax = 250 },
            new Voiture { Marque = "Audi", Modele = "RS6 Avant", Puissance = 621, VitesseMax = 305 },
            new Voiture { Marque = "Porsche", Modele = "911 GT2 RS", Puissance = 700, VitesseMax = 340 },
            new Voiture { Marque = "Porsche", Modele = "Cayenne Turbo GT", Puissance = 640, VitesseMax = 300 },
            new Voiture { Marque = "Porsche", Modele = "Taycan Turbo S", Puissance = 761, VitesseMax = 260 },
            new Voiture { Marque = "Aston Martin", Modele = "Valkyrie", Puissance = 1160, VitesseMax = 400 },
            new Voiture { Marque = "Koenigsegg", Modele = "Jesko", Puissance = 1600, VitesseMax = 480 }
        };

        // Afficher les voitures pour tester
        foreach (var voiture in voitures)
        {
            Console.WriteLine($"{voiture.Marque} {voiture.Modele} - {voiture.Puissance} chevaux - {voiture.VitesseMax} km/h");
        }

        //1. Recherche des voitures en fonction de critère 
        // j'ai utiliser la syntaxe requete
        var voituresPuissantes = from v in voitures
                                where v.Puissance > 900
                                select v;

        Console.WriteLine("Voitures puissantes (plus de 900 chevaux) :");
        foreach (var voiture in voituresPuissantes)
        {
            Console.WriteLine($"{voiture.Marque} {voiture.Modele} - {voiture.Puissance} chevaux");
        }

        //2. trier les voitures par puissance croissante 
        // j'ai utiliser la syntaxe méthode
        var voituresTriees = voitures.OrderBy(v => v.Puissance).ToList();

        Console.WriteLine("Voitures triées par puissance :");
        foreach (var voiture in voituresTriees)
        {
            Console.WriteLine($"{voiture.Marque} {voiture.Modele} - {voiture.Puissance} chevaux");
        }

        // 3. Groupement des voitures par marque (Syntaxe Requête)
        // j'ai utiliser la syntaxe requete
        var voituresGroupées = from v in voitures
                               group v by v.Marque into groupe
                               select groupe;

        Console.WriteLine("\nVoitures groupées par marque :");
        foreach (var groupe in voituresGroupées)
        {
            Console.WriteLine($"Marque : {groupe.Key}");
            foreach (var voiture in groupe)
            {
                Console.WriteLine($" - {voiture.Modele}, {voiture.Puissance} chevaux, {voiture.VitesseMax} km/h");
            }
        }

        // 4. Exporter les résultats triés en JSON
        var voituresTrieesJSON = from v in voitures
                                orderby v.Puissance
                                select v;

        string json = JsonConvert.SerializeObject(voituresTrieesJSON, Formatting.Indented);
        File.WriteAllText("voituresTriées.json", json);

        Console.WriteLine("\nLes données ont été exportées en JSON.");

        // Exporter les résultats triés en XML
        XElement xml = new XElement("Voitures",
            from v in voituresTrieesJSON
            select new XElement("Voiture",
                new XElement("Marque", v.Marque),
                new XElement("Modele", v.Modele),
                new XElement("Puissance", v.Puissance),
                new XElement("VitesseMax", v.VitesseMax)
            )
        );

        xml.Save("voituresTriees.xml");
        Console.WriteLine("\nLes données ont été exportées en XML.");

        Console.WriteLine("\nQue voulez-vous exporter ?");
        Console.WriteLine("1. Exporter toutes les données");
        Console.WriteLine("2. Exporter seulement les Marques et Modèles");
        Console.WriteLine("3. Exporter les voitures de plus de 900 chevaux");
        Console.WriteLine("4. Exporter les voitures triées par vitesse maximale");
        Console.WriteLine("5. Exporter les voitures groupées par marque");
        Console.WriteLine("6. Exporter les voitures avec leur puissance par marque");

        string? choix = Console.ReadLine();

        switch (choix)
        {
            case "1":
                ExporterToutesLesDonnees(voitures);
                break;
            case "2":
                ExporterMarquesEtModeles(voitures);
                break;
            case "3":
                ExporterVoituresPuissantes(voitures);
                break;
            case "4":
                ExporterVoituresParVitesse(voitures);
                break;
            case "5":
                ExporterVoituresParMarque(voitures);
                break;
            case "6":
                ExporterPuissanceParMarque(voitures);
                break;
            default:
                Console.WriteLine("Choix invalide.");
                break;
        }
    }

    static void ExporterToutesLesDonnees(List<Voiture> voitures)
    {
        string json = JsonConvert.SerializeObject(voitures, Formatting.Indented);
        File.WriteAllText("voitures_completes.json", json);
        Console.WriteLine("Données complètes exportées en JSON.");
    }

    static void ExporterMarquesEtModeles(List<Voiture> voitures)
    {
        var voituresSimplifiees = voitures.Select(v => new { v.Marque, v.Modele }).ToList();
        string json = JsonConvert.SerializeObject(voituresSimplifiees, Formatting.Indented);
        File.WriteAllText("voitures_simplifiees.json", json);
        Console.WriteLine("Marques et modèles exportés en JSON.");
    }

    static void ExporterVoituresPuissantes(List<Voiture> voitures)
    {
        var voituresPuissantes = voitures.Where(v => v.Puissance > 900)
                                       .Select(v => new { v.Marque, v.Modele, v.Puissance });
        string json = JsonConvert.SerializeObject(voituresPuissantes, Formatting.Indented);
        File.WriteAllText("voitures_puissantes.json", json);
        Console.WriteLine("Voitures de plus de 900 chevaux exportées en JSON.");
    }

    static void ExporterVoituresParVitesse(List<Voiture> voitures)
    {
        var voituresParVitesse = voitures.OrderByDescending(v => v.VitesseMax)
                                       .Select(v => new { v.Marque, v.Modele, v.VitesseMax });
        string json = JsonConvert.SerializeObject(voituresParVitesse, Formatting.Indented);
        File.WriteAllText("voitures_par_vitesse.json", json);
        Console.WriteLine("Voitures triées par vitesse exportées en JSON.");
    }

    static void ExporterVoituresParMarque(List<Voiture> voitures)
    {
        var voituresParMarque = voitures.GroupBy(v => v.Marque)
                                      .Select(g => new { 
                                          Marque = g.Key, 
                                          Voitures = g.Select(v => new { v.Modele, v.Puissance, v.VitesseMax })
                                      });
        string json = JsonConvert.SerializeObject(voituresParMarque, Formatting.Indented);
        File.WriteAllText("voitures_par_marque.json", json);
        Console.WriteLine("Voitures groupées par marque exportées en JSON.");
    }

    static void ExporterPuissanceParMarque(List<Voiture> voitures)
    {
        var puissanceParMarque = voitures.GroupBy(v => v.Marque)
                                       .Select(g => new {
                                           Marque = g.Key,
                                           PuissanceMoyenne = g.Average(v => v.Puissance),
                                           PuissanceMax = g.Max(v => v.Puissance),
                                           PuissanceMin = g.Min(v => v.Puissance)
                                       });
        string json = JsonConvert.SerializeObject(puissanceParMarque, Formatting.Indented);
        File.WriteAllText("puissance_par_marque.json", json);
        Console.WriteLine("Statistiques de puissance par marque exportées en JSON.");
    }
}

