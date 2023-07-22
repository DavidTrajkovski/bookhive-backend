using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Identity;
using BookHiveDB.Repository.Interface;
using BookHiveDB.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookHiveDB.Service.Implementation
{
    public class PostService : IPostService
    {
        private readonly IUserRepository userRepository;
        private readonly IPostRepository postRepository;
        private readonly ITopicRepository topicRepository;

        public PostService(IUserRepository userRepository, IPostRepository postRepository, ITopicRepository topicRepository)
        {
            this.userRepository = userRepository;
            this.postRepository = postRepository;
            this.topicRepository = topicRepository;
        }

        public void deleteById(Guid postId)
        {
            Post post = postRepository.findById(postId); 
            postRepository.Delete(post);
        }

        public Post edit(Guid postId, string content, string userId, Guid topicId)
        {
            Post post = findById(postId);
            BookHiveApplicationUser user = userRepository.Get(userId);
            Topic topic = topicRepository.findById(topicId);
            post.content = content;
            post.BookHiveApplicationUser = user;
            post.BookHiveApplicationUserId = userId;
            post.TopicId = topicId;
            post.Topic = topic;
            postRepository.Update(post);
            return post;
        }

        public List<Post> findAll()
        {
            return postRepository.findAll().ToList();
        }

        public Post findById(Guid postId)
        {
            return postRepository.findById(postId);
        }

        public List<Post> findByTopic(Guid topicId)
        {
            Topic topic = topicRepository.findById(topicId);
            return postRepository.findByTopic(topic).ToList();
        }

        public Post save(string content, string userId, Guid topicId)
        {
            BookHiveApplicationUser user = userRepository.Get(userId);
            Topic topic = topicRepository.findById(topicId);
            Post post = new Post { Topic = topic, content = content, 
                                   BookHiveApplicationUser = user, 
                                   BookHiveApplicationUserId = userId, 
                                   dateCreated = DateTime.Now, 
                                   TopicId = topicId };
            postRepository.Insert(post);
            return post;
        }
    }
}
