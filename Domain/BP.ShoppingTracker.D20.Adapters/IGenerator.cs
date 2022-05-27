using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.ShoppingTracker.D20.Adapters
{
    public interface IGenerator
    {
        Task GenerateInitialRows(string configurationfilePath);
    }
}
