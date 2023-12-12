using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


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
    private readonly ApplicationDbContext _dbContext;

    public BookController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

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
    [ProducesResponseType(201, Type = typeof(Book))]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Book>> PostBook([FromBody] Book book)
    {
        // we check if the parameter is null
        if (book == null)
        {
            return BadRequest();
        }
        // we check if the book already exists
        Book? addedBook = await _dbContext.Books.FirstOrDefaultAsync(b => b.Title == book.Title);
        if (addedBook != null)
        {
            return BadRequest("Book already exists");
        }
        else
        {
            // we add the book to the database
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();

            // we return the book
            return Created("api/book", book);

        }
    }
}