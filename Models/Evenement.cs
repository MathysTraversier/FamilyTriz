using System.ComponentModel.DataAnnotations;

namespace MvcFamilyTriz.Models;

public class Evenement {
    public int id {get; set;}
    
    [Display(Name = "Nom")]
    public string nom {get; set;} = null!;

    [Display(Name = "Description"),StringLength(600)]
    public string description {get; set;} = null!;
    
    [Display(Name = "Nombre de points à gagner")]
    public int nbPointAGagner {get; set;}

    [Display(Name = "Nombre de points gagné par les rouges")]
    public int nbPointRouge {get; set;}

    [Display(Name = "Nombre de points gagné par les verts")]
    public int nbPointVert {get; set;}

    [Display(Name = "Nombre de points gagné par les bleus")]
    public int nbPointBleu {get; set;}

    [Display(Name = "Nombre de points gagné par les jaunes")]
    public int nbPointJaune {get; set;}

    [Display(Name = "Nombre de points gagné par les oranges")]
    public int nbPointOrange {get; set;}


    [Display(Name = "Date de l'événement"), DataType(DataType.Date)]
    public DateTime date {get; set;}

    public Evenement()
    {
        nbPointBleu = 0;
        nbPointJaune = 0;
        nbPointOrange = 0;
        nbPointRouge = 0;
        nbPointVert = 0;
    }




}