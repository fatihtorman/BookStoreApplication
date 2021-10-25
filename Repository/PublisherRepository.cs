using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repository
{
    public class PublisherRepository : Repository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(BookStoreDbContext dataContext) : base(dataContext)
        {

        }

        public Publisher GetById(int id)
        {
            return Context.Set<Publisher>()
                          .Include(x => x.Book)
                          .FirstOrDefault(x => x.Id == id);
        }
    }
}
