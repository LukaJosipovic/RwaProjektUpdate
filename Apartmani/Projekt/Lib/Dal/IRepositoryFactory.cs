using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Dal
{
    public static class IRepositoryFactory
    {
        public static IRepository GetRepository() => new DBRepository();
    }
}
