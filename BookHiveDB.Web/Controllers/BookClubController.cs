using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.DTO;
using BookHiveDB.Domain.Identity;
using BookHiveDB.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookHiveDB.Web.Controllers
{
    public class BookClubController : Controller
    {

        private readonly IBookClubService _bookclubService;
        private readonly ITopicService _topicService;
        private readonly IInvitationService _invitationService;
        private readonly UserManager<BookHiveApplicationUser> _userManager;

        public BookClubController(IBookClubService bookclubService, ITopicService topicService, IInvitationService invitationService, UserManager<BookHiveApplicationUser> userManager)
        {
            _bookclubService = bookclubService;
            _topicService = topicService;
            _invitationService = invitationService;
            _userManager = userManager;
        }

         public async Task<IActionResult> Index(string search)
        {
            List<BookClub> bookClubs;
            if (search!=null && !search.Equals(""))
                bookClubs = _bookclubService.findAllByNameContainingIgnoreCase(search);
            else
                bookClubs = _bookclubService.findAll();
            BookHiveApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
            BookClubsLoggedInUser obj = new BookClubsLoggedInUser(bookClubs, user);
            return View(obj);
        }


        public async Task<IActionResult> Details(Guid? id)
        {
            BookClub bookClub = _bookclubService.findById((Guid)id);
            BookHiveApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
            List<Topic> topicsInBookClub = _topicService.findByBookClub(bookClub.Id);
            BookClubWithTopics dto = new BookClubWithTopics(bookClub, user, topicsInBookClub);
            return View(dto);
        }


        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string name, string description) 
        {
            BookHiveApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
            _bookclubService.save(name, user.Id, description);
            return RedirectToAction(nameof(Index));
        }


   
        public IActionResult EditPage(Guid? id)
        {
            BookClub bookClub = _bookclubService.findById((Guid)id);
            return View(bookClub);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, string name, string description) 
        {
            BookHiveApplicationUser user = await _userManager.GetUserAsync(HttpContext.User); 
            _bookclubService.edit((Guid)id, name, user.Id, description);
            return RedirectToAction(nameof(Index));
        }

       
        public IActionResult DeletePage(Guid? id)
        {
            BookClub bookClub = _bookclubService.findById((Guid)id);
            return View(bookClub);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteBookClub(Guid id)
        {
            BookClub bookClub = _bookclubService.findById(id);
            _bookclubService.deleteById(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult removeMemberFromBookClub(string memberId, Guid id)
        {
            _bookclubService.removeUserFromBookclub(id,memberId);
            return RedirectToRoute("default", new { controller = "BookClub", action = "Details", id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LeaveBookClub(Guid id)
        {
            BookHiveApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
            _bookclubService.removeUserFromBookclub(id, user.Id);
            return RedirectToRoute("default", new { controller = "User", action = "Index" });
        }

        public async Task<IActionResult> GetBookclubInvitationPage() 
        {
            BookHiveApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
            return View(null, user);
        }

        public async Task<IActionResult> GetBookClubMembersPage(Guid id) 
        {
            BookHiveApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
            BookClub bookClub = _bookclubService.findById(id);
            List<BookHiveApplicationUser> members = _bookclubService.getAllMembers(bookClub);
            BookClubMembersDTO dto = new BookClubMembersDTO(user, bookClub, members);
            return View(dto);
        }

        public async Task<IActionResult> GetBookclubMembershipRequestsPage(Guid id) 
        {
            BookHiveApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
            BookClub bookClub = _bookclubService.findById(id);
            List<Invitation> invitations = _invitationService.findByBookClubAndIsRequest(id, true);
            BookClubInvitations dto = new BookClubInvitations(bookClub, invitations);
            return View(dto);
        }

        public async Task<IActionResult> RequestBookclubMembership(Guid id)
        {
            BookHiveApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
            BookClub bookClub = _bookclubService.findById(id);
            _invitationService.save(user.Id, bookClub.BookHiveApplicationUser.Email, id, "", true);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteTopic(Guid id)
        {
            Topic t = _topicService.findById(id);
            _topicService.deleteById(id);
            return RedirectToRoute("default", new { controller = "BookClub", action = "Details", id = t.BookClubId });
        }
    }
}
