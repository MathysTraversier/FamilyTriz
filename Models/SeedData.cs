using MvcFamilyTriz.Data;

namespace MvcFamilyTriz.Models;

public class SeedData
{
    public static void Init()
    {
        using(var context = new MvcFamilyTrizContext())
        {
            if(context.Familles.Any() || context.Eleves.Any() || context.Evenements.Any())
            {
                return;
            }
            else
            {
                Famille jaune = new Famille
                {
                    couleur = "Jaune",
                    points = 0,
                };
                Famille rouge = new Famille
                {
                    couleur = "Rouge",
                    points = 0,
                };
                Famille vert = new Famille
                {
                    couleur = "Vert",
                    points = 0,
                };
                Famille bleu = new Famille
                {
                    couleur = "Bleu",
                    points = 0,
                };
                Famille orange = new Famille
                {
                    couleur = "Orange",
                    points = 0,
                };

                context.Familles.AddRange(
                    jaune,
                    rouge,
                    vert,
                    bleu,
                    orange
                );

                Eleve maiwen = new Eleve
                {
                    nom = "Maginet",
                    prenom = "Maiwen",
                    promotion = 2023,
                    famille = orange
                };
                Eleve melissa = new Eleve
                {
                    nom = "Bruzat",
                    prenom = "Melissa",
                    promotion = 2023,
                    famille = orange
                };
                Eleve thoutmes = new Eleve
                {
                    nom = "Akemakou",
                    prenom = "Thoutmes",
                    promotion = 2023,
                    famille = orange
                };
                Eleve romain = new Eleve
                {
                    nom = "Durieux",
                    prenom = "Romain",
                    promotion = 2023,
                    famille = orange
                };
                Eleve tiphaine = new Eleve
                {
                    nom = "Petit",
                    prenom = "Tiphaine",
                    promotion = 2024,
                    parrain = maiwen,
                    famille = orange
                };
                Eleve mathys = new Eleve
                {
                    nom = "Traversier",
                    prenom = "Mathys",
                    promotion = 2024,
                    parrain = melissa,
                    famille = orange
                };
                Eleve corentinN = new Eleve
                {
                    nom = "Nivelet Etcheberry",
                    prenom = "Corentin",
                    promotion = 2024,
                    parrain = thoutmes,
                    famille = orange
                };
                Eleve mateo = new Eleve
                {
                    nom = "Moreau",
                    prenom = "Mateo",
                    promotion = 2024,
                    parrain = romain,
                    famille = orange
                };
                Eleve thomas = new Eleve
                {
                    nom = "Legay",
                    prenom = "Thomas",
                    promotion = 2025,
                    parrain = tiphaine,
                    famille = orange
                };
                Eleve cherif = new Eleve
                {
                    nom = "El Beshlawy",
                    prenom = "Cherif",
                    promotion = 2025,
                    parrain = mathys,
                    famille = orange
                };
                Eleve jean = new Eleve
                {
                    nom = "Mestressat",
                    prenom = "Jean",
                    promotion = 2025,
                    parrain = mathys,
                    famille = orange
                };
                Eleve gabriel = new Eleve
                {
                    nom = "Wourms",
                    prenom = "Gabriel",
                    promotion = 2025,
                    parrain = corentinN,
                    famille = orange
                };
                Eleve amandine = new Eleve
                {
                    nom = "Arlet",
                    prenom = "Amandine",
                    promotion = 2025,
                    parrain = mateo,
                    famille = orange
                };
                Eleve gabin = new Eleve
                {
                    nom = "Mobetie",
                    prenom = "Gabin",
                    promotion = 2025,
                    parrain = mateo,
                    famille = orange
                };
                Eleve corentinL = new Eleve
                {
                    nom = "Léger",
                    prenom = "Corentin",
                    promotion = 2023,
                    famille = rouge
                };
                Eleve valentin = new Eleve
                {
                    nom = "Herrero",
                    prenom = "Valentin",
                    promotion = 2024,
                    parrain = corentinL,
                    famille = rouge
                };
                Eleve diane = new Eleve
                {
                    nom = "Vacherie",
                    prenom = "Diane",
                    promotion = 2024,
                    parrain = valentin,
                    famille = rouge
                };

                context.Eleves.AddRange(
                    maiwen,
                    melissa,
                    thoutmes,
                    romain,
                    tiphaine,
                    mathys,
                    mateo,
                    corentinN,
                    thomas,
                    jean,
                    cherif,
                    gabriel,
                    amandine,
                    gabin,
                    corentinL,
                    valentin,
                    diane
                );

                Evenement relais = new Evenement
                {
                    nom = "Relais",
                    description = "Le but est de réunir toutes les familles autour d'un relais au Bois de Thouars avec des points à la clé pour les 3 premières familles.",
                    nbPointAGagner = 40,
                    date = new DateTime(2023,1,20)
                };

                Evenement laserGames = new Evenement
                {
                    nom = "Laser Games",
                    description = "Les familles se réuniront autour d'un laser games avec des points à la clé.",
                    nbPointAGagner = 10,
                    date = new DateTime(2022,9,20)
                };

                context.Evenements.AddRange(
                    relais,
                    laserGames
                );

                context.SaveChanges();
            }
        }
    }
}