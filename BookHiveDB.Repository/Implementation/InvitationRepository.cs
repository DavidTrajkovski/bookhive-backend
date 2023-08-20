using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Identity;
using BookHiveDB.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using BookHiveDB.Domain.Models;

namespace BookHiveDB.Repository.Implementation
{
    public class InvitationRepository : IInvitationRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Invitation> entities;

        public InvitationRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Invitation>();
        }

        public IEnumerable<Invitation> findAll()
        {
            return entities.Include(z => z.UserSender)
                .Include(z => z.UserReceiver)
                .Include(z => z.BookClub)
                .ToListAsync().Result;
        }

        public Invitation findById(Guid? invitationId)
        {
            return entities.Include(z => z.UserSender)
                .Include(z => z.UserReceiver)
                .Include(z => z.BookClub)
                .SingleOrDefaultAsync(s => s.Id == invitationId).Result;
        }

        public void Insert(Invitation entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(Invitation entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(Invitation entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public List<Invitation> findByReceiver(BookHiveApplicationUser receiver)
        {
            return entities.Include(z => z.UserSender)
                .Include(z => z.UserReceiver)
                .Include(z => z.BookClub)
                .Where(z => z.UserReceiver.Equals(receiver)).ToList();
        }

        public List<Invitation> findByBookClubAndIsRequest(BookClub bookClub, bool isRequest)
        {
            return entities.Include(z => z.UserSender)
                .Include(z => z.UserReceiver)
                .Include(z => z.BookClub)
                .Where(z => z.BookClub.Equals(bookClub) && z.IsRequest.Equals(isRequest)).ToList();
        }

        public List<Invitation> findByReceiverAndIsRequest(BookHiveApplicationUser receiver, bool isRequest)
        {
            return entities.Include(z => z.UserSender)
                .Include(z => z.UserReceiver)
                .Include(z => z.BookClub)
                .Where(z => z.UserReceiver.Equals(receiver) && z.IsRequest.Equals(isRequest)).ToList();
        }
    }
}
