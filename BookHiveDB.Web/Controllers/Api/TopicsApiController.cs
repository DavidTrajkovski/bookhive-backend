using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookHiveDB.Domain.Dtos.Rest.BookClub;
using BookHiveDB.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookHiveDB.Web.Controllers.Api;

[Route("api/topics")]
[ApiController]
public class TopicsApiController : Controller
{
    private readonly IUserService _userService;
    private readonly ITopicService _topicService;
    private readonly IPostService _postService;
    private readonly IMapper _mapper;

    public TopicsApiController(ITopicService topicService, IPostService postService, IMapper mapper, IUserService userService)
    {
        _topicService = topicService;
        _postService = postService;
        _mapper = mapper;
        _userService = userService;
    }

    [HttpGet("{topicId:guid}")]
    [Authorize("Default")]
    public IActionResult GetTopicById(Guid topicId)
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
        if (string.IsNullOrEmpty(userId)) return BadRequest("Invalid token, ID claim is empty.");

        var user = _userService.findById(userId);
        if (user is null) return NotFound("User not found");
        
        var topic = _topicService.findById(topicId);

        if (topic is null) return NotFound("Topic not found.");

        var topicDto = _mapper.Map<TopicDto>(topic);

        topicDto.IsCreator = topic.BookHiveApplicationUserId == userId;
        
        return Ok(topicDto);
    }

    [HttpGet("{topicId:guid}/posts")]
    [Authorize("Default")]
    public IActionResult GetPostsForTopic(Guid topicId)
    {
        var topic = _topicService.findById(topicId);
        if (topic is null) return NotFound("Topic not found.");

        var posts = _postService.findByTopic(topicId);
        var postDtos = _mapper.Map<List<PostDto>>(posts);
        return Ok(postDtos);
    }

    [HttpPost]
    [Authorize("Default")]
    public IActionResult CreateTopic([FromBody] CreateTopicDto createTopicDto)
    {
        var newlyCreatedTopic =
            _topicService.save(createTopicDto.Title, createTopicDto.CreatorId, Guid.Parse(createTopicDto.BookclubId));

        var topicDto = _mapper.Map<TopicDto>(newlyCreatedTopic);
        return Ok(topicDto);
    }
    
    [HttpPut("{topicId:guid}")]
    [Authorize("Default")]
    public IActionResult EditTopic(Guid topicId, [FromBody] CreateTopicDto createTopicDto)
    {
        var editedTopic =
            _topicService.edit(topicId, createTopicDto.Title, createTopicDto.CreatorId, Guid.Parse(createTopicDto.BookclubId));

        var topicDto = _mapper.Map<TopicDto>(editedTopic);
        return Ok(topicDto);
    }

    [HttpPost("{topicId:guid}/posts")]
    [Authorize("Default")]
    public IActionResult AddPostToTopic(Guid topicId, [FromBody] CreateNewPostDto createNewPostDto)
    {
        var newPost = _postService.save(createNewPostDto.Content, createNewPostDto.UserId, createNewPostDto.TopicId);
        var newPostDto = _mapper.Map<PostDto>(newPost);
        return Ok(newPostDto);
    }
}
