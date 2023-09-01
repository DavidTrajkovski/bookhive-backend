using System;
using System.Collections.Generic;
using BookHiveDB.Domain.Models;

namespace BookHiveDB.Service.Interface
{
    public interface IPostService
    {
        List<Post> findAll();
        Post findById(Guid postId);
        List<Post> findByTopic(Guid topicId);
        Post save(string content, string userId, Guid topicId);
        Post edit(Guid postId, string content, string userId, Guid topicId);
        void deleteById(Guid postId);
    }
}
