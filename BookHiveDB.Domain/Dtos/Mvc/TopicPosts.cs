using System.Collections.Generic;
using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Identity;
using BookHiveDB.Domain.Models;

namespace BookHiveDB.Domain.Dtos.Mvc
{
    public class TopicPosts
    {
        public Topic topic { get; set; }
        public BookHiveApplicationUser user { get; set; }
        public List<Post> topicPosts { get; set; }
        public TopicPosts(Topic topic, List<Post> topicPosts, BookHiveApplicationUser user)
        {
            this.topic = topic;
            this.topicPosts = topicPosts;
            this.user = user;
        }
    }
}
