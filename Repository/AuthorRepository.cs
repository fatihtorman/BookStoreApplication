using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(BookStoreDbContext dataContext) : base(dataContext)
        {

        }

        public Author GetById(int id)
        {
            return Context.Set<Author>()
                          .FirstOrDefault(x => x.Id == id);
        }
    }
}
