﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookHiveDB.Domain.Dtos.Rest.BookClub;
using BookHiveDB.Domain.Models;
using BookHiveDB.Service.Interface;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookHiveDB.Web.Controllers.Api;

[Route("api/bookclubs")]
[ApiController]
public class BookClubsApiController : Controller
{
    private readonly IUserService _userService;
    private readonly IBookClubService _bookClubService;
    private readonly IInvitationService _invitationService;
    private readonly ITopicService _topicService;
    private readonly IMapper _mapper;

    public BookClubsApiController(IBookClubService bookClubService, IMapper mapper, ITopicService topicService,
        IUserService userService, IInvitationService invitationService)
    {
        _bookClubService = bookClubService;
        _mapper = mapper;
        _topicService = topicService;
        _userService = userService;
        _invitationService = invitationService;
    }

    [HttpGet]
    [Authorize("Default")]
    public IActionResult GetAllBookClubs()
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
        if (string.IsNullOrEmpty(userId)) return BadRequest("Invalid token, ID claim is empty.");

        var user = _userService.findById(userId);
        if (user is null) return NotFound("User not found");

        var bookclubs = _bookClubService.findAll();
        var bookclubDtos = bookclubs.Select(bookclub => new BookClubDto
            {
                Id = bookclub.Id,
                Name = bookclub.name,
                Owner = $"{bookclub.BookHiveApplicationUser.FirstName} {bookclub.BookHiveApplicationUser.LastName}",
                Description = bookclub.description,
                IsMember = bookclub.UserInBookClubs.Exists(e => e.UserId == userId),
                IsOwner = bookclub.BookHiveApplicationUserId == userId
            })
            .ToList();

        return Ok(bookclubDtos);
    }

    [HttpGet("{bookclubId:guid}")]
    [Authorize("Default")]
    public IActionResult GetBookClubById(Guid bookclubId)
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
        if (string.IsNullOrEmpty(userId)) return BadRequest("Invalid token, ID claim is empty.");

        var user = _userService.findById(userId);
        if (user is null) return NotFound("User not found");

        var bookclub = _bookClubService.findById(bookclubId);

        if (bookclub is null) return NotFound();

        var bookClubDto = _mapper.Map<BookClubDto>(bookclub);

        bookClubDto.IsOwner = bookclub.BookHiveApplicationUserId == userId;

        return Ok(bookClubDto);
    }

    [HttpGet("{bookclubId:guid}/topics")]
    [Authorize("Default")]
    public IActionResult GetTopicsForBookClub(Guid bookclubId)
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
        if (string.IsNullOrEmpty(userId)) return BadRequest("Invalid token, ID claim is empty.");

        var user = _userService.findById(userId);
        if (user is null) return NotFound("User not found");

        var bookclub = _bookClubService.findById(bookclubId);

        if (bookclub is null) return NotFound();

        var topics = _topicService.findByBookClub(bookclubId);
        var topicDtos = topics.Select(topic => new TopicDto
        {
            Id = topic.Id,
            BookclubId = topic.BookClubId,
            Title = topic.title,
            CreatedBy = $"{topic.BookHiveApplicationUser.FirstName} {topic.BookHiveApplicationUser.LastName}",
            IsCreator = topic.BookHiveApplicationUserId == userId
        }).ToList();

        return Ok(topicDtos);
    }

    [HttpGet("{bookclubId:guid}/members")]
    public IActionResult GetMembersForBookClub(Guid bookclubId)
    {
        var bookclub = _bookClubService.findById(bookclubId);

        if (bookclub is null) return NotFound();

        var members = _bookClubService.getAllMembers(bookclub);
        var memberDtos = _mapper.Map<List<MemberDto>>(members);

        return Ok(memberDtos);
    }

    [HttpPost]
    public IActionResult CreateBookClub([FromBody] CreateBookClubDto createBookClubDto)
    {
        var newlyCreatedBookClub = _bookClubService.save(createBookClubDto.Name, createBookClubDto.OwnerId,
            createBookClubDto.Description);

        var bookclubDto = _mapper.Map<BookClubDto>(newlyCreatedBookClub);

        return Ok(bookclubDto);
    }

    [HttpPut("{bookclubId:guid}")]
    public IActionResult EditBookClub(Guid bookclubId, [FromBody] CreateBookClubDto createBookClubDto)
    {
        var editedBookclub = _bookClubService.edit(bookclubId, createBookClubDto.Name, createBookClubDto.OwnerId,
            createBookClubDto.Description);

        var bookclubDto = _mapper.Map<BookClubDto>(editedBookclub);

        return Ok(bookclubDto);
    }

    [HttpDelete("{bookclubId:guid}/members/{memberId:guid}")]
    public IActionResult KickMemberFromBookClub(Guid bookclubId, Guid memberId)
    {
        _bookClubService.removeUserFromBookclub(bookclubId, memberId.ToString());
        return Ok();
    }
}