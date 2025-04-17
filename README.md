# VoituresGrandBolide

Ce projet est une application console .NET Core qui démontre l'utilisation de LINQ pour manipuler une collection d'objets `Voiture`.

Il permet d'effectuer diverses opérations de recherche, tri, groupage et d'exporter les résultats dans différents formats et avec différents niveaux de détail.

## Fonctionnalités

L'application charge une liste prédéfinie de voitures et propose ensuite un menu pour exporter les données selon différents critères :

1.  **Exporter toutes les données :** Exporte la liste complète des voitures avec tous leurs attributs (Marque, Modèle, Puissance, VitesseMax) au format JSON.
2.  **Exporter seulement les Marques et Modèles :** Exporte une liste simplifiée contenant uniquement la marque et le modèle de chaque voiture au format JSON.
3.  **Exporter les voitures de plus de 900 chevaux :** Filtre les voitures dont la puissance est supérieure à 900 chevaux et exporte leur marque, modèle et puissance au format JSON.
4.  **Exporter les voitures triées par vitesse maximale :** Trie les voitures par vitesse maximale (décroissante) et exporte leur marque, modèle et vitesse maximale au format JSON.
5.  **Exporter les voitures groupées par marque :** Regroupe les voitures par marque et exporte la liste des modèles, puissances et vitesses maximales pour chaque marque au format JSON.
6.  **Exporter les voitures avec leur puissance par marque :** Calcule et exporte les statistiques de puissance (moyenne, maximale, minimale) pour chaque marque au format JSON.

L'application exporte également initialement les données triées par puissance aux formats JSON et XML (`voituresTriées.json` et `voituresTriees.xml`).

## Comment utiliser

1.  **Prérequis :** Assurez-vous d'avoir le SDK .NET installé (compatible avec la version spécifiée dans `VoituresGrandBolide.csproj`).
2.  **Cloner le dépôt** (si applicable).
3.  **Naviguer** vers le répertoire `LinQ_project` dans votre terminal.
4.  **Restaurer les dépendances :**
    ```bash
    dotnet restore
    ```
5.  **Construire le projet :**
    ```bash
    dotnet build
    ```
6.  **Exécuter l'application :**
    ```bash
    dotnet run
    ```
7.  Suivez les instructions dans la console pour choisir une option d'exportation.
8.  Les fichiers JSON/XML exportés seront créés dans le répertoire de l'exécutable (par exemple, `bin/Debug/netX.X/`).

## Technologies utilisées

*   .NET Core
*   C#
*   LINQ (Language Integrated Query)
*   Newtonsoft.Json (pour la sérialisation JSON)
*   System.Xml.Linq (pour la création XML) 
