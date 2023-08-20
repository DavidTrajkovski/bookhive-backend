using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using BookHiveDB.Domain.Dtos.Rest.BookClub;
using BookHiveDB.Domain.Identity;
using BookHiveDB.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookHiveDB.Web.Controllers.Api;

[Route("api/invitations")]
[ApiController]
public class InvitationsApiController : ControllerBase
{
    private readonly IInvitationService _invitationService;
    private readonly IBookClubService _bookclubService;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public InvitationsApiController(IInvitationService invitationService, IBookClubService bookclubService,
        IMapper mapper, IUserService userService)
    {
        _invitationService = invitationService;
        _bookclubService = bookclubService;
        _mapper = mapper;
        _userService = userService;
    }

    [HttpGet]
    [Authorize("Default")]
    public IActionResult GetUserInvitations()
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
        if (string.IsNullOrEmpty(userId)) return BadRequest("Invalid token, ID claim is empty.");

        var user = _userService.findById(userId);
        if (user is null) return NotFound("User not found");

        var invitations = _invitationService.findByReceiver(user.Email);
        var invitationDtos = _mapper.Map<List<InvitationDto>>(invitations);

        return Ok(invitationDtos);
    }

    [HttpGet("count")]
    [Authorize("Default")]
    public IActionResult GetUserInvitationsCount()
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
        if (string.IsNullOrEmpty(userId)) return BadRequest("Invalid token, ID claim is empty.");

        var user = _userService.findById(userId);
        if (user is null) return NotFound("User not found");

        var invitationsCount = _invitationService.findByReceiver(user.Email).Count;

        return Ok(invitationsCount);
    }

    [HttpGet("{bookclubId:guid}/requests-count")]
    [Authorize("Default")]
    public IActionResult GetRequestsCountForBookClub(Guid bookclubId)
    {
        var requestsCountForBookClub = _invitationService.findByBookClubAndIsRequest(bookclubId, true).Count;
        return Ok(requestsCountForBookClub);
    }

    [HttpPost("send-invitation")]
    [Authorize("Default")]
    public IActionResult SendInvitation([FromBody] CreateInvitationDto createInvitationDto)
    {
        _invitationService.save(createInvitationDto.SenderId, createInvitationDto.ReceiverEmail,
            createInvitationDto.BookClubId, createInvitationDto.Message, false);
        return Ok();
    }

    [HttpPost("{invitationId:guid}/accept-invitation")]
    [Authorize("Default")]
    public IActionResult AcceptInvitation(Guid invitationId)
    {
        var invitation = _invitationService.findById(invitationId);
        if (invitation is null) return NotFound("Invitation not found");

        _bookclubService.addUserToBookclub(invitation.BookClubId, invitation.UserReceiverId);
        _invitationService.deleteById(invitationId);

        return Ok();
    }

    [HttpDelete("{invitationId:guid}/decline-invitation")]
    [Authorize("Default")]
    public IActionResult DeclineInvitation(Guid invitationId)
    {
        var invitation = _invitationService.findById(invitationId);
        if (invitation is null) return NotFound("Invitation not found");

        _invitationService.deleteById(invitationId);

        return Ok();
    }

    [HttpPost("{invitationId:guid}/accept-request")]
    [Authorize("Default")]
    public IActionResult AcceptRequest(Guid invitationId)
    {
        var invitation = _invitationService.findById(invitationId);
        if (invitation is null) return NotFound("Request not found");

        _bookclubService.addUserToBookclub(invitation.BookClubId, invitation.UserReceiverId);
        _invitationService.deleteById(invitationId);

        return Ok();
    }

    [HttpDelete("{invitationId:guid}/decline-request")]
    [Authorize("Default")]
    public IActionResult DeclineRequest(Guid invitationId)
    {
        var invitation = _invitationService.findById(invitationId);
        if (invitation is null) return NotFound("Request not found");

        _invitationService.deleteById(invitationId);

        return Ok();
    }
}
