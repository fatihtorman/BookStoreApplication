using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(BookStoreDbContext dataContext) : base(dataContext)
        {

        }

        public Book GetById(int id)
        {
            return Context.Set<Book>()
                          .Include(x => x.Author)
                          .FirstOrDefault(x => x.Id == id);
        }
    }
}
