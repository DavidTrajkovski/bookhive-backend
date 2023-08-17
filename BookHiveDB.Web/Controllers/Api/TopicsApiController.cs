using System;
using System.Collections.Generic;
using AutoMapper;
using BookHiveDB.Domain.Dtos.Rest.BookClub;
using BookHiveDB.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BookHiveDB.Web.Controllers.Api;

[Route("api/topics")]
[ApiController]
public class TopicsApiController : Controller
{
    private readonly ITopicService _topicService;
    private readonly IPostService _postService;
    private readonly IMapper _mapper;

    public TopicsApiController(ITopicService topicService, IPostService postService, IMapper mapper)
    {
        _topicService = topicService;
        _postService = postService;
        _mapper = mapper;
    }

    [HttpGet("{topicId:guid}")]
    public IActionResult GetTopicById(Guid topicId)
    {
        var topic = _topicService.findById(topicId);

        if (topic is null) return NotFound("Topic not found.");

        var topicDto = _mapper.Map<TopicDto>(topic);
        return Ok(topicDto);
    }

    [HttpGet("{topicId:guid}/posts")]
    public IActionResult GetPostsForTopic(Guid topicId)
    {
        var topic = _topicService.findById(topicId);
        if (topic is null) return NotFound("Topic not found.");

        var posts = _postService.findByTopic(topicId);
        var postDtos = _mapper.Map<List<PostDto>>(posts);
        return Ok(postDtos);
    }

    [HttpPost("{topicId:guid}/posts")]
    public IActionResult AddPostToTopic(Guid topicId, [FromBody] CreateNewPostDto createNewPostDto)
    {
        var newPost = _postService.save(createNewPostDto.Content, createNewPostDto.UserId, createNewPostDto.TopicId);
        var newPostDto = _mapper.Map<PostDto>(newPost);
        return Ok(newPostDto);
    }
}
