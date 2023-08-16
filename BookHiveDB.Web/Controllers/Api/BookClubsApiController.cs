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
    private readonly ITopicService _topicService;
    private readonly IMapper _mapper;

    public BookClubsApiController(IBookClubService bookClubService, IMapper mapper, ITopicService topicService)
    {
        _bookClubService = bookClubService;
        _mapper = mapper;
        _topicService = topicService;
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

    [HttpGet("{bookclubId:guid}/topics")]
    public IActionResult GetTopicsForBookClub(Guid bookclubId)
    {
        var bookclub = _bookClubService.findById(bookclubId);

        if (bookclub is null) return NotFound();

        var topics = _topicService.findByBookClub(bookclubId);
        var topicDtos = _mapper.Map<List<TopicDto>>(topics);

        return Ok(topicDtos);
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
