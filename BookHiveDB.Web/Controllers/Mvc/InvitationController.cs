using System;
using System.Threading.Tasks;
using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Identity;
using BookHiveDB.Domain.Models;
using BookHiveDB.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookHiveDB.Web.Controllers.Mvc
{
    public class InvitationController : Controller
    {
        private readonly IInvitationService _invitationService;
        private readonly IBookClubService _bookclubService;
        private readonly UserManager<BookHiveApplicationUser> _userManager;

        public InvitationController(IInvitationService invitationService, IBookClubService bookclubService, UserManager<BookHiveApplicationUser> userManager)
        {
            _invitationService = invitationService;
            _bookclubService = bookclubService;
            _userManager = userManager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InvitationPage(Guid bookClubId)
        {
            var bookClub = _bookclubService.findById(bookClubId);
            return View(bookClub);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendInvitation(Guid bookClubId, string senderId, string receiverEmail, string message)
        {
            _invitationService.save(senderId, receiverEmail, bookClubId, message, false);
            return RedirectToRoute("default", new { controller = "BookClub", action = "Details", id=bookClubId });
        }

        public async Task<IActionResult> GetMyInvitations()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var invitations = _invitationService.findByReceiver(user.Email);
            return View(invitations);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AcceptInvitation(Guid id)
        {
            Invitation invitation = _invitationService.findById(id);
            _bookclubService.addUserToBookclub(invitation.BookClubId, invitation.UserReceiverId);
            _invitationService.deleteById(id);
            return RedirectToRoute("default", new { controller = "BookClub", action = "Details", id = invitation.BookClubId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeclineInvitation(Guid id)
        {
            var invitation = _invitationService.findById(id);
            _invitationService.deleteById(id);
            return RedirectToRoute("default", new { controller = "User", action = "Index" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AcceptRequest(Guid id)
        {
            var invitation = _invitationService.findById(id);
            _bookclubService.addUserToBookclub(invitation.BookClubId, invitation.UserSenderId);
            _invitationService.deleteById(id);
            return RedirectToRoute("default", new { controller = "BookClub", action = "Details", id = invitation.BookClubId });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeclineRequest(Guid id)
        {
            var invitation = _invitationService.findById(id);
            _invitationService.deleteById(id);
            return RedirectToRoute("default", new { controller = "BookClub", action = "Details", id = invitation.BookClubId });
        }
    }
}
