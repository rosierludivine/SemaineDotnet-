using System.Collections.Generic;
using BookStoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers; //mettre le chemin de juste au dossier qui contient le fichier 

//2 Méthode avec deux chemindifferent 

//Ceci est une annotation, elle permet de définir des métadonnées sur une classes ``
// Dans ce contexte elle permet de définir que la classe boojController est un controleur d'api 
// on parle aussi de decorator/ decorateur permet d'ajouter des fonctionnalités (de facon dinamique) 
//a une classe sans modifié le code source 
[ApiController]
[Route("api/[controller]")]//permet de ne plus mettre [HttpPost[books]]
public class BookController : ControllerBase  //Heritage de ControllerBase afin de completer les valeurs en doublons dans les tables
{
    [HttpGet]
    public ActionResult<List<Book>> GetBooks()
    {

        var books = new List<Book>
        {
            new() { Id = 1, Title = "Le seigneur des anneaux", Author = "J.R.R Tolkien" }
        };

        return Ok(books);

    }

//Creer une methode avec la methode post
[HttpPost]
    public CreateBook ([FromBody] Book book){//[FromBody] permet de dire ou la requete http est dans le corps
        Console.WriteLine(book.Title); 
        return CreatAtAction(nameof(GetBooks), new {id = book.Id}, book)
    }
}