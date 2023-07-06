using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Identity;
using BookHiveDB.Repository.Interface;
using BookHiveDB.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookHiveDB.Service.Implementation
{
    public class TopicService : ITopicService
    {
        private readonly IUserRepository userRepository;
        private readonly IBookClubRepository bookClubRepository;
        private readonly ITopicRepository topicRepository;

        public TopicService(IUserRepository userRepository, IBookClubRepository bookClubRepository, ITopicRepository topicRepository)
        {
            this.userRepository = userRepository;
            this.bookClubRepository = bookClubRepository;
            this.topicRepository = topicRepository;
        }

        public void deleteById(Guid id)
        {
            Topic topic = topicRepository.findById(id);
            topicRepository.Delete(topic);
        }

        public Topic edit(Guid id, string title, string userId, Guid bookClubId)
        {
            Topic topic = topicRepository.findById(id);
            BookClub bookClub = bookClubRepository.findById(bookClubId);
            BookHiveApplicationUser user = userRepository.Get(userId);
            topic.title = title;
            topic.BookHiveApplicationUser = user;
            topic.BookHiveApplicationUserId = userId;
            topic.BookClub = bookClub;
            topic.BookClubId = bookClubId;
            topicRepository.Update(topic);
            return topic;
        }

        public List<Topic> findAll()
        {
            return topicRepository.findAll().ToList();
        }

        public List<Topic> findByBookClub(Guid id)
        {
            BookClub bookClub = bookClubRepository.findById(id);
            return topicRepository.findByBookClub(bookClub).ToList();
        }

        public Topic findById(Guid topicId)
        {
            return topicRepository.findById(topicId);
        }

        public Topic save(string title, string userId, Guid id)
        {
            BookClub bookClub = bookClubRepository.findById(id);
            BookHiveApplicationUser user = userRepository.Get(userId);
            Topic topic = new Topic { BookClubId = id, BookHiveApplicationUserId = userId, BookClub = bookClub, BookHiveApplicationUser = user, date = DateTime.Now, title = title };
            topicRepository.Insert(topic);
            return topic;
        }
    }
}
