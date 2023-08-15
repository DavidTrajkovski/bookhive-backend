using System;
using System.Collections.Generic;
using AutoMapper;
using BookHiveDB.Domain.Dtos.Rest.BookClub;
using BookHiveDB.Domain.Models;
using BookHiveDB.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BookHiveDB.Web.Controllers.Api;

[Route("api/bookclubs")]
[ApiController]
public class BookClubsApiController : Controller
{
    private readonly IBookClubService _bookClubService;
    private readonly IMapper _mapper;

    public BookClubsApiController(IBookClubService bookClubService, IMapper mapper)
    {
        _bookClubService = bookClubService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAllBookClubs()
    {
        var bookclubs = _bookClubService.findAll();
        var bookclubDtos = _mapper.Map<List<BookClubDto>>(bookclubs);
        return Ok(bookclubDtos);
    }

    [HttpGet("{bookclubId:guid}")]
    public IActionResult GetBookClubById(Guid bookclubId)
    {
        var bookclub = _bookClubService.findById(bookclubId);

        if (bookclub is null) return NotFound();

        var bookClubDto = _mapper.Map<BookClubDto>(bookclub);

        return Ok(bookClubDto);
    }

    [HttpPost]
    public IActionResult CreateBookClub([FromBody] CreateBookClubDto createBookClubDto)
    {
        var newlyCreatedBookClub = _bookClubService.save(createBookClubDto.Name, createBookClubDto.OwnerId,
            createBookClubDto.Description);

        var bookclubDto = _mapper.Map<BookClubDto>(newlyCreatedBookClub);

        return Ok(bookclubDto);
    }
}
