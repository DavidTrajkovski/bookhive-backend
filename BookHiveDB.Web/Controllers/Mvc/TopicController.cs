using System;
using System.Threading.Tasks;
using BookHiveDB.Domain.DTO;
using BookHiveDB.Domain.Dtos.Mvc;
using BookHiveDB.Domain.Identity;
using BookHiveDB.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookHiveDB.Web.Controllers.Mvc
{
    public class TopicController : Controller
    {
        private readonly ITopicService _topicService;
        private readonly IPostService _postService;
        private readonly IBookClubService _bookClubService;
        private readonly UserManager<BookHiveApplicationUser> _userManager;

        public TopicController(ITopicService topicService, IPostService postService,
            UserManager<BookHiveApplicationUser> userManager, IBookClubService bookClubService)
        {
            _topicService = topicService;
            _postService = postService;
            _userManager = userManager;
            _bookClubService = bookClubService;
        }

        public async Task<IActionResult> GetTopicById(Guid id)
        {
            var topic = _topicService.findById(id);
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var posts = _postService.findByTopic(id);
            var topicPosts = new TopicPosts(topic, posts, user);
            var bookClub = _bookClubService.findById(topic.BookClubId);
            ViewBag.bookClubOwnerId = bookClub.BookHiveApplicationUserId;
            return View(topicPosts);
        }

        public IActionResult GetAddTopicForm(Guid id)
        {
            ViewBag.bookClubId = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> addNewTopic(Guid bookClubId, string title)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            _topicService.save(title, user.Id, bookClubId);
            return RedirectToRoute("default", new { controller = "BookClub", action = "Details", id = bookClubId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> addNewPostToTopic(Guid topicId, Guid bookClubId, string content)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            _postService.save(content, user.Id, topicId);
            return RedirectToRoute("default", new { controller = "Topic", action = "GetTopicById", id = topicId });
        }

        public IActionResult deletePostFromTopic(Guid id)
        {
            var topic = _postService.findById(id).Topic;
            _postService.deleteById(id);
            return RedirectToRoute("default", new { controller = "Topic", action = "GetTopicById", id = topic.Id });
        }
    }
}