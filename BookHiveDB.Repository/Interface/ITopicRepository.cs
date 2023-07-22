using BookHiveDB.Domain.DomainModels;
using System;
using System.Collections.Generic;

namespace BookHiveDB.Repository.Interface
{
    public interface ITopicRepository
    {
        void Insert(Topic entity); 
        void Update(Topic entity); 
        void Delete(Topic entity); 
        public IEnumerable<Topic> findAll(); 
        public Topic findById(Guid? bookClubId); 
        List<Topic> findByBookClub(BookClub bookClub); 
        Topic findByTitle(string title); 
    }
}
