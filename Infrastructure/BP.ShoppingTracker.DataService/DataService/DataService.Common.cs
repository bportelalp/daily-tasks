using BP.ShoppingTracker.Adaptables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.DataService
{
    public partial class DataService : IDataService
    {
        //public void AddOrUpdateIfExists<T>(T entity, DbSet<T> dbSet)
        //{
        //    if (dbContext.Formats.Any(f => f.ID == mainFormat.ID))
        //        dbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //    else
        //        dbContext.Add(entity);
        //}
    }
}
