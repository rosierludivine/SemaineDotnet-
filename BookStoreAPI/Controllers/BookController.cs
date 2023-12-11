using System.Collections.Generic;
using BookStoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers; //mettre le chemin de juste au dossier qui contient le fichier 


//Ceci est une annotation, elle permet de définir des métadonnées sur une classes ``
// Dans ce contexte elle permet de définir que la classe boojController est un controleur d'api 
// on parle aussi de decorator/ decorateur permet d'ajouter des fonctionnalités (de facon dinamique) 
//a une classe sans modifié le code source 
[ApiController]
public class BookController : ControllerBase  //Heritage de ControllerBase afin de completer les valeurs en doublons dans les tables
{
    [HttpGet("books")]
    public ActionResult<List<Book>> GetBooks()
    {

        var books = new List<Book>
        {
            new() { Id = 1, Title = "Le seigneur des anneaux", Author = "J.R.R Tolkien" }
        };

        return Ok(books);

    }
}