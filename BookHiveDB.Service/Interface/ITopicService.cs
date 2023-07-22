using BookHiveDB.Domain.DomainModels;
using System;
using System.Collections.Generic;

namespace BookHiveDB.Service.Interface
{
    public interface ITopicService
    {
        List<Topic> findAll();
        Topic findById(Guid topicId);
        List<Topic> findByBookClub(Guid bookClubId);
        Topic save(string title, string userId, Guid bookClubId);
        Topic edit(Guid topicId, string title, string userId, Guid bookClubId);
        void deleteById(Guid topicId);
    }
}
