using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.Adapters.Catalogue.Mapping
{
    internal class MapperBase
    {


        internal IEnumerable<TResult> MapList<T, TResult>(IEnumerable<T> items, Func<T, TResult> mapperSingle)
        {
            List<TResult> result = new List<TResult>();
            foreach (var item in items)
                result.Add(mapperSingle(item));
            return result;
        }
    }
}
