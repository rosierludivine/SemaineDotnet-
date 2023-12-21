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

    [ProducesResponseType(StatusCodes.Status201Created)] //erreur 201 
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost("auteur")]
public async Task<ActionResult<Auteur>> PostAuthor([FromBody] AuteurDto auteurDto)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    var auteur = _mapper.Map<Auteur>(auteurDto);

    if (auteur == null)
    {
        return BadRequest();
    }

    _dbContext.Auteurs.Add(auteur);
    await _dbContext.SaveChangesAsync();

    return CreatedAtAction(nameof(GetAuteur), new { id = auteur.Id }, auteurDto);
}}