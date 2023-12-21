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


[ApiController]
[Route("api/[controller]")]//permet de ne plus mettre [HttpPost[books]]

public class AuteurController: ControllerBase {
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper; 

    public AuteurController(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }


    [HttpGet]
    public async Task<ActionResult<List<AuteurDto>>> GetAuteur()
    {
        var auteurs = await _dbContext.Auteurs.ToListAsync(); 
         
        var auteursDto = new List <Auteur>(auteurs); 

        // foreach (var acteur in auteurs){
        //     AuteurDto.Add(_mapper.Map<AuteurDto>(auteurs)); 
        // }
        return Ok(auteursDto);

    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)] //erreur 201 
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<Auteur>>> PostAuteur([FromBody] Auteur auteur)
    {

        // On regarde si ce qui est rentré n'est pas null 
        if (auteur == null)
        {
            return BadRequest("");
        }
        // on regarde si l'auteur existe déjà 
        Auteur? addAuteur = await _dbContext.Auteurs.FirstOrDefaultAsync(a => a.Name == auteur.Name);
        
        if (addAuteur != null)
        {
            return BadRequest($"L'auteur existe déjà !!! ") ;
        }
        else
        {
            //On ajoute l'auteur  a la base de données 
            await _dbContext.Auteurs.AddAsync(auteur);
            await _dbContext.SaveChangesAsync();

            // on affiche l'auteur  
            return Created("api/book", auteur);

        }
    }
    

} 