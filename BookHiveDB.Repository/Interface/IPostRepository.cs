using BookHiveDB.Domain.DomainModels;
using System;
using System.Collections.Generic;

namespace BookHiveDB.Repository.Interface
{
    public interface IPostRepository
    {
        void Insert(Post entity); 
        void Update(Post entity); 
        void Delete(Post entity); 
        public IEnumerable<Post> findAll(); 
        public Post findById(Guid? bookClubId); 
        public List<Post> findByTopic(Topic topic); 
    }
}
