// Instanciation du conteneur d'objets Pays
var tabPays = new List<Pays>();

// Lecture du fichier et itération sur les lignes lues
// File.ReadAllLines crée un tableau de string
// représentant chaque ligne
foreach (var line in File.ReadAllLines("pays.txt"))
{
    // Certaines lignes sont vides
    // et doivent être filtrées
    if (string.IsNullOrEmpty(line))
        continue;

    // split construit un tableau de string à partir
    // d'une ligne découpée suivant les tabulations
    var entries = line.Split('\t');

    // Les espaces dans les superficies sont filtrés
    string? tmp = null;
    foreach (var c in entries[2])
    {
        if (c == ' ') continue;
        tmp += c;
    }
    int.TryParse(tmp, out int superficie);

    // Ajout de l'instance dans le conteneur
    tabPays.Add(new Pays
    {
        Nom = entries[0],
        Continent = entries[1],
        Superficie = superficie
    });
}
// La liste d'objets est chargée, on peut commencer à jouer

// 1. Afficher le nombre de pays en Asie


// 1.1 Afficher le nombre de pays en Asie mais qui s'affranchit des problèmes potentiels de casse


// 2. Afficher en ordre alphabétique les noms et les superficies des pays asiatiques


// 3. Calculer et afficher la surface totale de l’Asie


// 4. Afficher en ordre alphabétique tous les pays d’Asie dont le nom commence par A


// 5. Calculer et afficher la surface totale des pays d’Asie dont le nom commence par A


// 6. Afficher le nom du pays d’Asie ayant la plus grande superficie


// 7. Afficher le nom du pays d’Asie ayant la plus petite superficie


// 8. Afficher les noms de chaque continent suivis par les noms des pays qui les constituent 


// 8.1. Compléter l’affichage précédent par les surfaces de chaque continent et de chacun de ces pays


// 9. Afficher le nom du plus grand continent avec sa superficie


// 10. Afficher le nom du plus petit continent avec sa superficie


public class Pays
{
    public string? Nom { get; set; }
    public string? Continent { get; set; }
    public int Superficie { get; set; }
}
