// using BookHiveDB.Domain.DomainModels;
// using Microsoft.EntityFrameworkCore;
// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
//
// namespace BookHiveDB.Repository.Startup
// {
//     public class GenreInitializer : IGenreInitializer
//     {
//         private DbSet<Genre> genres;
//         private readonly ApplicationDbContext context;
//
//         public GenreInitializer(ApplicationDbContext context)
//         {
//             genres = context.Set<Genre>();
//             this.context = context;
//         }
//
//         public async Task Seed()
//         {
//             if(await genres.CountAsync() == 0)
//             {
//                 genres.Add(new Genre { GenreName = "HORROR" });
//                 genres.Add(new Genre { GenreName = "ACTION" });
//                 genres.Add(new Genre { GenreName = "DRAMA" });
//                 genres.Add(new Genre { GenreName = "ADVENTURE" });
//                 genres.Add(new Genre { GenreName = "ROMANCE" });
//                 genres.Add(new Genre { GenreName = "SCI_FI" });
//                 genres.Add(new Genre { GenreName = "FANTASY" });
//                 genres.Add(new Genre { GenreName = "CULINARY" });
//                 genres.Add(new Genre { GenreName = "POETRY" });
//                 genres.Add(new Genre { GenreName = "SELF_HELP" });
//                 genres.Add(new Genre { GenreName = "CRIME" });
//                 context.SaveChanges();
//             }
//         }
//         public void Insert(Genre entity)
//         {
//             if (entity == null)
//             {
//                 throw new ArgumentNullException("entity");
//             }
//             genres.Add(entity);
//             context.SaveChanges();
//         }
//
//         public List<Genre> GetAll()
//         {
//             return genres.ToListAsync().Result;
//         }
//
//         public Genre GetById(Guid id)
//         {
//             return genres.SingleOrDefaultAsync(z=>z.Id == id).Result;
//         }
//
//
//     }
// }
