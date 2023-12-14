using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookStoreAPI.Entities;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


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
    private readonly IMapper _mapper; 

     public BookController(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<BookDto>>> GetBooks()
    {
        var books = await _dbContext.Books.ToListAsync();
        var booksDto = new List<BookDto>(); 

        foreach (var book in books ){   
            booksDto.Add(_mapper.Map<BookDto>(book));
        }
        

        return Ok(booksDto);

    }
    //Creer une methode avec la methode post 
    [HttpPost]
    [ProducesResponseType(201, Type = typeof(Book))]// permet de controler que ce soit bien un objet Book 
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
            return BadRequest($"Book already exists ModelState ") ;
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

    //Put
    [HttpPut("id")]
    [ProducesResponseType(201, Type = typeof(Book))]// permet de controler que ce soit bien un objet Book 
    [ProducesResponseType(400)]
    public async Task<ActionResult<Book>> PutBook(long id,[FromBody] Book UpdateBook)
    {
     if (id != UpdateBook.Id)
        {
            return BadRequest();
        }

        // Recherche dans la base de donnée 
        var existingBook= await _dbContext.Books.FindAsync(id); 

        //Si le Book n'existe pas 
        if (existingBook == null)
        {
            //alors non trouver 
            return NotFound();
        }

        // Mettre à jour les propriétés 
        existingBook.Id = UpdateBook.Id;
        existingBook.Author = UpdateBook.Author;

        //tracker les modifications 
        _dbContext.Entry(existingBook).State = EntityState.Modified;
        //Sauvegarder les modfications pour quelle soit prise en compte 
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult<BookDto>> DeleteBook (int id){
        
        var bookDelete = await _dbContext.Books.FindAsync(id);
        var bookDto = new List<BookDto>(); 
        
        if (bookDelete == null ){
            return NotFound(); 
        }
        
    
        //tracker la suppression 
        _dbContext.Entry(bookDelete).State = EntityState.Deleted; 
        // Sauvegarder la supppression 
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }

    //[HttpPost ("validationLegnth")]
   // public async Task<ActionResult<BookDto>> ValitationLength (int id){
     //   if (!ModelState.IsValid){
       //     return BadRequest (ModelState);
        //}
        //_dbContext.Books.Add(book);
        //await _dbContext.SaveChangesAsync();
        //return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        //}
}
        
