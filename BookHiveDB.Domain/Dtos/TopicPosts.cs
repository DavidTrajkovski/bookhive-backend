using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookHiveDB.Domain.DTO
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
