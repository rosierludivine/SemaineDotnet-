using System.Collections.Generic;
using BookStoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers; //mettre le chemin de juste au dossier qui contient le fichier 


//Ceci est une annotation, elle permet de définir des métadonnées sur une classes ``
// Dans ce contexte elle permet de définir que la classe boojController est un controleur d'api 
// on parle aussi de decorator/ decorateur permet d'ajouter des fonctionnalités (de facon dinamique) 
//a une classe sans modifié le code source 
[ApiController]
public class LivreController : ControllerBase  //Heritage de ControllerBase afin de completer les valeurs en doublons dans les tables
{
    [HttpGet("livres")]// Affichage des resultats si nous sommes sur '/Livres'
    public ActionResult<List<Livre>> GetLivres()//Methode qui doit retourner Livre 
    {

        var livres = new List<Livre> //variable livre qui prend en compte une List de Livre 
        {
            new() { Id = 1, Title = "Peter Pan ", Auteur = "Simon Rousseau" },//Création d'un objet Livre 
            new() { Id = 2, Title = "Blanche-Neige", Auteur = "Simon Rousseau" }
        };

        return Ok(livres);// le Ok nous permet de retourner l'objet Livre 

    }
}